using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                _distance = 0;
            }

            //поля
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks => _marks;
            public int Result
            {
                get
                {
                    if (_marks == null || _distance == 0) return 0;

                    int result = _marks.Sum() - _marks.Max() - _marks.Min() + 60 + (_distance - 120) * 2;

                    if (result < 0) return 0;

                    return result;
                }
            }

            //методы
            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                if (marks != null && marks.Length == 5) Array.Copy(marks, _marks, 5);
            }
            public static void Sort(Participant[] array)
            {
                if(array == null) return;

                for(int i = 1, j = 2; i < array.Length; )
                {
                    if(i == 0 || array[i - 1].Result >= array[i].Result)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (array[i - 1], array[i]) = (array[i], array[i - 1]);
                        i--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {Result}");
            }
        }
    }
}
