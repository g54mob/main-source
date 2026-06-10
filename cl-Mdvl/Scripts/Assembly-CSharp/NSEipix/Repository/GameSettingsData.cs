using NSMedieval;

namespace NSEipix.Repository
{
	public class GameSettingsData : SettingsData<GameSettingsData, GameSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/GameSettings.json";
		}
	}
}
