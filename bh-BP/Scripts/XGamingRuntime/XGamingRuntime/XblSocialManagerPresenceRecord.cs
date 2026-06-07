using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerPresenceRecord
	{
		public XblSocialManagerPresenceTitleRecord[] PresenceTitleRecords;

		public XblPresenceUserState UserState { get; private set; }

		internal XblSocialManagerPresenceRecord(XGamingRuntime.Interop.XblSocialManagerPresenceRecord interopRecord)
		{
		}
	}
}
