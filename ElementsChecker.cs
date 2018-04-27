using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace nival_task {

    /*****************************************************
    * ElementsChecker:
    * Класс, выполнящий проверку правильности xml-файлов.
    *****************************************************/

    class ElementsChecker {
        private string currentFile;
        private List<string> logs;

        public ElementsChecker(string file, ref List<string> lgs) {
            currentFile = file;
            logs = lgs;
        }

        public bool CheckOperation(XElement element) {        
            if (element.HasAttributes) {
                if (CheckAttributes(element)) {
                    return true;
                } else {
                    return false;
                }
            } else {
                logs.Add(string.Format("> Нет ни одного аттрибута. Добавьте их, пожалуйста. Файл: {0}. Строка: {1}.", currentFile, ((IXmlLineInfo)element).LineNumber));
                return false;
            }
        }

        protected bool CheckAttributes(XElement element) {
            int line = ((IXmlLineInfo)element).LineNumber;
            if (element.Name == "str") {
                if (element.Attribute("name") == null) {
                    logs.Add(string.Format("> Нет аттрибута 'name' в элементе '{0}'. Добавьте его, пожалуйста. Файл: {1}. Строка: {2}.", element.Name.ToString(), currentFile, line));
                    return false;
                } else if (element.Attribute("value") == null) {
                    logs.Add(string.Format("> Нет аттрибута 'value' в элементе '{0}'. Добавьте его, пожалуйста. Файл: {1}. Строка: {2}.", element.Name.ToString(), currentFile, line));
                    return false;
                } else if (element.Attribute("name").Value == "uid") {
                    if (element.Attribute("value").Value.Length != 32) {
                        logs.Add(string.Format("> Длина строки uid не равна {0}. Измените, пожалуйста, эту строку. Файл: {1}. Строка: {2}.", 32, currentFile, line));
                        return false;
                    } else {
                        return true;
                    }
                } else if (element.Attribute("name").Value == "operand") {
                    foreach (var value in Enum.GetValues(typeof(EnumOperation))) {
                        if (element.Attribute("value").Value == value.ToString()) {
                            return true;
                        }
                    }
                    logs.Add(string.Format("> Оператора {0} не существует. Пожалуйста, не придумывайте свои операторы. Спасибо. Файл: {1}. Строка: {2}.", element.Attribute("value").Value, currentFile, line));
                    return false;
                }
                return false;
            } else if (element.Name == "int") {
                if (element.Attribute("name") == null) {
                    logs.Add(string.Format("> Нет аттрибута 'name' в элементе '{0}'. Добавьте его, пожалуйста. Файл: {1}. Строка: {2}.", element.Name.ToString(), currentFile, line));
                    return false;
                } else if (element.Attribute("name").Value == "mod") {
                    if (element.Attribute("value") == null) {
                        logs.Add(string.Format("> Нет аттрибута 'value' в элементе '{0}'. Добавьте его, пожалуйста. Файл: {1}. Строка: {2}.", element.Name.ToString(), currentFile, line));
                        return false;
                    }
                    if (!float.TryParse(element.Attribute("value").Value, out float value)) {
                        logs.Add(string.Format("> Значение {0} не является числом. Исправьте, пожалуйста, это значение на число. Файл: {1}. Строка: {2}.", element.Attribute("name").Value, currentFile, line));
                        return false;
                    } else {
                        return true;
                    }
                }
                return false;
            } else {
                return false;
            }
        }

        public bool CheckZeroDivide(Operation op, XElement el) {
            if (!((op.operation == EnumOperation.divide) && (op.operand == 0))) {
                return true;
            } else {
                logs.Add(string.Format("> Внимание! Деление на ноль! Уберите, пожалуйста, ноль в строке: {0}. Файл: {1}.", ((IXmlLineInfo)el).LineNumber, currentFile));
                return false;
            }
        }
    }
}