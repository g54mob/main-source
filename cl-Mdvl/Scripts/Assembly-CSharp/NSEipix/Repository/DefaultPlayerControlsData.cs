using NSMedieval;

namespace NSEipix.Repository
{
	public class DefaultPlayerControlsData : SettingsData<DefaultPlayerControlsData, DefaultPlayerControls>
	{
		protected override string JsonFile()
		{
			return "Settings/DefaultPlayerControls.json";
		}
	}
}
