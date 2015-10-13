using System;

namespace Test
{
	static class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (var arg in args)
			{
				Console.WriteLine(arg);
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Hello from DNX!");
		}
	}
}