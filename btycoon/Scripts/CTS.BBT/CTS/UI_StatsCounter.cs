using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class UI_StatsCounter : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _description;

		[SerializeField]
		private TMP_Text _counter;

		[SerializeField]
		private Image _backgroundImage;

		private PrestigeUIStatsSO _data;

		public TMP_Text Counter => _counter;

		private void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			if (_data != null)
			{
				_data.OnCurrentValueChanged -= OnValueChanged;
			}
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			_description.text = _data.Name.GetLocalizedStringSafe();
		}

		public void Init(PrestigeUIStatsSO data, Color backgroundColor)
		{
			_backgroundImage.color = backgroundColor;
			_data = data;
			_counter.text = data.CurrentValue.ToString();
			_description.text = _data.Name.GetLocalizedStringSafe();
			_data.OnCurrentValueChanged += OnValueChanged;
		}

		private void OnValueChanged(int value)
		{
			_counter.text = value.ToString();
		}
	}
}
