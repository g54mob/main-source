using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class PhotoCameraSettingsData : DynamicSettingsData<PhotoCameraSettingsData, CameraSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/PhotoCameraSettings.json";
		}
	}
}
