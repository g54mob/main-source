using System;

namespace JetBrains.Annotations;

internal sealed class HtmlElementAttributesAttribute : Attribute
{
	private string _003CName_003Ek__BackingField;

	public string Name
	{
		get
		{
			return _003CName_003Ek__BackingField;
		}
		private set
		{
			_003CName_003Ek__BackingField = value;
		}
	}

	public HtmlElementAttributesAttribute()
	{
	}

	public HtmlElementAttributesAttribute(string name)
	{
		_003CName_003Ek__BackingField = name;
	}
}
