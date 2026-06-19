using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbySearchFriendsFilter
	{
		public bool IncludeSteamFriends { get; set; }

		public bool IncludeFacebookFriends { get; set; }

		public string IncludeXboxFriendsToken { get; set; }

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbySearchFriendsFilter* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFLobbySearchFriendsFilter interopStruct = new PlayFab.Multiplayer.Interop.PFLobbySearchFriendsFilter
			{
				includeSteamFriends = IncludeSteamFriends,
				includeFacebookFriends = IncludeFacebookFriends
			};
			if (!string.IsNullOrEmpty(IncludeXboxFriendsToken))
			{
				interopStruct.includeXboxFriendsToken = new UTF8StringPtr(IncludeXboxFriendsToken, disposableCollection).Pointer;
			}
			return (PlayFab.Multiplayer.Interop.PFLobbySearchFriendsFilter*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
