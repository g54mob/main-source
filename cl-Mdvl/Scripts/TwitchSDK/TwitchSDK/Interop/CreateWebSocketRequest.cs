using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CreateWebSocketRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -1487905959;

		public string Url;

		public string Protocol;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return (13 * 7 + Url.GetHashCode()) * 7 + Protocol.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			CreateWebSocketRequest createWebSocketRequest = obj as CreateWebSocketRequest;
			if (createWebSocketRequest == null)
			{
				return false;
			}
			if (Url == createWebSocketRequest.Url)
			{
				return Protocol == createWebSocketRequest.Protocol;
			}
			return false;
		}

		public static bool operator ==(CreateWebSocketRequest a, CreateWebSocketRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(CreateWebSocketRequest a, CreateWebSocketRequest b)
		{
			return !(a == b);
		}
	}
}
