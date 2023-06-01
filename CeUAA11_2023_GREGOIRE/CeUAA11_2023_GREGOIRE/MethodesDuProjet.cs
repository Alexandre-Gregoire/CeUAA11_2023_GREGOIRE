using System;
using System.Collections.Generic;
using System.Text;

namespace CeUAA11_2023_GREGOIRE
{
    public struct MethodesDuProjet
    {
        /// <summary>
        /// permet de tester si la phrase est bien plus grande que la clé
        /// </summary>
        /// <param name="phrase">la phrase </param>
        /// <param name="cle">la cle</param>
        public void entreeV(out string phrase,out string cle)
        {
            phrase = " ";
            cle = "";
            bool testCharSpec = true;
            while (cle.Length < phrase.Length)
            {
                while (testCharSpec)
                {

                    Console.WriteLine("Quel sera votre phrase a crypter ?");
                    phrase = Console.ReadLine();
                    phrase = phrase.ToUpper();
                    suprimmerEspaces(phrase, out phrase);
                    verifierCharSpec(phrase, out testCharSpec);
                    if (testCharSpec)
                    {
                        Console.WriteLine("veuillez entrer seulement des lettres");
                    }
                }
                testCharSpec = true;
                while (testCharSpec)
                {
                    testCharSpec = false;
                    Console.WriteLine("Quel sera votre clé ?");
                    cle = Console.ReadLine();
                    cle = cle.ToUpper();
                    suprimmerEspaces(cle, out cle);
                    verifierCharSpec(cle, out testCharSpec);
                    if (testCharSpec)
                    {
                        Console.WriteLine("veuillez entrer seulement des lettres");
                    }
                }
            }
            
        }
        public void entreeA(out string phrase)
        {
            phrase = " ";

            bool testCharSpec = true;

            while (testCharSpec)
            {
                testCharSpec = false;
                Console.WriteLine("Quel sera votre phrase a crypter ?");
                phrase = Console.ReadLine();
                phrase = phrase.ToUpper();
                suprimmerEspaces(phrase, out phrase);
                verifierCharSpec(phrase, out testCharSpec);
                if (testCharSpec)
                {
                    Console.WriteLine("veuillez entrer seulement des lettres");
                }
            }
            

        }


        /// <summary>
        /// permet de verifier si a est bien egale a ca : 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25.
        /// </summary>
        /// <param name="question">la question a poser a l'utilisateur </param>
        /// <param name="a">la valeur de a</param>
        public void verifierA(string question,out int a)
        {
            string nUser;
            Console.Write(question);
            nUser = Console.ReadLine();
            while (!int.TryParse(nUser, out a))
            {
                Console.WriteLine("Attention ! vous devez taper un nombre réel !");
                nUser = Console.ReadLine();
            }
            while (a != 1 && a != 3 && a != 5 && a != 7 && a != 9 && a != 11 && a != 15 && a != 17 && a != 19 && a != 21 && a != 23 && a != 25)
            {
                Console.WriteLine("Attention ! vous devez taper un nombre parmis ceux ci : 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25.");
                nUser = Console.ReadLine();
                while (!int.TryParse(nUser, out a))
                {
                    Console.WriteLine("Attention ! vous devez taper un nombre réel !");
                    nUser = Console.ReadLine();
                }
            }
        }
        /// <summary>
        /// permet de verifier si a est compris entre 0 et 25
        /// </summary>
        /// <param name="question">la question a poser a l'utilisateur</param>
        /// <param name="b">la valeur de b</param>
        public void verifierB(string question, out int b)
        {
            string nUser;
            Console.Write(question);
            nUser = Console.ReadLine();
            while (!int.TryParse(nUser, out b))
            {
                Console.WriteLine("Attention ! vous devez taper un nombre réel !");
                nUser = Console.ReadLine();
            }
            while (b >= 25 || b <= 0)
            {
                Console.WriteLine("Attention ! vous devez taper un nombre compris entre 0 et 25");
                nUser = Console.ReadLine();
                while (!int.TryParse(nUser, out b))
                {
                    Console.WriteLine("Attention ! vous devez taper un nombre réel !");
                    nUser = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// permet de crypter une phrase selon la methode de vigenere
        /// </summary>
        /// <param name="phClaire">phrase à crypter</param>
        /// <param name="phClef">clef de cryptage</param>
        /// <param name="matVigenere">Matrice de cryptage de Vigenère</param>
        public void CryptVigenere(string phClaire, string phClef, out string[,] matVigenere)
        {
            int codeAscii;
            matVigenere = new string[4, phClaire.Length];
            int j = 0;
            for (int i = 0; i < phClaire.Length; i++)
            {
                matVigenere[0, i] = phClaire[i].ToString();
                if (j == phClef.Length)
                {
                    j = 0;
                }
                matVigenere[1, i] = phClef[j].ToString();
                matVigenere[2, i] = (((int)phClef[j]) - 65).ToString();
                if ((int)phClaire[i] + int.Parse(matVigenere[2, i]) <= 90)
                {
                    codeAscii = (int)char.Parse(matVigenere[0, i]) + int.Parse(matVigenere[2, i]);
                }
                else
                {
                    codeAscii = (int)char.Parse(matVigenere[0, i]) + int.Parse(matVigenere[2, i]) - 26;
                }
                matVigenere[3, i] = Convert.ToChar(codeAscii).ToString();
                j++;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phClaire">phrase à crypter</param>
        /// <param name="a">1° coefficient du cryptage</param>
        /// <param name="b">2° coefficient du cryptage</param>
        /// <param name="matAffine">matrice de cryptage affine</param>
        public void CryptAffine(string phClaire, int a, int b, out string[,] matAffine)
        {
            int x;
            int y;
            matAffine = new string[4, phClaire.Length];
            for (int i = 0; i < phClaire.Length; i++)
            {
                matAffine[0, i] = phClaire[i].ToString();
                x = ((int)phClaire[i] - 65);
                matAffine[1, i] = x.ToString();
                y = (a * x + b) % 26;
                matAffine[2, i] = y.ToString();
                matAffine[3, i] = Convert.ToChar(y + 65).ToString();
            }
        }
        /// <summary>
        /// permet d'ecrire une matrice dans la console
        /// </summary>
        /// <param name="matrices">la matrice a ecrire</param>
        public void printMatrices(string[,] matrices)
        {
            for (int i = 0; i < matrices.GetLength(0); i++)
            {
                for (int y = 0; y < matrices.GetLength(1); y++)
                {
                    Console.Write(matrices[i, y] + " ");
                }
                Console.WriteLine();
            }
        }






        /// <summary>
        /// permet de suprimmer les espaces dans une phrase
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="phrase2"></param>
        public void suprimmerEspaces(string phrase, out string phrase2)
        {
            phrase2 = "";
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] != ' ')
                {
                    phrase2 += phrase[i];
                }
            }
        }
        public void verifierCharSpec(string phrase,out bool testCharSpec)
        {
            testCharSpec = false;
            int i = 0;
            foreach (char c in phrase)
            {
                if (!char.IsLetter(c))
                {
                    i++;
                }

            }
            if (i > 0)
            {
                testCharSpec = true;
            }
            else
            {
                testCharSpec = false;
            }
        }
    }
}
