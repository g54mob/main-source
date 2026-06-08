namespace Amazon.Runtime.Internal
{
	public sealed class DeterminedCSMConfiguration
	{
		private static readonly DeterminedCSMConfiguration instance;

		public CSMConfiguration CSMConfiguration { get; set; }

		public static DeterminedCSMConfiguration Instance => instance;

		private DeterminedCSMConfiguration()
		{
			CSMConfiguration = new CSMFallbackConfigChain().GetCSMConfig();
		}

		static DeterminedCSMConfiguration()
		{
			instance = new DeterminedCSMConfiguration();
		}
	}
}
