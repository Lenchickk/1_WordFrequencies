using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordFrequencies
{
    class Counter
    {
        static public void countWordsInFile(string file, Dictionary<string, int> words)
        {
            var content = File.ReadAllText(file);

            var wordPattern = new Regex(@"\w+");

            foreach (Match match in wordPattern.Matches(content))
            {
                String str = match.Value;
                if (Char.IsLower(str, 0)) continue;
                if (Char.IsNumber(str, 0)) continue;
                if (str == "Под" || str == "Как" || str == "По" || str == "Ранее" || str == "Ru" || str == "Об" || str == "Согласно"
                                    || str == "Сейчас" || str == "Всего" || str == "Однако" || str == "Кроме" || str == "Мы" || str == "Он" || str == "Над" || str == "На") continue;
                if (str.Length < 2) continue;
                if (!words.ContainsKey(match.Value))
                    words.Add(match.Value, 1);
                else
                    words[match.Value]++;
            }
        }

        static public bool IsEnglish(string inputstring)
        {
            Regex regex = new Regex(@"[A-Za-z0-9 .,-=+(){}\[\]\\]");
            MatchCollection matches = regex.Matches(inputstring);

            if (matches.Count.Equals(inputstring.Length))
                return true;
            else
                return false;
        }

        static public void countWordsInText(string content, Dictionary<string, int> words)
        {
            var wordPattern = new Regex(@"\w+");

            foreach (Match match in wordPattern.Matches(content))
            {
                String str = match.Value;
                if (IsEnglish(str)) continue;
                if (Char.IsLower(str, 0)) continue;
                if (Char.IsNumber(str, 0)) continue;

                /*
                 * if (str == "Под" || str == "Как" || str == "По" || str == "Ранее" || str == "Ru" || str == "Об" || str == "Согласно"
                                    || str == "Сейчас" || str == "Всего" || str == "Однако" || str == "Кроме" || str == "Taкже" || str == "Мы" || str == "Он" || str == "Над" || str == "На"
                                      || str == "Это" || str == "Тоже" || str == "Меня" || str == "Для" || str=="Вести" || str=="AdFox" || str=="Новые" || str=="РФ" || str=="Новые"
                                      || str=="Планшет" || str=="Мобильный" || str == "Старт" ||  str=="Adv" || str=="START" || str=="Площадка" || str=="Видео" || str=="ДТП"
                                       || str == "Toolkit" || str == "AdFoxBanner" || str == "END" || str == "Из" || str == "Категория" || str == "Тип" || str == "Apple" || str == "Google"
                                         || str == "Глава" || str == "Рубль" || str == "Пожар" || str == "Евро" || str == "За" || str == "СМИ" || str == "Футбол" || str == "Глава"
                                          || str == "Доллар" || str == "Кубок" || str == "Президент" || str == "При" || str == "Mercedes" || str == "BMW" || str == "Ferrari" || str == "Реплика"
                                          || str == "Власти" || str == "Lada" || str == "ВВП" || str == "Гран" || str == "Android" || str == "Microsoft" || str == "Число" || str == "Новый"
                                          || str == "ЦБ" || str == "МИД" || str == "Новый" || str == "Тренер" || str == "Премьер" || str == "Нью" || str == "Взрыв" || str == "Победы" || str == "Победа"
                                            || str == "Toyota" || str == "Формула" || str == "Минобороны" || str == "МЧС" || str == "Volkswagen" || str == "Кубка" || str == "Российские"
                                             || str == "Хоккей" || str == "Суд" || str == "Samsung" || str == "Facebook" || str == "Алексей" || str == "Сергей" || str == "Владимир"
                                              || str == "Алексей" || str=="Александр" || str=="Правительство" || str=="Госдума"|| str=="Формулы" || str== "Минфин" || str=="Ford" || str=="Renault"
                                              || str =="Дмитрий"
                                            || str == "Чемпионат" || str == "День" || str == "Прибыль" || str == "Формула" || str == "Audi" || str == "Nissan" || str == "Во" || str == "Сборная"
                                               || str == "Торги" || str == "Биатлон" || str == "Прибыль" || str == "Полиция" || str == "Экс" || str == "Нефть" || str == "Почему" || str == "ФИФА"
                                               || str=="СК" || str =="Рост" || str=="Мужчины"|| str=="Женщины"
                                           || str == "Скандал" || str == "Выборы") continue;
                                            
                */
                if (str.Contains("Украин"))
                {
                    if (!words.ContainsKey("Украина"))
                        words.Add("Украина", 1);
                    else
                        words["Украина"]++;
                    continue;
                }

                if (str.Contains("Сири"))
                {
                    if (!words.ContainsKey("Сирия"))
                        words.Add("Сирия", 1);
                    else
                        words["Сирия"]++;
                    continue;
                }

                if (str.Contains("Крым"))
                {
                    if (!words.ContainsKey("Крым"))
                        words.Add("Крым", 1);
                    else
                        words["Крым"]++;
                    continue;
                }

                if (str.Contains("Турци"))
                {
                    if (!words.ContainsKey("Турция"))
                        words.Add("Турция", 1);
                    else
                        words["Турция"]++;
                    continue;
                }

                if (str.Contains("Европ"))
                {
                    if (!words.ContainsKey("Европа"))
                        words.Add("Европа", 1);
                    else
                        words["Европа"]++;
                    continue;
                }
                if (str.Contains("Сири"))
                {
                    if (!words.ContainsKey("Сирия"))
                        words.Add("Сирия", 1);
                    else
                        words["Сирия"]++;
                    continue;
                }
                if (str.Contains("ИГ"))
                {
                    if (!words.ContainsKey("ИГИЛ"))
                        words.Add("ИГИЛ", 1);
                    else
                        words["ИГИЛ"]++;
                    continue;
                }

                if (str.Contains("РФ"))
                {
                    if (!words.ContainsKey("Россия"))
                        words.Add("Россия", 1);
                    else
                        words["Россия"]++;
                    continue;
                }
                if (str.Contains("Донбасс"))
                {
                    if (!words.ContainsKey("Донбасс"))
                        words.Add("Донбасс", 1);
                    else
                        words["Донбасс"]++;
                    continue;
                }
                if (str == "На") continue;
                if (str.Length < 2) continue;
                if (!words.ContainsKey(match.Value))
                    words.Add(match.Value, 1);
                else
                    words[match.Value]++;
          
            }
        }

    }
}
