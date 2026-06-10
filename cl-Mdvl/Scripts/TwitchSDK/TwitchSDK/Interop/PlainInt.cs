using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PlainInt : IMarshallable
	{
		internal readonly int TypeCode = -1549817923;

		public int Data;

		public override int GetHashCode()
		{
			return 13 * 7 + Data.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PlainInt plainInt = obj as PlainInt;
			if (plainInt == null)
			{
				return false;
			}
			return Data == plainInt.Data;
		}

		public static bool operator ==(PlainInt a, PlainInt b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PlainInt a, PlainInt b)
		{
			return !(a == b);
		}
	}
}
