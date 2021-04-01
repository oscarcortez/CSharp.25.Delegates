using System;

namespace ConsoleApp4Delegates
{

    /// <summary>
    /// delegates: es la manera de crear un tipo de referencia a metodos existentes o anonimos
    ///             es como apuntar a la direccion de memoria donde se encuentra el method
    /// action: es un delegate pero no retorna nada, puede recibir mas de un parameter pero no mas de 16
    /// func: es un delegate que si tiene un retorno de valor y se le declara al final de los parametros de entrada: Func<in, in, in, ..., out>
    /// predicate: solo puede tener un parametro de entrada y su salida es un boolean
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="number1"></param>
    /// <param name="number2"></param>
    public delegate void PrintCalcular<T>(T number1, T number2);

    public delegate T GetCalcular<T>(T number1, T number2);


    class Program
    {
        static void Sumar(int number1, int number2)
        {
            Console.WriteLine(number1+number2);
        }

        static void Multiplicar(int number1, int number2)
        {
            Console.WriteLine(number1 * number2);
        }

        static int GetSumar(int number1, int number2)
        {
            return number1 + number2;
        }

        static int GetMultiplicar(int number1, int number2)
        {
            return number1 * number2;
        }

        static Action<string> imprimirAction2 = delegate (string valor)
        {
            Console.WriteLine($"esto es una accion: {valor}");
        };

        static Action<string,string> imprimirAction22 = delegate (string valor, string valor2)
        {
            Console.WriteLine($"esto es una accion: {valor} {valor2}");
        };

        //static Action<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string> imprimirAction16 = delegate (
        //    string valor,
        //    string valor2,
        //    string valor3,
        //    string valor4,
        //    string valor5,
        //    string valor6,
        //    string valor7,
        //    string valor8,
        //    string valor9,
        //    string valor10,
        //    string valor11,
        //    string valor12,
        //    string valor13,
        //    string valor14,
        //    string valor15,
        //    string valor16,
        //    string valor17
        //    )
        //{
        //    Console.WriteLine($"esto es una accion: {valor} {valor2}");
        //};

        static Action<string> imprimirAction3 = valor => Console.WriteLine(valor);
        

        static void EjemploActionAnonimo()
        {
            Action<string> imprimirAction = delegate (string valor)
            {
                Console.WriteLine($"esto es una accion: {valor}");
            };

            imprimirAction("ejemplo");
        }


        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            PrintCalcular<int> imprimirDelegado = new PrintCalcular<int>(Sumar);

            imprimirDelegado(5, 7);

            imprimirDelegado = Multiplicar;

            imprimirDelegado(3, 14);

            GetCalcular<int> calcular = new GetCalcular<int>(GetSumar);

            Console.WriteLine("--------------------");

            EjemploActionAnonimo();

            imprimirAction2("fasdfas");
            imprimirAction3("111");

            calcular = delegate (int x, int y)
            {
                return x / y;
            };

            Console.WriteLine($"resultado de un tipo delegado anonimo: {calcular(10, 2)}");

            imprimirAction22("hola", "oscar");

            Console.WriteLine("--------------------");
            Func<int, int, int> funcOperacion = (v1, v2) => v1 * v2;

            int result = funcOperacion(2, 5);

            Console.WriteLine($"FuncOperacion multiplicacion anonima: {result}");

            funcOperacion = GetSumar;

            result = funcOperacion(3, 3);

            Console.WriteLine($"FuncOperacion existent method sumar : {result}");

            Predicate<int> mayorque = e => e >= 18;

        }
    }


}
