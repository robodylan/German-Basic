using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * public = Öffentlichkeit
 * static = statisch
 * void = Leere
 * if = wenn
 * while = wahrend
 * string = Saite
 * namespace = Namensraum
 * console = Konsole
 * try = versuchen
 * catch = Fang
  */
namespace GSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> variables = new Dictionary<string,int>();
            Dictionary<string, int> labels = new Dictionary<string,int>();
            string[] lines = new string[0];
            lines = File.ReadAllLines(args[0]);
            Console.WriteLine(args[0]);
            int lineNumber = 0;
            while(lineNumber < lines.Length)
            {
                string line = lines[lineNumber];
                string[] lexarData = line.Split(' ');
                string arg1 = "";
                string arg2 = "";
                string arg3 = "";
                string arg4 = "";
                try
                {
                    arg1 = lexarData[1];
                    arg2 = lexarData[2];
                    arg3 = lexarData[3];
                    arg4 = lexarData[4];
                }
                catch
                {

                }
                switch(lexarData[0])
                {
                    case "SATZ":
                        if(!variables.ContainsKey(arg1))
                        {
                            variables.Add(arg1, 0);
                        }
                        if(arg2 == "=")
                        {
                            int result = 0;
                            if(int.TryParse(arg3,out result))
                            {
                                variables[arg1] = result;
                            }
                            else
                            {
                                variables[arg1] = variables[arg3];
                            }
                        }
                        if (arg2 == "+")
                        {
                            int result = 0;
                            if (int.TryParse(arg3, out result))
                            {
                                variables[arg1] = result;
                            }
                            else
                            {
                                variables[arg1] += variables[arg3];
                            }
                        }
                        if (arg2 == "-")
                        {
                            int result = 0;
                            if (int.TryParse(arg3, out result))
                            {
                                variables[arg1] = result;
                            }
                            else
                            {
                                variables[arg1] -= variables[arg3];
                            }
                        }
                        if (arg2 == "/")
                        {
                            int result = 0;
                            if (int.TryParse(arg3, out result))
                            {
                                variables[arg1] = result;
                            }
                            else
                            {
                                variables[arg1] /= variables[arg3];
                            }
                        }
                        if (arg2 == "*")
                        {
                            int result = 0;
                            if (int.TryParse(arg3, out result))
                            {
                                variables[arg1] = result;
                            }
                            else
                            {
                                variables[arg1] *= variables[arg3];
                            }
                        }
                        break;
                    case "WENN":
                        int outresult = 0;
                        if (int.TryParse(arg3, out outresult))
                        {
                            variables[arg1] = outresult;
                            if(arg2 == ">")
                            {
                                int A = variables[arg1];
                                int B;
                                int.TryParse(arg3, out B);
                                if(A > B)
                                {
                                    lineNumber = labels[arg4];
                                }
                            }
                            if (arg2 == "<")
                            {
                                int A = variables[arg1];
                                int B;
                                int.TryParse(arg3, out B);
                                if (A < B)
                                {
                                    lineNumber = labels[arg4];
                                }
                            }
                            if (arg2 == ">")
                            {
                                int A = variables[arg1];
                                int B;
                                int.TryParse(arg3, out B);
                                if (A > B)
                                {
                                    lineNumber = labels[arg4];
                                }
                            }
                        }
                        else
                        {
                            if (arg2 == ">")
                            {
                                int A = variables[arg1];
                                int B = variables[arg3]; 
                                if (A > B)
                                {
                                    lineNumber = labels[arg4];
                                }
                            }
                            if (arg2 == "<")
                            {
                                int A = variables[arg1];
                                int B = variables[arg3]; 
                                if (A < B)
                                {
                                    lineNumber = labels[arg4];
                                }
                            }
                            if (arg2 == ">")
                            {
                                int A = variables[arg1];
                                int B = variables[arg3]; 
                                if (A > B)
                                {
                                    lineNumber = labels[arg4];
                                }
                            }
                        }

                        break;
                    case "ETIKETTE":
                        if(!labels.ContainsKey(arg1))
                        {
                            labels.Add(arg1, lineNumber);
                        }
                        break;
                    case "GEHEZU":
                        lineNumber = labels[arg1] - 1;
                        break;
                    case "DRUCK":
                        if(arg1[0] == '\"')
                        {

                            Console.WriteLine(arg1.Substring(1, arg1.Length - 2));
                        }
                        else
                        {
                            Console.WriteLine(variables[arg1]);
                        }
                        break;

                }
                lineNumber++;
            }
        }
    }
}
