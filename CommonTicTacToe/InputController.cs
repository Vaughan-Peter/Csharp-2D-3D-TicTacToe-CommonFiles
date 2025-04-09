using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CommonTicTacToe
{
    public class InputController
    {
        public int[] Current { get; private set; } = new int[2];
        private Dictionary<Keys, bool> lastKeyStates = new();

        public void UpdateKeyboardState(KeyboardState k)
        {
            HandleKey(k, Keys.Up, () => Current[1] = (Current[1] + 1) % 3);
            HandleKey(k, Keys.Right, () => Current[0] = (Current[0] + 1) % 3);
        }

        public bool WasKeyPressed(KeyboardState k, Keys key)
        {
            bool wasPressed = !lastKeyStates.ContainsKey(key) || !lastKeyStates[key];
            bool isNowPressed = k.IsKeyDown(key);
            lastKeyStates[key] = isNowPressed;
            return isNowPressed && wasPressed;
        }

        private void HandleKey(KeyboardState k, Keys key, System.Action action)
        {
            if (WasKeyPressed(k, key))
                action();
        }
    }
}