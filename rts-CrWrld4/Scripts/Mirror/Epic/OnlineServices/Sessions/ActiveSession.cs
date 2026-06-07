using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	public sealed class ActiveSession : Handle
	{
		public const int ActivesessionCopyinfoApiLatest = 1;

		public const int ActivesessionGetregisteredplayerbyindexApiLatest = 1;

		public const int ActivesessionGetregisteredplayercountApiLatest = 1;

		public const int ActivesessionInfoApiLatest = 1;

		public ActiveSession()
		{
		}

		public ActiveSession(IntPtr innerHandle)
		{
		}

		public Result CopyInfo(ActiveSessionCopyInfoOptions options, out ActiveSessionInfo outActiveSessionInfo)
		{
			outActiveSessionInfo = null;
			return default(Result);
		}

		public ProductUserId GetRegisteredPlayerByIndex(ActiveSessionGetRegisteredPlayerByIndexOptions options)
		{
			return null;
		}

		public uint GetRegisteredPlayerCount(ActiveSessionGetRegisteredPlayerCountOptions options)
		{
			return 0u;
		}

		public void Release()
		{
		}

		[PreserveSig]
		internal static extern Result EOS_ActiveSession_CopyInfo(IntPtr handle, IntPtr options, ref IntPtr outActiveSessionInfo);

		[PreserveSig]
		internal static extern IntPtr EOS_ActiveSession_GetRegisteredPlayerByIndex(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_ActiveSession_GetRegisteredPlayerCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_ActiveSession_Release(IntPtr activeSessionHandle);

		[PreserveSig]
		internal static extern void EOS_ActiveSession_Info_Release(IntPtr activeSessionInfo);
	}
}
