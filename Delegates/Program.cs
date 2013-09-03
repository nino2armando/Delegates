using System;
using System.Linq.Expressions;

namespace Delegates
{
    class Program
    {
        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Standard delegate call---------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //static double CalculateArea(int r)
        //{
        //    return 3.14*r*r;
        //}

        //delegate double CalculateAreaPointer(int r);

        //static CalculateAreaPointer calArea = CalculateArea;

        //static void Main(string[] args)
        //{
        //    double area = calArea.Invoke(20);

        //    Console.WriteLine(area.ToString());

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Anounymous method call---------------------------------------
        //-----------------------------------------------------------------------------------------------------------------

        //delegate double CalculateAreaPointer(int r);

        //static void Main(string[] args)
        //{
        //    // standard call
        //    CalculateAreaPointer calculate = new CalculateAreaPointer(delegate(int r)
        //        {
        //            return 3.14*r*r;
        //        });

        //    // lambda call
        //    var calculateLambda = new CalculateAreaPointer(r => 3.14*r*r);

        //    double area1 = calculate.Invoke(20);

        //    double area2 = calculateLambda.Invoke(20);

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Delegate Lambda expression-----------------------------------
        //-----------------------------------------------------------------------------------------------------------------

        //delegate double CalculateAreaPointer(int r);

        //static void Main(string[] args)
        //{
        //    CalculateAreaPointer calculate = r => 3.14 * r * r;

        //    double area = calculate.Invoke(20);

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Delegate Lambda + Func<int, out>-----------------------------
        //-----------------------------------------------------------------------------------------------------------------

        //static void Main(string[] args)
        //{           
        //    Func<double, double> calculate = r => 3.14 * r * r;

        //    double area = calculate.Invoke(20);

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Action Example (void return)---------------------------------
        //-----------------------------------------------------------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Action<string> parseString = s => Console.WriteLine(s);

        //    parseString.Invoke("Nino's Cat");
        //    // or
        //    parseString("Nino's Cat");

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Predicate Example (bool return)------------------------------
        //-----------------------------------------------------------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Predicate<string> CheckLength = c => c.Length > 4;

        //    var isGreater = CheckLength("Nino's Cat");
        //    Console.WriteLine(isGreater.ToString());

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Predicate Example In List------------------------------------
        //-----------------------------------------------------------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    List<string> lst = new List<string>()
        //        {
        //            "Nino's Cat", "is a stray", "cat"
        //        };

        //    Predicate<string> CheckLength = c => c.Length > 4;

        //    var result = lst.Find(CheckLength);

        //    Console.WriteLine(result);

        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------Expression Trees example-------------------------------------
        //-----------------------------------------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            // building an expression tree for (10 + 2) - (3 + 4)

            // (10 + 2)
            BinaryExpression firstAdd = Expression.MakeBinary(ExpressionType.Add,
                                                              Expression.Constant(10),
                                                              Expression.Constant(2));
            // (3 + 4)
            BinaryExpression secondAdd = Expression.MakeBinary(ExpressionType.Add,
                                                               Expression.Constant(3),
                                                               Expression.Constant(4));
            // (10 + 2) - (3 + 4)
            BinaryExpression subAll = Expression.MakeBinary(ExpressionType.Subtract, firstAdd, secondAdd);

            int result = Expression.Lambda<Func<int>>(subAll).Compile()();
            
            Console.ReadKey();
        }
    }
}
