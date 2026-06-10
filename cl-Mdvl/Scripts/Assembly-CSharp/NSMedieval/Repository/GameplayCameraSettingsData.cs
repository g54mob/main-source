using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class GameplayCameraSettingsData : DynamicSettingsData<GameplayCameraSettingsData, CameraSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/GameplayCameraSettings.json";
		}
	}
}
