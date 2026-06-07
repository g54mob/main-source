using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionCapabilities
	{
		public bool Connectivity { get; set; }

		public bool Team { get; set; }

		public bool Arbitration { get; set; }

		public bool SuppressPresenceActivityCheck { get; set; }

		public bool Gameplay { get; set; }

		public bool Large { get; set; }

		public bool ConnectionRequiredForActiveMembers { get; set; }

		public bool UserAuthorizationStyle { get; set; }

		public bool Crossplay { get; set; }

		public bool Searchable { get; set; }

		public bool HasOwners { get; set; }

		public XblMultiplayerSessionCapabilities()
		{
		}

		internal XblMultiplayerSessionCapabilities(XGamingRuntime.Interop.XblMultiplayerSessionCapabilities interopStruct)
		{
		}
	}
}
