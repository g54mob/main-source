namespace XGamingRuntime.Interop
{
	internal struct XblSocialManagerUser
	{
		internal readonly ulong xboxUserId;

		internal readonly bool isFavorite;

		internal readonly bool isFollowingUser;

		internal readonly bool isFollowedByCaller;

		internal readonly byte[] displayName;

		internal readonly byte[] realName;

		internal readonly byte[] displayPicUrlRaw;

		internal readonly bool useAvatar;

		internal readonly byte[] gamerscore;

		internal readonly byte[] gamertag;

		internal readonly byte[] modernGamertag;

		internal readonly byte[] modernGamertagSuffix;

		internal readonly byte[] uniqueModernGamertag;

		internal readonly XblSocialManagerPresenceRecord presenceRecord;

		internal readonly XblTitleHistory titleHistory;

		internal readonly XblPreferredColor preferredColor;
	}
}
