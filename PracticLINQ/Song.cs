using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLINQ
{
   public class Song 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid MusicalGroupId { get; set; }
        public MusicalGroup MusicalGroup { get; set; } // Музыкальная группа

        public Guid DescriptionId { get; set; }
        public Description Description { get; set; }
        public Song()
        {
            Id = Guid.NewGuid();
        }
    }
}
