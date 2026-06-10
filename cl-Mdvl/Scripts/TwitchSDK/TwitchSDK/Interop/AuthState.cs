using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class AuthState : IMarshallable
	{
		internal readonly int TypeCode = 824783168;

		public AuthStatus Status;

		public string[] Scopes;

		public override int GetHashCode()
		{
			return (13 * 7 + Status.GetHashCode()) * 7 + Scopes.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			AuthState authState = obj as AuthState;
			if (authState == null)
			{
				return false;
			}
			if (Status == authState.Status)
			{
				return Scopes == authState.Scopes;
			}
			return false;
		}

		public static bool operator ==(AuthState a, AuthState b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(AuthState a, AuthState b)
		{
			return !(a == b);
		}
	}
}
