using System;

namespace Projet_2_Shell
{
   
    class Program
    {
        string[] tableau = new string[] { "ciseau", "papier", "roche" };
        string[] fruits = new string[] { "banane", "poire", "pomme", "cerise", "mangue", "figue", "tangerine", "fraise", "framboise", "bleuet" };
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            string choix;

            Menu();

            do
            {
               

                choix = Console.ReadLine();
                selectionchoice(choix);

            } while (choix != "3");



        }
        private void Menu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Veuillez choisir le jeu à jouer:");
            Console.WriteLine("1- Roche/papier/ciseau   2- La devinette   3- Quitter");
            Console.WriteLine("----------------------------------------------------");
        }
          private void selectionchoice(string choix)
        {
            switch (choix)
            {
                case "1":
                    JouerARochePapierCiseau();
                    break;
                case "2":
                    Ladevinette ();
                    break;
                case "3":
                    Quitter ();
                    break;
                default:
                    choixinvalide();
                    break;

            }

        }

        private void choixinvalide() 
        {
            Console.WriteLine("Veuillez effectuer un choix valide");
           
        }
        private void Quitter()
        {
            Environment.Exit(0);
        }

        // Le Jeu de la devinette
        private void Ladevinette()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Bienvenue dans La devinette");
            Console.WriteLine("---------------------------------------------------------------------------");
            var rand = new Random();
            int indice = rand.Next(0, 10);
            
           // on tire d'abord un fruit au hazard dans le tableau contenant les fruits
            string fruit = fruits[indice];
            
   // on tranforme le fruit tirer au hazard en un tableau de char
            char[] fruitChar = fruit.ToCharArray();
            int indice1, indice2, indice3;    
            indice1 = rand.Next(0, fruit.Length);
            indice2 = rand.Next(0, fruit.Length);
            indice3 = rand.Next(0, fruit.Length);
            if(indice1 == indice2 )
            {
                while (indice1 == indice2)  // generrer a nouveau indice2 tant que indice1 est egale a indice1
                {
                    indice2 = rand.Next(0, fruit.Length);

                }

            }
            if(indice3 == indice2 || indice3 == indice1)
            {
                while (indice3 == indice2 || indice3 == indice1) // tant que indice3 est egale indice2 ou indice3 est egale a indice1 
                {
                    indice3 = rand.Next(0, fruit.Length);

                }

            }
            fruitChar[indice1] = '_';
            fruitChar[indice2] = '_';
            fruitChar[indice3] = '_';
            
            string nouveauFruit = new string(fruitChar);
            Console.WriteLine("FRUIT A TROUVER : " + nouveauFruit);
            string fruitATrouver;
            int nombreDeTentative = 0;
            fruitATrouver = Console.ReadLine();
           
            // tant que le fruit a trouver n'est pas egale au fruit saisi par l'utilisateur  et le nombre de tentative est inferieur a 3


            while (!fruitATrouver.Equals(fruit) && nombreDeTentative < 3)
            {
                    Console.WriteLine("FRUIT A TROUVER : " + nouveauFruit);
                     fruitATrouver = Console.ReadLine();
                if (fruitATrouver.Equals(fruit))
                {
                    Console.WriteLine("Bravo! vous avez trouvé le mot!");
                    ++nombreDeTentative; 


                }
               
                    
                   
            }
            if (nombreDeTentative < 3)
            {
                Console.WriteLine("Bravo! vous avez trouvé le mot!");
                


            }


        }
        


        private void JouerARochePapierCiseau()
        {
            Console.WriteLine("Bienvenue dans le jeu roche/papier/ciseau"); ;
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("J'ai déja choisis mon élément! A votre tour de choisir l'élément:");
            var rand = new Random();
            int indice = rand.Next(0, 3);                          // next est une fonction de l'objet rand qui vq genérer le nombre 
            string computerChoice = tableau[indice];                //aléatoire compris entre 0 et 3 (3 est exclus)
                                                                    //string computerChoice = tableau[indice];
            Console.WriteLine("choix ordinateur = " + computerChoice);         //pour récuperer le choix de l'ordinateur dans le tebleau déclaré en haut
            string userchoice = GetUserChoice();
            if (userchoice.Equals(computerChoice))
            {
                Console.WriteLine("partie nulle! nous avons choisis le méme élement! ");
            }
            if (computerChoice.Equals("ciseau"))
            {
                switch (userchoice)
                {
                    case "papier":
                        Console.WriteLine("votre choix est "+userchoice+" et mon choix est "+computerChoice+ " Je gagne la partie");
                        break;
                    case "roche":
                        Console.WriteLine("votre choix est " + userchoice + " et mon choix est " + computerChoice + " vous avez gagné la partie !");
                        break;
                }
            }
            if (computerChoice.Equals("papier"))
            { 
                switch (userchoice)
                {
                    case "roche":
                        Console.WriteLine("votre choix est " + userchoice + " et mon choix est " + computerChoice + " Je gagne la partie");
                        break;
                    case "ciseau":
                        Console.WriteLine("votre choix est " + userchoice + " et mon choix est " + computerChoice + " vous avez gagné la partie !");
                        break;

                }

            }
            if (computerChoice.Equals("roche"))
            {
                switch (userchoice)
                {
                    case "ciseau":
                        Console.WriteLine("votre choix est " + userchoice + " et mon choix est " + computerChoice + " Je gagne la partie");
                        break;
                    case "papier":
                        Console.WriteLine("votre choix est " + userchoice + " et mon choix est " + computerChoice + " vous avez gagné la partie !");
                        break;

                }

            }
            Console.WriteLine("Voullez-vous refaire une partie(O/N)?");
            string choice = Console.ReadLine();
            while (!choice.Equals("O") && !choice.Equals("o")&& !choice.Equals("N")&& !choice.Equals("n")) //on peut aussi l'ecrire != 
            {
                Console.WriteLine("Voullez-vous refaire une partie(O/N)?");
                choice = Console.ReadLine();



            }
            switch(choice.ToUpper()) // la fonction tolower converti le o dans le choix en min/maj + le choix de case doit etre du meme genre ca veut dire maj ou min
            {
                case "O":
                    JouerARochePapierCiseau();
                    break;
                case "N":
                    Menu();
                    break;

            }









        }

        private bool IsAnotherGame()
        {
            return false;
        }


        private string GetUserChoice()
        {

            Console.WriteLine("Veuillez saisir un choix");
            string element = Console.ReadLine();
            if(element != "roche" && element != "papier" && element != "ciseau")
            {
                Console.WriteLine(" votre choix est invalide veuillez le saisir à nouveau");

            }
            while (element != "roche" && element != "papier" && element != "ciseau") 
            {
                element = Console.ReadLine();
                if(element != "roche" && element != "papier" && element != "ciseau")
                {

                    Console.WriteLine("votre choix est invalide veuillez le saisir à nouveau");
                }

            }


            return element;
        }
        private void ValidateWinner(string userChoice, string cpuChoice)
        {

        }

        private string GetComputerChoice()
        {
            return null;
        }

        private void JouerADevinette()
        {

        }

        private void AfficherResultatGame(bool isFound, string fruitToFind)
        {

        }

        private bool IsFruitPlayerGood(string fruitPlayer, string fruitToFind)
        {
            return false;
        }

        private string GetFruitWithout3Letters(string fruit)
        {
            return null;
        }

        private int[] GetThreeRandomNumber(string fruit)
        {
            return null;
        }

        private string GetFruit()
        {
            return null;
        }
    }
}