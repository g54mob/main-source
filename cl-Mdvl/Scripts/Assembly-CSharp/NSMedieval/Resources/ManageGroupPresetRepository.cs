using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;

namespace NSMedieval.Resources
{
	public class ManageGroupPresetRepository : PresetRepository<ManageGroupPresetRepository, ManageGroupPreset>
	{
		protected override string UserPresetsPath()
		{
			return "UserData/ManageGroupPresets.json";
		}

		public bool IsDefault(ManageGroupPreset preset)
		{
			return GetAllItems().Any((ManageGroupPreset p) => p.GetID().Equals(preset.GetID()));
		}

		public override void UpdateUserPreset(ManageGroupPreset preset)
		{
			base.UserPresets.RemoveWhere((ManageGroupPreset item) => item.GetID() == preset.GetID());
			ManageGroupPreset clone = GetClone(preset);
			base.UserPresets.Add(clone);
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.OnEquipmentPresetUpdated(clone);
			}
			SaveUserPresets();
		}

		public void UpdateUserPresets(List<ManageGroupPreset> presets)
		{
			base.UserPresets.Clear();
			foreach (ManageGroupPreset preset in presets)
			{
				ManageGroupPreset clone = GetClone(preset);
				base.UserPresets.Add(clone);
			}
			SaveUserPresets();
		}

		public bool IsLocked(string presetId)
		{
			return GetAllItems().Any((ManageGroupPreset p) => p.GetID().Equals(presetId));
		}

		private static ManageGroupPreset GetClone(ManageGroupPreset preset)
		{
			return new ManageGroupPreset(preset.GetID(), preset.DisplayName, preset.GroupId, new FloatRange(preset.HitpointsMin, preset.HitpointsMax), new IntRange(preset.QualityMin, preset.QualityMax), preset.DefaultAllowedResources, preset.DefaultForbiddenResources, preset.DefaultPreset, preset.ForceUnequipInvalid, preset.YearlyOverrideAllowedResources, preset.YearlyOverrideForbiddenResources, preset.YearlyOverrideDateMin, preset.YearlyOverrideDateMax, preset.IsYearlyOverrideEnabled);
		}

		protected override string JsonFile()
		{
			return "Resources/ManageGroupPreset.json";
		}
	}
}
