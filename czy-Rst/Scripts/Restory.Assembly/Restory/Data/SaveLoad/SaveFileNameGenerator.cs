using Restory.Data.GameConfigs;
using Zenject;

namespace Restory.Data.SaveLoad
{
	public class SaveFileNameGenerator
	{
		private readonly GameConfig gameConfig;

		private readonly SaveSystemSettings settings;

		[Inject]
		public SaveFileNameGenerator(GameConfig gameConfig, SaveSystemSettings settings)
		{
			this.gameConfig = gameConfig;
			this.settings = settings;
		}

		public string AutoSaveNameTemplate(SaveFileNameParameters parameters)
		{
			string text = gameConfig.VersionType switch
			{
				VersionType.Demo => settings.DemoPostfix, 
				VersionType.Playtest => settings.PlaytestPostfix, 
				_ => settings.ReleasePostfix, 
			};
			return $"{parameters.GameplayMode}{settings.SlotSeparator}{parameters.Profile}.{text}";
		}

		public string TemporarySaveFileName(SaveFileNameParameters parameters)
		{
			return settings.TempFileName;
		}
	}
}
