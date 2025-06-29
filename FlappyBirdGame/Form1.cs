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
        int pipeSpeed = 5;
        int gravity = 15;
        int score = 0;

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
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity=-15;
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
               bird.Bounds.IntersectsWith(graund.Bounds))
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            
            gameTimer.Stop();
            scoreLabel.Text+="GameOver!";
        }
    }
}
