namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionCapabilities
	{
		internal readonly NativeBool Connectivity;

		internal readonly NativeBool Team;

		internal readonly NativeBool Arbitration;

		internal readonly NativeBool SuppressPresenceActivityCheck;

		internal readonly NativeBool Gameplay;

		internal readonly NativeBool Large;

		internal readonly NativeBool ConnectionRequiredForActiveMembers;

		internal readonly NativeBool UserAuthorizationStyle;

		internal readonly NativeBool Crossplay;

		internal readonly NativeBool Searchable;

		internal readonly NativeBool HasOwners;

		internal XblMultiplayerSessionCapabilities(XGamingRuntime.XblMultiplayerSessionCapabilities publicObject)
		{
			Connectivity = default(NativeBool);
			Team = default(NativeBool);
			Arbitration = default(NativeBool);
			SuppressPresenceActivityCheck = default(NativeBool);
			Gameplay = default(NativeBool);
			Large = default(NativeBool);
			ConnectionRequiredForActiveMembers = default(NativeBool);
			UserAuthorizationStyle = default(NativeBool);
			Crossplay = default(NativeBool);
			Searchable = default(NativeBool);
			HasOwners = default(NativeBool);
		}
	}
}
