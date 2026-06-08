using System;

namespace kcp2k
{
	public static class Log
	{
		public static Action<string> Info;

		public static Action<string> Warning;

		public static Action<string> Error;
	}
}
