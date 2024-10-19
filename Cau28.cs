using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex01
{
    public partial class Cau28 : Form
    {
        PictureBox pbBasket = new PictureBox();
        PictureBox pbEgg = new PictureBox();
        PictureBox pbChicken = new PictureBox();
        PictureBox pbBomb = new PictureBox();

        Timer tmEgg = new Timer();
        Timer tmChicken = new Timer();
        Timer tmBomb = new Timer();

        int xBasket = 300;
        int yBasket = 300;
        int xDeltaBasket = 30;

        int xChicken = 300;
        int yChicken = 10;
        int xDeltaChicken = 5;

        int xEgg = 300;
        int yEgg = 10;
        int yDeltaEgg = 3;

        int xBomb = 300;
        int yBomb = -100; // Start offscreen
        int yDeltaBomb = 3;

        int score = 0;
        int eggsCaught = 0; // Counter for caught eggs
        bool bombSpawned = false; // Flag to check if the bomb has been spawned

        bool gameOver = false; // Flag to check if the game is over

        public Cau28()
        {
            InitializeComponent();
        }

        private void Cau28_Load(object sender, EventArgs e)
        {
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            tmChicken.Interval = 10;
            tmChicken.Tick += tmChicken_Tick;
            tmChicken.Start();

            tmBomb.Interval = 10;
            tmBomb.Tick += tmBomb_Tick; // Initialize bomb timer
            tmBomb.Start(); // Start bomb timer (even if it's offscreen)
            lblGameOver.Visible = false;

            InitializePictures();
        }

        private void InitializePictures()
        {
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.Size = new Size(70, 70);
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.BackColor = Color.Transparent;
            this.Controls.Add(pbBasket);
            pbBasket.Image = Image.FromFile("../../Images/basket.png");

            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 50);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;
            this.Controls.Add(pbEgg);
            pbEgg.Image = Image.FromFile("../../Images/egg_gold.png");

            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.Size = new Size(100, 100);
            pbChicken.Location = new Point(xEgg, yEgg);
            pbChicken.BackColor = Color.Transparent;
            this.Controls.Add(pbChicken);
            pbChicken.Image = Image.FromFile("../../Images/chicken.png");

            pbBomb.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBomb.Size = new Size(50, 50);
            pbBomb.Location = new Point(xBomb, yBomb);
            pbBomb.BackColor = Color.Transparent;
            this.Controls.Add(pbBomb);
            pbBomb.Image = Image.FromFile("../../Images/bomb.png");
            pbBomb.Visible = false; // Initially hide the bomb
        }

        private void Cau28_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return; // Ignore key inputs if the game is over

            if (e.KeyValue == 39 && (xBasket < this.ClientSize.Width - pbBasket.Width))
                xBasket += xDeltaBasket;
            if (e.KeyValue == 37 && xBasket > 0)
                xBasket -= xDeltaBasket;
            pbBasket.Location = new Point(xBasket, yBasket);
        }

        void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;

            // Check for collision with the basket
            Rectangle eggRect = new Rectangle(xEgg, yEgg, pbEgg.Width, pbEgg.Height);
            Rectangle basketRect = new Rectangle(xBasket, yBasket, pbBasket.Width, pbBasket.Height);

            // If the egg is caught by the basket
            if (eggRect.IntersectsWith(basketRect))
            {
                // Reset the egg position directly below the chicken
                xEgg = xChicken + (pbChicken.Width / 2) - (pbEgg.Width / 2); // Center egg under chicken
                yEgg = yChicken + pbChicken.Height; // Set egg to fall from the bottom of chicken
                score++;
                lblScore.Text = score.ToString();

                eggsCaught++; // Increment the eggs caught counter
                if (eggsCaught >= 5 && !bombSpawned) // Check if 5 eggs are caught
                {
                    SpawnBomb(); // Spawn bomb
                    eggsCaught = 0; // Reset egg counter after spawning bomb
                }
            }
            else if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                pbEgg.Image = Image.FromFile("../../Images/egg_gold_broken.png");
                yEgg = this.ClientSize.Height - pbEgg.Height;
                xDeltaBasket = 0;
                tmEgg.Stop();
                lblGameOver.Visible = true;
            }

            pbEgg.Location = new Point(xEgg, yEgg);
        }


        void tmChicken_Tick(object sender, EventArgs e)
        {
            xChicken += xDeltaChicken;
            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
                xDeltaChicken = -xDeltaChicken;
            pbChicken.Location = new Point(xChicken, yChicken);
        }

        void tmBomb_Tick(object sender, EventArgs e)
        {
            if (bombSpawned)
            {
                yEgg = -100;
                yBomb += yDeltaBomb;

                // Check for collision with the basket
                Rectangle bombRect = new Rectangle(xBomb, yBomb, pbBomb.Width, pbBomb.Height);
                Rectangle basketRect = new Rectangle(xBasket, yBasket, pbBasket.Width, pbBasket.Height);

                // If the bomb hits the basket
                if (bombRect.IntersectsWith(basketRect))
                {
                    // Handle game over or decrease score
                    pbBomb.Image = Image.FromFile("../../Images/bomb_explode.png");
                    yBomb = this.ClientSize.Height - pbBomb.Height;
                    pbBasket.Visible = false; // Hide the basket
                    gameOver = true; // Set game over flag
                    lblGameOver.Visible = true;
                    tmEgg.Stop(); // Stop egg timer
                    tmChicken.Stop(); // Stop chicken timer
                    tmBomb.Stop(); // Stop bomb timer

                }
                else if (yBomb > this.ClientSize.Height) // If bomb goes off screen
                {
                    bombSpawned = false; // Reset bomb state
                    pbBomb.Visible = false; // Hide the bomb
                    yBomb = -100; // Reset bomb position off-screen
                    xEgg = xChicken + (pbChicken.Width / 2) - (pbEgg.Width / 2); // Center egg under chicken
                    yEgg = yChicken + pbChicken.Height; // Set egg to fall from the bottom of chicken
                }

                pbBomb.Location = new Point(xBomb, yBomb);
            }
        }

        private void SpawnBomb()
        {
            xBomb = new Random().Next(0, this.ClientSize.Width - pbBomb.Width); // Randomize the starting position of the bomb
            yBomb = 10; // Reset the bomb's vertical position to the top
            pbBomb.Visible = true; // Show the bomb
            bombSpawned = true; // Set bomb spawned state
        }
    }
}
