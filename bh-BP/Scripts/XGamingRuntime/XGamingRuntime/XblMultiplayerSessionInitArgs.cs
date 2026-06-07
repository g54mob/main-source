using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionInitArgs
	{
		public uint MaxMembersInSession { get; private set; }

		public XblMultiplayerSessionVisibility Visibility { get; private set; }

		public ulong[] InitiatorXuids { get; private set; }

		public string CustomJson { get; private set; }

		public XblMultiplayerSessionInitArgs(uint maxMembers, XblMultiplayerSessionVisibility visibility, string customJson, params ulong[] initiatorXuids)
		{
		}

		internal XblMultiplayerSessionInitArgs(XGamingRuntime.Interop.XblMultiplayerSessionInitArgs interopStruct)
		{
		}
	}
}
