using System;

class minhaClasse
{
   static void Main(string[] args)
   {
     double a, b, c, delta, r1, r2;
     string[] entrada = Console.ReadLine().Split();   


     a = Convert.ToDouble(entrada[0]);
     b = Convert.ToDouble(entrada[1]);
     c = Convert.ToDouble(entrada[2]);

     delta = (b * b) - (4 * a * c);
     r1 = (-b + Math.Sqrt(delta)) / (2 * a);
     r2 = (-b - Math.Sqrt(delta)) / (2 * a);

     if (delta > 0 && a != 0 )
           {
             //complete a condicional
             Console.WriteLine("R1 = " + (r1).ToString("0.00000"));
             Console.WriteLine("R2 = " + (r2).ToString("0.00000"));
           }
           else
           {
               Console.WriteLine("Impossivel calcular");
           }

   }
}