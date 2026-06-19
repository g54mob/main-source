namespace PlayFab.Multiplayer
{
	public struct MatchUser
	{
		public PFEntityKey LocalUser { get; set; }

		public string TeamId { get; set; }

		public string LocalUserJsonAttributesJSON { get; set; }

		public MatchUser(PlayFabAuthenticationContext localUser, string localUserJsonAttributesJSON, string teamId = "")
		{
			PlayFabMultiplayer.SetEntityToken(localUser);
			LocalUser = new PFEntityKey(localUser);
			TeamId = teamId;
			LocalUserJsonAttributesJSON = localUserJsonAttributesJSON;
		}

		public MatchUser(PFEntityKey localUser, string localUserJsonAttributesJSON, string teamId = "")
		{
			LocalUser = localUser;
			TeamId = teamId;
			LocalUserJsonAttributesJSON = localUserJsonAttributesJSON;
		}
	}
}
