namespace Multiplayer
{
	public enum AppSate
	{
		Startup = 0,
		Menu = 1,
		Customize = 2,
		LoadLevel = 3,
		PlayLevel = 4,
		ServerHost = 5,
		ServerLoadLobby = 6,
		ServerLobby = 7,
		ServerLoadLevel = 8,
		ServerPlayLevel = 9,
		ClientJoin = 10,
		ClientLoadLobby = 11,
		ClientLobby = 12,
		ClientLoadLevel = 13,
		ClientWaitServerLoad = 14,
		ClientPlayLevel = 15
	}
}
