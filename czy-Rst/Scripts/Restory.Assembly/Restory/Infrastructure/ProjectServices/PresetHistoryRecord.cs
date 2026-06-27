using Restory.Data.Locations;

namespace Restory.Infrastructure.ProjectServices
{
	public record PresetHistoryRecord
	{
		public ScenePresetType PresetType;

		public GameMode GameplayMode;

		public GameplaySubtype GameplaySubtype;

		public string PresetName;

		public GameScenesPreset Preset;
	}
}
