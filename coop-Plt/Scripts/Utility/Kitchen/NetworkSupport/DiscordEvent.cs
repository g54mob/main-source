namespace Kitchen.NetworkSupport
{
	public enum DiscordEvent
	{
		Null = 0,
		FailedToOpenInvite = 1,
		FailedToOpenGuildInvite = 2,
		ActivityJoinRequest = 3,
		JoiningGame = 4,
		EditorUsingSecondaryDiscord = 5,
		ActivityFailedToUpdate = 6,
		ActivityUpdate = 7,
		ActivityFailedToClear = 8,
		ActivityCleared = 9,
		DiscordNotPresent = 10
	}
}
