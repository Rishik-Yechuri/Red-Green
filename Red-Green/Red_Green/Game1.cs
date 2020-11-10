using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Red_Green
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D redSquare;
        Rectangle backgroundRectangle;
        Texture2D greenSquare;
        Rectangle greenRectangle;
        int stateOfLight = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            backgroundRectangle = new Rectangle(0,0,800,480);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            redSquare = Content.Load<Texture2D>("red");
            greenSquare = Content.Load<Texture2D>("green");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            MouseState mouse = Mouse.GetState();
            // TODO: Add your update logic here
            if (mouse.Y >= 0 && mouse.Y <= 480)
            {
                if (0 <= mouse.X && mouse.X <= 400)
                {
                    greenRectangle = new Rectangle(0,0, 400, 480);
                }
                else if (mouse.X > 400 && mouse.X <= 800)
                {
                    greenRectangle = new Rectangle(400,0,400,480);
                }
                else
                {
                    greenRectangle = new Rectangle(0,0,0,0);
                }
            }
            else {
                greenRectangle = new Rectangle(0, 0, 0, 0);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(redSquare,backgroundRectangle,Color.White);
            spriteBatch.Draw(greenSquare,greenRectangle,Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
