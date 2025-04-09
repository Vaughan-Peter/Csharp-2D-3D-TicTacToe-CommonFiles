using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using CommonTicTacToe;

namespace _3D_TicTacToe
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private CameraManager camera;
        private GameGrid grid;
        private InputController input;
        private ModelManager models;

        private float aspectRatio;
        private bool lastTimeWasNotSpace = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            camera = new CameraManager();
            camera.SetPosition(new Vector3(-200.0f, 450.0f, 450.0f));
            grid = new GameGrid();
            input = new InputController();
            models = new ModelManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Debug.WriteLine("3D_TicTacToe LoadContent");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            models.Load(Content, _graphics);

            aspectRatio = (float)_graphics.GraphicsDevice.Viewport.Width /
                            (float)_graphics.GraphicsDevice.Viewport.Height;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyboard = Keyboard.GetState();
            camera.UpdateFromKeyboard(keyboard);
            input.UpdateKeyboardState(keyboard);

            if (input.WasKeyPressed(keyboard, Keys.Space))
            {
                int x = input.Current[0];
                int y = input.Current[1];
                Debug.WriteLine($" current[0]={x} current[1]={y}");
                grid.ToggleCell(x, y);
                grid.SetSelected(x, y, !grid.IsSelected(x, y));
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            var WhoWon = grid.GetWinner();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var pos = new Vector3(i * 100 - 50.0f, j * 100 - 50.0f, 0.0f);
                    var val = grid[i, j];
                    bool selected = input.Current[0] == i && input.Current[1] == j;
                    bool won = val != GameGrid.GridVal.Dot && WhoWon == val;

                    models.DrawCell(val, pos, selected, won, camera.Position, aspectRatio, camera.Target, camera.UpDirection);
                }
            }

            base.Draw(gameTime);
        }
    }
}
