using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Code
    {
        private int[] code;
        private Random rnd = new Random();

        public Code(int length)
        {
            code = new int[length];

            for(int i=0; i < code.Length; i++)
            {
                code[i] = rnd.Next(0, 2);
            }
        }

        public int ControleerCode(int[] guess)
        {
            int correctAmount = 0;
            if(guess.Length != code.Length)
            {
                throw new Exception("Guess is not the same length as the code!");
            }


            for (int i = 0; i < code.Length; i++)
            {
                if(code[i] == guess[i])
                {
                    correctAmount++;
                }
            }

            return correctAmount;
        }
    }
}
