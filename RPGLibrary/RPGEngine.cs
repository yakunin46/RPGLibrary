using System;
using System.Collections.Generic;
using System.Text;

namespace RPGLibrary
{
    /// <summary>
    /// Игровой движок
    /// </summary>
    public static class RPGEngine
    {
        /// <summary>
        /// Экземпляр карты
        /// </summary>
        static Map map = new Map(2, 2);

        /// <summary>
        /// Экземпляр игрока
        /// </summary>
        public static Player player = new Player(1, 1);

        /// <summary>
        /// Меняет карту
        /// </summary>
        /// <param name="map"></param>
        public static void SetMap(Map map)
        {
            RPGEngine.map = map;
        }

        /// <summary>
        /// Меняет позицию игрока на карте
        /// </summary>
        /// <param name="x">Новое положение игрока по оси X</param>
        /// <param name="y">Новое положение игрока по оси Y</param>
        public static void SetPlayer(int x, int y)
        {
            player.x = x;
            player.y = y;
        }

        /// <summary>
        /// Проверяет нажатую клавишу
        /// </summary>
        /// <param name="inputKey">Информация о нажатой клавише</param>
        private static void CheckKey(ConsoleKeyInfo inputKey)
        {
            if (inputKey.KeyChar == '1' && player.x > 1)
                SetPlayer(player.x - 1, player.y);

            if (inputKey.KeyChar == '2' && player.x < map.width - 2)
                SetPlayer(player.x + 1, player.y);

            if (inputKey.KeyChar == '3' && player.y > 1)
                SetPlayer(player.x, player.y - 1);

            if (inputKey.KeyChar == '4' && player.y < map.height - 2)
                SetPlayer(player.x, player.y + 1);
        }

        /// <summary>
        /// Обрабатывает столкновение игрока с другими объектами или врагами
        /// </summary>
        private static void ProcessCollisions()
        {
            Item? item = map.GetItem(player.x, player.y);
            if (item != null)
            {
                player.AddItem(item);
                map.listOfItems.Remove(item);
            }

            Enemy? enemy = map.GetEnemy(player.x, player.y);
            if (enemy != null)
            {
                enemy.Attack(player.attack);
                if (enemy.hp <= 0)
                    map.listOfEnemies.Remove(enemy);
            }
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        public static void Run()
        {
            ConsoleKeyInfo inputKey;
            Console.Clear();
            Console.CursorVisible = false;

            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                map.Show();

                Console.SetCursorPosition(2 * player.x, player.y);
                Console.Write(Atlas.Get(Cell.PLAYER));

                ProcessCollisions();

                Console.SetCursorPosition(0, map.height);
                Console.Write("1.Влево\n2.Вправо\n3.Вверх\n4.Вниз\n>\n");
                player.PrintInventory();

                Console.SetCursorPosition(1, map.height + 4);
                inputKey = Console.ReadKey();
                CheckKey(inputKey);
            }
        }
    }
}