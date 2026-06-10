using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class SendWebSocketMessageRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -223523082;

		public int Handle;

		public string Message;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return (13 * 7 + Handle.GetHashCode()) * 7 + Message.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			SendWebSocketMessageRequest sendWebSocketMessageRequest = obj as SendWebSocketMessageRequest;
			if (sendWebSocketMessageRequest == null)
			{
				return false;
			}
			if (Handle == sendWebSocketMessageRequest.Handle)
			{
				return Message == sendWebSocketMessageRequest.Message;
			}
			return false;
		}

		public static bool operator ==(SendWebSocketMessageRequest a, SendWebSocketMessageRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(SendWebSocketMessageRequest a, SendWebSocketMessageRequest b)
		{
			return !(a == b);
		}
	}
}
