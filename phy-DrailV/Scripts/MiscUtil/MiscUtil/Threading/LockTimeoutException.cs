using System;

namespace MiscUtil.Threading
{
	public class LockTimeoutException : Exception
	{
		internal LockTimeoutException(string message)
			: base(message)
		{
		}

		internal LockTimeoutException(string format, params object[] args)
			: this(string.Format(format, args))
		{
		}
	}
}
