using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class UserInfo : IMarshallable
	{
		internal readonly int TypeCode = -1969979977;

		public string ChannelId;

		public string LoginName;

		public string DisplayName;

		public string UserType;

		public string BroadcasterType;

		public string Description;

		public string ProfileImageUrl;

		public string OfflineImageUrl;

		public long ViewCount;

		public string CreatedAt;

		public string Email;

		public override int GetHashCode()
		{
			return ((((((((((13 * 7 + ChannelId.GetHashCode()) * 7 + LoginName.GetHashCode()) * 7 + DisplayName.GetHashCode()) * 7 + UserType.GetHashCode()) * 7 + BroadcasterType.GetHashCode()) * 7 + Description.GetHashCode()) * 7 + ProfileImageUrl.GetHashCode()) * 7 + OfflineImageUrl.GetHashCode()) * 7 + ViewCount.GetHashCode()) * 7 + CreatedAt.GetHashCode()) * 7 + Email.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			UserInfo userInfo = obj as UserInfo;
			if (userInfo == null)
			{
				return false;
			}
			if (ChannelId == userInfo.ChannelId && LoginName == userInfo.LoginName && DisplayName == userInfo.DisplayName && UserType == userInfo.UserType && BroadcasterType == userInfo.BroadcasterType && Description == userInfo.Description && ProfileImageUrl == userInfo.ProfileImageUrl && OfflineImageUrl == userInfo.OfflineImageUrl && ViewCount == userInfo.ViewCount && CreatedAt == userInfo.CreatedAt)
			{
				return Email == userInfo.Email;
			}
			return false;
		}

		public static bool operator ==(UserInfo a, UserInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(UserInfo a, UserInfo b)
		{
			return !(a == b);
		}
	}
}
