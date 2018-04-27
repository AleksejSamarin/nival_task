# Выполненное тестовое задание (консольное приложение на C#). Требования:

После запуска приложение должно: 
1) Принимать аргументом запуска путь до директории. 
2) Десериализовать данные из всех файлов "*.xml" в указанной директории (структура данных приведена в аттаче, количество элементов «calculation» - произвольное). 
3) Десериализовать элементы «operand» в тип Enum. В остальном, модель данных для десериализации - произвольная. 
4) В случае ошибок/неполноты в данных элемента «calculation» - пропускать этот элемент. 
5) Для каждого файла произвести последовательно арифметические действия в соответствии со считанными данными и вывести в консоль имя файла и результат вычисления. 
6) В конце выполнения вывести в консоль название файла с наибольшим количеством успешно десериализованных элементов "calculation" и время выполнения программы. 

Задачи со звёздочкой: 
1) Считывать несколько файлов в разных потоках. 
2) Выводить в консоль информацию об элементах, которые не удалось десериализовать, информацию как их починить и где найти. 
 
Примеры xml файлов находятся в папке resources. Пример результата вычисления арифметических действий является 0 + 15 * 2 / 3 - 8 = 2

Пример вывода разработанной программы:
-------------------------------------------

* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile1.xml.
* Внимание! Деление на ноль! Уберите, пожалуйста, ноль в строке: 13. Файл: C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile1.xml.
* 0 + 15 * 2 - 8 + 12 = 34
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile2.xml.
* 0 + 15 * 2 + 1 = 31
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile3.xml.
* Длина строки uid не равна 32. Измените, пожалуйста, эту строку. Файл: C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile3.xml. Строка: 24.
* 0 + 15 * 2 / 3 - 8 = 2
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile4.xml.
* Нет аттрибута 'name' в элементе 'str'. Добавьте его, пожалуйста. Файл: C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile4.xml. Строка: 10.
* 0 + 15 / 3 - 8 = -3
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile5.xml.
* 0 + 15 * 2 / 3 - 8 * 80 = 160
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile6.xml.
* 0 * 2 / 3 - 8 = -8
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile7.xml.
* Нет ни одного аттрибута. Добавьте их, пожалуйста. Файл: C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile7.xml. Строка: 9.
* 0 + 15 = 15
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile8.xml.
* 0 + 15 * 2 - 30 - 80 = -80
* Текущий поток: Thread_for_file_C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile9.xml.
* Нет аттрибута 'name' в элементе 'str'. Добавьте его, пожалуйста. Файл: C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile9.xml. Строка: 19.
* 0 + 1 * 2 = 2
* Наибольшее количество успешно десериализованных элементов в файле: C:\Users\Aleksej\source\repos\nival_task\resources\XMLFile5.xml.
* Время выполнения программы составило 16 миллисекунд.

Скачать программу:
-------------------------------------------
[Яндекс.Диск](https://yadi.sk/d/OsASX8pj3UovgG)
