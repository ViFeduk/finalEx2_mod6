namespace finalEx2_mod6
{
    internal class Program
    {
        public delegate void ChildSortedDelegate(Children[] children);
        public static event ChildSortedDelegate SortedSurename;
        static void Main(string[] args)
        {

            var childrens = Children.Childrens();
            SortedSurename += FinalyChildSort;
            SortedSurename?.Invoke(childrens);
        }

       

        static void FinalyChildSort(Children[] children)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"\nВведите число 1- сортировать по алфавиту или 2- против алфавита");
                    int choose = Convert.ToInt32(Console.ReadLine());
                    if (choose != 1 && choose != 2)
                    {
                        throw new Exception();
                    }
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("Отсоритрованный массив: ");
                            foreach (Children ch in ChildSortAZ(children))
                            {
                                Console.WriteLine($"{ch.SureName}, ");
                            }
                            break;


                        case 2:
                            Console.WriteLine("Отсоритрованный массив: ");
                            foreach (Children ch in ChildSortZA(children))
                            {
                                Console.WriteLine($"{ch.SureName}, ");
                            }
                            break;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Значение введено некооректно\n");
                }
            }
            
            
            
        }
          static Children[] ChildSortZA(Children[] children)
          {
            Children[] arr = children;
            arr = arr.OrderByDescending(child => child.SureName).ToArray();
            return arr;
        }
          static Children[] ChildSortAZ(Children[] children)
          {
            Children[] arr = children;
            arr = arr.OrderBy(child => child.SureName).ToArray();
            return arr;
          }
        

        public class Children
        {
            public string SureName { get; private set; }
            public Children(string surename)
            {
                SureName = surename;
            }
           public static Children[] Childrens()
            {
                Children[] childrens =
                {
                new Children("Абулафия"),
                new Children ("Федченков"),
                new Children("Гагарин"),
                new Children("Бабуркин"),
                new Children ("Труневы")
                };
                return childrens;
            }
        }
    }
}
