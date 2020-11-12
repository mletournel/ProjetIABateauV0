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
                foreach (GenericNode N in Lres)
                {
                    listBox1.Items.Add(N);
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
            {
                labelsolution.Text = "Une solution a été trouvée";
                foreach (GenericNode N in Lres)
                {
                    listBox1.Items.Add(N);
                }
                labelcountopen.Text = "Nb noeuds des ouverts : " + g.CountInOpenList().ToString();
                labelcountclosed.Text = "Nb noeuds des fermés : " + g.CountInClosedList().ToString();
                g.GetSearchTree(treeView1);
            }
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
                foreach (GenericNode N in Lres)
                {
                    listBox1.Items.Add(N);
                }
                labelcountopen.Text = "Nb noeuds des ouverts : " + g.CountInOpenList().ToString();
                labelcountclosed.Text = "Nb noeuds des fermés : " + g.CountInClosedList().ToString();
                g.GetSearchTree(treeView1);
            }
        }
    }     
}
