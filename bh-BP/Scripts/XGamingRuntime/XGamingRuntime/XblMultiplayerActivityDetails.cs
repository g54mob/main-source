using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerActivityDetails
	{
		public XblMultiplayerSessionReference SessionReference { get; private set; }

		public string HandleId { get; private set; }

		public uint TitleId { get; private set; }

		public XblMultiplayerSessionVisibility Visibility { get; private set; }

		public XblMultiplayerSessionRestriction JoinRestriction { get; private set; }

		public bool Closed { get; private set; }

		public ulong OwnerXuid { get; private set; }

		public uint MaxMembersCount { get; private set; }

		public uint MembersCount { get; private set; }

		public string CustomSessionPropertiesJson { get; private set; }

		internal XblMultiplayerActivityDetails(XGamingRuntime.Interop.XblMultiplayerActivityDetails interopStruct)
		{
		}
	}
}
