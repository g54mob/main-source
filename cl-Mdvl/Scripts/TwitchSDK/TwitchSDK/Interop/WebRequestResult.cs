using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class WebRequestResult : IMarshallable
	{
		internal readonly int TypeCode = 706061000;

		public int HttpStatus;

		public string ResponseBody;

		public override int GetHashCode()
		{
			return (13 * 7 + HttpStatus.GetHashCode()) * 7 + ResponseBody.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			WebRequestResult webRequestResult = obj as WebRequestResult;
			if (webRequestResult == null)
			{
				return false;
			}
			if (HttpStatus == webRequestResult.HttpStatus)
			{
				return ResponseBody == webRequestResult.ResponseBody;
			}
			return false;
		}

		public static bool operator ==(WebRequestResult a, WebRequestResult b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(WebRequestResult a, WebRequestResult b)
		{
			return !(a == b);
		}
	}
}
