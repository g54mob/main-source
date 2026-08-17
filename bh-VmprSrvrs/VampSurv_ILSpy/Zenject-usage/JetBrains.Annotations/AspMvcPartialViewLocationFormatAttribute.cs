using System;

namespace JetBrains.Annotations;

internal sealed class AspMvcPartialViewLocationFormatAttribute(string format) : Attribute
{
	private string _003CFormat_003Ek__BackingField = format;

	public string Format
	{
		get
		{
			return _003CFormat_003Ek__BackingField;
		}
		private set
		{
			_003CFormat_003Ek__BackingField = value;
		}
	}
}
