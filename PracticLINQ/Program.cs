using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создать приложение которе позволяет хранить, получать, создавать (добавлять) музыкальные группы, 
            их песни и описание этих песен (слова, время звучания, рейтинг). Дать пользователю консольное управление
            этим процессом, в том числе и поиском по группам, песням. Сортировку по рейтингу (обратную и прямую).
            */
           
                Console.WriteLine("1) Список групп");
            Console.WriteLine("2) Список песен");
            Console.WriteLine("3) Поиск песни по названию");
            Console.WriteLine("4) Добавить новую песню");
            /*
             * var marksWithT = (from mark
                                 in context.Marks
                                  where mark.Name.ToLower().Contains("t")
                                  orderby mark.Name
                                  ascending
                                  select mark).ToList();
             * */

            int choise = int.Parse(Console.ReadLine());
            if (choise == 1)
            {
                using (var context = new SongLoadContext())
                {
                    var listNameGroup = (from musicalGroup
                                        in context.MusicalGroups
                                         orderby musicalGroup.Name
                                         ascending
                                         select musicalGroup).ToList();
                    for (int i = 0; i < listNameGroup.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ")" + listNameGroup[i].Name);
                    }
                }

            }
            else if (choise == 2)
            {
                using (var context = new SongLoadContext())
                {
                
                    var listNameSong = (from song
                                        in context.Songs
                                        orderby song.Name
                                        ascending
                                        select song).ToList();
                    for (int i = 0; i < listNameSong.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ")" + listNameSong[i].Name);
                    }
                }

            }
            else if (choise == 3)
            {
                Console.WriteLine("Введите название песни: ");
                string nameSong = Console.ReadLine();
                using (var context = new SongLoadContext())
                {
                  
                    var findSong = (from song
                                        in context.Songs
                                        where song.Name.ToLower().Contains(nameSong)
                                        orderby song.Name
                                        ascending
                                        select song).ToList();
                    Console.WriteLine("Найдено:");
                    for(int i = 0;i< findSong.Count;i++)
                    {
                        Console.WriteLine(i +1+")"+ findSong[i].Name);
                    }
                    Console.WriteLine("Выберите песню:");
                    int choiseSong = int.Parse(Console.ReadLine());
                 

                    
                    for(int i = 0; i < findSong.Count;i++)
                    {

                        if (choiseSong == i + 1)
                        {
                            Console.WriteLine("Название песни: " + findSong[i].Name);
                            var groups = (from musicalGroup
                                  in context.MusicalGroups
                                         where musicalGroup.Id.Equals(findSong[i].Id)
                                         select musicalGroup).ToList();
                                          

                            Console.WriteLine("Название группы: " + groups[0].Name);
                            var descriptions = (from description
                                  in context.Descriptions
                                          where description.Id.Equals(findSong[i].Id)
                                          select description).ToList();
                            Console.WriteLine("Длительность пенси(секунд): " + descriptions[0].DurationSong);
                            Console.WriteLine("Рейтинг: " + descriptions[0].Rating);
                        }
                    }
                }

            }
            else if(choise == 4 )
            {
                using (var context = new SongLoadContext())
                {
                    Console.WriteLine("Введите название песни: ");
                    string nameSong = Console.ReadLine();

                    Console.WriteLine("Введите название группы: ");
                    MusicalGroup musicalGroup = new MusicalGroup()
                    {
                        Name = Console.ReadLine()
                    };
                    context.MusicalGroups.Add(musicalGroup);

                   // Console.WriteLine("Вставьте песню(ctrl + v): ");
                    List<string> textSong = CopyTextSong();
                    Console.WriteLine("Введите длительность в секундах: ");
                    int timeSong = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите рейтинг песни:(1-5)");
                    int rating = int.Parse(Console.ReadLine());

                    Description description = new Description
                    {
                        Text = textSong,
                        DurationSong = timeSong,
                        Rating = rating
                    };
                    context.Descriptions.Add(description);

                    context.Songs.Add(new Song { Name = nameSong, MusicalGroupId = musicalGroup.Id, DescriptionId = description.Id });
                    context.SaveChanges();
                    Console.WriteLine("Песня успешно добавлена!");
                    Console.ReadLine();
                }
            }

            

            /*
                using (var context = new SongLoadContext())
                {
                    MusicalGroup musicalGroup = new MusicalGroup
                    {
                        Name = "Imagine Dragons"
                    };
                Description description = new Description
                {
                    Text = CopyTextSong(),
                    DurationSong = 212,
                    Rating = 4
                    };
                Song song = new Song
                {
                    Name = "believer",
                    Description = description,
                    MusicalGroup = musicalGroup
                };


                context.MusicalGroups.Add(musicalGroup);
                context.Descriptions.Add(description);
                context.Songs.Add(song);


                context.SaveChanges();
                }*/

            
          

            Console.ReadLine();
        }
        public static void ShowTextSong(List<string> song)
        {
            for(int i = 0;i < song.Count;i++)
            {
                Console.WriteLine(song[i]);
            }
        }
        public static List<string> CopyTextSong()
        {
            List<string> song = new List<string>();
            Console.WriteLine("Вставте текст песни (после вставки напишите end): ");
            while (true)
            {
                song.Add(Console.ReadLine());
                if (song[song.Count() - 1] == " ")
                {
                    song.Remove(song[song.Count() - 1]);
                    break;
                }
            }


            return song;
        }
    }
}
