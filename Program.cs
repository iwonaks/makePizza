using System.Threading.Tasks.Dataflow;

var stack = new Stack<double>();

var stackstring = new Stack<string>();


Console.WriteLine("Podstawowy przepis na 1 dużą pizzę zawiera 500g mąki (ok 2 pełne szklanki mąki)");
Console.WriteLine("");

do
{   stack.Push(15);
    stack.Push(5);
    stack.Push(13);
    stack.Push(10);
    stack.Push(350);
    stack.Push(500);

    stackstring.Push("Oliwa: ");
    stackstring.Push("cukier: ");
    stackstring.Push("sól: ");
    stackstring.Push("świeże drożdże piekarskie: ");
    stackstring.Push("woda: ");
    stackstring.Push("mąka typu 00: ");

    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Podaj ile gram mąki posiadasz. Program poda Ci ile potrzebujesz pozostałych składników. /n Wagę podaj w gramach, równą lub więszą od 125g (ok pół szklanki)");
   
    string input = Console.ReadLine();

    if (input != null)
    {   
        try
        {
            double many = Double.Parse(input);
            if (many >= 125)
            {
                double convert = many / 500;
                Console.WriteLine("Potrzebujesz:");

                while (stack.Count > 0 && stackstring.Count > 0)
                {
                    double item = stack.Pop() * convert;
                    string itemstring = stackstring.Pop();

                    Console.WriteLine($"{itemstring} {item:N1} g");
                }
            }
            else
            {
                Console.WriteLine("{0} jest wartością poniżej 125 g, nikt nie poje sobie taką pizzą", many);
                stack.Clear();
                stackstring.Clear();
            }
        }

        catch (System.OverflowException)
        {
            Console.WriteLine("Bez żartów, program ma sens dla wartości od 125g mąki");
            stack.Clear();
            stackstring.Clear();
        }

        catch (System.FormatException)
        {
            Console.WriteLine("Wpisałeś niepoprawną wratość");
            stack.Clear();
            stackstring.Clear();
        }
    }
}
while(true);