using System.Collections.Generic;
using System.Linq;
using SettingScripts;
using SimulationScripts;
using TMPro;

namespace UIScripts.SettingHandles
{
	public class MatterMaterialDropdown : SettingDropdown<MatterMaterialSetting, MatterMaterial>
	{
		public override void InitUIElement()
		{
			base.InitUIElement();
			MatterMaterialManager.onMaterialListChange.AddListener(PopulateList);
		}

		public override void ReleaseDependencies()
		{
			base.ReleaseDependencies();
			MatterMaterialManager.onMaterialListChange.RemoveListener(PopulateList);
		}

		public override void UpdateUIElement()
		{
			settingDropdownRef.dropdown.SetValueWithoutNotify(MatterMaterialManager.PhysicalMaterials.IndexOf(setting.val) + 1);
		}

		protected override void PopulateList()
		{
			settingDropdownRef.dropdown.options.Clear();
			List<MatterMaterial> physicalMaterials = MatterMaterialManager.PhysicalMaterials;
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData(setting.labelForNoTarget ?? "None")
			};
			list.AddRange(physicalMaterials.Select((MatterMaterial m) => new TMP_Dropdown.OptionData(m.Name)));
			settingDropdownRef.dropdown.AddOptions(list);
			if (setting.val == null || !physicalMaterials.Contains(setting.val))
			{
				setting.SetValue(null);
				settingDropdownRef.dropdown.value = 0;
			}
			else
			{
				settingDropdownRef.dropdown.value = physicalMaterials.IndexOf(setting.val) + 1;
			}
		}

		protected override void SetValueOfSetting(int val)
		{
			SetValue((val > 0) ? MatterMaterialManager.PhysicalMaterials[val - 1] : null);
		}

		public MatterMaterialDropdown()
		{
		}

		public MatterMaterialDropdown(MatterMaterialSetting _setting)
		{
			setting = _setting;
		}
	}
}
