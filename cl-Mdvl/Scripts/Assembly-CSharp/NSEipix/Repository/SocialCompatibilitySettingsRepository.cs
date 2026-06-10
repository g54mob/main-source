using Social;

namespace NSEipix.Repository
{
	public class SocialCompatibilitySettingsRepository : DynamicJsonRepository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>
	{
		protected override string JsonFile()
		{
			return "SocialInteraction/SocialCompatibilitySettings.json";
		}

		public SocialCompatibilitySettings Settings(string id = "default")
		{
			return GetByID(id);
		}
	}
}
