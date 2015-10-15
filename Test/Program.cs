using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
				var assembly = Assembly.LoadFrom(path);
				var testClasses = GetTestClasses(assembly);
				foreach(Type testClass in testClasses)
				{
					Console.WriteLine(testClass.FullName);
				}
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Hello from DNX!");
		}
		
		public static IEnumerable<Type> GetTestClasses(Assembly assembly)
		{
				foreach(Type type in assembly.GetTypes()) {
					if (type.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0) {
						yield return type;
					}
				}
		}
	}
}