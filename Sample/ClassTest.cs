using Test;

namespace Sample.Tests
{
	[TestClass]
	public class ClassTest
	{
		[Test]
		public void ClassIntegerShouldReturn314()
		{
			var _class = new Class();
			var actual = _class.GetInteger();
			var expected = 314;
			Assert.True(actual == expected);
		}

		[Test]
		public void ThisTestShouldFail()
		{
			Assert.False(true);
		}
	}
}