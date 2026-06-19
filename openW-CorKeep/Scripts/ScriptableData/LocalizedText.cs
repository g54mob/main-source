using System;
using UnityEngine;

[Serializable]
public struct LocalizedText
{
	[SerializeField]
	[HideInInspector]
	private DataBlockRef<LanguageDataBlock> m_language;

	public string title;

	[TextArea(4, 20)]
	public string description;

	public LocalizedText(DataBlockAddress address)
	{
		m_language = address;
		title = (description = null);
	}

	public string GetTitle(string fallback)
	{
		if (!string.IsNullOrEmpty(title))
		{
			return title;
		}
		return "<" + fallback + ">";
	}

	public string GetDescription(string fallback)
	{
		if (!string.IsNullOrEmpty(description))
		{
			return description;
		}
		return "<" + fallback + ">";
	}
}
