using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coef = new double[4];
                for (int i = 0; i < 4; i++) _coef[i] = 2.5;
                _marks = new int[4, 7];

                counterJump = 0;
            }

            //поля
            private string _name;
            private string _surname;
            private double[] _coef; 
            private int[,] _marks;

            private int counterJump; 

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => _coef;
            public int[,] Marks => _marks;
            public double TotalScore
            {
                get
                {
                    if (_marks == null || _coef == null) return 0;

                    double result = 0;
                    for(int jump = 0; jump < 4; jump++)
                    {
                        int iMax = 0, iMin = 0;
                        double score = 0;
                        for(int judge = 1; judge < 7; judge++)
                        {
                            if (_marks[jump, judge] > _marks[jump, iMax]) iMax = judge; 
                            if (_marks[jump, judge] < _marks[jump, iMin]) iMin = judge;
                        }
                        for(int judge = 0; judge < 7; judge++)
                        {
                            if(judge != iMax && judge != iMin) score += _marks[jump, judge];
                        }
                        score *= _coef[jump];
                        result += score;
                    }
                    return result;
                }
            }

            //методы
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || _coef == null) return;
                Array.Copy(coefs, _coef, 4);
            }
            public void Jump(int[] marks)
            {
                if (marks == null || counterJump >= 4 || _marks == null) return;
                for(int judge = 0; judge < 7; judge++)
                {
                    _marks[counterJump, judge] = marks[judge];
                }
                counterJump++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for(int i = 1, j = 2; i < array.Length; )
                {
                    if (i == 0 || array[i - 1].TotalScore >= array[i].TotalScore)
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
                Console.WriteLine($"{_name} {_surname} {TotalScore}");                
            }
        }
    }
}
