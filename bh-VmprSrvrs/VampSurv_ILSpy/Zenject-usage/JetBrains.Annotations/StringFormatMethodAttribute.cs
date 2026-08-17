using System;

namespace JetBrains.Annotations;

internal sealed class StringFormatMethodAttribute(string formatParameterName) : Attribute
{
	private string _003CFormatParameterName_003Ek__BackingField = formatParameterName;

	public string FormatParameterName
	{
		get
		{
			return _003CFormatParameterName_003Ek__BackingField;
		}
		private set
		{
			_003CFormatParameterName_003Ek__BackingField = value;
		}
	}
}
