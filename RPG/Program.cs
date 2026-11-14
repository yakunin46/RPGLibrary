using System;
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
        static void Main()
        {
            Atlas.Set(" #$W?");

            Map map = new Map(30, 20);

            map.AddItem(new Item("Бочка"), 2, 2);
            map.AddItem(new Item("Камень"), 5, 8);
            map.AddItem(new Item("Бревно"), 22, 12);
            map.AddItem(new Item("Меч"), 13, 17);
            map.AddItem(new Item("Часы"), 24, 5);

            map.AddEnemy(new Enemy(5, 5, 100));
            map.AddEnemy(new Enemy(12, 10, 100));

            RPGEngine.SetMap(map);
            RPGEngine.SetPlayer(17, 3);

            RPGEngine.Run();
        }
    }
}
