using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CommonTicTacToe
{
    public abstract class otherModel
    {

        // Abstract method for drawing the model, must be implemented by derived classes
        public abstract void Draw(Vector3 cameraPosition, float aspectRatio, Vector3 cameraTarget, Vector3 cameraUpDirection, bool won = false);

    }

}