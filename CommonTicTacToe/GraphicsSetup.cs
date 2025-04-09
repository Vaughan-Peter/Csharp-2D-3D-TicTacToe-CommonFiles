using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CommonTicTacToe
{
    public abstract class GraphicsSetup
    {
        protected static GraphicsDeviceManager graphicsManager;

        public static void Setup(GraphicsDeviceManager graphics)
        {
            graphicsManager = graphics;
        }
    }
}
