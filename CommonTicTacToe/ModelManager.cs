using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace CommonTicTacToe
{
    public class ModelManager
    {
        private Dictionary<GameGrid.GridVal, myModel> models = new();

        public void Load(ContentManager content, GraphicsDeviceManager graphics)
        {
            myModel.setupGraphics(graphics);
            models[GameGrid.GridVal.Center] = new myModel(content.Load<Model>("Models/Z"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            models[GameGrid.GridVal.X] = new myModel(content.Load<Model>("Models/X"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            models[GameGrid.GridVal.O] = new myModel(content.Load<Model>("Models/O"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            try
            {
                models[GameGrid.GridVal.Dot] = new myModel(content.Load<Model>("Models/dot"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            }
            catch (ContentLoadException e)
            {
                Debug.WriteLine("Warning: Could not load 'Models/dot'. " + e.Message);
                models[GameGrid.GridVal.Dot] = models[GameGrid.GridVal.X]; // fallback
            }
        }

        public void DrawCell(GameGrid.GridVal val, Vector3 position, bool isSelected, bool isWinner,
                             Vector3 cameraPosition, float aspectRatio, Vector3 target, Vector3 upDirection)
        {
            myModel model = models[val];
            model.pos = position;

            // Default color
            model.color = Color.PaleGreen;

            // Assign color based on value
            if (val == GameGrid.GridVal.X) model.color = Color.BlueViolet;
            if (val == GameGrid.GridVal.O) model.color = Color.DarkOrange;
            if (isSelected) model.color = Color.Red;

            model.draw(cameraPosition, aspectRatio, target, upDirection, isWinner);
        }
    }
}