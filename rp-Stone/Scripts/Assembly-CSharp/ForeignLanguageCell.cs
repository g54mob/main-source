using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ForeignLanguageCell : MonoBehaviour
{
	public float fontScale = 1.4f;

	public float fontScaleRU = 1.4f;

	public float fontScaleKR = 1.2f;

	public float fontScaleTK = 1.4f;

	public float fontScaleZH = 1.2f;

	public float fontScaleJP = 1.2f;

	private char _unicodeValue;

	private TextMeshProUGUI myGui;

	private RectTransform myRectTransform;

	private Vector4 initialMargin;

	private string _languageIdOverride;

	private static string lastLanguageId;

	private static float _scale = 1.25f;

	public char unicodeValue
	{
		get
		{
			return _unicodeValue;
		}
		set
		{
			_unicodeValue = SpecialSymbols.MapUnicode(value);
			myGui.text = _unicodeValue.ToString();
		}
	}

	public void SetColor(Color c)
	{
		myGui.color = c;
	}

	public void SetPosition(Vector2 newPos)
	{
		myRectTransform.anchoredPosition = newPos;
	}

	public void SetFontSize(float size)
	{
		myGui.fontSize = size * GetScale();
		Vector2 anchoredPosition = myRectTransform.anchoredPosition;
		anchoredPosition.x += size / 2f;
		myRectTransform.anchoredPosition = anchoredPosition;
		myGui.margin = initialMargin * size / 22f;
	}

	public void SetSizeOverrideLanguage(string languageIdOverride)
	{
		_languageIdOverride = languageIdOverride;
	}

	private float GetScale()
	{
		string text = Te.id;
		if (_languageIdOverride != null)
		{
			text = _languageIdOverride;
			_languageIdOverride = null;
		}
		if (lastLanguageId != text)
		{
			lastLanguageId = text;
			_scale = fontScale;
			if (lastLanguageId == "ZH-CN" || lastLanguageId == "ZH-TW")
			{
				_scale = fontScaleZH;
			}
			else if (lastLanguageId == "RU")
			{
				_scale = fontScaleRU;
			}
			else if (lastLanguageId == "JP")
			{
				_scale = fontScaleJP;
			}
			else if (lastLanguageId == "KR")
			{
				_scale = fontScaleKR;
			}
			else if (lastLanguageId == "TK")
			{
				_scale = fontScaleTK;
			}
		}
		return _scale;
	}

	public void SetHeight(float height)
	{
		myRectTransform.sizeDelta = new Vector2(0f, height);
	}

	public void Init()
	{
		myGui = GetComponent<TextMeshProUGUI>();
		myRectTransform = GetComponent<RectTransform>();
		initialMargin = myGui.margin;
	}
}
