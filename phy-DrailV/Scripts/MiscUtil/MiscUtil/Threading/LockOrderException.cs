using System;

namespace MiscUtil.Threading
{
	public class LockOrderException : Exception
	{
		internal LockOrderException(string message)
			: base(message)
		{
		}

		internal LockOrderException(string format, params object[] args)
			: this(string.Format(format, args))
		{
		}
	}
}
