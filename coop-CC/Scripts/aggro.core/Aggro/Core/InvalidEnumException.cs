using System;

namespace Aggro.Core
{
	public class InvalidEnumException : Exception
	{
		public InvalidEnumException()
		{
		}

		public InvalidEnumException(string msg)
			: base(msg)
		{
		}

		public InvalidEnumException(object e)
			: base((e != null) ? e.ToString() : "<NULL>")
		{
		}
	}
}
