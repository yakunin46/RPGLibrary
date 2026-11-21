using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RPGLibrary
{
    /// <summary>
    /// Графика
    /// </summary>
    internal static class Graphics
    {
        /// <summary>
        /// Форма
        /// </summary>
        public static Form window = null!;

        /// <summary>
        /// Инициализация графики (создание окна)
        /// </summary>
        public static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new Form();
        }

        /// <summary>
        /// Запускает цикл обработки событий
        /// </summary>
        public static void Run()
        {
            Application.Run(window);
        }

    }
}
