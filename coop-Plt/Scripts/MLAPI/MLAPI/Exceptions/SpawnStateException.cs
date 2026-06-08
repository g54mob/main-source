using System;

namespace MLAPI.Exceptions
{
	public class SpawnStateException : Exception
	{
		public SpawnStateException()
		{
		}

		public SpawnStateException(string message)
			: base(message)
		{
		}

		public SpawnStateException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
