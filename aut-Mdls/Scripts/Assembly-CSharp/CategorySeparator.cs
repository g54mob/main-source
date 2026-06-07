#define ENABLE_DEBUG_EXCEPTIONS
using TMPro;
using UnityEngine;
using Utils;

public class CategorySeparator : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text;

	private string _localizationKey;

	private void Awake()
	{
		LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
	}

	private void OnDestroy()
	{
		LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
	}

	private void OnLanguageUpdate()
	{
		_text.SetText(LocalizationUtility.GetLocalizedText(_localizationKey));
	}

	public void SetText(string localizationKey)
	{
		if (_text == null)
		{
			this.DevException("CategorySeparator has no TextMeshProUGUI!", "SetText", 30);
			return;
		}
		_localizationKey = localizationKey;
		_text.SetText(LocalizationUtility.GetLocalizedText(localizationKey));
	}
}
