using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class LogRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = 1210189489;

		public LogLevel Level;

		public string Message;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return (13 * 7 + Level.GetHashCode()) * 7 + Message.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			LogRequest logRequest = obj as LogRequest;
			if (logRequest == null)
			{
				return false;
			}
			if (Level == logRequest.Level)
			{
				return Message == logRequest.Message;
			}
			return false;
		}

		public static bool operator ==(LogRequest a, LogRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(LogRequest a, LogRequest b)
		{
			return !(a == b);
		}
	}
}
