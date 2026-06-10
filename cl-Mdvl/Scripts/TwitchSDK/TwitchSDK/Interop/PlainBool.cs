using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PlainBool : IMarshallable
	{
		internal readonly int TypeCode = 288933883;

		public bool Data;

		public override int GetHashCode()
		{
			return 13 * 7 + Data.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PlainBool plainBool = obj as PlainBool;
			if (plainBool == null)
			{
				return false;
			}
			return Data == plainBool.Data;
		}

		public static bool operator ==(PlainBool a, PlainBool b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PlainBool a, PlainBool b)
		{
			return !(a == b);
		}
	}
}
