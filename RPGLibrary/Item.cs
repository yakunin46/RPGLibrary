using System;
using System.Collections.Generic;
using System.Text;

namespace RPGLibrary
{
    /// <summary>
    /// Игровой предмет
    /// </summary>
    public class Item
    {

        /// <summary>
        /// Название предмета
        /// </summary>
        string name;

        /// <summary>
        /// Положение предмета по оси абсцис
        /// </summary>
        public int x;

        /// <summary>
        /// Положение предмета по оси ординат
        /// </summary>
        public int y;

        /// <summary>
        /// Индекс в атласе
        /// </summary>
        public int atlasNumber;

        /// <summary>
        /// Создает предмет
        /// </summary>
        /// <param name="name">Имя предмета</param>
        public Item(string name, int x, int y, int atlasNumber)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.atlasNumber = atlasNumber;
        }

        /// <summary>
        /// Выводит название предмеета в консоль
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }
    }
}
