using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionCapabilities
	{
		public bool Connectivity { get; }

		public bool Team { get; }

		public bool Arbitration { get; }

		public bool SuppressPresenceActivityCheck { get; }

		public bool Gameplay { get; }

		public bool Large { get; }

		public bool ConnectionRequiredForActiveMembers { get; }

		public bool UserAuthorizationStyle { get; }

		public bool Crossplay { get; }

		public bool Searchable { get; }

		public bool HasOwners { get; }

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
