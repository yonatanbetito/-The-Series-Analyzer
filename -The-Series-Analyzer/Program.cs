using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

class Program
{
    //משתנה שמחזיק את הסדרה שלי
    static int[] series;
   
    //פונקציה שמטפלת בארגומנטים שהתקבלו בקונסול
    static int[] get_series_from_console(string[] args)
    {
        series = args.Select(int.Parse).ToArray();
        if (series.Length < 3 || series.Min() < 0)
        {
            return get_series_from_user();
        }
        return series;
    }
    
    //קבלת הסדרה עי המשתמש באינפוט או בארגומנט(יבוצע בהמשך)
    static int[] get_series_from_user()
    {
        int[] series;
        do
        {
            Console.WriteLine("Please enter a series of numbers separated by space (at least 3 numbers): ");
            series = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
        } while (series.Length < 3 || series.Min()< 0);
        
        return series;
    }
    
    //פונקציה שמציגה את התפריט
    static void menu_show()
    {
        Console.WriteLine("menu:");
        Console.WriteLine("a. Input a Series. (Replace the current series)");
        Console.WriteLine("b. Display the series in the order it was entered.");
        Console.WriteLine("c. Display the series in the reversed order it was entered.");
        Console.WriteLine("d. Display the series in sorted order (from low to high).");
        Console.WriteLine("e. Display the Max value of the series.");
        Console.WriteLine("f. Display the Min value of the series.");
        Console.WriteLine("g. Display the Average of the series.");
        Console.WriteLine("h. Display the Number of elements in the series.");
        Console.WriteLine("i. Display the Sum of the series.");
        Console.WriteLine("j. Exit.");
    }

    //פונקציה שמקבלת/מחזירה בחירה של המשתמש
    static string input_choice()
    {
        Console.WriteLine("enter your choice(a-j): ");
        string choice = Console.ReadLine();
        return choice;
    }

    //פונקציה שמריצה/קוראת פונקציה אחרת בהתאם לבחירה
     static void Manager_by_choice()
     {
         string choice;
         do
         {
             choice = input_choice();
             switch (choice)
             {
                 case "a":
                     // Console.WriteLine("a. Input a Series. (Replace the current series)");
                     print_input(input_new_series());
                     break;
                 case "b":
                     Console.WriteLine("The order it was entered: ");
                     print_input(show_series());
                     break;
                 case "c":
                     Console.WriteLine("The reversed: ");
                     print_input(show_series_reversed());
                     break;
                 case "d":
                     Console.WriteLine("the series in sorted order (low to high):");
                     print_input(show_series_sorted());
                     break;
                 case "e":
                     Console.Write("Max value of the series: ");
                     print_input(max_value());
                     break;
                 case "f":
                     Console.Write("Min value of the series: ");
                     print_input(min_value());
                     break;
                 case "g":
                     Console.Write("Average of the series: ");
                     print_input(average_value());
                     break;
                 case "h":
                     Console.Write("The Number of elements: ");
                     print_input(number_of_elements());
                     break;
                 case "i":
                     Console.Write("Sum of the series:");
                     print_input(sum_of_elements());
                     break;
                 case "j":
                     Console.WriteLine("exit");
                     break;
                    
                 default:
                     Console.WriteLine("invalid choice");
                     break;
             }
         } while (choice != "j");
         
    }

     //הכנסת סדרה חדשה
    static int[] input_new_series()
    {
        return series = get_series_from_user();
    }

    //הצגת הסדרה
    static int[] show_series()
    {
        return series;
    }

    //פונקציה שמחזירה *רשימה חדשה* הפוכה 
    static List<int> show_series_reversed()
    {
        List<int> reversed_series = new List<int>();
        for (int index = series.Length-1; index>=0; index--)
        {
            reversed_series.Add(series[index]);
        }

        return reversed_series;
    }

    //פונקציה שעושה מיון לרשימה (משנה את המקורית)
    static int[] show_series_sorted()
    {
        int[] sorted = series.ToArray();
        bool sort;
        for (int i = 0; i < sorted.Length; i++)
        {
            sort = true;
            for (int j = 0 ;  j<sorted.Length-1-i;j++)
            {
                if(sorted[j]>sorted[j+1])
                {
                    int temp = sorted[j];
                    sorted[j] = sorted[j + 1];
                    sorted[j + 1] = temp;
                    sort = false;
                }
            }
            if (sort)
            {
                break;
            }
        }
        return sorted;
    }

    //מחזירה את הערך המקסימלי
    static int max_value()
    {
        int maximum = series[0];
        for (int index = 1; index < series.Length; index++)
        {
            if (series[index] > maximum)
            {
                maximum = series[index];
            }
        }

        return maximum;
    }

    //פונקציה שמחזירה את הערך המינמלי שבסדרה
    static int min_value()
    {
        int minimum = series[0];
        for (int index = 1; index < series.Length; index++)
        {
            if (series[index] < minimum)
            {
                minimum = series[index];
            }
        }
        
        return minimum;
    }

    //מחזירה ממוצע של כל הסדרה
    static double average_value()
    {
        double average;
        int sum_of = 0;
        foreach (int number in series)
        {
            sum_of += number;
        }
        average = (double)sum_of / series.Length;
        return average;
    }

    //מספר של אלמנטים
    static int number_of_elements()
    {
        return series.Length;
    }

    //סכום כל האלמנטים
    static int sum_of_elements()
    {
        int sum = 0;
        foreach (int number in series)
        {
            sum += number;
        }
        return sum;
    }
    
    //מה שיחזור מהפונקציה שהמנגר החזירה יודפס לפי הטייפ שלו
    static void print_input(object input)
    {
        switch (input)
        {
            case int number:
                Console.WriteLine($"{number}");
                break;

            case List<int> list:
                Console.WriteLine(string.Join(" ", list));
                break;

            case int[] array:
                Console.WriteLine(string.Join(" ", array));
                break;
            case double number:
                Console.WriteLine($"{number}");
                break;
        }
    }
     
    //פונקציה שבעצם תנהל את כל הפרוייקט
    static void Main(string[] args)
    {
        if (args.Length>0)
        {
            series = get_series_from_console(args);
        }
        else
        {
            series = get_series_from_user();    
        }
        menu_show();
        Manager_by_choice();
        
    }
    
}
