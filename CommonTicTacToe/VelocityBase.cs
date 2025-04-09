using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CommonTicTacToe
{

    public abstract class VelocityBase
    {
        protected Random random = new Random();

        // Abstract properties for velocity and rotational velocity
        public abstract Vector3 Vel { get; set; }
        public abstract Vector3 RotVel { get; set; }

        // Abstract method for setting velocity and rotational velocity
        public abstract void SetRND_Velocity();
    }
}