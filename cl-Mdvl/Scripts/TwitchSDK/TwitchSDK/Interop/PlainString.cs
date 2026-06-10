using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PlainString : IMarshallable
	{
		internal readonly int TypeCode = 988587891;

		public string Data;

		public override int GetHashCode()
		{
			return 13 * 7 + Data.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PlainString plainString = obj as PlainString;
			if (plainString == null)
			{
				return false;
			}
			return Data == plainString.Data;
		}

		public static bool operator ==(PlainString a, PlainString b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PlainString a, PlainString b)
		{
			return !(a == b);
		}
	}
}
