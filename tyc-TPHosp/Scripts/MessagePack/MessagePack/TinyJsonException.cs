using System;

namespace MessagePack
{
	internal class TinyJsonException : Exception
	{
		public TinyJsonException(string message)
			: base(message)
		{
		}
	}
}
