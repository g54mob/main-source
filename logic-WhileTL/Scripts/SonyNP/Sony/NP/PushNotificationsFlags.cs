namespace Sony.NP
{
	public enum PushNotificationsFlags
	{
		None = 0,
		NewGameDataMessage = 1,
		NewInvitation = 2,
		UpdateBlockedUsersList = 4,
		UpdateFriendPresence = 8,
		UpdateFriendsList = 0x10,
		NewInGameMessage = 0x20
	}
}
