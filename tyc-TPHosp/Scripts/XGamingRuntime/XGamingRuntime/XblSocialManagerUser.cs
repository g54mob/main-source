using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerUser
	{
		public ulong XboxUserId { get; }

		public bool IsFavorite { get; }

		public bool IsFollowingUser { get; }

		public bool IsFollowedByCaller { get; }

		public string DisplayName { get; }

		public string RealName { get; }

		public string DisplayPicUrlRaw { get; }

		public bool UseAvatar { get; }

		public string Gamerscore { get; }

		public string Gamertag { get; }

		public string ModernGamertag { get; }

		public string ModernGamertagSuffix { get; }

		public string UniqueModernGamertag { get; }

		public XblSocialManagerPresenceRecord PresenceRecord { get; }

		public XblTitleHistory TitleHistory { get; }

		public XblPreferredColor PreferredColor { get; }

		internal XblSocialManagerUser(XGamingRuntime.Interop.XblSocialManagerUser interopUser)
		{
			XboxUserId = interopUser.xboxUserId;
			IsFavorite = interopUser.isFavorite;
			IsFollowingUser = interopUser.isFollowingUser;
			IsFollowedByCaller = interopUser.isFollowedByCaller;
			DisplayName = Converters.ByteArrayToString(interopUser.displayName);
			RealName = Converters.ByteArrayToString(interopUser.realName);
			DisplayPicUrlRaw = Converters.ByteArrayToString(interopUser.displayPicUrlRaw);
			UseAvatar = interopUser.useAvatar;
			Gamerscore = Converters.ByteArrayToString(interopUser.gamerscore);
			Gamertag = Converters.ByteArrayToString(interopUser.gamertag);
			ModernGamertag = Converters.ByteArrayToString(interopUser.modernGamertag);
			ModernGamertagSuffix = Converters.ByteArrayToString(interopUser.modernGamertagSuffix);
			UniqueModernGamertag = Converters.ByteArrayToString(interopUser.uniqueModernGamertag);
			PresenceRecord = new XblSocialManagerPresenceRecord(interopUser.presenceRecord);
			TitleHistory = new XblTitleHistory(interopUser.titleHistory);
			PreferredColor = new XblPreferredColor(interopUser.preferredColor);
		}
	}
}
