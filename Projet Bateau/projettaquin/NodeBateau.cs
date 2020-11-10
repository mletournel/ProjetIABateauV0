using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettaquin
{
    class NodeBateau : GenericNode
    {

        double _x;
        double _y;
        public static  double _xf;
        public static double _yf;
 /*
        main
        writeline
        xo, yo, xf, yf
            NodeBateau noeudinitial = new NodeBateau(xo,yo)
            noeudInitial._xf = 250;
            noeudInitial._yf = 250;
   */ 
        
        public NodeBateau(double x, double y) : base() 
        {
            _x = x;
            _y = y;
            
        }

        

        public override bool IsEqual (GenericNode N2) // Permet de verifier si deux noeuds sont égaux. ???
        {
            NodeBateau NT = (NodeBateau)(N2);// Permet la conversion N2 qui est un Genericcode en NodeBateau, il force la conversion
            return (NT._x ==_x && NT._y==_y ); // Verifier si les x et y sont égaux, ça retourne true ou false ce test d'égalité
        }

        public override double GetArcCost(GenericNode N2) // Ajouter times estimation
        {
            NodeBateau NT = (NodeBateau)(N2);
            double x2 = NT._x;
            double y2 = NT._y;
 
            double distance = Math.Sqrt((_x - x2) * (_x - x2) + (_y - y2) * (_y - y2));
            if (distance > 10) return 1000000;
            double windspeed = get_wind_speed((_x + x2) / 2.0, (_y + y2) / 2.0);
            double winddirection = get_wind_direction((_x + x2) / 2.0, (_y + y2) / 2.0);
            double boatspeed;
            double boatdirection = Math.Atan2(y2 - _y, x2 - _x) * 180 / Math.PI;
            // On ramène entre 0 et 360
            if (boatdirection < 0) boatdirection = boatdirection + 360;
            // calcul de la différence angulaire
            double alpha = Math.Abs(boatdirection - winddirection);
            // On se ramène à une différence entre 0 et 180 :
            if (alpha > 180) alpha = 360 - alpha;
            if (alpha <= 45)
            {
                /* (0.6 + 0.3α / 45) v_v */
                boatspeed = (0.6 + 0.3 * alpha / 45) * windspeed;
            }
            else if (alpha <= 90)
            {
                /*v_b=(0.9-0.2(α-45)/45) v_v */
                boatspeed = (0.9 - 0.2 * (alpha - 45) / 45) * windspeed;
            }
            else if (alpha < 150)
            {
                /* v_b=0.7(1-(α-90)/60) v_v */
                boatspeed = 0.7 * (1 - (alpha - 90) / 60) * windspeed;
            }
            else
                return 1000000;
            // estimation du temps de navigation entre p1 et p2
            return (distance / boatspeed);
        }
        /*
        public double time_estimation(double _x, double _y, double x2, double y2)
        {
            
        }
        */

        public override bool EndState() // Elle retourne true si le noeud est le noeud final
        {
            return (_x==_xf && _y==_yf) ;
        }

        public override List<GenericNode> GetListSucc() // Liste toute les positions dans lequels peut aller le bateau
        {
            
            // On reconstruit le carré 3x3 à partir du nom et on mémorise la position du ?
           /* int posx=-1; int posy=-1;
            char[,] tab = new char[3,3];
            for (int j = 0; j <= 2; j++)
                for (int i = 0; i <= 2; i++) 
                {
                    tab[i,j] = Name[j*3+i];

                    if (tab[i,j] == '?')
                    {
                        posx = i;
                        posy = j;
                    }
                }*/

            List<GenericNode> lsucc = new List<GenericNode>(); // permet de lister tout les positions potentiel dans lequel le bateau peut se déplacer

            //4 if poour chaque coin 
            if (_x == 0 && _y == 0) // Cas en bas a gauche 
            {
                lsucc.Add(new NodeBateau(_x + 1, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y + 1)); // pour aller en haut

            }

            else if (_x == 0 && _y == 300) // Case en haut à gauche
            {
                lsucc.Add(new NodeBateau(_x + 1, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y - 1)); // pour aller en bas

            }

            else if (_x == 300 && _y == 0) // Case en bas à droite
            {
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x, _y + 1)); // pour aller en haut

            }
            else if (_x == 300 && _y == 300) // Case en haut à droite
            {
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x, _y - 1)); // pour aller en bas

            }

            //4 if pour les cotés et vérifier pour y différent 0 et 300
            else if (_x == 0 && _y != 0) //Ligne du cas
            {
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x, _y + 1)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x + 1, _y)); // poour aller a droite
            }
            else if (_y == 0 && _x != 0) //coté gauche
            {
                lsucc.Add(new NodeBateau(_x, _y - 1)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x, _y + 1)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x + 1, _y)); // poour aller a droite
            }
            else if (_x == 300 && _y != 0) //coté gauche
            {
                lsucc.Add(new NodeBateau(_x, _y - 1)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x, _y + 1)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
            }
            else if (_y == 300 && _x != 0) //coté en haut
            {
                lsucc.Add(new NodeBateau(_x + 1, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y - 1)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
            }
            else
            {
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x + 1, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y - 1)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x - 1, _y)); // poour aller à gauche 
            }
            /* if (posx > 0)
             {
                 // Successeur à gauche
                 // recopie du tableau
                 char[,] tab2 = new char[3, 3];
                 for (int j = 0; j <= 2; j++)
                     for (int i = 0; i <= 2; i++)
                     {
                         tab2[i, j] = tab[i, j];
                     }
                 // MAJ de la position du ?
                 tab2[posx, posy] = tab2[posx - 1, posy];
                 tab2[posx - 1, posy] = '?';
                 // Ajout à listsucc
                 lsucc.Add(new NodeBateau(GetStringFromTab(tab2)));
             }
             if (posx < 2)
             {
                 // Successeur à droite
                 // recopie du tableau
                 char[,] tab2 = new char[3, 3];
                 for (int j = 0; j <= 2; j++)
                     for (int i = 0; i <= 2; i++)
                     {
                         tab2[i, j] = tab[i, j];
                     }
                 // MAJ de la position du ?
                 tab2[posx, posy] = tab2[posx + 1, posy];
                 tab2[posx + 1, posy] = '?';
                 // Ajout à listsucc
                 lsucc.Add(new NodeBateau(GetStringFromTab(tab2)));
             }

             if (posy > 0)
             {
                 // Successeur en haut
                 // recopie du tableau
                 char[,] tab2 = new char[3, 3];
                 for (int j = 0; j <= 2; j++)
                     for (int i = 0; i <= 2; i++)
                     {
                         tab2[i, j] = tab[i, j];
                     }
                 // MAJ de la position du ?
                 tab2[posx, posy] = tab2[posx, posy-1];
                 tab2[posx, posy-1] = '?';
                 // Ajout à listsucc
                 lsucc.Add(new NodeBateau(GetStringFromTab(tab2)));
             }
             if (posy < 2)
             {
                 // Successeur en bas
                 // recopie du tableau
                 char[,] tab2 = new char[3, 3];
                 for (int j = 0; j <= 2; j++)
                     for (int i = 0; i <= 2; i++)
                     {
                         tab2[i, j] = tab[i, j];
                     }
                 // MAJ de la position du ?
                 tab2[posx, posy] = tab2[posx, posy + 1];
                 tab2[posx, posy + 1] = '?';
                 // Ajout à listsucc
                 lsucc.Add(new NodeBateau(GetStringFromTab(tab2)));
             }
             */
            return lsucc;
        }

        public override double CalculeHCost() //Calculer heuristique : distance entre le point 
        {

        
             // on compte les mal placés 
            /*  int nb=8;
              for (int i = 0; i < 8; i++)
                  if (Name[i] == Convert.ToChar(i + 49)) // En code ASCII 1 est le 49ème caractère
                      nb--;
              return(nb);
             */  
            return(0);
        }

       /* private string GetStringFromTab ( char [,] tab ) 
        {
            string newname = "";
            for (int j=0;j<=2; j++)
                for (int i=0;i<=2;i++)
                    {
                       newname = newname + tab[i,j]; 
                   }  
            return newname;
        }
        */

        public override string ToString()
        {
            
            return("abscisse : " +_x +" ordonnée"+_y); 
        }
    }
}
