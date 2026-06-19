using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbySearchConfiguration
	{
		public PFLobbySearchFriendsFilter FriendsFilter { get; set; }

		public string FilterString { get; set; }

		public string SortString { get; set; }

		public uint? ClientSearchResultCount { get; set; }

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbySearchConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFLobbySearchConfiguration interopStruct = default(PlayFab.Multiplayer.Interop.PFLobbySearchConfiguration);
			if (FriendsFilter != null)
			{
				interopStruct.friendsFilter = FriendsFilter.ToPointer(disposableCollection);
			}
			else
			{
				interopStruct.friendsFilter = null;
			}
			if (!string.IsNullOrEmpty(FilterString))
			{
				interopStruct.filterString = new UTF8StringPtr(FilterString, disposableCollection).Pointer;
			}
			else
			{
				interopStruct.filterString = null;
			}
			if (!string.IsNullOrEmpty(SortString))
			{
				interopStruct.sortString = new UTF8StringPtr(SortString, disposableCollection).Pointer;
			}
			else
			{
				interopStruct.sortString = null;
			}
			if (ClientSearchResultCount.HasValue)
			{
				interopStruct.clientSearchResultCount = (uint*)(void*)Converters.StructToPtr(ClientSearchResultCount.Value, disposableCollection);
			}
			else
			{
				interopStruct.clientSearchResultCount = null;
			}
			return (PlayFab.Multiplayer.Interop.PFLobbySearchConfiguration*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
