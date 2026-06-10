using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CloseWebSocketRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -2145718554;

		public int Handle;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return 13 * 7 + Handle.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			CloseWebSocketRequest closeWebSocketRequest = obj as CloseWebSocketRequest;
			if (closeWebSocketRequest == null)
			{
				return false;
			}
			return Handle == closeWebSocketRequest.Handle;
		}

		public static bool operator ==(CloseWebSocketRequest a, CloseWebSocketRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(CloseWebSocketRequest a, CloseWebSocketRequest b)
		{
			return !(a == b);
		}
	}
}
