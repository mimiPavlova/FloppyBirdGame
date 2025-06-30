using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        bool gameOver=false;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                gravity=15;
            }
            if (e.KeyCode==Keys.R&&gameOver)
            {
                //run the restart function;
                RestartGame();
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity=-8;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            bird.Top+=gravity;
            pipeDown.Left-=pipeSpeed;
            pipeUp.Left-=pipeSpeed;
            scoreLabel.Text=$"Score: {score}";

            if (pipeDown.Left<-150)
            {
                pipeDown.Left=800;
                score++;

            }
            if(pipeUp.Left<-180)
            {
                pipeUp.Left=950;
                score++;
            }

            if (bird.Bounds.IntersectsWith(pipeDown.Bounds)||
               bird.Bounds.IntersectsWith(pipeUp.Bounds)||
               bird.Bounds.IntersectsWith(graund.Bounds)||bird.Top<-25)
            {
                EndGame();
            }


            if (score>14) pipeSpeed=9;
            if (score>20) pipeSpeed=11;

           

        }
        private void EndGame()
        {
            
            gameTimer.Stop();
            scoreLabel.Text+="   GameOver!\nPress R to play again";
            gameOver=true;


        }
        private void RestartGame()
        {
            gameOver=false;
            bird.Location=new Point(76, 235);
            pipeUp.Left=700;
            pipeDown.Left=110;
            score=0;
            pipeSpeed=8;
            scoreLabel.Text=$"Score {score}";
            gameTimer.Start();

        }
    }
}
