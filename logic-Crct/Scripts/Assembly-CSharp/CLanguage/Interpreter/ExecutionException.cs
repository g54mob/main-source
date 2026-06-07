using System;

namespace CLanguage.Interpreter
{
	public class ExecutionException : Exception
	{
		public ExecutionException(string message)
		{
		}

		public ExecutionException(string message, Exception innerException)
		{
		}
	}
}
