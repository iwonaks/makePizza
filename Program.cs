using System.Threading.Tasks.Dataflow;

var weightComponent = new Stack<double>();

var component = new Stack<string>();


Console.WriteLine("Podstawowy przepis na 1 dużą pizzę zawiera 500g mąki (ok 2 pełne szklanki mąki)");
Console.WriteLine("");

do
{
    weightComponent.Push(15);
    weightComponent.Push(5);
    weightComponent.Push(13);
    weightComponent.Push(10);
    weightComponent.Push(350);
    weightComponent.Push(500);

    component.Push("Oliwa: ");
    component.Push("cukier: ");
    component.Push("sól: ");
    component.Push("świeże drożdże piekarskie: ");
    component.Push("woda: ");
    component.Push("mąka typu 00: ");

    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Podaj ile gram mąki posiadasz. Program poda Ci ile potrzebujesz pozostałych składników. /n Wagę podaj w gramach, równą lub więszą od 125g (ok pół szklanki)");
   
    string? input = Console.ReadLine();

    if (input != null)
    {   
        try
        {
            double many = Double.Parse(input);
            if (many >= 125)
            {
                double convert = many / 500;
                Console.WriteLine("Potrzebujesz:");

                while (weightComponent.Count > 0 && component.Count > 0)
                {
                    double item = weightComponent.Pop() * convert;
                    string itemstring = component.Pop();

                    Console.WriteLine($"{itemstring} {item:N1} g");
                }
            }
            else
            {
                Console.WriteLine("{0} jest wartością poniżej 125 g, nikt nie poje sobie taką pizzą", many);
                weightComponent.Clear();
                component.Clear();
            }
        }

        catch (System.OverflowException)
        {
            Console.WriteLine("Bez żartów, program ma sens dla wartości od 125g mąki");
            weightComponent.Clear();
            component.Clear();
        }

        catch (System.FormatException)
        {
            Console.WriteLine("Wpisałeś niepoprawną wratość");
            weightComponent.Clear();
            component.Clear();
        }
    }
}
while(true);