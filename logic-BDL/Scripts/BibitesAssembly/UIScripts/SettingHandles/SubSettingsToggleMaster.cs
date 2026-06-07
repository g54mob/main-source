using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class SubSettingsToggleMaster : SettingHandle<Setting<bool>, bool>
	{
		public SubSettingToggleMasterReference ToggleRef;

		public override void CreateUIElement(GameObject _parent)
		{
			ToggleRef = Object.Instantiate(UIPrefabsHolder.Instance.SubSettingsToggleMasterPrefab, _parent.transform).GetComponent<SubSettingToggleMasterReference>();
			InitUIElement();
			initialized = true;
		}

		public override void InitUIElement()
		{
			base.InitUIElement();
			if (ToggleRef.toggle != null)
			{
				ToggleRef.toggle.onValueChanged.AddListener(base.SetValue);
			}
			if (ToggleRef.helperButton != null)
			{
				ToggleRef.helperButton.WikiLink = setting.WikiLink;
			}
			if (ToggleRef.settingName != null)
			{
				ToggleRef.settingName.text = setting.Name;
				TooltipTrigger component = ToggleRef.settingName.gameObject.GetComponent<TooltipTrigger>();
				if (component != null && !string.IsNullOrEmpty(setting.HelperText) && !string.IsNullOrEmpty(setting.HelperText))
				{
					component.UpdateText(setting.Name, setting.HelperText);
				}
			}
			if (ToggleRef.helperText != null)
			{
				ToggleRef.helperText.text = "Info : \n" + setting.HelperText;
				ToggleRef.helperText.transform.parent.parent.gameObject.SetActive(value: false);
			}
			UpdateUIElement();
		}

		public override void UpdateUIElement()
		{
			ToggleRef.toggle.isOn = setting.val;
		}

		public override void HideUIElement()
		{
			ToggleRef.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			ToggleRef.gameObject.SetActive(value: true);
		}

		public SubSettingsToggleMaster(Setting<bool> _setting)
			: base(_setting, false)
		{
		}
	}
}
