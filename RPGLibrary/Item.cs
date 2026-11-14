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
        /// Создает предмет
        /// </summary>
        /// <param name="name">Имя предмета</param>
        public Item(string name)
        {
            this.name = name;
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
