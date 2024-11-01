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
using WMPLib;

namespace Ex01
{
    public partial class Cau28 : Form
    {
        Image backgroundImage;

        PictureBox pbBasket = new PictureBox();
        PictureBox pbEgg = new PictureBox();
        PictureBox pbChicken = new PictureBox();
        PictureBox pbBomb = new PictureBox();
        PictureBox pbHeart = new PictureBox();
        PictureBox heart = new PictureBox();

        List<PictureBox> hearts = new List<PictureBox>(); // List to hold heart icons
        int lives = 1; // Start with 1 life
        int maxLives = 5;

        Timer tmEgg = new Timer();
        Timer tmChicken = new Timer();
        Timer tmBomb = new Timer();
        Timer tmHeart = new Timer();

        int xBasket = 300;
        int yBasket = 300;
        int xDeltaBasket = 30;

        int xChicken = 300;
        int yChicken = 10;
        int xDeltaChicken = 5;

        int xEgg = 300;
        int yEgg = 10;
        int yDeltaEgg = 3;

        int xEggLastPosition; // Track the last x-position of the egg

        int xBomb = 300;
        int yBomb = -100; // Start offscreen
        int yDeltaBomb = 3;
        bool bombSpawned = false; // Flag to check if the bomb has been spawned

        int xHeart = 300;
        int yHeart = -100; // Start offscreen
        int yDeltaHeart = 3;
        bool heartSpawned = false;

        int score = 0;
        int eggsCaught = 0; // Counter for caught eggs

        bool gameOver = false; // Flag to check if the game is over

        // WindowsMediaPlayer objects for background and sound effects
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();
        WindowsMediaPlayer chickenSound = new WindowsMediaPlayer();
        WindowsMediaPlayer eggCatchSound = new WindowsMediaPlayer();
        WindowsMediaPlayer eggBrokenSound = new WindowsMediaPlayer();
        WindowsMediaPlayer bombExplosionSound = new WindowsMediaPlayer();
        WindowsMediaPlayer gameOverSound = new WindowsMediaPlayer();

        public Cau28()
        {
            InitializeComponent();
            backgroundImage = Image.FromFile("../../Images/background_image.png"); // Load your background image
        }


        private void Cau28_Load(object sender, EventArgs e)
        {
            this.SizeChanged += Cau28_SizeChanged;

            // Set the sound files and play the background music in loop
            backgroundMusic.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\background_music.mp3";
            chickenSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\chicken.mp3";

            backgroundMusic.settings.setMode("loop", true);
            backgroundMusic.controls.play();
            chickenSound.settings.setMode("loop", true);
            chickenSound.controls.play();


            // Initialize timers and picture boxes
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            tmChicken.Interval = 10;
            tmChicken.Tick += tmChicken_Tick;
            tmChicken.Start();

            tmBomb.Interval = 10;
            tmBomb.Tick += tmBomb_Tick;
            tmBomb.Start();

            tmHeart.Interval = 10;
            tmHeart.Tick += tmHeart_Tick;
            tmHeart.Start();

            lblGameOver.Visible = false;

            InitializePictures();
        }

        private void Cau28_SizeChanged(object sender, EventArgs e)
        {
            int newWidth = this.ClientSize.Width;
            int newHeight = this.ClientSize.Height;

            // Center the basket at the bottom
            yBasket = newHeight - pbBasket.Height; // Update yBasket to be at the bottom
            pbBasket.Location = new Point((newWidth - pbBasket.Width) / 2, yBasket);

            // Resize the egg and bomb
            pbEgg.Size = new Size(newWidth / 20, newWidth / 20);
            pbBomb.Size = pbHeart.Size = pbEgg.Size;

            // Center chicken
            pbChicken.Location = new Point((newWidth - pbChicken.Width) / 2, 10);

            // Adjust hearts
            for (int i = 0; i < hearts.Count; i++)
            {
                hearts[i].Location = new Point(10 + i * 35, 120);
            }



            //"Game Over" Text Adjust
            lblGameOver.Location = new Point(newWidth/ 2, newHeight/2);
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

            pbHeart.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHeart.Size = new Size(50, 50);
            pbHeart.Location = new Point(xHeart, yHeart);
            pbHeart.BackColor = Color.Transparent;
            this.Controls.Add(pbHeart);
            pbHeart.Image = Image.FromFile("../../Images/heart.png");
            pbHeart.Visible = false;

            //Heart displayed as lives
            for (int i = 0; i < lives; i++)
            {
                heart.SizeMode = PictureBoxSizeMode.StretchImage;
                heart.Size = new Size(30, 30);
                heart.Location = new Point(10 + i * 35, 120);
                heart.BackColor = Color.Transparent;
                heart.Image = Image.FromFile("../../Images/heart.png");
                hearts.Add(heart);
                this.Controls.Add(heart);
            }
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

        // Function to check and increase the speed of egg and bomb
        private void CheckAndIncreaseSpeed()
        {
            if (score % 10 == 0) // Increase speed at every multiple of 10
            {
                yDeltaEgg += 1; // Increase egg speed
                yDeltaBomb += 1; // Increase bomb speed
                yDeltaHeart += 1;
            }
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
                eggCatchSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\egg_catch.mp3";
                eggCatchSound.controls.play();

                // Reset egg position under the chicken after catching it
                xEgg = xChicken + (pbChicken.Width / 2) - (pbEgg.Width / 2); // Center egg under chicken
                yEgg = yChicken + pbChicken.Height; // Reset egg to fall from chicken's position
                score++;
                lblScore.Text = score.ToString();

                CheckAndIncreaseSpeed(); // Check and increase the speed based on the score

                // Track eggs caught for bomb spawning
                eggsCaught++;
                if (eggsCaught >= 5 && !bombSpawned)
                {
                    SpawnBombAndHeart();
                    eggsCaught = 0; // Reset the counter after spawning bomb
                }
            }
            // If egg missed the basket
            else if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                xEggLastPosition = xEgg; // Store last x-position before reset
                if (lives > 0)
                {
                    //Remove a Heart (life)
                    lives--;
                    if (lives >= 0 && lives < hearts.Count)
                    {
                        this.Controls.Remove(hearts[lives]);
                        hearts.RemoveAt(lives);
                    }

                    // Play egg broken sound
                    eggBrokenSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\egg_break.mp3";
                    eggBrokenSound.controls.play();

                    // Reset egg position
                    xEgg = xChicken + (pbChicken.Width / 2) - (pbEgg.Width / 2);
                    yEgg = yChicken + pbChicken.Height;

                    // Check if no lives are left
                    if (lives == 0)
                    {
                        // Game over actions
                        GameOver();
                    }
                }
            }

