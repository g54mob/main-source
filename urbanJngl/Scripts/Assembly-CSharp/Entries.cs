using System;
using System.Collections.Generic;

public class Entries
{
	private Type _type;

	private Type Type
	{
		get
		{
			if (_type == null)
			{
				_type = GetType();
			}
			return _type;
		}
	}

	public bool published { get; set; }

	public string url { get; set; }

	public string title { get; set; }

	public string title_Chinese { get; set; }

	public string title_French { get; set; }

	public string title_German { get; set; }

	public string title_Japanese { get; set; }

	public string title_Korean { get; set; }

	public string title_Russian { get; set; }

	public string title_Spanish { get; set; }

	public string title_BrazilianPortuguese { get; set; }

	public string excerpt { get; set; }

	public string excerpt_BrazilianPortuguese { get; set; }

	public string excerpt_Chinese { get; set; }

	public string excerpt_French { get; set; }

	public string excerpt_German { get; set; }

	public string excerpt_Japanese { get; set; }

	public string excerpt_Korean { get; set; }

	public string excerpt_Russian { get; set; }

	public string excerpt_Spanish { get; set; }

	public string content { get; set; }

	public string content_Chinese { get; set; }

	public string content_French { get; set; }

	public string content_German { get; set; }

	public string content_Japanese { get; set; }

	public string content_Korean { get; set; }

	public string content_Russian { get; set; }

	public string content_Spanish { get; set; }

	public string content_BrazilianPortuguese { get; set; }

	public bool pinned { get; set; }

	public GentlymadImage image { get; set; }

	public List<string> tags { get; set; }

	public List<string> defines { get; set; }

	private string GetLocalized(string contentType, string language)
	{
		string name = contentType + "_" + language;
		if (Type.GetProperty(name) != null)
		{
			return (string)Type.GetProperty(name).GetValue(this);
		}
		return null;
	}

	public string GetLocalizedTitle(string language)
	{
		string localized = GetLocalized("title", language);
		if (localized != null)
		{
			return localized;
		}
		return title;
	}

	public string GetLocalizedContent(string language)
	{
		string localized = GetLocalized("content", language);
		if (localized != null)
		{
			return localized;
		}
		return content;
	}

	public string GetLocalizedExcerpt(string language)
	{
		string localized = GetLocalized("excerpt", language);
		if (localized != null)
		{
			return localized;
		}
		return excerpt;
	}
}
