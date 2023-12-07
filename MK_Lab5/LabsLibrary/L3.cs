using System.Collections.Generic;
using System.Linq;

namespace LabsLibrary
{
    public class L3Manager
    {
        private readonly char[][] _game;
        private readonly int _size;

        public L3Manager(char[][] game)
        {
            _game = game;
            _size = game.Length;
        }

        public string Run()
        {
            if (_size < 6 || _size > 19)
            {
                return "Out of range exception!";
            }
            else
            {
                return GetCountBlackGroupInAtari(_game).ToString();
            }
        }

        private int GetCountBlackGroupInAtari(char[][] game)
        {
            int result = 0;
            bool isBlackGroup = game.SelectMany(row => row).Any(ch => ch == 'B');
            while (isBlackGroup)
            {
                (int row, int col) groupPos = (0, 0);
                for (int i = 0; i < game.Length; i++)
                {
                    for (int j = 0; j < game.Length; j++)
                    {
                        if (game[i][j] == 'B')
                        {
                            groupPos = (i, j);
                            break;
                        }
                    }
                    if (groupPos != (0, 0))
                    {
                        break;
                    }
                }

                if (groupIsInAtari(groupPos, game))
                {
                    result++;
                }
                isBlackGroup = game.SelectMany(row => row).Any(ch => ch == 'B');
            }
            return result;
        }

        private static bool groupIsInAtari((int row, int col) groupPos, char[][] game)
        {
            //Перелік позицій усіх елементів групи
            List<(int row, int col)> groupPosList = getGroupPositions(groupPos, game);
            //Перелік позицій усіх даме групи
            List<(int row, int col)> damePosList = new List<(int row, int col)>();
            foreach (var pos in groupPosList)
            {
                damePosList.AddRange(getDamePosListAroundPos(pos, game));
            }
            damePosList = damePosList.Distinct().ToList();
            return damePosList.Count == 1;
        }

        private static List<(int row, int col)> getDamePosListAroundPos((int row, int col) pos, char[][] game)
        {
            List<(int row, int col)> result = new List<(int row, int col)>();
            if (pos.row != 0 && game[pos.row - 1][pos.col] == '.')
            {
                result.Add((pos.row - 1, pos.col));
            }
            if (pos.col != 0 && game[pos.row][pos.col - 1] == '.')
            {
                result.Add((pos.row, pos.col - 1));
            }
            if (pos.row != game.Length - 1 && game[pos.row + 1][pos.col] == '.')
            {
                result.Add((pos.row + 1, pos.col));
            }
            if (pos.col != game.Length - 1 && game[pos.row][pos.col + 1] == '.')
            {
                result.Add((pos.row, pos.col + 1));
            }
            return result;
        }

        private static List<(int row, int col)> getGroupPositions((int row, int col) groupPos, char[][] game)
        {
            fillGroupInGame(groupPos, game);
            List<(int row, int col)> result = new List<(int row, int col)>();
            for (int i = 0; i < game.Length; i++)
            {
                for (int j = 0; j < game.Length; j++)
                {
                    if (game[i][j] == 'G')
                    {
                        result.Add((i, j));
                        game[i][j] = 'D';
                    }
                }
            }
            return result;
        }

        private static void fillGroupInGame((int row, int col) pos, char[][] game)
        {
            game[pos.row][pos.col] = 'G';
            if (pos.row != 0 && game[pos.row - 1][pos.col] == 'B')
            {
                fillGroupInGame((pos.row - 1, pos.col), game);
            }
            if (pos.col != 0 && game[pos.row][pos.col - 1] == 'B')
            {
                fillGroupInGame((pos.row, pos.col - 1), game);
            }
            if (pos.row != game.Length - 1 && game[pos.row + 1][pos.col] == 'B')
            {
                fillGroupInGame((pos.row + 1, pos.col), game);
            }
            if (pos.col != game.Length - 1 && game[pos.row][pos.col + 1] == 'B')
            {
                fillGroupInGame((pos.row, pos.col + 1), game);
            }
        }
    }
}
