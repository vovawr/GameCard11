using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCard.Models
{
    public class Card
    {
        public int Id { get; set; } //номера карт : 2 3 4 5 6 7 8 9 10 11(Валет) 12(Дама) 13(король) 14(Туз)
        public char Mast { get; set; }  //пики (n) черви(w) трефы(t) бубны(b)     
        public int Cost { get; set; } //Стоимость в очках: от 2-10(1 очко) 11(2) 12(3) 13(4) 14(11)
     
        public override string ToString()
        {
            return $"Номер карты: {Id} , Стоимость: {Cost} , Масть карты : {Mast}";
        }

        public Card(int id, int mastName )
        {
            Id = id;
            Cost = Id;
           
            switch(mastName) 
            {
                    case 0:
                    Mast = 'n'; break; 
                    case 1:
                    Mast = 'w'; break;  
                    case 2:
                    Mast = 't'; break;  
                    case 3:
                    Mast = 'b';
                    break;             
            }
            

        }

    }


}
