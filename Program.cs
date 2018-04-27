using System;
using System.Collections.Generic;
using System.Linq;

namespace nival_task {

    /*****************************************************
    * Program:
    * Класс, содержащий в себе метод Main (точку входа в
    * С# приложение). В нем создаются нужные для работы 
    * объекты классов-менеджеров, вызываются их некоторые
    * методы. Изначально объекты класса ParseManager заносятся
    * в контейнер, в котором впоследствии произойдет сортировка
    * по успешно десериализованным объектам. Вывод всех логов
    * происходит в самом конце посредством вызова метода 
    * WriteAll() объекта класса OutputManager.
    *****************************************************/

    class Program {
        static void Main(string[] args) {
            TimerManager timerManager = new TimerManager();
            timerManager.Start();

            OutputManager outputManager = new OutputManager();
            InputManager inputManager = new InputManager(args, outputManager);
            List<ParseManager> parsemanagers = new List<ParseManager>();

            for (int i = 0; i < inputManager.count; i++) {
                parsemanagers.Add(new ParseManager(inputManager.files.ElementAt(i)));
                parsemanagers.ElementAt(i).Work(outputManager);
            }

            parsemanagers.Sort();
            outputManager.addLog(string.Format("> Наибольшее количество успешно десериализованных элементов в файле: {0}.", parsemanagers.Last().file));

            timerManager.Stop(outputManager);
            outputManager.WriteAll();

            Console.ReadKey(true);
        }
    }
}
