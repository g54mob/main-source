using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	public sealed class LobbySearch : Handle
	{
		public const int LobbysearchCopysearchresultbyindexApiLatest = 1;

		public const int LobbysearchFindApiLatest = 1;

		public const int LobbysearchGetsearchresultcountApiLatest = 1;

		public const int LobbysearchRemoveparameterApiLatest = 1;

		public const int LobbysearchSetlobbyidApiLatest = 1;

		public const int LobbysearchSetmaxresultsApiLatest = 1;

		public const int LobbysearchSetparameterApiLatest = 1;

		public const int LobbysearchSettargetuseridApiLatest = 1;

		public LobbySearch()
		{
		}

		public LobbySearch(IntPtr innerHandle)
		{
		}

		public Result CopySearchResultByIndex(LobbySearchCopySearchResultByIndexOptions options, out LobbyDetails outLobbyDetailsHandle)
		{
			outLobbyDetailsHandle = null;
			return default(Result);
		}

		public void Find(LobbySearchFindOptions options, object clientData, LobbySearchOnFindCallback completionDelegate)
		{
		}

		public uint GetSearchResultCount(LobbySearchGetSearchResultCountOptions options)
		{
			return 0u;
		}

		public void Release()
		{
		}

		public Result RemoveParameter(LobbySearchRemoveParameterOptions options)
		{
			return default(Result);
		}

		public Result SetLobbyId(LobbySearchSetLobbyIdOptions options)
		{
			return default(Result);
		}

		public Result SetMaxResults(LobbySearchSetMaxResultsOptions options)
		{
			return default(Result);
		}

		public Result SetParameter(LobbySearchSetParameterOptions options)
		{
			return default(Result);
		}

		public Result SetTargetUserId(LobbySearchSetTargetUserIdOptions options)
		{
			return default(Result);
		}

		internal static void OnFindCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_LobbySearch_CopySearchResultByIndex(IntPtr handle, IntPtr options, ref IntPtr outLobbyDetailsHandle);

		[PreserveSig]
		internal static extern void EOS_LobbySearch_Find(IntPtr handle, IntPtr options, IntPtr clientData, LobbySearchOnFindCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern uint EOS_LobbySearch_GetSearchResultCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_LobbySearch_Release(IntPtr lobbySearchHandle);

		[PreserveSig]
		internal static extern Result EOS_LobbySearch_RemoveParameter(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbySearch_SetLobbyId(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbySearch_SetMaxResults(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbySearch_SetParameter(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbySearch_SetTargetUserId(IntPtr handle, IntPtr options);
	}
}
