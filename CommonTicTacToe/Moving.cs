using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CommonTicTacToe
{
    public abstract class Moving
    {
        // Define properties for position, velocity, and rotation - Not used
        protected Vector3 pos;      // Position (3D)
        protected Vector3 vel;      // Velocity (3D)
        protected Vector3 rot;      // Rotation (3D)
        protected Vector3 rot_vel;  // Rotation velocity (3D)

        // Abstract method: Derived classes must implement the Move logic
        public abstract void Move();

    }
}