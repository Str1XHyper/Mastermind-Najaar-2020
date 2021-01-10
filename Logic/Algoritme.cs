using System;
using System.Collections.Generic;

namespace Logic
{
    public class Algoritme
    {
        Code code;
        int codeLength;

        public Algoritme(int length)
        {
            codeLength = length;
            code = new Code(codeLength);
        }

        public void RunAlgoritme()
        {
            Random rnd = new Random();

            int[] guess = new int[codeLength];
            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] = rnd.Next(0, 2);
            }

            int FirstGuessCorrect = code.ControleerCode(guess);

            if(FirstGuessCorrect == codeLength)
            {
                Console.WriteLine($"Guess: {stringify(guess)}, All numbers are correct!");
                return;
            }

            int pogingen = 0;
            List<int> UsefullGuesses = new List<int>();

            while(pogingen < codeLength)
            {
                int[] nextGuess = new int[codeLength];
                for(int i = 0; i < guess.Length; i++)
                {
                    nextGuess[i] = guess[i];
                }
                nextGuess = NextGuess(nextGuess, pogingen);

                int amountCorrect = code.ControleerCode(nextGuess);

                Console.WriteLine($"Guess: {stringify(nextGuess)}, Number of guesses: {pogingen}, Amount of number correct: {amountCorrect}");
                if (amountCorrect > FirstGuessCorrect)
                {
                    UsefullGuesses.Add(pogingen);
                }

                pogingen++;
            }

            int[] CorrectGuess = FinalGuess(guess, UsefullGuesses.ToArray());
            int finalCorrectCount = code.ControleerCode(CorrectGuess);

            if(finalCorrectCount == codeLength)
            {
                Console.WriteLine($"De juiste code is geraden in {pogingen} pogingen!");
                Console.WriteLine($"Het antwoord was: {stringify(CorrectGuess)}");
            }
            else
            {
                Console.WriteLine("De code is niet geraden binnen het maximale aantal pogingen");
            }
        }
        private int[] NextGuess(int[] array, int swapLocation)
        {
            array[swapLocation] = SwapNumber(array[swapLocation]);
            return array;
        }

        private int[] FinalGuess(int[] Guess, int[] UsefullLocations)
        {
            foreach(int i in UsefullLocations)
            {
                Guess[i] = SwapNumber(Guess[i]);
            }

            return Guess;
        }

        private int SwapNumber(int number)
        {
            switch (number)
            {
                case 0:
                    return 1;
                case 1:
                    return 0;
                default:
                    return 0;
            }
        }

        private string stringify(int[] array)
        {
            string result = string.Empty;

            foreach(int number in array)
            {
                result += number.ToString();
            }
            return result;
        }
    }
}
