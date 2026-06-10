using NSEipix.Repository;

namespace NSMedieval.Manager.RaidPointsFactors
{
	public class BattleScalesSettingsData : SettingsData<BattleScalesSettingsData, BattleScaleSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/BattleScalesSettings.json";
		}
	}
}
