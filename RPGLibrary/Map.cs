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
        public Cell[,] grid;

        /// <summary>
        /// Список предметов мира
        /// </summary>
        public List<Item> listOfItems;

        /// <summary>
        /// Список врагов
        /// </summary>
        public List<Enemy> listOfEnemies;

        /// <summary>
        /// Создает карту
        /// </summary>
        /// <param name="height">Высота мира</param>
        /// <param name="width">Ширина мира</param>
        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new Cell[height, width];
            Create();

            listOfItems = new List<Item>();
            listOfEnemies = new List<Enemy>();
        }

        /// <summary>
        /// Заполняет границы карты как стенки
        /// </summary>        
        void Create()
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                        grid[i, j] = Cell.WALL;
                    else
                        grid[i, j] = Cell.EMPTY;
        }

        /// <summary>
        /// Устанавливает положение предмета на карте
        /// </summary>
        /// <param name="item"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddItem(Item item, int x, int y)
        {
            item.x = x;
            item.y = y;
            listOfItems.Add(item);
        }

        /// <summary>
        /// Добавляет врага на карту
        /// </summary>
        /// <param name="enemy"></param>
        public void AddEnemy(Enemy enemy)
        {
            listOfEnemies.Add(enemy);
        }

        /// <summary>
        /// Обрабатывает столкновение игрока с другими объектами или врагами
        /// </summary>
        public Item? GetItem(int x, int y)
        {
            foreach (Item item in listOfItems)
                if (x == item.x && y == item.y)
                    return item;
            return null;
        }

        public Enemy? GetEnemy(int x, int y)
        {
            foreach (Enemy enemy in listOfEnemies)
                if (x == enemy.x && y == enemy.y)
                    return enemy;
            return null;
        }

        /// <summary>
        /// Отображает карту, врагов и предметы в консоли
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
                Console.Write(Atlas.Get(Cell.ENEMY));
            }

            foreach (Item item in listOfItems)
            {
                Console.SetCursorPosition(2 * item.x, item.y);
                Console.Write(Atlas.Get(Cell.ITEM));
            }
        }
    }
}
