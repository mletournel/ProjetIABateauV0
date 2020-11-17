using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projettaquin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NodeBateau.cas = 'a';
            SearchTree g = new SearchTree();
            NodeBateau N0 = new NodeBateau(100, 200);
            NodeBateau._xf = 200;
            NodeBateau._yf = 100;
            List<GenericNode> Lres = g.RechercheSolutionAEtoile(N0);

            if (Lres.Count == 0)
            {
                labelsolution.Text = "Pas de solution";
            }
            else
            {
                labelsolution.Text = "Une solution a été trouvée";
                int i = 0;
                Pen penwhite = new Pen(Color.White); // d’autres couleurs sont disponibles
                Graphics g1 = pictureBox1.CreateGraphics();
                foreach (GenericNode N in Lres)
                {
                    listBox1.Items.Add(N);
                    listBox1.Items.Add("G : " + N.GetGCost().ToString());
                    if (i < Lres.Count - 1)
                    {
                        NodeBateau NT = (NodeBateau)(N);

                        int x1 = NT.Get_x();
                        int y1 = NT.Get_y();

                        NodeBateau NT2 = (NodeBateau)(Lres[i + 1]);

                        int x2 = NT2.Get_x();
                        int y2 = NT2.Get_y();

                        g1.DrawLine(penwhite, new Point((int)x1, pictureBox1.Height - (int)y1),
                        new Point((int)x2, pictureBox1.Height - (int)y2));

                        i++;
                    }
                }
                labelcountopen.Text = "Nb noeuds des ouverts : " + g.CountInOpenList().ToString();
                labelcountclosed.Text = "Nb noeuds des fermés : " + g.CountInClosedList().ToString();
                g.GetSearchTree(treeView1);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NodeBateau.cas = 'b';
            SearchTree g = new SearchTree();
            NodeBateau N0 = new NodeBateau(100, 200);
            NodeBateau._xf = 200;
            NodeBateau._yf = 100;
            List<GenericNode> Lres = g.RechercheSolutionAEtoile(N0);

            if (Lres.Count == 0)
            {

                labelsolution.Text = "Pas de solution";
            }
            else
                labelsolution.Text = "Une solution a été trouvée";
            int i = 0;
            Pen penwhite = new Pen(Color.White); // d’autres couleurs sont disponibles
            Graphics g1 = pictureBox1.CreateGraphics();
            foreach (GenericNode N in Lres)
            {
                listBox1.Items.Add(N);
                listBox1.Items.Add("G : " + N.GetGCost().ToString());
                if (i < Lres.Count - 1)
                {
                    NodeBateau NT = (NodeBateau)(N);

                    int x1 = NT.Get_x();
                    int y1 = NT.Get_y();

                    NodeBateau NT2 = (NodeBateau)(Lres[i + 1]);

                    int x2 = NT2.Get_x();
                    int y2 = NT2.Get_y();

                    g1.DrawLine(penwhite, new Point((int)x1, pictureBox1.Height - (int)y1),
                    new Point((int)x2, pictureBox1.Height - (int)y2));

                    i++;
                }

            }
            labelcountopen.Text = "Nb noeuds des ouverts : " + g.CountInOpenList().ToString();
            labelcountclosed.Text = "Nb noeuds des fermés : " + g.CountInClosedList().ToString();
            g.GetSearchTree(treeView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NodeBateau.cas = 'c';
            SearchTree g = new SearchTree();
            NodeBateau N0 = new NodeBateau(200, 100);
            NodeBateau._xf = 100;
            NodeBateau._yf = 200;
            List<GenericNode> Lres = g.RechercheSolutionAEtoile(N0);

            if (Lres.Count == 0)
            {
                labelsolution.Text = "Pas de solution";
            }
            else
            {
                labelsolution.Text = "Une solution a été trouvée";
                int i = 0;
                Pen penwhite = new Pen(Color.White); // d’autres couleurs sont disponibles
                Graphics g1 = pictureBox1.CreateGraphics();
                foreach (GenericNode N in Lres)
                {
                    listBox1.Items.Add(N);
                    listBox1.Items.Add("G : " + N.GetGCost().ToString());
                    if (i < Lres.Count-1)
                    {
                        NodeBateau NT = (NodeBateau)(N);

                        int x1 = NT.Get_x();
                        int y1 = NT.Get_y();

                        NodeBateau NT2 = (NodeBateau)(Lres[i + 1]);

                        int x2 = NT2.Get_x();
                        int y2 = NT2.Get_y();
                       
                        g1.DrawLine(penwhite, new Point((int)x1, pictureBox1.Height - (int)y1),
                        new Point((int)x2, pictureBox1.Height - (int)y2));

                        i++;
                    }
                }
                labelcountopen.Text = "Nb noeuds des ouverts : " + g.CountInOpenList().ToString();
                labelcountclosed.Text = "Nb noeuds des fermés : " + g.CountInClosedList().ToString();
                g.GetSearchTree(treeView1);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }     
}
