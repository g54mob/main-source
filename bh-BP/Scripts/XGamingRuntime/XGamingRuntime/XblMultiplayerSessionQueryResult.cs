using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionQueryResult
	{
		public long StartTime;

		public XblMultiplayerSessionReference SessionReference;

		public XblMultiplayerSessionStatus Status;

		public XblMultiplayerSessionVisibility Visibility;

		public bool IsMyTurn;

		public ulong Xuid;

		public uint AcceptedMemberCount;

		public XblMultiplayerSessionRestriction JoinRestriction;

		internal XblMultiplayerSessionQueryResult(XGamingRuntime.Interop.XblMultiplayerSessionQueryResult other)
		{
		}
	}
}
