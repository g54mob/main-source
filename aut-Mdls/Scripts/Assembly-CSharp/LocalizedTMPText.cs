using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedTMPText : MonoBehaviour
{
	[SerializeField]
	private string _textId = "";

	[SerializeField]
	private List<string> _arguments;

	[SerializeField]
	private bool _convertToUpper;

	private TextMeshProUGUI _text;

	public string TextId => _textId;

	private void OnEnable()
	{
		LocalizeText();
		LocalizationUtility.OnLanguageUpdate += LocalizeText;
	}

	private void OnDisable()
	{
		LocalizationUtility.OnLanguageUpdate -= LocalizeText;
	}

	public void LocalizeText()
	{
		if (!LocalizationUtility.HasData() || _textId == null)
		{
			return;
		}
		if (!_text)
		{
			_text = GetComponent<TextMeshProUGUI>();
		}
		string text = LocalizationUtility.GetLocalizedText(_textId);
		if (text.Contains("{0}") && _arguments != null && _arguments.Count > 0)
		{
			for (int i = 0; i < _arguments.Count; i++)
			{
				string text2 = $"{{{i}}}";
				if (text.Contains(text2))
				{
					text = text.Replace(text2, _arguments[i]);
				}
			}
		}
		if (!_convertToUpper)
		{
			_text.SetText(text);
		}
		else
		{
			_text.SetText(text.ToUpper());
		}
	}

	public void UpdateTextId(string newId)
	{
		_textId = newId;
		LocalizeText();
	}

	public void SetArguments(params string[] args)
	{
		_arguments.Clear();
		_arguments.AddRange(args);
		LocalizeText();
	}
}
