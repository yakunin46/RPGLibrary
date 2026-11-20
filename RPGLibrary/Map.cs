using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace RPGLibrary
{
    /// <summary>
    /// Игровая карта
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Ширина карты
        /// </summary>
        public int width;

        /// <summary>
        /// Высота карты
        /// </summary>
        public int height;

        /// <summary>
        /// Создает сетку карты
        /// </summary>
        public int[,] grid;

        /// <summary>
        /// Список предметов карты
        /// </summary>
        public List<Item> listOfItems;

        /// <summary>
        /// Список врагов карты
        /// </summary>
        public List<Enemy> listOfEnemies;

        /// <summary>
        /// Создает карту
        /// </summary>
        /// <param name="height">Высота мира</param>
        /// <param name="width">Ширина мира</param>
        public Map(int[,] matrix)
        {
            height = matrix.GetLength(0);
            width = matrix.GetLength(1);
            grid = matrix;

            listOfItems = new List<Item>();
            listOfEnemies = new List<Enemy>();
        }

        /// <summary>
        /// Устанавливает положение нового предмета на карте
        /// </summary>
        /// <param name="item"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddItem(Item item)
        {
            listOfItems.Add(item);
        }

        /// <summary>
        /// Добавляет врага на карту
        /// </summary>
        /// <param name="enemy">добавляемый враг</param>
        public void AddEnemy(Enemy enemy)
        {
            listOfEnemies.Add(enemy);
        }

        /// <summary>
        /// Проверяет коллизию игрока с предметами
        /// </summary>
        public Item? GetItem(int x, int y)
        {
            foreach (Item item in listOfItems)
                if (x == item.x && y == item.y)
                    return item;
            return null;
        }

        /// <summary>
        /// Проверяет коллизию игрока с врагами
        /// </summary>
        public Enemy? GetEnemy(int x, int y)
        {
            foreach (Enemy enemy in listOfEnemies)
                if (x == enemy.x && y == enemy.y)
                    return enemy;
            return null;
        }

        /// <summary>
        /// Отображает карту, врагов и предметы в консоль
        /// </summary>
        public void Show()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    Console.Write(Atlas.Get(grid[i, j]) + " ");
                Console.WriteLine();
            }

            foreach (Enemy enemy in listOfEnemies)
            {
                Console.SetCursorPosition(2 * enemy.x, enemy.y);
                Console.Write(Atlas.Get(enemy.atlasNumber));
            }

            foreach (Item item in listOfItems)
            {
                Console.SetCursorPosition(2 * item.x, item.y);
                Console.Write(Atlas.Get(item.atlasNumber));
            }
        }
    }
}