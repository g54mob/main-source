using NSEipix;

namespace NSMedieval.Resources
{
	public class CharacterPresetRepository : PresetRepository<CharacterPresetRepository, WorkerInstancePreset>
	{
		public override void Deserialize()
		{
		}

		protected override string UserPresetsPath()
		{
			return "UserData/CharacterPresets.json";
		}

		public override void UpdateUserPreset(WorkerInstancePreset preset)
		{
			base.UserPresets.RemoveWhere((WorkerInstancePreset workerInstancePreset) => workerInstancePreset.GetID() == preset.GetID());
			WorkerInstancePreset item = new WorkerInstancePreset(preset.GetID(), preset.Name, preset.Instance);
			base.UserPresets.Add(item);
			SaveUserPresets();
		}

		public new void DeleteUserPreset(WorkerInstancePreset preset)
		{
			if (base.UserPresets.Contains(preset))
			{
				base.UserPresets.Remove(preset);
			}
			SaveUserPresets();
		}

		protected override string JsonFile()
		{
			return string.Empty;
		}
	}
}
