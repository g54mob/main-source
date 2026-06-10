using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class AuthenticationInfo : IMarshallable
	{
		internal readonly int TypeCode = -256913275;

		public string Uri;

		public string UserCode;

		public override int GetHashCode()
		{
			return (13 * 7 + Uri.GetHashCode()) * 7 + UserCode.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			AuthenticationInfo authenticationInfo = obj as AuthenticationInfo;
			if (authenticationInfo == null)
			{
				return false;
			}
			if (Uri == authenticationInfo.Uri)
			{
				return UserCode == authenticationInfo.UserCode;
			}
			return false;
		}

		public static bool operator ==(AuthenticationInfo a, AuthenticationInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(AuthenticationInfo a, AuthenticationInfo b)
		{
			return !(a == b);
		}
	}
}
