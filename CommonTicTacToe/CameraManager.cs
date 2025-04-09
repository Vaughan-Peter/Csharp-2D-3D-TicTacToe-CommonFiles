using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CommonTicTacToe
{
    public class CameraManager
    {
        public Vector3 Position { get; private set; } = new Vector3(0.0f, 350.0f, 350.0f);
        public Vector3 Target { get; private set; } = Vector3.Zero;
        public Vector3 UpDirection { get; private set; } = Vector3.Up;

        public void UpdateFromKeyboard(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.D1))
                Position = new Vector3(0.0f, 350.0f, 350.0f);
            if (k.IsKeyDown(Keys.D2))
                Position = new Vector3(50.0f, 450.0f, 450.0f);
            if (k.IsKeyDown(Keys.D3))
                Position = new Vector3(100.0f, 250.0f, 250.0f);
            if (k.IsKeyDown(Keys.D4))
                Position = new Vector3(0.0f, -350.0f, 250.0f);
        }

        public void SetPosition(Vector3 newPosition) => Position = newPosition;
    }
}