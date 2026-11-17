using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RPGLibrary;

namespace RPG
{
    /// <summary>
    /// Задание: 
    /// В RPGEngine map не должен быть public.
    /// Мы создаем его в Main, туда все добавляем,
    /// а потом делаем один раз SetMap().
    /// </summary>
    class Program
    {
        /// <summary>
        /// Тип ячейки мира
        /// </summary>
        public enum Cell
        {
            /// <summary>
            /// Пустая ячейка
            /// </summary>
            EMPTY,

            /// <summary>
            /// Стена
            /// </summary>
            WALL,

            /// <summary>
            /// Игрок
            /// </summary>
            PLAYER,

            /// <summary>
            /// Враг
            /// </summary>
            ENEMY,

            /// <summary>
            /// Предмет
            /// </summary>
            ITEM
        }

        static Cell[,] GenerateMatrix(int width, int height)
        {
            Cell[,] cellMatrix = new Cell[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    cellMatrix[i, j] = Cell.WALL;

            for (int i = 1; i < 5; i++)
                for (int j = 1; j < 5; j++)
                    cellMatrix[i, j] = Cell.EMPTY;

            for (int i = 6; i < 9; i++)
                for (int j = 5; j < 8; j++)
                    cellMatrix[i, j] = Cell.EMPTY;

            return cellMatrix;
        }

        static int[,] ConvertToNumbers(Cell[,] cellMatrix)
        {
            int height = cellMatrix.GetLength(0);
            int width = cellMatrix.GetLength(1);
            int[,] intMatrix = new int[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    intMatrix[i, j] = (int)cellMatrix[i, j];

            return intMatrix;
        }

        static void Main()
        {
            Atlas.Set(" #$W?");

            Cell[,] cellMatrix = GenerateMatrix(10, 15);
            int[,] matrix = ConvertToNumbers(cellMatrix);

            Map map = new Map(matrix);

            map.AddItem(new Item("Бревно", 1, 4, 4));
            map.AddItem(new Item("Бочка", 3, 3, 4));
            map.AddItem(new Item("Камень", 4, 3, 4));
            map.AddItem(new Item("Меч", 3, 4, 4));
            map.AddItem(new Item("Часы", 4, 4, 4));

            map.AddEnemy(new Enemy(5, 8, 100, 3));
            map.AddEnemy(new Enemy(7, 6, 100, 3));

            RPGEngine.SetMap(map);
            RPGEngine.SetPlayer(1, 1);

            RPGEngine.Run();
        }
    }
}
