namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerActivityDetails
	{
		internal readonly XblMultiplayerSessionReference SessionReference;

		private unsafe fixed byte HandleId[40];

		internal readonly uint TitleId;

		internal readonly XblMultiplayerSessionVisibility Visibility;

		internal readonly XblMultiplayerSessionRestriction JoinRestriction;

		internal readonly NativeBool Closed;

		internal readonly ulong OwnerXuid;

		internal readonly uint MaxMembersCount;

		internal readonly uint MembersCount;

		internal readonly UTF8StringPtr CustomSessionPropertiesJson;

		internal string GetHandleId()
		{
			return null;
		}

		internal XblMultiplayerActivityDetails(XGamingRuntime.XblMultiplayerActivityDetails publicObject, DisposableCollection disposableCollection)
		{
			SessionReference = default(XblMultiplayerSessionReference);
			TitleId = 0u;
			Visibility = default(XblMultiplayerSessionVisibility);
			JoinRestriction = default(XblMultiplayerSessionRestriction);
			Closed = default(NativeBool);
			OwnerXuid = 0uL;
			MaxMembersCount = 0u;
			MembersCount = 0u;
			CustomSessionPropertiesJson = default(UTF8StringPtr);
		}
	}
}
