using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class StreamQuery : IMarshallable
	{
		internal readonly int TypeCode = -1548732846;

		public string After;

		public int First;

		public string[] GameIds;

		public string[] Languages;

		public string[] UserIds;

		public string[] UserLogins;

		public override int GetHashCode()
		{
			return (((((13 * 7 + After.GetHashCode()) * 7 + First.GetHashCode()) * 7 + GameIds.GetHashCode()) * 7 + Languages.GetHashCode()) * 7 + UserIds.GetHashCode()) * 7 + UserLogins.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			StreamQuery streamQuery = obj as StreamQuery;
			if (streamQuery == null)
			{
				return false;
			}
			if (After == streamQuery.After && First == streamQuery.First && GameIds == streamQuery.GameIds && Languages == streamQuery.Languages && UserIds == streamQuery.UserIds)
			{
				return UserLogins == streamQuery.UserLogins;
			}
			return false;
		}

		public static bool operator ==(StreamQuery a, StreamQuery b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(StreamQuery a, StreamQuery b)
		{
			return !(a == b);
		}
	}
}
