using GameCard.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameCard
{
    public class Engine
    {
        public List<Card> DeckCard = new List<Card>();//карты
        public List<Player> Players = new List<Player>();//игроки
        public Card trumCard;
        Random rnd = new Random();
        Card trump;
        public int tap;
        public void GenerakDeck()//генерирует и выводит список карт 
        {
            for (int i=0; i <4;i++)
            {
                for(int j=2; j <15; j++)
                {
                    var card = new Card(j,i);  
                    DeckCard.Add(card);
                    Console.WriteLine($"{card.Mast} = {j}");                 
                   
                }
            }          
            int trumpId = rnd.Next(DeckCard.Count);//рандомно выбирает козырь
            trump = DeckCard[trumpId];              
            Console.WriteLine(DeckCard[trumpId]);

        }
        public void Do()
        {
           
            if (DeckCard.Count == 0)//карты в колоде заканчиваются , выводится сообщение
            {
                Console.WriteLine("Карты все");                            
                for (int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine($"Кошелек игрока {i}: {Players[i].Wallet}");
                }
                Winner();
                return;                               
            }


            
           
            if (tap >= Players.Count)//обнуляет игроков до указанного значения
            {
                tap = 0;
            }
            
            
            int leave = rnd.Next(DeckCard.Count);//рандомно вытягивает карту          

            Console.WriteLine($"Игрок {tap} вытянул карту : " + DeckCard[leave]);
            
            Console.WriteLine($"карта : {leave}. количество : {DeckCard.Count}. Игроки : {Players.Count}. ход : {tap}");
            
            if (DeckCard[leave].Mast == trump.Mast)
            {
                Return(leave);                         
            }
            else
            {
                tap++;  
            }           
            DeckCard.Remove(DeckCard[leave]);
      
        }
        public void Return(int leave)//выводит значение кошелька игрока кто вытянул козырь
        {
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Wallet += DeckCard[leave].Cost;
            }
            Players[tap].Wallet -= DeckCard[leave].Cost;
            Console.WriteLine($"Кошелек игрока {tap}: {Players[tap].Wallet}");
            Console.WriteLine("Козырь");
        }
        public void Winner()
        {
            int[] walletScores = new int[Players.Count];
            for (int i = 0; i < Players.Count; i++)
            {
                walletScores[i] = Players[i].Wallet;
            }
            Array.Sort(walletScores);//сортирует массив кошельков по возрастанию
            Console.WriteLine($"Победил игрок {Players.Find(x => x.Wallet == walletScores.Last()).Id} со счетом {walletScores.Last()}");
        //выводит игрока с большим счетом (последний элемент массива по возрастанию)
        }
        public void Init(int playersCount)//запуск с консоли
        {
            Start(playersCount);
            GenerakDeck();        
            Try();
        }      
        private void Start(int playersCount)//создание игроков
        {           
            if (playersCount < 2 || playersCount > 4)
            {
                throw new Exception($"Недопустимое кол-во игроков: {playersCount}!");
            }
            for( int i = 0; i < playersCount; i++)
            {
                Players.Add(new Player(i, playersCount));
            }
            Console.WriteLine("Игроков в игре : " + playersCount);          
        } 
    
        public void Try()
        {
            while (true) 
            {
                Do();               
                Console.ReadLine(); 
            }
        
        }
    }
}
