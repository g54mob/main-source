using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class UIHelpListToggle : MonoBehaviour
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private TMP_Text _toggleText;

		[SerializeField]
		private Sprite _selectedSprite;

		[SerializeField]
		private Sprite _unselectedSprite;

		private Color _defaultColor;

		[field: SerializeField]
		public Toggle Toggle { get; private set; }

		public UIGifsListSO GifsList { get; private set; }

		public static event Action<UIGifsListSO> OnHelpGiftChanged;

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

		public void Init(Color color, UIGifsListSO gifsList)
		{
			GifsList = gifsList;
			_defaultColor = color;
			_image.color = color;
			_toggleText.text = GifsList.HelpName.GetLocalizedString();
		}

		private void OnValueChanged(bool isOn)
		{
			_image.sprite = (isOn ? _selectedSprite : _unselectedSprite);
			_image.color = (isOn ? Color.white : _defaultColor);
			if (isOn)
			{
				UIHelpListToggle.OnHelpGiftChanged?.Invoke(GifsList);
			}
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			if (!(GifsList == null))
			{
				_toggleText.text = GifsList.HelpName.GetLocalizedString();
			}
		}
	}
}
