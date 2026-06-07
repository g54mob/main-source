using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls
{
	public class EnumFlagItem : MonoBehaviour
	{
		public UILabel Label;

		public GameObject Checkbox;

		public GameObject Questionmark;

		private FlagEnumSettingControl _control;

		private bool _isActive;

		private bool _isUnknown;

		public Enum EnumValue;

		public void Init(FlagEnumSettingControl control, Enum enumValue, bool isActive, bool isUnkown)
		{
			_isActive = isActive;
			EnumValue = enumValue;
			Label.text = enumValue.ToLocalizationString();
			Label.UpdateNGUIText();
			_isUnknown = true;
			_control = control;
			Questionmark.gameObject.SetActive(isUnkown);
			Checkbox.SetActive(isActive && !isUnkown);
		}

		public void OnClick()
		{
			if (_isUnknown)
			{
				_isActive = true;
			}
			else
			{
				_isActive = !_isActive;
			}
			_isUnknown = false;
			Checkbox.SetActive(_isActive);
			_control.SetActive(EnumValue, _isActive);
			Questionmark.gameObject.SetActive(false);
		}

		public void OnTooltip(bool show)
		{
			if (Label.processedText != Label.text)
			{
				NimbatusToolTip.Show(Label.text, show);
			}
		}

		public void UpdateCheckmark(bool active, bool unknown)
		{
			_isActive = active;
			_isUnknown = unknown;
			Questionmark.gameObject.SetActive(_isUnknown);
			Checkbox.SetActive(_isActive && !_isUnknown);
		}
	}
}
