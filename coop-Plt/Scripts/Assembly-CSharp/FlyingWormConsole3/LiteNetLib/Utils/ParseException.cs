using System;

namespace FlyingWormConsole3.LiteNetLib.Utils
{
	public class ParseException : Exception
	{
		public ParseException(string message)
			: base(message)
		{
		}
	}
}
