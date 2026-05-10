using System;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class UI_VigilanceStatsCounter : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _description;

		[SerializeField]
		private TMP_Text _counter;

		[SerializeField]
		private Image _backgroundDescription;

		[SerializeField]
		private Image _backgroundValue;

		[SerializeField]
		private PaletteData _positiveColor;

		[SerializeField]
		private PaletteData _negativeColor;

		private PrestigeUIStatsSO _data;

		private bool _isCurrentMounth;

		public static event Action OnCurrentValueChanged;

		private void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			if (_data != null)
			{
				if (_isCurrentMounth)
				{
					_data.OnCurrentValueChanged -= OnValueChanged;
				}
				else
				{
					_data.OnLastMounthValueChanged -= OnValueChanged;
				}
			}
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			_description.text = _data.Name.GetLocalizedStringSafe();
		}

		public void Init(PrestigeUIStatsSO data, Color backgroundColor, bool isCurrentMounth)
		{
			_isCurrentMounth = isCurrentMounth;
			_backgroundDescription.color = backgroundColor;
			_data = data;
			OnValueChanged(_isCurrentMounth ? _data.CurrentValue : _data.PreviousMounthValue);
			_description.text = _data.Name.GetLocalizedStringSafe();
			if (_isCurrentMounth)
			{
				_data.OnCurrentValueChanged += OnValueChanged;
			}
			else
			{
				_data.OnLastMounthValueChanged += OnValueChanged;
			}
		}

		private void OnValueChanged(int value)
		{
			_counter.text = ((value > 0) ? "+" : "") + value;
			_backgroundValue.color = ((value > 0) ? _positiveColor.GetColor() : _negativeColor.GetColor());
			if (_isCurrentMounth)
			{
				UI_VigilanceStatsCounter.OnCurrentValueChanged?.Invoke();
			}
		}
	}
}
