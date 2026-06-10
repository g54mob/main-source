using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class SleepRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -504035953;

		public int Milliseconds;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return 13 * 7 + Milliseconds.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			SleepRequest sleepRequest = obj as SleepRequest;
			if (sleepRequest == null)
			{
				return false;
			}
			return Milliseconds == sleepRequest.Milliseconds;
		}

		public static bool operator ==(SleepRequest a, SleepRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(SleepRequest a, SleepRequest b)
		{
			return !(a == b);
		}
	}
}
