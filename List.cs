using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab4
{
    internal class ListClass
    {
        public static List<int> RemoveValue(List<int> list, int val)
        {
            if (!CheckValInList(list, val)) {
                Console.WriteLine("Такого числа нет!");
                return list;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == val)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }

        public static List<int> ReverseValue(List<int> list, int E)
        {
            int index1 = -1;
            int index2 = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == E)
                {
                    if (index1 == -1)
                    {
                        index1 = i;
                    }
                    index2 = i;
                }
            }
            if (index1 == -1)
            {
                Console.WriteLine("Элемент не найден");
            }
            if (index1 == index2)
            {
                Console.WriteLine("Найден только один элемент");
            }
            list.Reverse(index1 + 1, index2 - index1 - 1);
            return list;
        }

        private static bool CheckValInList(List<int> list, int val)
        {
            return list.Contains(val);
        }

        public static (HashSet<string> all, HashSet<string> some, HashSet<string> none) ViewersFilms(HashSet<string> films, List<HashSet<string>> viewers)
        {
            var viewersAll = new HashSet<string>(films);
            foreach (var viewer in viewers)
            {
                viewersAll.IntersectWith(viewer);
            }

            var viewersSome = new HashSet<string>();
            foreach (var viewer in viewers)
            {
                foreach (var film in viewer)
                {
                    viewersSome.Add(film);
                }
            }

            var viewersNone = new HashSet<string>();
            foreach (var film in films)
            {
                if (!viewersSome.Contains(film))
                {
                    viewersNone.Add(film);
                }
            }

            return (all: viewersAll, some: viewersSome, none: viewersNone);
        }   

        private static readonly HashSet<char> voicedConsonants = new HashSet<char>
        {
          'б', 'в', 'г', 'д', 'ж', 'з', 'л', 'м', 'н', 'р', 'й'
        };

        public static HashSet<char> consonantsInText()
        {
            var result = new HashSet<char>();
            try
            {
                using (StreamReader reader = new StreamReader("RusText.txt", Encoding.UTF8))
                {
                    string text = reader.ReadToEnd().ToLower();
                    var SeenConstans = new HashSet<char>();
                    var CurrentWord = new HashSet<char>();
                    var consResult = new HashSet<char>();

                    foreach (char c in text)
                    {
                        if (char.IsLetter(c))
                        {
                            if (voicedConsonants.Contains(c))
                            {
                                CurrentWord.Add(c);
                            }
                        }
                        else if (CurrentWord.Count > 0)
                        {
                            foreach (char cons in CurrentWord)
                            {
                                if (SeenConstans.Contains(cons))
                                {
                                    consResult.Add(cons);
                                }
                                else
                                {
                                    SeenConstans.Add(cons);
                                }
                            }
                            CurrentWord.Clear();
                        }
                    }
                    if (CurrentWord.Count > 0)
                    {
                        foreach (char cons in CurrentWord)
                        {
                            if (SeenConstans.Contains(cons))
                            {
                                consResult.Add(cons);
                            }
                            else
                            {
                                SeenConstans.Add(cons);
                            }
                        }
                    }
                    result = new HashSet<char>(consResult.OrderBy(c => c));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл RusText.txt не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            return result;
        }
    
        public static double companyEmployees()
        {
            if (!File.Exists("Employees.txt"))
            {
                Console.WriteLine("Файл не найден");
                return 0;
            }

            string[] employees = File.ReadAllLines("Employees.txt");

            if (employees.Length == 0)
            {
                Console.WriteLine("Файл пуст");
                return 0;
            }

            Dictionary<string, int> CountEmp = new Dictionary<string, int>();

            foreach (string st in employees)
            {
                string phone = "";
                foreach (char s in st)
                {
                    if (s != ' ' && s != '/')
                    {
                        if (char.IsDigit(s))
                        {
                            phone += s;
                        }
                    }
                }
                if (phone.Length >= 2)
                {
                    string subdivision = phone.Substring(phone.Length - 2, 2);

                    if (CountEmp.ContainsKey(subdivision))
                        CountEmp[subdivision]++;
                    else
                        CountEmp[subdivision] = 1;
                }
            }
            if (CountEmp.Count == 0)
            {
                return 0;
            }
            double sum = 0;
            foreach (int count in CountEmp.Values)
                sum += count;

            return sum / CountEmp.Count;
        }
    }
}
