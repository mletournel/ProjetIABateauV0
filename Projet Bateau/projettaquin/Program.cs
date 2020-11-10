using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projettaquin
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           // Console.WriteLine("Quelle est ta position en abscisse" ?)
             NodeBateau noeudInitial = new NodeBateau(1, 1);

            // NodeBateau noeudInitial = new NodeBateau(1, 1);
            // NodeBateau noeudlambda = new NodeBateau(43, 5);
            //noeudInitial._xf = 250;

            //List<GenericNode> ouverts = noeudInitial.GetListSucc();


            // 1- Classe NodeBateau méthode public override List<GenericNode> GetListSucc() 
           /* On doit ajouter le déplacement en diagonale/*
            2- On doit modifier le form
            3- Voir dans le main noeuf final
            4- Heuristique
            */
            

        }
    }
}
