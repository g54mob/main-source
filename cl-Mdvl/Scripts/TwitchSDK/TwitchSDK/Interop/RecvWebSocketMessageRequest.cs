using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class RecvWebSocketMessageRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = 1869071618;

		public int Handle;

		public int TimeoutSeconds;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return (13 * 7 + Handle.GetHashCode()) * 7 + TimeoutSeconds.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			RecvWebSocketMessageRequest recvWebSocketMessageRequest = obj as RecvWebSocketMessageRequest;
			if (recvWebSocketMessageRequest == null)
			{
				return false;
			}
			if (Handle == recvWebSocketMessageRequest.Handle)
			{
				return TimeoutSeconds == recvWebSocketMessageRequest.TimeoutSeconds;
			}
			return false;
		}

		public static bool operator ==(RecvWebSocketMessageRequest a, RecvWebSocketMessageRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(RecvWebSocketMessageRequest a, RecvWebSocketMessageRequest b)
		{
			return !(a == b);
		}
	}
}
