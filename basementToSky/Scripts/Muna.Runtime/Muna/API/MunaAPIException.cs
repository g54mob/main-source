using System;

namespace Muna.API
{
	public sealed class MunaAPIException : Exception
	{
		public readonly int status;

		public MunaAPIException(string message, int status)
			: base(message)
		{
			this.status = status;
		}
	}
}
