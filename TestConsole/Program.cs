using AA.System;
using System;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Period test = Period.Today;
			Console.WriteLine("Today		: {0}",test);

			test = Period.ThisWeek;
			Console.WriteLine("This week	: {0}",test);

			test = Period.ThisMonth;
			Console.WriteLine("This month	: {0}", test);

			OrderedPeriods periods = new OrderedPeriods();

			

			Console.WriteLine("\n\nEnter to END");
			string end = Console.ReadLine();
		}
	}
}
