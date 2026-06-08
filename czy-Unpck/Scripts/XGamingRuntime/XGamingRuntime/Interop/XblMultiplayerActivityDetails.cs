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

		internal unsafe string GetHandleId()
		{
			fixed (byte* handleId = HandleId)
			{
				return Converters.BytePointerToString(handleId, 40);
			}
		}

		internal unsafe XblMultiplayerActivityDetails(XGamingRuntime.XblMultiplayerActivityDetails publicObject, DisposableCollection disposableCollection)
		{
			SessionReference = new XblMultiplayerSessionReference(publicObject.SessionReference);
			fixed (byte* handleId = HandleId)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.HandleId, handleId, 40);
			}
			TitleId = publicObject.TitleId;
			Visibility = publicObject.Visibility;
			JoinRestriction = publicObject.JoinRestriction;
			Closed = new NativeBool(publicObject.Closed);
			OwnerXuid = publicObject.OwnerXuid;
			MaxMembersCount = publicObject.MaxMembersCount;
			MembersCount = publicObject.MembersCount;
			CustomSessionPropertiesJson = new UTF8StringPtr(publicObject.CustomSessionPropertiesJson, disposableCollection);
		}
	}
}
