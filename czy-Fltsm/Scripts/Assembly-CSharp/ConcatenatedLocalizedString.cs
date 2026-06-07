using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[Serializable]
public class ConcatenatedLocalizedString
{
	public enum Separators
	{
		None = 0,
		Space = 1,
		CarriageReturn = 2,
		LineFeed = 3,
		NewLine = 4,
		Paragraph = 5
	}

	[SerializeField]
	private List<LocalizedString> _localizedStrings = new List<LocalizedString>();

	[SerializeField]
	private Separators _separator;

	[SerializeField]
	private bool _cache;

	private string _cachedTranslation;

	public override string ToString()
	{
		if (_cache && _cachedTranslation != null)
		{
			return _cachedTranslation;
		}
		_cachedTranslation = string.Join(ReturnSeparator(), _localizedStrings);
		return _cachedTranslation;
	}

	public void AddLocalizedString(LocalizedString str)
	{
		_localizedStrings.Add(str);
	}

	public bool HasText()
	{
		if (_localizedStrings != null && _localizedStrings.Count > 0)
		{
			return (string)_localizedStrings.Find((LocalizedString str) => !str.ToString().IsNullOrEmpty()) != null;
		}
		return false;
	}

	private string ReturnSeparator()
	{
		return _separator switch
		{
			Separators.Space => " ", 
			Separators.CarriageReturn => "\r", 
			Separators.LineFeed => "\n", 
			Separators.NewLine => "\r\n", 
			Separators.Paragraph => "\r\n\r\n", 
			_ => "", 
		};
	}

	public static implicit operator string(ConcatenatedLocalizedString str)
	{
		return str.ToString();
	}
}
