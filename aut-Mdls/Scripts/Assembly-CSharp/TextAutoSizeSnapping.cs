using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class TextAutoSizeSnapping : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _fromText;

	[SerializeField]
	private TMP_Text _toText;

	[SerializeField]
	private List<float> _fontSizes = new List<float>();

	private void Start()
	{
		_fromText.OnPreRenderText += OnPreRenderText;
	}

	private void OnDestroy()
	{
		_fromText.OnPreRenderText -= OnPreRenderText;
	}

	private void OnPreRenderText(TMP_TextInfo info)
	{
		CopyValuesFromText();
	}

	[Button(null, EButtonEnableMode.Always)]
	private void CopyValuesFromText()
	{
		_toText.SetText(_fromText.text);
		_toText.color = _fromText.color;
		_toText.alignment = _fromText.alignment;
		foreach (float fontSize in _fontSizes)
		{
			if (_fromText.fontSize >= fontSize)
			{
				_toText.fontSize = fontSize;
				return;
			}
		}
		_toText.fontSize = _fromText.fontSize;
	}
}
