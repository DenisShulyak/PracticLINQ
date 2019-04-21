using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLINQ
{
   public  class Description
    {
        public Guid Id { get; set; }

        public List<string> Text { get; set; }
        public int DurationSong { get; set; } //В секундах
        public int Rating { get; set; }
        public ICollection<Song> Songs { get; set; }
        public Description()
        {
            Id = Guid.NewGuid();
        }
    }
}
