using System;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Variables
{
	public abstract class VariableSO : ScriptableObject
	{
		public abstract void ResetToDefault();
	}
	public class VariableSO<T> : VariableSO
	{
		[SerializeField]
		protected T _defaultValue;

		[SerializeField]
		private T _value;

		public virtual T Value => _value;

		public virtual T DefaultValue => _defaultValue;

		public event Action<T> ValueChanged = delegate
		{
		};

		protected virtual void OnDisable()
		{
			_value = _defaultValue;
		}

		protected virtual void OnEnable()
		{
			_value = _defaultValue;
		}

		public override void ResetToDefault()
		{
			SetValue(_defaultValue);
		}

		public virtual void SetValue(T value)
		{
			_value = value;
			this.ValueChanged(value);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void CallValueChanged()
		{
			this.ValueChanged(_value);
		}
	}
}
