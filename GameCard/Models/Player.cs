using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCard.Models
{
    public class Player
    {
        public string Name { get; set; }    
        public int Id { get; set; }     
        public int Wallet { get; set; }        
        public int PlayersCount { get; set; }        
        
        public Player(int id , int playersCount )
        {
            Id = id;    
            PlayersCount = playersCount;
            Name = "Игрок" + id;
        
        }
    }
}
