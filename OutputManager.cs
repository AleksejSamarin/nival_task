using System;
using System.Collections.Generic;

namespace nival_task {

    /*****************************************************
    * OutputManager:
    * Класс для вывода всех логов программы. В процессе
    * выполнения программы они заносятся в контейнер
    * и затем выводятся с методом WriteAll()
    *****************************************************/

    class OutputManager {
        private List<string> logs;

        public OutputManager() {
            logs = new List<string>();
        }

        public void addLog(string log) {
            logs.Add(log);
        }

        public void addLogList(List<string> list) {
            logs.AddRange(list);
        }

        public void WriteAll() {
            foreach (string s in logs) {
                Console.WriteLine(s);
            }
        }
    }
}