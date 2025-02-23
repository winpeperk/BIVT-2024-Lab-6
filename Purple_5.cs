using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            //конструктор
            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            //поля
            private string _animal;
            private string _characterTrait;
            private string _concept;

            //свойства
            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            //методы
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int counter = 0;

                foreach(var response in responses)
                {
                    switch(questionNumber)
                    {
                        case 1:
                            {
                                if (response.Animal != null) counter++;
                                break;
                            }
                        case 2:
                            {
                                if (response.CharacterTrait != null) counter++;
                                break;
                            }
                        case 3:
                            {
                                if (response.Concept != null) counter++;
                                break;
                            }
                    }
                }

                return counter;
            }
            public void Print()
            {
                Console.WriteLine($"{_animal} {_characterTrait} {_concept}");
            }
        }
        public struct Research
        {
            //конструктор
            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            //поля
            private string _name;
            private Response[] _responses;

            //свойства
            public string Name => _name;
            public Response[] Responses => _responses;

            //методы
            public void Add(string[] answers)
            {
                if (answers == null || _responses == null) return;

                Response newResponse = new Response(answers[0], answers[1], answers[2]);

                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = newResponse;
            }
            public string[] GetTopResponses(int question)
            {
                if(_responses == null) return null;

                string[] array = new string[0];
                string[] answers = new string[1];
                int[] counterAnswers = new int[1];

                switch(question)
                {
                    case 1:
                        {
                            for(int i = 0; i < _responses.Length; i++)
                            {
                                if(_responses[i].Animal != null)
                                {
                                    Array.Resize(ref array, array.Length + 1);
                                    array[array.Length - 1] = _responses[i].Animal;
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < _responses.Length; i++)
                            {
                                if (_responses[i].CharacterTrait != null)
                                {
                                    Array.Resize(ref array, array.Length + 1);
                                    array[array.Length - 1] = _responses[i].CharacterTrait;
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            for (int i = 0; i < _responses.Length; i++)
                            {
                                if (_responses[i].Concept != null)
                                {
                                    Array.Resize(ref array, array.Length + 1);
                                    array[array.Length - 1] = _responses[i].Concept;
                                }
                            }
                            break;
                        }
                    default: return null;
                }

                answers[0] = array[0];
                counterAnswers[0] = 1;

                for (int i = 1; i < array.Length; i++)
                {
                    bool flag = false;
                    int count = -1;

                    for (int j = 0; j < answers.Length; j++)
                    {
                        if (array[i] == answers[j])
                        {
                            flag = true;
                            count = j;
                            break;
                        }
                    }

                    if (flag)
                    {
                        counterAnswers[count]++;
                    }
                    else
                    {
                        Array.Resize(ref answers, answers.Length + 1);
                        Array.Resize(ref counterAnswers, counterAnswers.Length + 1);
                        answers[answers.Length - 1] = array[i];
                        counterAnswers[counterAnswers.Length - 1] = 1;
                    }
                }

                //сортируем
                for(int i = 1, j = 2; i < answers.Length; )
                {
                    if(i == 0 || counterAnswers[i - 1] >= counterAnswers[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (counterAnswers[i - 1], counterAnswers[i]) = (counterAnswers[i], counterAnswers[i - 1]);
                        (answers[i - 1], answers[i]) = (answers[i], answers[i - 1]);
                        i--;
                    }
                }

                Array.Resize(ref answers, 5);

                return answers;
            }
            public void Print()
            {
                foreach(var response in _responses)
                {
                    response.Print();
                }
            }
        }
    }
}
