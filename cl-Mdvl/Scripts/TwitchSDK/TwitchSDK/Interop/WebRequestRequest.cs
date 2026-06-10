using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class WebRequestRequest : IMarshallableStartAsync, IMarshallable
	{
		internal readonly int TypeCode = -1855527540;

		public HttpMethod Method;

		public string Uri;

		public string ContentType;

		public string ClientId;

		public string Authorization;

		public string RequestBody;

		public GenericTaskCallback TaskCallback { get; set; }

		public IntPtr TaskCallbackPayload { get; set; }

		public override int GetHashCode()
		{
			return (((((13 * 7 + Method.GetHashCode()) * 7 + Uri.GetHashCode()) * 7 + ContentType.GetHashCode()) * 7 + ClientId.GetHashCode()) * 7 + Authorization.GetHashCode()) * 7 + RequestBody.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			WebRequestRequest webRequestRequest = obj as WebRequestRequest;
			if (webRequestRequest == null)
			{
				return false;
			}
			if (Method == webRequestRequest.Method && Uri == webRequestRequest.Uri && ContentType == webRequestRequest.ContentType && ClientId == webRequestRequest.ClientId && Authorization == webRequestRequest.Authorization)
			{
				return RequestBody == webRequestRequest.RequestBody;
			}
			return false;
		}

		public static bool operator ==(WebRequestRequest a, WebRequestRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(WebRequestRequest a, WebRequestRequest b)
		{
			return !(a == b);
		}
	}
}
