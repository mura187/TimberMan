using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace timber
{
    public partial class Form1 : Form
    {
        PictureBox picTimber = new PictureBox();
        PictureBox picTree = new PictureBox();
        PictureBox picBranchL = new PictureBox();
        PictureBox picBranchR = new PictureBox();
        PictureBox picCut = new PictureBox();
        PictureBox picBranchL2 = new PictureBox();

        PictureBox picBranchR2 = new PictureBox();
        int direction = 1;

        public int score = 0;


        public Form1()
        {
            InitializeComponent();

            KeyDown += new KeyEventHandler(TimberMove_KeysDown);
        }

        private void Update(object sender, EventArgs e)
        {

          //  textBox1.Text = string.Format("Score:{0}", score);
            score++;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUpTimber();
            SetUpTree();
            SetUpBranches();
            //IsBranchFell();
        }
           

        void SetUpBranches()
        {
            picBranchR.Image = imageList1.Images[4];
            picBranchR.Size = new Size(140, 68);
            picBranchR.SizeMode = PictureBoxSizeMode.StretchImage;
            picBranchR.Left = 190;
            picBranchR.Top = -900;
            Controls.Add(picBranchR);


            picBranchR2.Image = imageList1.Images[4];
            picBranchR2.Size = new Size(140, 68);
            picBranchR2.SizeMode = PictureBoxSizeMode.StretchImage;
            picBranchR2.Left = 190;
            picBranchR2.Top = -1400;
            Controls.Add(picBranchR2);


            picBranchL.Image = imageList1.Images[3];
            picBranchL.Size = new Size(140, 68);
            picBranchL.SizeMode = PictureBoxSizeMode.StretchImage;
            picBranchL.Left = -10;
            picBranchL.Top = 0;
            Controls.Add(picBranchL);

            picBranchL2.Image = imageList1.Images[3];
            picBranchL2.Size = new Size(140, 68);
            picBranchL2.SizeMode = PictureBoxSizeMode.StretchImage;
            picBranchL2.Left = -10;
            picBranchL2.Top = -500;
            Controls.Add(picBranchL2);

           
        }

        void NewBranches()
        {
            if ((picBranchL.Top > 570) && (picBranchR.Top > 600) && (picBranchL2.Top > 500) && (picBranchR2.Top > 700)
            ){

                SetUpBranches();

            }
         


        }
        void SetUpTree()
        {


            picTree.Image = imageList1.Images[2];
            picTree.Size = new Size(100, 15589);
            picTree.SizeMode = PictureBoxSizeMode.StretchImage;
            picTree.Left = 115;
            picTree.Top = -9159;
            Controls.Add(picTree);


        }


        void SetUpTimber()
        {


            picTimber.Image = imageList1.Images[0];
            picTimber.Size = new Size(100, 100);
            picTimber.SizeMode = PictureBoxSizeMode.StretchImage;
            picTimber.Left = 10;
            picTimber.Top = 315;
            Controls.Add(picTimber);

        }
        void IsBranchFell()
        {
            if ((picBranchL.Bounds.IntersectsWith(picTimber.Bounds)) || (picBranchR.Bounds.IntersectsWith(picTimber.Bounds)) || (picBranchL2.Bounds.IntersectsWith(picTimber.Bounds) || (picBranchR2.Bounds.IntersectsWith(picTimber.Bounds))))
            {

                MessageBox.Show("You Lose! Last Score: " + score.ToString() + " \n\nPress OK to replay");
                
                Application.Restart(); 



                SetUpBranches();

                score = 0;
            }

            
            
        }

        void TimberMove_KeysDown(object sender, KeyEventArgs e)
        {
            this.Focus();

            switch (e.KeyCode)
            {
                case Keys.Right:
                    switch (direction)
                    {
                        case 1:

                            picTimber.Image = imageList1.Images[1];
                            picTimber.Left = 220;
                            picTimber.Top = 315;
                            picBranchL.Top += 55;
                            picBranchR.Top += 55;
                            picTree.Top += 38;
                            picBranchL2.Top += 55;
                            picTimber.Size = new Size(100, 100);
                            picTimber.SizeMode = PictureBoxSizeMode.StretchImage;
                            picBranchL2.Top += 55;

                            picBranchR2.Top+= 55;
                            score++;
                            label1.Text = string.Format("Score:{0}", score);


                            break;

                            
                    }
                    break;

                case Keys.Left:
                    switch (direction)
                    {
                        case 1: 

                            picTimber.Image = imageList1.Images[0];
                            picTimber.Left = 10;
                            picTimber.Top = 315;

                            picBranchL.Top += 55;

                            picBranchR.Top += 55;
                            picBranchL2.Top += 55;

                            picBranchR2.Top += 55;
                            picTree.Top += 35;
                             
                            score++;
                            label1.Text = string.Format("Score:{0}", score);


                            break;
                    }
                    break;
                
            }

            IsBranchFell();
            NewBranches();

        }


    }
}
