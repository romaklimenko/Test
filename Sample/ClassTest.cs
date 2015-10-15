using System;
using Test;

namespace Sample.Tests
{
	[TestClass]
	public class ClassTest
	{
		[Test]
		public void ClassIntegerShouldReturn42()
		{
			var _class = new Class();
			var actual = _class.GetInteger();
			var expected = 42;
			Console.WriteLine(actual == expected);
		}
	}
}