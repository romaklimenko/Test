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
			foreach (var arg in args)
			{
				var path = Path.GetFullPath(arg);
				var testAssembly = Assembly.LoadFrom(path);
				var testTypes = GetTestTypes(testAssembly);
				foreach(Type testType in testTypes)
				{
					Console.WriteLine("{0}:", testType.FullName);
					
					var testMethodInfos = GetTestMethodInfos(testType);
					foreach (var testMethodInfo in testMethodInfos)
					{
						Console.WriteLine("  {0}:", testMethodInfo.Name);
						object instance = Activator.CreateInstance(testType, null);
						try
						{
							testMethodInfo.Invoke(instance, null);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("    Success.");
							Console.ResetColor();
						}
						catch (TargetInvocationException targetInvocationException)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine(
								"    Failure: {0}", 
								targetInvocationException.InnerException.Message);
							Console.ResetColor();
						}
					}
				}
			}
		}
		
		public static IEnumerable<Type> GetTestTypes(Assembly testAssembly)
		{
				foreach(Type testType in testAssembly.GetTypes())
				{
					if (testType.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0)
					{
						yield return testType;
					}
				}
		}
		
		public static IEnumerable<MethodInfo> GetTestMethodInfos(Type testType)
		{
			foreach (var testMethodInfo in testType.GetMethods())
			{
				if (testMethodInfo.GetCustomAttributes(typeof(TestAttribute), true).Length > 0)
				{
					yield return testMethodInfo;
				}
			}
		}
	}
}