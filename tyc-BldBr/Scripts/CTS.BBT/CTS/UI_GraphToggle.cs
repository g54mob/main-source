using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class UI_GraphToggle : MonoBehaviour
	{
		[SerializeField]
		private Image _checkboxBakground;

		[SerializeField]
		private TMP_Text _toggleText;

		private GraphDataline _toggleData;

		[field: SerializeField]
		public Toggle Toggle { get; private set; }

		private void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			Toggle.onValueChanged.AddListener(OnValueChanged);
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			Toggle.onValueChanged.RemoveListener(OnValueChanged);
		}

		public void Init(GraphDataline toggleData)
		{
			_toggleData = toggleData;
			_checkboxBakground.color = (Toggle.isOn ? _toggleData.colorActive : _toggleData.colorInactive);
			_toggleText.text = _toggleData.name.GetLocalizedStringSafe();
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			if (_toggleData.name != null)
			{
				_toggleText.text = _toggleData.name.GetLocalizedStringSafe();
			}
		}

		private void OnValueChanged(bool value)
		{
			_checkboxBakground.color = (Toggle.isOn ? _toggleData.colorActive : _toggleData.colorInactive);
		}
	}
}