            pbEgg.Location = new Point(xEgg, yEgg);
        }

        private void GameOver()
        {
            // Stop background music and play game over sound
            backgroundMusic.controls.stop();
            chickenSound.controls.stop();
            gameOverSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\game_over.mp3";
            gameOverSound.controls.play();

            pbEgg.Image = Image.FromFile("../../Images/egg_gold_broken.png");
            xEgg = xEggLastPosition; // Set xEgg to its last position
            yEgg = this.ClientSize.Height - pbEgg.Height;
            xDeltaBasket = 0;
            tmEgg.Stop();
            lblGameOver.Visible = true;
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
                    // Stop the Background Music! Play bomb explosion & game over sound
                    backgroundMusic.controls.stop();
                    chickenSound.controls.stop();
                    bombExplosionSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\bomb_explosion.mp3";
                    bombExplosionSound.controls.play();
                    gameOverSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\game_over.mp3";
                    gameOverSound.controls.play();

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

        void tmHeart_Tick(object sender, EventArgs e)
        {
            if (heartSpawned)
            {
                yEgg = -100;
                yHeart += yDeltaHeart;

                // Check for collision with the basket
                Rectangle heartRect = new Rectangle(xHeart, yHeart, pbHeart.Width, pbHeart.Height);
                Rectangle basketRect = new Rectangle(xBasket, yBasket, pbBasket.Width, pbBasket.Height);

                // If the bomb hits the basket
                if (heartRect.IntersectsWith(basketRect))
                {
                    eggCatchSound.URL = @"D:\C#\BuiHuuDanh_2122110119\Ex01\Sounds\egg_catch.mp3";
                    eggCatchSound.controls.play();
                    // Check if lives can be incremented without exceeding hearts collection size
                    // Add a life up to max lives
                    if (lives < maxLives)
                    {
                        lives++;
                        PictureBox newHeart = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(30, 30),
                            Location = new Point(10 + (lives - 1) * 35, 120),
                            BackColor = Color.Transparent,
                            Image = Image.FromFile("../../Images/heart.png")
                        };
                        hearts.Add(newHeart);
                        this.Controls.Add(newHeart);
                    }
                    // Reset heart state
                    heartSpawned = false;
                    pbHeart.Visible = false; // Hide the heart
                    yHeart = -100; // Move heart off-screen

                }
                else if (yHeart > this.ClientSize.Height) // If bomb goes off screen
                {
                    heartSpawned = false; // Reset heart state
                    pbHeart.Visible = false; // Hide the heart
                    yHeart = -100; // Reset heart position off-screen
                    xEgg = xChicken + (pbChicken.Width / 2) - (pbEgg.Width / 2); // Center egg under chicken
                    yEgg = yChicken + pbChicken.Height; // Set egg to fall from the bottom of chicken
                }

                pbHeart.Location = new Point(xHeart, yHeart);
            }
        }

        private Random random = new Random(); // Create a single Random instance

        private void SpawnBombAndHeart()
        {
            xBomb = random.Next(0, this.ClientSize.Width - pbBomb.Width); // Randomize the starting position of the bomb
            yBomb = 10; // Reset the bomb's vertical position to the top
            pbBomb.Visible = true; // Show the bomb
            bombSpawned = true; // Set bomb spawned state

            xHeart = random.Next(0, this.ClientSize.Width - pbHeart.Width); // Randomize the starting position of the heart
            yHeart = 10; // Reset the heart's vertical position to the top
            pbHeart.Visible = true; // Show the heart
            heartSpawned = true; // Set heart spawned state
        }

    }
}
