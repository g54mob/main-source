using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class StructurePresetCameraSettingsData : DynamicSettingsData<StructurePresetCameraSettingsData, CameraSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/StructurePresetCameraSettings.json";
		}
	}
}
