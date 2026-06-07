using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public class ButtonContentSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private List<Sprite> _iconSprites;

		[SerializeField]
		private List<string> _locaKeys;

		private RectTransform _rectTransf;

		private List<string> _strings;

		private int _currentIndex;

		private void Awake()
		{
			_rectTransf = base.transform as RectTransform;
			_strings = new List<string>(_locaKeys.Count);
			SetLocaStrings();
			LocalizationUtility.OnLanguageUpdate += OnChangeLanguage;
		}

		private void SetLocaStrings()
		{
			_strings.Clear();
			for (int i = 0; i < _locaKeys.Count; i++)
			{
				_strings.Add(LocalizationUtility.GetLocalizedText(_locaKeys[i]));
			}
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnChangeLanguage;
		}

		public void SetContentByIndex(int index)
		{
			_currentIndex = index;
			_icon.sprite = _iconSprites[index];
			_text.SetText(_strings[index]);
			_rectTransf.ForceUpdateRectTransforms();
		}

		private void OnChangeLanguage()
		{
			SetLocaStrings();
			_text.SetText(_strings[_currentIndex]);
		}
	}
}
