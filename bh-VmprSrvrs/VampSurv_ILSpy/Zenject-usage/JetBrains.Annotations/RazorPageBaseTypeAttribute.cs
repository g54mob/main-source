using System;

namespace JetBrains.Annotations;

internal sealed class RazorPageBaseTypeAttribute : Attribute
{
	private string _003CBaseType_003Ek__BackingField;

	private string _003CPageName_003Ek__BackingField;

	public string BaseType
	{
		get
		{
			return _003CBaseType_003Ek__BackingField;
		}
		private set
		{
			_003CBaseType_003Ek__BackingField = value;
		}
	}

	public string PageName
	{
		get
		{
			return _003CPageName_003Ek__BackingField;
		}
		private set
		{
			_003CPageName_003Ek__BackingField = value;
		}
	}

	public RazorPageBaseTypeAttribute(string baseType)
	{
		_003CBaseType_003Ek__BackingField = baseType;
	}

	public RazorPageBaseTypeAttribute(string baseType, string pageName)
	{
		_003CBaseType_003Ek__BackingField = baseType;
		_003CPageName_003Ek__BackingField = pageName;
	}
}
