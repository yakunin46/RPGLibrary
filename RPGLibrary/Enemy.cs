using System;
using System.Collections.Generic;
using System.Text;

namespace RPGLibrary
{
    /// <summary>
    /// Враг
    /// </summary>
    public class Enemy
    {
        /// <summary>
        /// Положение врага по оси абсцис
        /// </summary>
        public int x;

        /// <summary>
        /// Положение врага по оси ординат
        /// </summary>
        public int y;

        /// <summary>
        /// Здоровье врага
        /// </summary>
        public int hp;

        /// <summary>
        /// Уровень атаки врага
        /// </summary>
        public int attack = 10;

        /// <summary>
        /// Уровень защиты врага
        /// </summary>
        public int defense = 50;

        public int atlasNumber;

        /// <summary>
        /// Создает врага
        /// </summary>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        public Enemy(int x, int y, int hp, int atlasNumber)
        {
            this.x = x;
            this.y = y;
            this.hp = hp;
            this.atlasNumber = atlasNumber;
        }

        /// <summary>
        /// Кто-то атакует врага
        /// </summary>
        /// <param name="attack">уровень атаки того, кто атакует</param>
        public void Attack(int attack)
        {
            hp -= attack - defense;
        }
    }
}