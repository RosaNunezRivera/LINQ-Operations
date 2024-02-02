using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movies
    {
        public int MovieId {  get; set; }
        public string MovieName { get; set; }  
        public int ReleaseYear { get; set; }
        public int MovieLength { get; set; } // this length will be in minutes.

        public string CountryOfOrigin { get; set; }

    }

    internal class MovieAward
    {
        public int AwardId {  get; set; }
        public string AwardName { get; set;}
        public int MovieId { get; set; }
    }
}
