#define ENABLE_DEBUG_ERRORS
using UnityEngine;
using UnityEngine.UI;
using Utils;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
	[SerializeField]
	private string _textId = "";

	private Text _text;

	private void OnEnable()
	{
		LocalizeText();
	}

	public void LocalizeText()
	{
		if (_textId == null)
		{
			this.LogError("Please set the text ID that should be loaded for this Text (" + base.name + ")", "LocalizeText", 22);
			return;
		}
		if (!_text)
		{
			_text = GetComponent<Text>();
		}
		string localizedText = LocalizationUtility.GetLocalizedText(_textId);
		_text.text = localizedText;
	}
}
