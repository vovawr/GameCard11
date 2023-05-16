using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCard
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            Console.WriteLine("Игра : Козырь\n Список команд:\n 1.Start\n 2.Stop\n 3.Rules");

            while (true) 
            {
                string userCommands;
                userCommands = (Convert.ToString(Console.ReadLine())).ToLower();

                switch(userCommands) 
                {
                    case "s":
                        Console.WriteLine("Введите количество игроков");
                        //try
                        //{
                        //   
                        //}
                        //catch (Exception ex) 
                        //{
                        //    Console.WriteLine($"{ex.Message}");
                        //}
                        engine.Init(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "stop":
                        Console.WriteLine("Игра на паузе");
                        break;
                    case "rules":
                        Console.WriteLine("1.Выбирается козырь из калоды карт\n2.Если игроку попадается не козырная карта , ход переходит к другому игроку ");
                        Console.WriteLine("3.Если карта козырная игрок выплачивает другим игрокам стиомость данной карты");
                        Console.WriteLine("4.Побеждает игрок получивший больше всех очков");    
                        break;
                    default: Console.WriteLine("Неизвестная команда"); 
                        break;   
                }
            
            }
        
        
        
        }   
    }
}
