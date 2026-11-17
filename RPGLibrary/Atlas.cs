using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPGLibrary
{
    /// <summary>
    /// Набор символов из которых состоит мир
    /// </summary>
    public static class Atlas
    {
        /// <summary>
        /// Содержит строку символов в том же порядке что и Cell
        /// </summary>
        private static string strOfChars = "";

        /// <summary>
        /// Задает Атлас как последовательность символов
        /// </summary>
        /// <param name="str">Строка из символов в том же порядке что и Cell</param>
        public static void Set(string str)
        {
            strOfChars = str;
        }

        /// <summary>
        /// Получить символ по коду из Cell
        /// </summary>
        /// <param name="cell">Тип ячейки</param>
        /// <returns></returns>
        public static int Get(int atlasNumber)
        {
            return strOfChars[atlasNumber];
        }
    }
}