using System.Collections.Generic;
using System.Linq;

namespace TEST
{
    internal class Vigenere
    {
        List<char> alphabet;

        public string VigenereG(string password, string text, bool decode)
        {
            password = password.ToLower();
            text = text.ToLower();

            string tempText = "";
            int tempValue = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (alphabet.Contains(text[i]) != true)
                {
                    tempText += text[i];
                }
                else
                {
                    if (decode != true)
                    {
                        tempText += alphabet[(alphabet.IndexOf(text[i]) + alphabet.IndexOf(password[tempValue])) % alphabet.Count];
                    }
                    else
                    {
                        int temp = alphabet.IndexOf(text[i]) - alphabet.IndexOf(password[tempValue]);
                        tempText += temp >= 0 ? alphabet[temp % alphabet.Count] : alphabet[temp + alphabet.Count];
                    }

                    if (tempValue + 1 > password.Length - 1)
                        tempValue = 0;
                    else
                        tempValue++;
                }
            }
            return tempText;
        }
        public Vigenere(string alphabet)
        {
            this.alphabet = alphabet.ToLower().ToCharArray().ToList();
        }
    }
}
