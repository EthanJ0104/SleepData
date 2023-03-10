// See https://aka.ms/new-console-template for more information
// Not sure how this is possible when all of the variables are local to the first if statement so I changed it a bit.
// ask for input
// create data file

// ask a question
Console.WriteLine("How many weeks of data is needed?");
// input the response (convert to int)
int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
DateTime today = DateTime.Now;
// we want full weeks sunday - saturday
DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
// subtract # of weeks from endDate to get startDate
DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
Console.WriteLine(dataDate);
// random number generator
Random rnd = new Random();
// create file
StreamWriter sw = new StreamWriter("data.txt");

// 7 days in a week
int[] hours = new int[7];

for (int i = 0; i < hours.Length; i++)
    {
        // generate random number of hours slept between 4-12 (inclusive)
        hours[i] = rnd.Next(4, 13);
    }

Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // M/d/yyyy,#|#|#|#|#|#|#
        Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
    while (dataDate < dataEndDate)
    {
        Console.WriteLine($"Week of {today:MMM}, {today:dd}, {today:yyyy}");
        Console.WriteLine("Su Mo Tu We Th Fr Sa");
        Console.WriteLine("-- -- -- -- -- -- --");
        Console.WriteLine($"{hours[0]} {hours[1]} {hours[2]} {hours[3]} {hours[4]} {hours[5]} {hours[6]} ");
        Console.WriteLine();
        dataDate = dataDate.AddDays(7);
        today = today.AddDays(7);
    }
    
}
