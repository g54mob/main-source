using Logic.Threading.Events;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Variables
{
	public class MainThreadVariableSO<T> : VariableSO
	{
		[SerializeField]
		protected T _defaultValue;

		[SerializeField]
		private T _value;

		public MainThreadEvent<T> ValueChanged = new MainThreadEvent<T>();

		public virtual T Value => _value;

		public virtual T DefaultValue => _defaultValue;

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
			CallValueChanged();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void CallValueChanged()
		{
			if (ApplicationUtils.IsApplicationPlaying)
			{
				ValueChanged.Fire(_value);
			}
		}
	}
}
