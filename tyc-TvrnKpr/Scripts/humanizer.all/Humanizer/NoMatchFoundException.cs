using System;

namespace Humanizer
{
	public class NoMatchFoundException : Exception
	{
		public NoMatchFoundException()
		{
		}

		public NoMatchFoundException(string message)
		{
		}

		public NoMatchFoundException(string message, Exception inner)
		{
		}
	}
}
