using HSVPicker;
using ManagementScripts;
using SettingScripts;
using UIScripts.UIReferences;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class SettingsColorPicker : SettingHandle<ColorSetting, Color>
	{
		private ColorPickerReference reff;

		private EscapableAction closeOnEscape;

		public override void CreateUIElement(GameObject _parent)
		{
			reff = Object.Instantiate(UIPrefabsHolder.Instance.ColorPickerPrefab, _parent.transform).GetComponent<ColorPickerReference>();
			InitUIElement();
			UpdateUIElement();
			initialized = true;
		}

		public override void InitUIElement()
		{
			base.InitUIElement();
			closeOnEscape = new EscapableAction(Cancel);
			reff.colorDisplay.color = setting.val;
			reff.settingName.text = setting.Name;
			reff.tooltip.UpdateText(setting.Name, setting.HelperText);
			reff.resetButton.onClick.AddListener(ResetValue);
			ColorPicker colorPicker = reff.colorPicker;
			colorPicker.Setup.ShowAlpha = setting.allowAlphaChange;
			colorPicker.UpdateColorPresets(setting.presetColors);
			colorPicker.onSubmit.AddListener(Submit);
			colorPicker.onCancel.AddListener(Cancel);
			reff.onEnterPressed.AddListener(Submit);
			reff.colorPicker.gameObject.SetActive(value: true);
			colorPicker.Regenerate();
			reff.colorPicker.gameObject.SetActive(value: false);
			reff.colorButton.onClick.AddListener(OpenColorPickerPanel);
		}

		public void OpenColorPickerPanel()
		{
			reff.colorPicker.gameObject.SetActive(value: true);
			UINavigationManager.AddEscapableToStack(closeOnEscape);
		}

		public void CloseColorPickerPanel()
		{
			reff.colorPicker.gameObject.SetActive(value: false);
			UINavigationManager.RemoveEscapableFromStack(closeOnEscape);
		}

		public void Cancel()
		{
			reff.colorPicker.CurrentColor = setting.val;
			CloseColorPickerPanel();
		}

		public void Submit()
		{
			SetValue(reff.colorPicker.CurrentColor);
			CloseColorPickerPanel();
		}

		public override void UpdateUIElement()
		{
			Color val = setting.val;
			reff.colorDisplay.color = val;
			reff.colorPicker.AssignColor(val);
			Color32 color = val;
			reff.colorValue.text = (setting.allowAlphaChange ? $"#{color.r:X2}{color.g:X2}{color.b:X2}{color.a:X2}" : $"#{color.r:X2}{color.g:X2}{color.b:X2}");
			HsvColor hsvColor = HSVUtil.ConvertRgbToHsv(val);
			reff.colorValue.color = ((hsvColor.V > 0.5) ? Color.black : Color.white);
		}

		public override void HideUIElement()
		{
			reff.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			reff.gameObject.SetActive(value: true);
		}

		public SettingsColorPicker(ColorSetting _setting)
			: base(_setting, false)
		{
		}
	}
}
