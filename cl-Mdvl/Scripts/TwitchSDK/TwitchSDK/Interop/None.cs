using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class None : IMarshallable
	{
		internal readonly int TypeCode = -1503227594;

		public override int GetHashCode()
		{
			return 13;
		}

		public override bool Equals(object obj)
		{
			if (obj as None == null)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(None a, None b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(None a, None b)
		{
			return !(a == b);
		}
	}
}
