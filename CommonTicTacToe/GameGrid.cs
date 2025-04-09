using System;

namespace CommonTicTacToe
{
    public class GameGrid
    {
        public enum GridVal { X, O, Center, Dot }

        private GridVal[,] grid = new GridVal[3, 3];
        private bool[,] selection = new bool[3, 3];

        public GameGrid()
        {
            Reset();
        }

        public void ToggleCell(int x, int y)
        {
            int next = ((int)grid[x, y] + 1) % Enum.GetValues(typeof(GridVal)).Length;
            grid[x, y] = (GridVal)next;
        }

        public GridVal GetWinner()
        {
            foreach (var player in new[] { GridVal.X, GridVal.O })
            {
                for (int i = 0; i < 3; i++)
                {
                    if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                        return player;
                    if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                        return player;
                }
                if (grid[0, 0] == player && grid[1, 1] == player && grid[2, 2] == player)
                    return player;
                if (grid[2, 0] == player && grid[1, 1] == player && grid[0, 2] == player)
                    return player;
            }
            return GridVal.Dot;
        }

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = GridVal.Dot;
                    selection[i, j] = false;
                }
        }

        public GridVal this[int x, int y] => grid[x, y];
        public void SetValue(int x, int y, GridVal value) => grid[x, y] = value;
        public void SetSelected(int x, int y, bool value) => selection[x, y] = value;
        public bool IsSelected(int x, int y) => selection[x, y];
    }
}
