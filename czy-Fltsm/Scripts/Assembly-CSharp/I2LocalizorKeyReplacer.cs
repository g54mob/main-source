using System.Text.RegularExpressions;
using I2.Loc;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class I2LocalizorKeyReplacer : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text;

	private Regex _regex;

	public void ReplaceTerms()
	{
		_text.text = ReturnText();
	}

	protected virtual string ReturnText()
	{
		if (_regex == null)
		{
			_regex = new Regex("\\%(.*?)\\%", RegexOptions.IgnoreCase);
		}
		return _regex.Replace(_text.text, (Match m) => ReturnTranslation(m));
	}

	private string ReturnTranslation(Match match)
	{
		if (LocalizationManager.TryGetTranslation(match.Value.Replace("%", ""), out var Translation))
		{
			return Translation;
		}
		return match.Value;
	}
}
