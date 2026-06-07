using System.Collections.Generic;
using System.Linq;
using SettingScripts;
using TMPro;

namespace UIScripts.SettingHandles
{
	public class TargetZoneDropdown : SettingDropdown<TargetZoneSetting, ZoneSettings>
	{
		public override void InitUIElement()
		{
			base.InitUIElement();
			ScenarioSettings.allZonesChanged.AddListener(PopulateList);
			ScenarioSettings.zoneNameChanged.AddListener(OnZoneNameChange);
		}

		public override void ReleaseDependencies()
		{
			base.ReleaseDependencies();
			ScenarioSettings.allZonesChanged.RemoveListener(PopulateList);
			ScenarioSettings.zoneNameChanged.RemoveListener(OnZoneNameChange);
		}

		public override void UpdateUIElement()
		{
			settingDropdownRef.dropdown.SetValueWithoutNotify(ScenarioSettings.Instance.allZones.IndexOf(setting.val) + 1);
		}

		protected override void PopulateList()
		{
			settingDropdownRef.dropdown.options.Clear();
			List<ZoneSettings> zones = ScenarioSettings.Instance.zones;
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData(setting.labelForNoTarget ?? "None")
			};
			list.AddRange(zones.Select((ZoneSettings z) => new TMP_Dropdown.OptionData(z.zoneName.val)));
			settingDropdownRef.dropdown.AddOptions(list);
			if (setting.val == null || !zones.Contains(setting.val))
			{
				setting.SetValue(null);
				settingDropdownRef.dropdown.value = 0;
			}
			else
			{
				settingDropdownRef.dropdown.value = zones.IndexOf(setting.val) + 1;
			}
		}

		private void OnZoneNameChange(int i, string newName)
		{
			if (i + 1 < settingDropdownRef.dropdown.options.Count)
			{
				settingDropdownRef.dropdown.options[i + 1].text = newName;
				settingDropdownRef.dropdown.RefreshShownValue();
			}
		}

		protected override void SetValueOfSetting(int val)
		{
			SetValue((val > 0) ? ScenarioSettings.Instance.zones[val - 1] : null);
		}

		public TargetZoneDropdown()
		{
		}

		public TargetZoneDropdown(TargetZoneSetting _setting)
		{
			setting = _setting;
		}
	}
}
