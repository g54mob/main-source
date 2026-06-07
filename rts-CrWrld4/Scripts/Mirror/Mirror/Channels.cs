using System;

namespace Mirror
{
	public static class Channels
	{
		public const int Reliable = 0;

		public const int Unreliable = 1;

		[Obsolete]
		public const int DefaultReliable = 0;

		[Obsolete]
		public const int DefaultUnreliable = 1;
	}
}
