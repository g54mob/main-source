using System;

namespace FlyingWormConsole3.LiteNetLib.Utils
{
	public class InvalidTypeException : ArgumentException
	{
		public InvalidTypeException(string message)
			: base(message)
		{
		}
	}
}
