using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Start();
        }

        /// <summary>
        /// Start of the program
        /// </summary>
        private static void Start()
        {
            Boolean end = false;
            while (true)
            {
                Console.WriteLine("Input 1 - BalanceParenthesis, 2 - Palendrome, 3 - Terminate Program");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Boolean b = BalanceParenthesis();
                        if (b)
                            Console.WriteLine("GoodJob It is a BalanceParenthesis \n");
                        else
                            Console.WriteLine("Invalid Input It will cause UnBalance Parenthesis \n");
                        break;
                    case 2:
                        Boolean p = Palendrome();
                        if (p)
                            Console.WriteLine("GoodJob It is a Palendrome \n");
                        else
                            Console.WriteLine("Invalid Input It will be an Invalid Palendrome \n");
                        break;
                    case 3:
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                if (end)
                    break;
            }
        }

        /// <summary>
        /// Will run BalanceParenthesis program
        /// </summary>
        /// <returns>A Boolean if it is a BalanceParenthesis or not</returns>
        private static Boolean BalanceParenthesis()
        {
            Console.WriteLine("BalanceParenthesis Program has started and Input 0 to Terminate BalanceParenthesis Program");
            Stack<String> stack = new Stack<String>();
            while (true)
            {
                String pos = Console.ReadLine();
                if (stack.Count() == 0)
                    if (pos == "}" || pos == "]" || pos == ")")
                        return false;
                switch (pos)
                {
                    case "{":
                    case "[":
                    case "(":
                        stack.Push(pos);
                        break;
                    case "}":
                        if (stack.Peek() == "{")
                            stack.Pop();
                        break;
                    case "]":
                        if (stack.Peek() == "[")
                            stack.Pop();
                        break;
                    case ")":
                        if (stack.Peek() == "(")
                            stack.Pop();
                        break;
                    case "0":
                        return true;
                    default:
                        return false;
                }
            }
        }


        /// <summary>
        /// Will run the Palendrome Program
        /// </summary>
        /// <returns>A Boolean if it is Palendrone or not</returns>
        private static Boolean Palendrome()
        {
            Console.WriteLine("Palendrome Program has started");
            Stack<String> stack = new Stack<String>();
            String word = "";
            while (true)
            {
                Console.WriteLine("Input 1- Input char, 2 - Check, 3 - Terminate Palendrome Program");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.Write("Input char: ");
                        String c = Console.ReadLine();
                        stack.Push(c);
                        word += c;
                        break;
                    case 2:
                        return Check(word, stack);
                    case 3:
                        return true;
                }
            }
        }

        /// <summary>
        /// Will Check if the word in the stack is a Palendrome
        /// </summary>
        /// <param name="word"></param>
        /// <param name="stack"></param>
        /// <returns>A Boolean if it is Palendrome or not</returns>
        public static Boolean Check(String word, Stack<String> stack)
        {
            foreach(char c in word)
            {
                if (c.ToString() == stack.Peek())
                    stack.Pop();
                else
                    return false;
            }
            return true;
        }
    }
}
