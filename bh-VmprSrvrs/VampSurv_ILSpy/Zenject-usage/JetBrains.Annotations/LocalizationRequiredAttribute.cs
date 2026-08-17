using System;

namespace JetBrains.Annotations;

internal sealed class LocalizationRequiredAttribute : Attribute
{
	private bool _003CRequired_003Ek__BackingField;

	public bool Required
	{
		get
		{
			return _003CRequired_003Ek__BackingField;
		}
		private set
		{
			_003CRequired_003Ek__BackingField = value;
		}
	}

	public LocalizationRequiredAttribute()
	{
		_003CRequired_003Ek__BackingField = true;
	}

	public LocalizationRequiredAttribute(bool required)
	{
		_003CRequired_003Ek__BackingField = required;
	}
}
