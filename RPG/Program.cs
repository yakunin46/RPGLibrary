using System;
using RPGLibrary;

namespace RPG
{
    /// <summary>
    /// Задание: 
    /// - класс RPGEngine пусть будет статическим, все public методы статические
    /// - списки предметов и врагов перенеси в Map
    /// (по смыслу они относятся к карте, а не к движку)
    /// - вместо RPGEngine.ShowMap будет Map.Show,
    /// перенеси туда всю отрисовку кроме игрока
    /// - чтобы обрабатывать коллизии лучше сделать методы Map.GetItem(x, y),
    /// Map.GetEnemy(x, y), которые возвращают соответствено предмет и врага в координатах.
    /// Если нет в этой ячейке, то они возвращают null
    /// - AddItem, AddEnemy тоже переносим в Map
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
