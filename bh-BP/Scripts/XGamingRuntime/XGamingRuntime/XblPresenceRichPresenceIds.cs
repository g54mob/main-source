namespace XGamingRuntime
{
	public class XblPresenceRichPresenceIds
	{
		public string ServiceConfigurationId { get; private set; }

		public string PresenceId { get; private set; }

		public string[] PresenceTokenIds { get; private set; }

		private XblPresenceRichPresenceIds(string serviceConfigurationId, string presenceId, string[] presenceTokenIds)
		{
		}

		public static int Create(string serviceConfigurationId, string presenceId, string[] presenceTokenIds, out XblPresenceRichPresenceIds richPresenceIds)
		{
			richPresenceIds = null;
			return 0;
		}
	}
}
