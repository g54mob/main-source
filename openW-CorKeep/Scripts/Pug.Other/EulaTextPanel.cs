using System;
using I2.Loc;
using TMPro;
using UnityEngine;

public class EulaTextPanel : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	private TMP_FontAsset _defaultFont;

	[SerializeField]
	private TMP_FontAsset _chineseTradFont;

	[SerializeField]
	private TMP_FontAsset _chineseSimpFont;

	[SerializeField]
	private TMP_FontAsset _japaneseFont;

	[SerializeField]
	private TMP_FontAsset _koreanFont;

	[SerializeField]
	private TMP_FontAsset _thaiFont;

	[SerializeField]
	private TMP_FontAsset _russianUkranianFont;

	private int _eulaTextCount = 60;

	private LanguageSource _source;

	private string _localizedFullString;

	private void Awake()
	{
		if (_text == null)
		{
			_text = GetComponentInChildren<TextMeshProUGUI>();
		}
		_source = GetComponent<LanguageSource>();
	}

	private void Start()
	{
		CombineEulaTexts();
	}

	private void SetFont(string languageCode)
	{
		switch (languageCode.ToLower())
		{
		case "ko":
			_text.font = _koreanFont;
			break;
		case "ja":
			_text.font = _japaneseFont;
			break;
		case "th":
			_text.font = _thaiFont;
			break;
		case "zh-cn":
		case "zh-hans":
			_text.font = _chineseSimpFont;
			break;
		case "zh-tw":
		case "zh-hant":
			_text.font = _chineseTradFont;
			break;
		case "ru":
		case "uk":
			_text.font = _russianUkranianFont;
			break;
		default:
			_text.font = _defaultFont;
			break;
		}
	}

	private void CombineEulaTexts()
	{
		SetFont(LocalizationManager.CurrentLanguageCode);
		string text = "";
		for (int i = 1; i <= _eulaTextCount; i++)
		{
			text = _source.SourceData.GetTranslation("EULA/Eula" + i);
			_localizedFullString = _localizedFullString + text + Environment.NewLine + Environment.NewLine;
		}
		_text.text = _localizedFullString;
	}
}
