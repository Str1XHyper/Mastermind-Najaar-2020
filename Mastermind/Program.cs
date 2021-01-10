using Logic;
using System;

namespace Mastermind
{
    class Program
    {
        static Algoritme algoritme;
        static void Main(string[] args)
        {
            Console.WriteLine("Hoe lang moet de mastermind code zijn?");
            int codeLength = Convert.ToInt32(Console.ReadLine());
            algoritme = new Algoritme(codeLength);
            algoritme.RunAlgoritme();
        }
    }
}
