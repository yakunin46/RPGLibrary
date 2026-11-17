using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RPGLibrary
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Положение игрока по оси абсцис
        /// </summary>
        public int x;

        /// <summary>
        /// Положение игрока по оси ординат
        /// </summary>
        public int y;

        public int atlasNumber = 2;

        /// <summary>
        /// Здоровье игрока
        /// </summary>
        public int hp = 100;

        /// <summary>
        /// Уровень атаки игрока
        /// </summary>
        public int attack = 100;

        /// <summary>
        /// Уровень защиты игрока
        /// </summary>
        public int defense = 50;

        /// <summary>
        /// Инвентарь игрока
        /// </summary>
        List<Item> inventory;

        /// <summary>
        /// Создает игрока
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
            inventory = new List<Item>();
        }

        /// <summary>
        /// Добавляет предмет в инвентарь игрока
        /// </summary>
        /// <param name="item">добавляемый предмет</param>
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        /// <summary>
        /// Выводит инвентарь игрока в консоль
        /// </summary>
        public void PrintInventory()
        {
            Console.WriteLine("Инвентарь игрока: ");
            foreach (Item item in inventory)
            {
                Console.WriteLine(item.GetName());
            }
        }
    }
}