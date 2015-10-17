namespace Test
{
	public static class Assert
	{
		public static void True(bool value)
		{
			if (!value)
			{
				throw new Test.AssertException("Expected true, but false.");
			}
		}
		
		public static void False(bool value)
		{
			if (value)
			{
				throw new Test.AssertException("Expected false, but true.");
			}
		}
	}
}