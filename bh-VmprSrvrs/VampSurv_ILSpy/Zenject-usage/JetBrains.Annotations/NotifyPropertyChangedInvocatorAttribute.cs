using System;

namespace JetBrains.Annotations;

internal sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
{
	private string _003CParameterName_003Ek__BackingField;

	public string ParameterName
	{
		get
		{
			return _003CParameterName_003Ek__BackingField;
		}
		private set
		{
			_003CParameterName_003Ek__BackingField = value;
		}
	}

	public NotifyPropertyChangedInvocatorAttribute()
	{
	}

	public NotifyPropertyChangedInvocatorAttribute(string parameterName)
	{
		_003CParameterName_003Ek__BackingField = parameterName;
	}
}
