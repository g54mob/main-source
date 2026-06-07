using System;

namespace Assets.Scripts.Craft.Exceptions
{
	public class CraftLoadAbortedException : Exception
	{
		public CraftLoadAbortedException()
		{
		}

		public CraftLoadAbortedException(string message)
			: base(message)
		{
		}

		public CraftLoadAbortedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
