using System.IO;

namespace nival_task {

    /*****************************************************
    * InputManager:
    * Класс, проверящий наличие аргументов, и в случае, если
    * они есть - устанавливает директорию с файлами, 
    * вычисляет количество xml-файлов в ней.
    *****************************************************/

    class InputManager {
        public string[] files { get; private set; }
        public int count { get; private set; }
        public bool state { get; private set; }

        public InputManager(string[] args, OutputManager om) {
            if (ArgsCheck(args)) {
                files = Directory.GetFiles(args[0], "*.xml");
                count = files.Length;
                state = true;
            } else {
                state = false;
                om.addLog("Нет параметра!");
            }
        }

        protected bool ArgsCheck(string[] args) {
            if (args.Length != 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}