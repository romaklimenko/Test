using System;

namespace Test
{
	[System.Serializable]
	public class AssertException : Exception
	{
		public AssertException() { }
		public AssertException( string message ) : base( message ) { }
		public AssertException( string message, Exception inner ) : base( message, inner ) { }
		protected AssertException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
	}
}