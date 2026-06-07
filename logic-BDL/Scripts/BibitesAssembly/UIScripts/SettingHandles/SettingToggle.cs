using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles
{
	public class SettingToggle : SettingHandle<Setting<bool>, bool>
	{
		private SettingToggleReference ToggleRef;

		public Toggle toggle => ToggleRef.toggle;

		public override void CreateUIElement(GameObject _parent)
		{
			LinkToRef(Object.Instantiate(UIPrefabsHolder.Instance.BoolSettingPrefab, _parent.transform).GetComponent<SettingToggleReference>());
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
			}
			if (ToggleRef.tooltip != null)
			{
				if (!string.IsNullOrEmpty(setting.HelperText))
				{
					ToggleRef.tooltip.UpdateText(setting.Name, setting.HelperText);
				}
			}
			else if (ToggleRef.settingName != null)
			{
				TooltipTrigger component = ToggleRef.settingName.gameObject.GetComponent<TooltipTrigger>();
				if (component != null && !string.IsNullOrEmpty(setting.HelperText))
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

		public void InitUIElement(SettingToggleReference toggleRef)
		{
			LinkToRef(toggleRef);
			InitUIElement();
		}

		public void LinkToRef(SettingToggleReference toggleRef)
		{
			ToggleRef = toggleRef;
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

		public SettingToggle(Setting<bool> _setting, SettingToggleReference reference)
		{
			setting = _setting;
			InitUIElement(reference);
		}

		public SettingToggle(Setting<bool> _setting)
			: base(_setting, false)
		{
		}

		public SettingToggle()
		{
		}
	}
}
