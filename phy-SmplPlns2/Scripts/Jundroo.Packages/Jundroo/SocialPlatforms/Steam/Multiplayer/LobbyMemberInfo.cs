namespace Jundroo.SocialPlatforms.Steam.Multiplayer
{
	public struct LobbyMemberInfo
	{
		public string PersonaName;

		public ulong UserId;

		public LobbyMemberInfo(ulong userId, string personaName)
		{
			UserId = userId;
			PersonaName = personaName;
		}
	}
}
