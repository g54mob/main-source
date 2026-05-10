using System;
using System.Runtime.InteropServices;

namespace Mono.Unix.Native
{
	[CLSCompliant(false)]
	public sealed class NativeConvert
	{
		public static readonly DateTime UnixEpoch;

		public static readonly DateTime LocalUnixEpoch;

		public static readonly TimeSpan LocalUtcOffset;

		private static readonly string[][] fopen_modes;

		private static void ThrowArgumentException(object value)
		{
		}

		[PreserveSig]
		private static extern int FromPollEvents(PollEvents value, out short rval);

		public static short FromPollEvents(PollEvents value)
		{
			return 0;
		}

		[PreserveSig]
		private static extern int ToPollEvents(short value, out PollEvents rval);

		public static PollEvents ToPollEvents(short value)
		{
			return default(PollEvents);
		}
	}
}
