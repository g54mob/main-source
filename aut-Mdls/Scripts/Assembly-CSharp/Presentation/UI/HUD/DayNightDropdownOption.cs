using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.HUD
{
	public class DayNightDropdownOption : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private CanvasGroup _content;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private GameObject _selected;

		private DayNightOptionData _optionData;

		private int _id;

		public Action<int> OnSelected = delegate
		{
		};

		public int ID => _id;

		public void SetSelected(bool value)
		{
			_selected.SetActive(value);
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnOptionSelected);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnOptionSelected);
		}

		private void OnOptionSelected()
		{
			OnSelected(_id);
		}

		public void Setup(int id, DayNightOptionData optionData)
		{
			_id = id;
			_optionData = optionData;
			LocalizationUtility.OnLanguageUpdate += SetTexts;
			SetTexts();
			_icon.sprite = optionData.IconSprite;
			_icon.color = optionData.IconColor;
			_content.alpha = optionData.Opacity;
		}

		private void SetTexts()
		{
			_text.SetText(LocalizationUtility.GetLocalizedText(_optionData.TextKey));
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= SetTexts;
		}
	}
}
