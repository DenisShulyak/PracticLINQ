using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLINQ
{
   public class MusicalGroup 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }

        public MusicalGroup()
        {
            Id = Guid.NewGuid();
        }
    }
}
