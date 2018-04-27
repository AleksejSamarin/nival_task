using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace nival_task {

    /*****************************************************
    * ParseManager:
    * Класс для десериализации элементов файла. Реализует
    * интерфейс IComparable для возможности сравнения объектов
    * по приватному полю с количеством успешно десериализованных
    * элементов. Файлы десериализуются в разных потоках, которые
    * создаются в количестве равном колтичеству файлов с 
    * расширением .xml в директории, указанной в аргументе
    * запуска программы.
    *****************************************************/

    class ParseManager : IComparable {
        private Thread thread;
        private List<string> logs;
        private ElementsChecker checker;
        private Example example;
        private int success;
        public string file { get; private set; }

        public int CompareTo(object o) {
            ParseManager pm = o as ParseManager;
            if (pm != null) {
                return this.success.CompareTo(pm.success);
            } else {
                throw new Exception();
            }
        }

        public ParseManager(string f) {
            file = f;
            logs = new List<string>();
            checker = new ElementsChecker(file, ref logs);
            example = new Example(ref logs);
            success = 0;
        }

        public void Work(OutputManager om) {
            thread = new Thread(() => Parse(file, om));
            thread.Name = "Thread_for_file_" + file;
            thread.Start();
            thread.Join();
        }

        protected void Parse(string file, OutputManager om) {
            int validDegree;
            Operation tempOperation;

            om.addLog(string.Format("# Текущий поток: {0}.", Thread.CurrentThread.Name));
            XDocument document = XDocument.Load(file, LoadOptions.SetLineInfo);
            foreach (XElement el in document.Root.Elements()) {
                validDegree = 0;
                tempOperation = new Operation();

                foreach (XElement element in el.Elements()) {
                    if (checker.CheckOperation(element)) {
                        AddOperation(element, ref tempOperation, ref validDegree);
                    }
                }
                if (validDegree == 3 && checker.CheckZeroDivide(tempOperation, el)) {
                    example.AddOperation(tempOperation);
                    success++;
                }
            }
            example.CalculateAll();
            om.addLogList(logs);
        }

        protected void AddOperation(XElement element, ref Operation op, ref int validDegree) {
            switch (element.Attribute("name").Value) {
                case "uid":
                    op.uid = element.Attribute("value").Value;
                    break;
                case "operand":
                    op.operation = (EnumOperation)Enum.Parse(typeof(EnumOperation), element.Attribute("value").Value.ToString());
                    break;
                case "mod":
                    op.operand = Convert.ToInt32(element.Attribute("value").Value);
                    break;
            }
            validDegree++;
        }
    }
}