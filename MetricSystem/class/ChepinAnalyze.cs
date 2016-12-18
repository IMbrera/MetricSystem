using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetricSystem
{
  public static class ChepinAnalyze
{
        public static string DeleteTheComments(string MetricCode)
        {
            Regex Comment = new Regex(@"//(.*?)");
            MetricCode = Comment.Replace(MetricCode, "");
            Regex MultiComment = new Regex(@"/(\*)(.*?)(\*)/", RegexOptions.Singleline);
            MetricCode = MultiComment.Replace(MetricCode, "");
            return MetricCode;
        }
        public static string DeleteTheStrings(string MetricCode)
        {
            Regex String = new Regex(@"""(.*?)""", RegexOptions.Singleline);
            MetricCode = String.Replace(MetricCode, "");
            return MetricCode;
        }
        private const int TypeCount = 10;
        private static readonly string[] ChepinTypes = { "byte", "short", "int", "long", "float", "double", "bool", "char", "string", "object" };
        public static List<string> GetVariables(string MetricCode)
        {
            List<string> Result = new List<string>();
            for (int j = 0; j < TypeCount; j++)
            {
                Regex RegularExpression = new Regex(@"\b" + ChepinTypes[j] + @"\b" + @"\s+\w+[^()]*;");
                Match Match = RegularExpression.Match(MetricCode);
                while (Match.Success)
                {
                    string Declaration = Match.Value;
                    int i = 0;
                    while (Declaration[i] != ' ')
                    {
                        i++;
                    }
                    while (Declaration[i] != ';')
                    {
                        i++;
                        string Variable = "";
                        while (Declaration[i] == ' ')
                        {
                            i++;
                        }
                        while ((Declaration[i] != ' ') && (Declaration[i] != '=') && (Declaration[i] != ';') && (Declaration[i] != ','))
                        {
                            Variable = Variable + Declaration[i];
                            i++;
                        }
                        Result.Add(Variable);
                        while ((Declaration[i] != ',') && (Declaration[i] != ';'))
                        {
                            i++;
                        }
                    }
                    Match = Match.NextMatch();
                }
            }
            return Result;
        }

        public struct VariableInfo
        {
            public string Identifier;
            public bool Input, Modified, Steward, Virus;
        }

        private const int OutputMethodsCount = 10;
        private static readonly string[] OutputMethods = { "const", "byte", "short", "int", "long", "float", "double", "bool", "char", "string" };
        private const int InputMethodsCount = 6;
        private static readonly string[] InputMethods = { "Console.WriteLine", "Write", "Console.ReadLine", "Console.Read", "Convert", "Parse" };
        private static bool IsDataVariable(string Variable, string MetricCode)
        {
            for (int i = 0; i < OutputMethodsCount; i++)
            {
                Regex RegularExpression = new Regex(OutputMethods[i] + @"\s*\([^)]*" + Variable + @"[^)]*\)");
                Match Match = RegularExpression.Match(MetricCode);
                if (Match.Success)
                {
                    return true;
                }
            }
            for (int i = 0; i < InputMethodsCount; i++)
            {
                Regex RegularExpression = new Regex(Variable + @"\s*=[^;]*" + InputMethods[i]);
                Match Match = RegularExpression.Match(MetricCode);
                if (Match.Success)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsStewardVariable(string Variable, string MetricCode)
        {
            Regex RegularExpression = new Regex(@"((for)|(while)|(if))\s*\(\s*" + Variable);
            Match Match = RegularExpression.Match(MetricCode);
            if (Match.Success)
            {
                return true;
            }
            return false;
        }

        private static bool IsModifiedVariable(string Variable, string MetricCode)
        {
            Regex RegularExpression = new Regex(/*@"[;{]\s*" +*/ @"\s*" + Variable + @"\s*=");
            Match Match = RegularExpression.Match(MetricCode);
            if (Match.Success)
            {
                return true;
            }
            return false;
        }

        private static VariableInfo GetVariableInfo(string Variable, string MetricCode)
        {
            VariableInfo Result = new VariableInfo();
            Result.Identifier = Variable;
            Result.Input = IsDataVariable(Variable, MetricCode);
            Result.Steward = IsStewardVariable(Variable, MetricCode);
            Result.Modified = IsModifiedVariable(Variable, MetricCode);
            if (!(Result.Input || Result.Modified || Result.Steward))
                Result.Virus = true;
            else
                Result.Virus = false;
            return Result;
        }

        public static List<VariableInfo> GetVariablesInfo(List<string> Variables, string MetricCode)
        {
            List<VariableInfo> Result = new List<VariableInfo>();
            for (int i = 0; i < Variables.Count; i++)
            {
                Result.Add(GetVariableInfo(Variables[i], MetricCode));
            }
            return Result;
        }
    }
}
