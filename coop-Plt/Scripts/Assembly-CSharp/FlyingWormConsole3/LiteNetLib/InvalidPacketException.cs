using System;

namespace FlyingWormConsole3.LiteNetLib
{
	public class InvalidPacketException : ArgumentException
	{
		public InvalidPacketException(string message)
			: base(message)
		{
		}
	}
}
