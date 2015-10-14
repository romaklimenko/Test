using System;
using System.IO;

namespace Test
{
	static class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (var arg in args)
			{
				var path = Path.GetFullPath(arg);
				Console.WriteLine(path);
				Console.WriteLine(File.Exists(path));
				Console.WriteLine(arg);
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Hello from DNX!");
		}
	}
}