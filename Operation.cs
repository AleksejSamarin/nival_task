namespace nival_task {

    /*****************************************************
    * Operation:
    * Класс, описывающий объекты действий в вычисляемом
    * примере, т.е. в данном случае: его uid, операнд и 
    * операцию.
    *****************************************************/

    class Operation {
        public string uid;
        public int operand;
        public EnumOperation operation;

        public Operation() { }

        public Operation(string u, int oprnd, EnumOperation oprtr) {
            uid = u;
            operand = oprnd;
            operation = oprtr;
        }
    }
}
