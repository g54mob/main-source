using System;

namespace JetBrains.Annotations;

internal sealed class MustUseReturnValueAttribute : Attribute
{
	private string _003CJustification_003Ek__BackingField;

	public string Justification
	{
		get
		{
			return _003CJustification_003Ek__BackingField;
		}
		private set
		{
			_003CJustification_003Ek__BackingField = value;
		}
	}

	public MustUseReturnValueAttribute()
	{
	}

	public MustUseReturnValueAttribute(string justification)
	{
		_003CJustification_003Ek__BackingField = justification;
	}
}
