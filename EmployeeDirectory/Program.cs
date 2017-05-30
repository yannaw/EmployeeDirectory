using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory {
    class Program {
        static void Main(string[] args) {

            Directory directory = new Directory();

            Console.WriteLine("Avsluta med enter");
/******* V 1    ******/
            //           List<Employee> directory = new List<Employee>();
            // Array - fix, Lista = dynamisk

            /*            Employee[] directory = { 
                            new Employee("Ett", 111),  
                            new Employee("Två", 222),
                            new Employee("Tre", 333)};  */

            /*            directory.AddEmployee("Ett", 111);
                        directory.AddEmployee("Två", 222);
                        directory.AddEmployee("Tre", 333);
            */

/*****  V 2     *****/
/*            //hämta användare
            var askForEmployee = true;
            while(askForEmployee) { //kontroll sker innan exekvering till skillnad från do-sats

                //Hämta anställdesd namn
                Console.Write("Namn: ");
                var name = Console.ReadLine();

                //hämta anställdes lön

                bool askForSalary = true;
                do {

                Console.Write("Lön: ");
                var strSalary = Console.ReadLine();

                //undantag kastas om fel format
                int salary;
                //int.TryParse(strSalary, out salary); //returnerar boolean

                //TryParse ersätter hela try&catch
                //returnerar boolean

                //if(parseSucceeded) {
                if(int.TryParse(strSalary, out salary)) {
                        directory.AddEmployee(name, salary);
                        askForSalary = false;
                } else {
                    Console.WriteLine("Endast siffror");
                    //felhantering
                }
                } while(askForSalary);

                /*               try {
                                   salary = int.Parse(strSalary);
                                   //Lägg till anställd  inte snyggt att ha i try då try endast bör innehålla det som try gäller
                                   directory.AddEmployee(name, salary);

                               } catch(FormatException e) {
                                   Console.WriteLine("Input error: "+ e.Message);
                                   //snygg kod att skicka tillbaka till början om det går fel
                               }
                               //Avsluta
                           }
              
                //skillnaden är att do alltid utförs minst en ggn. 
                /*  do { } while(true);   

                askForEmployee = false;
            }   //end while
            directory.ListEmployees();
*/
            /*****  V 3     *****/
 //           Extrahera kod från konstanter. Markera sträng och ctrl. 3:e alternativet. Därefter de två efterföljande  och ctr.
            //hämta användare
            while(true) {
                //Hämta namn
                string name = askForString("Namn: ");
                if(string.IsNullOrWhiteSpace(name)) { // alt för tydlighet name==""
                    break;
                }
                //Hämta lön
                int salary = AskForInt("Lön: ", "Error - Endast siffror");
                int age = AskForInt("Ålder: ", "Error - Endast siffror, 0 vid okänt");

                //Lägg till anställd
                directory.AddEmployee(name, salary, age);

            }   //end while
            directory.ListEmployees();
        }

        private static int AskForInt(string question, string errorMessage) {
            int value;
            bool askAgain;

            do {
                askAgain = false;
                var input = askForString(question);

                if(!int.TryParse(input, out value)) {
                    askAgain = true;
                    Console.WriteLine(errorMessage);
                } 
            } while(askAgain);
            return value;
        }

        private static string askForString(string question) {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}
