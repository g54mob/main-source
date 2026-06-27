using System;

namespace FluentAssertions.Execution
{
	public class AssertionFailedException : Exception, IAssertionException
	{
		public AssertionFailedException(string message)
			: base(message)
		{
		}
	}
}
