using NSMedieval;

namespace NSEipix.Repository
{
	public class AchievementSettingsData : SettingsData<AchievementSettingsData, AchievementSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/AchievementSettings.json";
		}
	}
}
