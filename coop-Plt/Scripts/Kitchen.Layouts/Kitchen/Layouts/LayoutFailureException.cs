using System;

namespace Kitchen.Layouts
{
	public class LayoutFailureException : Exception
	{
		public LayoutFailureException()
		{
		}

		public LayoutFailureException(string message)
			: base(message)
		{
		}

		public LayoutFailureException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
