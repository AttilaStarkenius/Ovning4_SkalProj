using System;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace SkalProj_Datastrukturer_Minne
{
    public class Program
    {

        //Frågor: 
        //    1.​​​​​​​​​​​​​​​​Hur​​fungerar​​​stacken​​​och​​​heapen​ ?
        //        Förklara​​gärna​​med​​exempel​​eller​​
        //        skiss​​på​​dessgrundläggande​​funktion
        /* 15.11.2022. Stack är som en hög med skolådor där man 
         måste först köra övre skolådorna innan
        man kan komma åt undre skolådorna, men stack
        har koll på garbage collection, ett exempel
        här: public void Method1()
        {
            int a = 10;
            
            int b = 20;

            Program obj = new Program();
        }
        ​​Program obj = new Program(); lagras i Heap
        eftersom den är klass type(av typen Program), och klass är en 
        reference type. Reference types lagras alltid i Heap.
        Medans value types lagras alltid där de deklareras 
        det vill säga i Stack eftersom dessa
        två value types deklareras i metoden public void Method1()
        {
            int a = 10;
            
            int b = 20;

            Program obj = new Program();
        }
        vilket inkluderar ju båda int a = 10;
            och int b = 20;    
        men i det här exemplet: 
        class Program{

                public int a = 10;

        }
        så ligger public int a = 10; i Heap
        eftersom den är deklarerad i klass
        "Program", och klass är en reference type,
        och reference types ligger ju alltid i Heap.

        */
        public int a = 10;

        public void Method1()
        {
            int a = 10;

            int b = 20;

            Program obj = new Program();
        }

        //2.​​​​​​​​​​​​​​​​Vad​​är​​​Value​​Types​​​repsektive
        //Reference​​Types​​​och​​vad​​skiljer​​dem​​åt ? 
        /*15.11.2022. Value types är 
         typer ​​från​​​ System.ValueType, value types är listade här:
        "bool•​​​​​​​​​​​​​​​​byte•​​​​​​​​​​​​​​​​char•​​​​​​​​​​​​​​​​decimal•​​​​​​​​​​​​​​​​double•
        enum•​​​​​​​​​​​​​​​​float•​​​​​​​​​​​​​​​​int•​​​​​​​​​​​​​​​​long•​​​​​​​​​​​​​​​​sbyte•​​​​​​​​​​​​​​​​short•
        struct•​​​​​​​​​​​​​​​​uint•​​​​​​​​​​​​​​​​ulong•​​​​​​​​​​​​​​​​ushort"
        medans reference​​ types är typer
        som är System.Object.object, reference types är listade här:
        "•​​​​​​​​​​​​​​​​class•​​​​​​​​​​​​​​​​interface•​​​​​​​​​​​​​​​​object•​​​​​​​​​​​​​​​​delegate•​​​​​​​​​​​​​​​​string"
        skillnaden mellan value types och reference types 
        är att man kommer åt reference types bara via pointer,
        och pointer pekar på annan ​​plats​​ i​​ minnet​​ eller ​​​null.
        reference ​​type​​​ lagras​​ alltid​​ på ​​​heapen, medans
        value type lagras antingen i stacken​​​ eller​​​ heapen.
        Till exempel value type deklarerad i en metod
        lagras i stacken, medans value type deklarerad 
        i en klass lagras i heapen.
        Stacken rensar sig själv, medans Heapen
        behöver specifik Garbage Collector, annars stannar
        värdena kvar i minnet och tar plats.*/


        //3.Följande​​metoder​​(​se​​bild​​nedan​)​​genererar​​olika​​svar.​​
        //Den​​första​​returnerar​​3,​​denandra​​returnerar​​4,​​varför ?
        /*15.11.2022. Den första metoden ser ut så här:
         "public int ReturnValue(){
        int x = new int();
        x = 3;
        int y = new int();
        y = x;
        y = 4;
        return x;
        }"
        och den andra metoden ser ut så här:
        "public int ReturnValue2()
        {
            MyInt x = new MyInt();
            x.MyValue = 3;
            MyInt y = new MyInt();
            y.MyValue = 4;
            return x.MyValue;
        }"
        Och frågan var så här: "Den​​första​​returnerar​​3,​​denandra​​returnerar​​4,​​varför ?"
        MyInt är en klass, så jag skapar en klass MyInt som inte än fanns
        i mitt projekt: "using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class MyInt
    {
        public int MyValue { get; set; }
    }
}"
                Och frågan var så här: "Den​​första​​returnerar​​3,​​denandra​​returnerar​​4,​​varför ?"
I första metod value typen int x har definierats med värde "3".
        I andra metod så har reference typen MyInt x definierats också med
        värde "3", men när man returnerar "return x.MyValue;"
        så returnerar man i själva verket MyInt.MyValue, som
        har här: "MyInt y = new MyInt();
            y.MyValue = 4;"
        tilldelats nytt värde "4". Således returneras värdet "4".

         */
        public int ReturnValue()
        {
            int x = new int();
            x = 3;
            int y = new int();
            y = x;
            y = 4;
            return x;
        }

        public int ReturnValue2()
        {
            MyInt x = new MyInt();
            x.MyValue = 3;
            MyInt y = new MyInt();
            y.MyValue = 4;
            return x.MyValue;
        }

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            //Övning​​1:​​ExamineList()
            //1.​​​​​​​​​​​​Skriv​​klart​​implementationen​​av​​​ExamineList
            //    - metoden​​​så​​att​​undersökningen
            //    blirgenomförbar.
            /*15.11.2022. I början ser implementationen av ExamineList(){}
             ut så här:
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
            /*Jag lägger det i en while loop så här:
             static void ExamineList()
        {
             string input = Console.ReadLine();
             while (input != "quit" && input != "exit"){
            List<string> theList = new List<string>();
            char nav = input[0];
            string value = input.substring(1);
            }
            }
            */
            //Console.WriteLine("Enter 'quit' or 'exit' to exit to main menu?");
            //Console.WriteLine("select 1 for book 1, 2 for book 2, and 3 for book 3");
            //string input = Console.ReadLine();


            //char nav = ' '; //Creates the character input to be used with the switch-case below.
            //try
            //{
            //    nav = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            //}
            //catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            //{
            //    Console.Clear();
            //    Console.WriteLine("Please enter some input!");
            //}

            List<string> theList = new List<string>();
            /*Frågorna 2.,3.,4. 17.11.2022. List<string> theList listans kapacitet ökar 
             från 0 till 4 när 
             jag lägger till en item "adam"
             4. List<T> använder Array som är alltid
            en mindre på grund av array datastruktur
            så första array element är T[0], inte T[1]. Om capacity är mindre än count,
            händer det här: "ArgumentOutOfRangeException
Capacity is set to a value that is less than Count."
            "Internally, a List<T> uses an array (so T[]) to store its contents.
This array starts off with a size of 4 elements, so equivalent to saying 
            T[] array = new T[4]. When you add an item to a List<T>, 
            it is stored in the array: the first item in array[0], 
            the second in array[1], etc. The fifth item, however, 
            can't fit into this array, as it's only four elements long. 
            And because the length of an array can't be changed after it has 
            been created, the only option is to take the contents of the array 
            and move it to a new array that is large enough to hold that fifth 
            item as well. The implementation of List<T> chooses to double the 
            size of the array buffer each time it runs out of space, so to
            fit the fifth item, it doubles the array capacity to 8. Then 16, and so on.
            Fråga 5. Listans capacity minskar inte när man tar bort en item
            Fråga 6. Man borde använda Array då när man vet hur lång arrayen är
            från första början
            "*/
            Console.WriteLine("Enter '+' at the beginning of string " +
                "to add item or '-' to remove item or 'm' to exit to main menu?");
            //Console.WriteLine("select 1 for book 1, 2 for book 2, and 3 for book 3");


            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                Console.Clear();
                /*15.11.2022. If the input string is empty, we ask the users for some input.*/
                Console.WriteLine("Please enter some input!");
                ExamineList();
                //throw new ArgumentException("Input cannot be null or empty.");
            }
            Console.WriteLine(theList.Capacity);

            //theList.Add(input);



            ////try
            ////    {
            //Console.WriteLine(theList.Capacity);
            //if (String.IsNullOrEmpty(input))
            //{
            //    Console.Clear();
            //    /*15.11.2022. If the input string is empty, we ask the users for some input.*/
            //    Console.WriteLine("Please enter some input!");
            //    ExamineList();
            //    //throw new ArgumentException("Input cannot be null or empty.");
            //}
            //ExamineList();
            // If the input string is empty, we ask the users for some input.
            //{
            //    Console.Clear();
            //    Console.WriteLine("Please enter some input!");
            //}
            //}
            //catch (ArgumentException) //If the input line is empty, we ask the users for some input.
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Please enter some input!");

            char nav = input[0];
            string value = input.Substring(1);
            //string withoutPlusOrMinus

            switch (nav)
            {
                case '+':
                    //string input = Console.ReadLine();
                    Console.WriteLine(theList.Capacity);

                    theList.Add(input);

                    Console.WriteLine(theList.Capacity);


                    //try
                    //    {
                    //Console.WriteLine(theList.Capacity);
                    //if (String.IsNullOrEmpty(input))
                    //{
                    //    Console.Clear();
                    //    /*15.11.2022. If the input string is empty, we ask the users for some input.*/
                    //    Console.WriteLine("Please enter some input!");
                    //    ExamineList();
                    //    //throw new ArgumentException("Input cannot be null or empty.");
                    //}
                    ExamineList();
                    //theList.Add(value);
                    break;
                case '-':
                    theList.Remove(value);
                    Console.WriteLine(theList.Capacity);
                    break;
                case 'm':
                    Program.Main();
                    break;
                default:
                    /*15.11.2022. In case nav is
                     neither + or -, I tell the user
                    to write either + or - at the beginning
                    of the string:  Console.WriteLine("Please use either 
                    + or - at the beginning of the string");

*/
                    Console.WriteLine("Please use either + or - at the beginning of the string");
                    break;
            }
        }
            //switch (input)
            //{
            //    case '1':
            //        ExamineList();
            //        break;
            //    case '2':
            //        ExamineQueue();
            //        break;
            //    case '3':
            //        ExamineStack();
            //        break;
            //    case '4':
            //        CheckParanthesis();
            //        break;
            /*
             * Extend the menu to include the recursive 
             * and iterative exercises.
             */
            //        case '0':
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
            //            break;
            //    }
            //}
            //}

            //while (input != "quit" && input != "exit")
            //{
            //switch (nav) {...}
            //List<string> theList = new List<string>();
            //    char nav = input[0];
            //    string value = input.Substring(1);
            //}
            //Program.Main();
            //Program.Main();

            //    2.​​​​​​​​​​​​​​​​När​​ökar​​listans​​kapacitet ?
            //    (Alltså​​den​​underliggande​​arrayens​​storlek)



            //    3.​​​​​​​​​​​​​​​​Med​​hur​​mycket​​ökar​​kapaciteten ? 



            //    4.​​​​​​​​​​​​​​​​Varför​​ökar​​inte​​listans​​kapacitet​​
            //    i​​samma​​takt​​som​​element​​läggs​​till ? 



            //    5.​​​​​​​​​​​​​​​​Minskar​​kapaciteten​​när​​element​​tas​​bort​​ur​​listan ? 



            //    6.​​​​​​​​​​​​​​​​När​​är​​det​​då​​fördelaktigt​​att​​använda​​
            //    en​​egendefinierad​​​array​​​istället​​för​​en​​lista ?





            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
            //}

            /// <summary>
            /// Examines the datastructure Queue
            /// </summary>
            static void ExamineQueue()
            {
            /*17.11.2022. Övning 2: ExamineQueue()
             * Datastrukturenkö(implementerad iQueue-klassen)
             * fungerar enligtFörst In Först Ut(FIFO)principen. 
             * Alltså att det element som läggstill först 
             * kommer vara det som tas bortförst.
             * 1.Simulera följande kö på papper:
             * a.ICA öppnar och kön till kassan är tom
             * b.Kalle ställer sig i kön
             * c.Greta ställer sig i kön
             * d.Kalle blir expedierad och lämnar kön
             * e.Stina ställer sig i kön
             * f.Greta blir expedierad och lämnar kön
             * g.Olle ställer sig i kön
             * h....
             
             svaret: Queue<string> icaQueue = new Queue<string>();
        icaQueue.Enqueue("icaOpen");
        icaQueue.Enqueue("kallePosition");
        icaQueue.Enqueue("gretaPosition");
        icaQueue.Enqueue("stinaPosition");
        icaQueue.Enqueue("ollePosition");
            
             
             2.Implementera metodenExamineQueue. 
            Metodenska simulera hur enkö
            fungerargenom att tillåta användaren
            att ställa element i kön (enqueue) 
            och ta bort elementur kön (dequeue). 
            AnvändQueue-klassentill hjälpför att
            implementera metoden.Simulera sedan 
            ICA-kön med hjälp av ditt program.*/


            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
            {
                /*
                 * Loop this method until the user inputs something to exit to main menue.
                 * Create a switch with cases to push or pop items
                 * Make sure to look at the stack after pushing and and poping to see how it behaves
                */
            }

            static void CheckParanthesis()
            {
                /*
                 * Use this method to check if the paranthesis in a string is Correct or incorrect.
                 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
                 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
                 */

            }

        }
    }
//}


