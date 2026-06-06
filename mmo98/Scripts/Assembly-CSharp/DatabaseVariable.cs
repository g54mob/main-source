using System;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[Serializable]
public class DatabaseVariable : IVariableValueChanged, IVariable
{
	private object _value;

	public object Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (_value == null || !_value.Equals(value))
			{
				_value = value;
				this.ValueChanged?.Invoke(this);
			}
		}
	}

	public bool Initialized => _value != null;

	public event Action<IVariable> ValueChanged;

	public DatabaseVariable()
	{
		_value = null;
	}

	public DatabaseVariable(object value)
	{
		_value = value;
	}

	public object GetSourceValue(ISelectorInfo _)
	{
		return Value;
	}

	public override string ToString()
	{
		return Value?.ToString();
	}
}
