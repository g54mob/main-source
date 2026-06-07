using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sanctions
{
	public sealed class SanctionsInterface : Handle
	{
		public const int CopyplayersanctionbyindexApiLatest = 1;

		public const int GetplayersanctioncountApiLatest = 1;

		public const int PlayersanctionApiLatest = 1;

		public const int QueryactiveplayersanctionsApiLatest = 2;

		public SanctionsInterface()
		{
		}

		public SanctionsInterface(IntPtr innerHandle)
		{
		}

		public Result CopyPlayerSanctionByIndex(CopyPlayerSanctionByIndexOptions options, out PlayerSanction outSanction)
		{
			outSanction = null;
			return default(Result);
		}

		public uint GetPlayerSanctionCount(GetPlayerSanctionCountOptions options)
		{
			return 0u;
		}

		public void QueryActivePlayerSanctions(QueryActivePlayerSanctionsOptions options, object clientData, OnQueryActivePlayerSanctionsCallback completionDelegate)
		{
		}

		internal static void OnQueryActivePlayerSanctionsCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Sanctions_CopyPlayerSanctionByIndex(IntPtr handle, IntPtr options, ref IntPtr outSanction);

		[PreserveSig]
		internal static extern uint EOS_Sanctions_GetPlayerSanctionCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Sanctions_QueryActivePlayerSanctions(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryActivePlayerSanctionsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sanctions_PlayerSanction_Release(IntPtr sanction);
	}
}
