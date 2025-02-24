using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            //конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
            }
            //поля
            private string _name;
            private string _surname;
            private double _time;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            //методы
            public void Run(double time)
            {
                if (_time == 0) _time = time; 
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_time}");
            }
        }
        public struct Group
        {
            //конструкторы
            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name = group.Name;
                if (group.Sportsmen != null)
                    _sportsmen = group.Sportsmen;
                else
                    _sportsmen = null;
            }

            //поля
            private string _name;
            private Sportsman[] _sportsmen;

            //свойства
            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            //методы
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;

                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null || _sportsmen == null) return;

                int before = _sportsmen.Length;
                Array.Resize(ref _sportsmen, before + sportsmen.Length);
                for(int i = 0; i < sportsmen.Length; i++)
                {
                    _sportsmen[before + i] = sportsmen[i];
                }
            }
            public void Add(Group group)
            {
                if(group.Sportsmen == null || _sportsmen == null) return;

                int before = _sportsmen.Length;
                Array.Resize(ref _sportsmen, before + group.Sportsmen.Length);
                for (int i = 0; i < group.Sportsmen.Length; i++)
                {
                    _sportsmen[before + i] = group.Sportsmen[i];
                }
            }
            public void Sort()
            {
                if (_sportsmen == null) return;

                for(int i = 1, j = 2; i < _sportsmen.Length; )
                {
                    if(i == 0 || _sportsmen[i - 1].Time <= _sportsmen[i].Time)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (_sportsmen[i - 1], _sportsmen[i]) = (_sportsmen[i], _sportsmen[i - 1]);
                        i--;
                    }
                }
            }
            public static Group Merge(Group group1, Group group2)
            {
                Group mergeredGroup = new Group("Финалисты");

                if(group1.Sportsmen == null || group2.Sportsmen == null) return mergeredGroup;

                int i = 0, j = 0;

                while(i < group1.Sportsmen.Length && j < group2.Sportsmen.Length)
                {
                    if (group1.Sportsmen[i].Time <= group2.Sportsmen[j].Time)
                    {
                        mergeredGroup.Add(group1.Sportsmen[i++]);
                    }
                    else
                    {
                        mergeredGroup.Add(group2.Sportsmen[j++]);
                    }
                }
                while(i < group1.Sportsmen.Length)
                {
                    mergeredGroup.Add(group1.Sportsmen[i++]);
                }
                while(j < group2.Sportsmen.Length)
                {
                    mergeredGroup.Add(group2.Sportsmen[j++]);
                }

                return mergeredGroup;
            }
            public void Print()
            {
                Console.WriteLine(_name);
                foreach (var sportsman in _sportsmen)
                {
                    sportsman.Print();
                }
            }
        }
    }
}
