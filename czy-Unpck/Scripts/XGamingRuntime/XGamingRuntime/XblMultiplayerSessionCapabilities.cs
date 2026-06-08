using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionCapabilities
	{
		public bool Connectivity { get; private set; }

		public bool Team { get; private set; }

		public bool Arbitration { get; private set; }

		public bool SuppressPresenceActivityCheck { get; private set; }

		public bool Gameplay { get; private set; }

		public bool Large { get; private set; }

		public bool ConnectionRequiredForActiveMembers { get; private set; }

		public bool UserAuthorizationStyle { get; private set; }

		public bool Crossplay { get; private set; }

		public bool Searchable { get; private set; }

		public bool HasOwners { get; private set; }

		internal XblMultiplayerSessionCapabilities(XGamingRuntime.Interop.XblMultiplayerSessionCapabilities interopStruct)
		{
			Connectivity = interopStruct.Connectivity.Value;
			Team = interopStruct.Team.Value;
			Arbitration = interopStruct.Arbitration.Value;
			SuppressPresenceActivityCheck = interopStruct.SuppressPresenceActivityCheck.Value;
			Gameplay = interopStruct.Gameplay.Value;
			Large = interopStruct.Large.Value;
			ConnectionRequiredForActiveMembers = interopStruct.ConnectionRequiredForActiveMembers.Value;
			UserAuthorizationStyle = interopStruct.UserAuthorizationStyle.Value;
			Crossplay = interopStruct.Crossplay.Value;
			Searchable = interopStruct.Searchable.Value;
			HasOwners = interopStruct.HasOwners.Value;
		}
	}
}
