namespace Platforms
{
	public struct NetworkInviteData
	{
		public string Identifier;

		public string InviteString;

		public int AvailableSlots;

		public string AsJoinCode()
		{
			string inviteOfPrefix = PlatformHelpers.GetInviteOfPrefix(InviteString, "STEAM_CODE:");
			if (inviteOfPrefix != null)
			{
				return inviteOfPrefix;
			}
			string inviteOfPrefix2 = PlatformHelpers.GetInviteOfPrefix(InviteString, "PHOTON_CODE:");
			if (inviteOfPrefix2 != null)
			{
				return inviteOfPrefix2;
			}
			return "";
		}

		public static NetworkInviteData FromInviteString(string platform_prefix, string platform_invite)
		{
			return new NetworkInviteData
			{
				InviteString = PlatformHelpers.CreateNetworkInvite(platform_prefix, platform_invite)
			};
		}
	}
}
