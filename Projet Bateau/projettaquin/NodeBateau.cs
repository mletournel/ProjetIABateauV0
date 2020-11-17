using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettaquin
{
    class NodeBateau : GenericNode
    {

        int _x ;
        int _y;
        public static  int _xf;
        public static int _yf;
        public static char cas ;
        /*
               main
               writeline
               xo, yo, xf, yf
                   NodeBateau noeudinitial = new NodeBateau(xo,yo)
                   noeudInitial._xf = 250;
                   noeudInitial._yf = 250;
          */
          
        public int Get_x ()
        {
            return _x;
        }
        public int Get_y()
        {
            return _y;
        }
        public NodeBateau(int x, int y) : base() 
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
            int x2 = NT._x;
            int y2 = NT._y;
 
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
        
        // à modifier en ‘b’ ou ‘c’ selon le choix de l’utilisateur
        public double get_wind_speed(double x, double y)
        {
            if (cas == 'a')
                return 50;
            else if (cas == 'b')
                if (y > 150)
                    return 50;
                else return 20;
            else if (y > 150)
                return 50;
            else return 20;
        }
        public double get_wind_direction(double x, double y)
        {
            if (cas == 'a')
                return 30;
            else if (cas == 'b')
                if (y > 150)
                    return 180;
                else return 90;
            else if (y > 150)
                return 170;
            else return 65;
        }
     

        public override bool EndState() // Elle retourne true si le noeud est le noeud final
        {
            return (_x==_xf && _y==_yf) ;
        }

        public override List<GenericNode> GetListSucc() // Liste toute les positions dans lequels peut aller le bateau
        {
            /*
            // Code position LUIS
            List<GenericNode> lsucc = new List<GenericNode>();

            if (_x != 0)
            {
                lsucc.Add(new NodeBateau(_x- 1, _y));
                if (_y != 0)
                {
                    lsucc.Add(new NodeBateau(_x - 1, _y - 1));
                }
                if (_y != 300)
                {
                    lsucc.Add(new NodeBateau(_x- 1, _y + 1));
                }
            }

            if (_y != 0)
            {
                lsucc.Add(new NodeBateau(_x, _y - 1));
                if (_x != 300)
                {
                    lsucc.Add(new NodeBateau(_x + 1, _y - 1));
                }
            }

            if (_x != 300)
            {
                lsucc.Add(new NodeBateau(_x + 1, _y));

                if (_y != 300)
                {
                    lsucc.Add(new NodeBateau(_x + 1, _y + 1));
                }
            }

            if (_y != 300)
            {
                lsucc.Add(new NodeBateau(_x, _y + 1));
            }
            */

            List<GenericNode> lsucc = new List<GenericNode>(); 




            // permet de lister tout les positions potentiel dans lequel le bateau peut se déplacer
            
            
            //4 if poour chaque coin 
                 if (_x != 0 && _y != 0 && _x != 300 && _y != 300)
            {
                lsucc.Add(new NodeBateau(_x - 2, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x + 2, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y - 2)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x, _y + 2)); // poour aller en haut 
                lsucc.Add(new NodeBateau(_x - 2, _y - 2)); // Diagonale en bas à gauche = Sud Ouest
                lsucc.Add(new NodeBateau(_x + 2, _y - 2));//Diagonale en bas à  gauche = Sud Est
                lsucc.Add(new NodeBateau(_x - 2, _y + 2)); //Diagonale en haut à gauche = Nord Ouest
                lsucc.Add(new NodeBateau(_x + 2, _y + 2)); //Diagonale en haut à droite = Nord est

            }
           else if (_x == 0 && _y == 0) // Cas en bas a gauche 
            {
                lsucc.Add(new NodeBateau(_x + 2, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y + 2)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x + 2, _y+ 2)); //Diagonale en haut à droite = Nord Est

            }

            else if (_x == 0 && _y == 300) // Case en haut à gauche
            {
                lsucc.Add(new NodeBateau(_x + 2, _y)); // pour aller a droite
                lsucc.Add(new NodeBateau(_x, _y - 2)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x + 2, _y - 2));//Diagonale en bas à  gauche = Sud Est

            }

            else if (_x == 300 && _y == 0) // Case en bas à droite
            {
                lsucc.Add(new NodeBateau(_x - 2, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x - 2, _y + 2)); //Diagonale en haut à gauche = Nord Ouest
                lsucc.Add(new NodeBateau(_x, _y + 2)); // pour aller en haut
                
            }
            else if (_x == 300 && _y == 300) // Case en haut à droite
            {
                lsucc.Add(new NodeBateau(_x - 2, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x, _y - 2)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x - 2, _y - 2)); // Diagonale en bas à gauche = Sud Ouest

            }

            //4 if pour les cotés et vérifier pour y différent 0 et 300
            else if (_x == 0 && _y != 0 && _y != 300) // A coté gauche
            {
                lsucc.Add(new NodeBateau(_x, _y - 2)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x, _y + 2)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x + 2, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x + 2, _y - 2));//Diagonale en bas à  gauche = Sud Est
                lsucc.Add(new NodeBateau(_x + 2, _y + 2)); //Diagonale en haut à droite = Nord Est



            }
            else if (_y == 0 && _x != 0 && _x!= 300) //En bas
            {
                lsucc.Add(new NodeBateau(_x - 2, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x, _y + 2)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x + 2, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x + 2, _y + 2)); //Diagonale en haut à droite = Nord Est
                lsucc.Add(new NodeBateau(_x - 2, _y + 2)); //Diagonale en haut à gauche = Nord Ouest

            }
            else if (_x == 300 && _y != 0 && _y==300) //coté droit
            {
                lsucc.Add(new NodeBateau(_x, _y - 2)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x, _y + 2)); // pour aller en haut
                lsucc.Add(new NodeBateau(_x - 2, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x - 2, _y + 2)); //Diagonale en haut à gauche = Nord Ouest
                lsucc.Add(new NodeBateau(_x - 2, _y - 2)); // Diagonale en bas à gauche = Sud Ouest


            }
            else if (_y == 300 && _x != 0 &&  _x!=300) //coté en haut
            {
                lsucc.Add(new NodeBateau(_x + 2, _y)); // poour aller a droite
                lsucc.Add(new NodeBateau(_x, _y - 2)); // pour aller en bas
                lsucc.Add(new NodeBateau(_x - 2, _y)); // poour aller à gauche 
                lsucc.Add(new NodeBateau(_x - 2, _y - 2)); // Diagonale en bas à gauche = Sud Ouest
                lsucc.Add(new NodeBateau(_x + 2, _y - 2));//Diagonale en bas à  gauche = Sud Est


            }

       

            return lsucc;
        }

        public override double CalculeHCost() //Calculer heuristique : distance entre les deux points 
        {

            double Hcoste = Math.Sqrt(Math.Pow(_xf - _x, 2) + Math.Pow(_yf - _y, 2))/45; //  en divisant par 45 CAS A = 7s, CAS B= 20 secodnes et Cas C= 5 secondes
            return (Hcoste);




        // return (0);
        }

        public override string ToString()
        {

            return ("abscisse : " + _x + " ordonnée" + _y + " Heuristique" + CalculeHCost());
        }
    }
}
