namespace XGamingRuntime.Interop
{
	internal struct XblSocialManagerPresenceTitleRecord
	{
		internal readonly uint titleId;

		internal readonly byte[] titleName;

		internal readonly bool isTitleActive;

		internal readonly byte[] presenceText;

		internal readonly bool isBroadcasting;

		internal readonly XblPresenceDeviceType deviceType;

		internal readonly bool isPrimary;

		internal XblSocialManagerPresenceTitleRecord(XGamingRuntime.XblSocialManagerPresenceTitleRecord titleRecord)
		{
			titleId = 0u;
			titleName = null;
			isTitleActive = false;
			presenceText = null;
			isBroadcasting = false;
			deviceType = default(XblPresenceDeviceType);
			isPrimary = false;
		}
	}
}
