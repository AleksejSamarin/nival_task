using System.Collections.Generic;

namespace nival_task {

    /*****************************************************
    * Example:
    * Класс, описывающий объекты вычисляемых примеров.
    *****************************************************/

    class Example {
        private List<Operation> operations;
        private List<string> logs;
        public int countOperations { get; private set; }
        private int result;

        public Example(ref List<string> lgs) {
            operations = new List<Operation>();
            logs = lgs;
            countOperations = 0;
            result = 0;
        }

        public void AddOperation(Operation op) {
            operations.Add(op);
        }

        public void CalculateAll() {
            string curlog;
            curlog = string.Format("        {0}", result);
            foreach (Operation operation in operations) {
                switch (operation.operation) {
                    case EnumOperation.add:
                        result += operation.operand;
                        curlog += " + ";
                        break;
                    case EnumOperation.subtract:
                        result -= operation.operand;
                        curlog += " - ";
                        break;
                    case EnumOperation.multiply:
                        result *= operation.operand;
                        curlog += " * ";
                        break;
                    case EnumOperation.divide:
                        result /= operation.operand;
                        curlog += " / ";
                        break;
                }
                curlog += operation.operand;
            }
            curlog += string.Format(" = {0}", result);
            logs.Add(curlog);
            countOperations = operations.Count;
        }
    }
}