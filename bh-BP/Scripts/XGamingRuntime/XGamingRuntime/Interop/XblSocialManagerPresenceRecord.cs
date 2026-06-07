namespace XGamingRuntime.Interop
{
	internal struct XblSocialManagerPresenceRecord
	{
		internal readonly XblPresenceUserState userState;

		internal readonly XblSocialManagerPresenceTitleRecord[] presenceTitleRecords;

		internal readonly uint presenceTitleCount;

		internal XblSocialManagerPresenceRecord(XGamingRuntime.XblSocialManagerPresenceRecord presenceRecord)
		{
			userState = default(XblPresenceUserState);
			presenceTitleRecords = null;
			presenceTitleCount = 0u;
		}
	}
}
