using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class MarshalException : IMarshallable
	{
		internal readonly int TypeCode = -1875581513;

		public string What;

		public override int GetHashCode()
		{
			return 13 * 7 + What.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			MarshalException ex = obj as MarshalException;
			if (ex == null)
			{
				return false;
			}
			return What == ex.What;
		}

		public static bool operator ==(MarshalException a, MarshalException b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(MarshalException a, MarshalException b)
		{
			return !(a == b);
		}
	}
}
