namespace Kitchen.NetworkSupport
{
	public enum SessionEvent
	{
		Null = 0,
		SwitchingToLocalOnly = 1,
		JoiningRemoteGame = 2,
		StartingHostedGame = 3,
		SwitchingToOnline = 4,
		PlayerBeingRemoved = 5,
		PlayerNotLive = 6,
		PlayerEntityInvalid = 7,
		DisconnectingPlayersOfSource = 8,
		DisconnectingPlayer = 9,
		DuplicatePlayersFound = 10
	}
}
