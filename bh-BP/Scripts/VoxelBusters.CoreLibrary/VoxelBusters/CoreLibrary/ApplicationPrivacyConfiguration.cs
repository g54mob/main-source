namespace VoxelBusters.CoreLibrary
{
	public class ApplicationPrivacyConfiguration
	{
		public ConsentStatus UsageConsent { get; private set; }

		public bool? IsAgeRestrictedUser { get; private set; }

		public ContentRating? PreferredContentRating { get; private set; }

		public bool? DoNotSell { get; set; }

		public string Version { get; private set; }

		public ApplicationPrivacyConfiguration(ConsentStatus usageConsent, bool? isAgeRestrictedUser = null, ContentRating? preferredContentRating = null, bool? doNotSell = null, string version = null)
		{
		}

		public bool? IsCoppaApplicable()
		{
			return null;
		}
	}
}
