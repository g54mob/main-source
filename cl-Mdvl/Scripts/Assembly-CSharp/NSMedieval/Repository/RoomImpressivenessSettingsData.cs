using NSEipix.Repository;
using NSMedieval.RoomDetection;

namespace NSMedieval.Repository
{
	public class RoomImpressivenessSettingsData : DynamicSettingsData<RoomImpressivenessSettingsData, RoomImpressivenessSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/RoomImpressivenessSettings.json";
		}
	}
}
