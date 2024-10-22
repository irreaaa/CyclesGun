StreamWriter txt = new StreamWriter("C:/Users/prdb/source/repos/cbuvf/ConsoleAppIra5/txt.txt");
Console.WriteLine("Введите координаты пушки (x, y): ");
string coordinate = Console.ReadLine();

Console.WriteLine("Введите начальную скорость снаряда: ");
double nachSkorost = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите угол вылета снаряда: ");
double ugolVyleta = Convert.ToDouble(Console.ReadLine());

string[] coordinates = coordinate.Split(",");
int x0 = Convert.ToInt32(coordinates[0]);
int y0 = Convert.ToInt32(coordinates[1]);

double radians = ugolVyleta * Math.PI / 180;
double t = 0;
double vx0 = nachSkorost * Math.Cos(radians);
double vy0 = nachSkorost * Math.Sin(radians);
double g = 9.81;
double x, y;
double maxHeight = y0;

Console.WriteLine("Время \t по Х \t по У");
while (true)
{
    x = x0 + vx0 * t;
    y = y0 + vy0 * t - ((g * Math.Pow(t, 2)) / 2);

    if(y > maxHeight)
    {
        maxHeight = y;
    }
    Console.WriteLine($"{t:F2} \t {x:f2} \t {y:f2}");
    txt.WriteLine($"{t:F2} \t {x:f2} \t {y:f2}");
    if (y <= 0)
        break;
    t = t + 0.1;
}

Console.WriteLine($"Наивысшая точка траектории  снаряда: {maxHeight:F2}");

txt.Close();