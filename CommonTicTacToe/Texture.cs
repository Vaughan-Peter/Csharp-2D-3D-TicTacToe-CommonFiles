using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CommonTicTacToe
{
    public abstract class Texture
    {
        // Abstract method: Derived classes must implement it
        public abstract Texture2D CreateTexture(int width, int height, Color paint);
    }
}