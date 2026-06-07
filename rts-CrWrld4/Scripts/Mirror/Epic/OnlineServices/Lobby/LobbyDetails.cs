using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	public sealed class LobbyDetails : Handle
	{
		public const int LobbydetailsCopyattributebyindexApiLatest = 1;

		public const int LobbydetailsCopyattributebykeyApiLatest = 1;

		public const int LobbydetailsCopyinfoApiLatest = 1;

		public const int LobbydetailsCopymemberattributebyindexApiLatest = 1;

		public const int LobbydetailsCopymemberattributebykeyApiLatest = 1;

		public const int LobbydetailsGetattributecountApiLatest = 1;

		public const int LobbydetailsGetlobbyownerApiLatest = 1;

		public const int LobbydetailsGetmemberattributecountApiLatest = 1;

		public const int LobbydetailsGetmemberbyindexApiLatest = 1;

		public const int LobbydetailsGetmembercountApiLatest = 1;

		public const int LobbydetailsInfoApiLatest = 1;

		public LobbyDetails()
		{
		}

		public LobbyDetails(IntPtr innerHandle)
		{
		}

		public Result CopyAttributeByIndex(LobbyDetailsCopyAttributeByIndexOptions options, out Attribute outAttribute)
		{
			outAttribute = null;
			return default(Result);
		}

		public Result CopyAttributeByKey(LobbyDetailsCopyAttributeByKeyOptions options, out Attribute outAttribute)
		{
			outAttribute = null;
			return default(Result);
		}

		public Result CopyInfo(LobbyDetailsCopyInfoOptions options, out LobbyDetailsInfo outLobbyDetailsInfo)
		{
			outLobbyDetailsInfo = null;
			return default(Result);
		}

		public Result CopyMemberAttributeByIndex(LobbyDetailsCopyMemberAttributeByIndexOptions options, out Attribute outAttribute)
		{
			outAttribute = null;
			return default(Result);
		}

		public Result CopyMemberAttributeByKey(LobbyDetailsCopyMemberAttributeByKeyOptions options, out Attribute outAttribute)
		{
			outAttribute = null;
			return default(Result);
		}

		public uint GetAttributeCount(LobbyDetailsGetAttributeCountOptions options)
		{
			return 0u;
		}

		public ProductUserId GetLobbyOwner(LobbyDetailsGetLobbyOwnerOptions options)
		{
			return null;
		}

		public uint GetMemberAttributeCount(LobbyDetailsGetMemberAttributeCountOptions options)
		{
			return 0u;
		}

		public ProductUserId GetMemberByIndex(LobbyDetailsGetMemberByIndexOptions options)
		{
			return null;
		}

		public uint GetMemberCount(LobbyDetailsGetMemberCountOptions options)
		{
			return 0u;
		}

		public void Release()
		{
		}

		[PreserveSig]
		internal static extern Result EOS_LobbyDetails_CopyAttributeByIndex(IntPtr handle, IntPtr options, ref IntPtr outAttribute);

		[PreserveSig]
		internal static extern Result EOS_LobbyDetails_CopyAttributeByKey(IntPtr handle, IntPtr options, ref IntPtr outAttribute);

		[PreserveSig]
		internal static extern Result EOS_LobbyDetails_CopyInfo(IntPtr handle, IntPtr options, ref IntPtr outLobbyDetailsInfo);

		[PreserveSig]
		internal static extern Result EOS_LobbyDetails_CopyMemberAttributeByIndex(IntPtr handle, IntPtr options, ref IntPtr outAttribute);

		[PreserveSig]
		internal static extern Result EOS_LobbyDetails_CopyMemberAttributeByKey(IntPtr handle, IntPtr options, ref IntPtr outAttribute);

		[PreserveSig]
		internal static extern uint EOS_LobbyDetails_GetAttributeCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern IntPtr EOS_LobbyDetails_GetLobbyOwner(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_LobbyDetails_GetMemberAttributeCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern IntPtr EOS_LobbyDetails_GetMemberByIndex(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_LobbyDetails_GetMemberCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_LobbyDetails_Release(IntPtr lobbyHandle);

		[PreserveSig]
		internal static extern void EOS_LobbyDetails_Info_Release(IntPtr lobbyDetailsInfo);
	}
}
