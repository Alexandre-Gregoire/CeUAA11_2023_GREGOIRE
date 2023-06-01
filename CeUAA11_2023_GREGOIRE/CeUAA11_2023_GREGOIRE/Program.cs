using System;

namespace CeUAA11_2023_GREGOIRE
{
    class Program
    {
        static void Main(string[] args)
        {
            string entreeUtilisateur = "";
            string phrase;
            string cle;
            int a;
            int b;
            string[,] cryptage;
            bool restart = true;
            while (restart)
            {
                MethodesDuProjet mesOutils = new MethodesDuProjet();
                entreeUtilisateur = "";
                while (entreeUtilisateur != "1" && entreeUtilisateur != "2")
                {
                    Console.WriteLine("Bonjour a vous quel cryptage voulez vous utilisez ? \n1. Méthode de cryptage de Vigenère\n2. Méthode du chiffre affine");
                    Console.WriteLine("Veuillez entrez 1 ou 2");
                    entreeUtilisateur = Console.ReadLine();
                }
                if (entreeUtilisateur == "1")
                {
                    Console.WriteLine("\n---Méthode de cryptage de Vigenère---\n");
                    mesOutils.entreeV(out phrase, out cle);
                    mesOutils.CryptVigenere(phrase, cle, out cryptage);
                    mesOutils.printMatrices(cryptage);

                }
                if (entreeUtilisateur == "2")
                {
                    Console.WriteLine("\n---Méthode du chiffre affine---\n");
                    mesOutils.entreeA(out phrase);
                    mesOutils.verifierA("Quel sera la valeur de a ?\n", out a);
                    mesOutils.verifierB("Quel sera la valeur de b ?\n", out b);
                    mesOutils.CryptAffine(phrase, a, b, out cryptage);
                    mesOutils.printMatrices(cryptage);
                }
                Console.WriteLine("voulez vous recommencer ? o = oui / reste = non");
                entreeUtilisateur = Console.ReadLine();
                if (entreeUtilisateur != "o")
                {
                    restart = false;
                }

            }
        }

    }
}
