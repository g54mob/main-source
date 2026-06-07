using System;
using ManagementScripts;
using UnityEngine.Events;

namespace SettingScripts
{
	[Serializable]
	public abstract class Setting<TValueType> : ChangingValueSetting<TValueType>, IForceUpdateSetting
	{
		[NonSerialized]
		public string Name;

		[NonSerialized]
		public string HelperText;

		[NonSerialized]
		public string WikiLink;

		[NonSerialized]
		public TValueType DefaultValue;

		public abstract TValueType val { get; set; }

		public void Subscribe(UnityAction action, bool call = false)
		{
			OnChange.AddListener(action);
			if (call)
			{
				action();
			}
		}

		public void Subscribe(UnityAction<TValueType> action, bool call = false)
		{
			OnValueChange.AddListener(action);
			if (call)
			{
				action(val);
			}
		}

		public void Subscribe(UnityAction<TValueType, TValueType> action, bool call = false)
		{
			OnValueChangeWithPrecedent.AddListener(action);
			if (call)
			{
				action(val, DefaultValue);
			}
		}

		public void UnSubscribe(UnityAction action)
		{
			OnChange.RemoveListener(action);
		}

		public void UnSubscribe(UnityAction<TValueType> action)
		{
			OnValueChange.RemoveListener(action);
		}

		public void UnSubscribe(UnityAction<TValueType, TValueType> action)
		{
			OnValueChangeWithPrecedent.RemoveListener(action);
		}

		public void SetDefaultAndValue(TValueType defaultVal)
		{
			DefaultValue = defaultVal;
			SetValue(defaultVal);
		}

		public virtual void SetValue(TValueType _value)
		{
			TValueType arg = val;
			val = _value;
			OnValueChangeWithPrecedent.Invoke(_value, arg);
			OnValueChange.Invoke(_value);
			OnChange.Invoke();
		}

		public IRevertableAction SetValueNonRevertable(TValueType _value)
		{
			TValueType val = this.val;
			SetValue(_value);
			return new ChangeSettingAction<Setting<TValueType>, TValueType>(this, val, _value, addToStack: false);
		}

		public IRevertableAction SetValueRevertable(TValueType _value)
		{
			TValueType val = this.val;
			SetValue(_value);
			return new ChangeSettingAction<Setting<TValueType>, TValueType>(this, val, _value);
		}

		public void ResetValue()
		{
			SetValue(DefaultValue);
		}

		public void ResetValueRevertable()
		{
			SetValueRevertable(DefaultValue);
		}

		public void ForceUpdate()
		{
			OnValueChangeWithPrecedent.Invoke(val, val);
			OnValueChange.Invoke(val);
			OnChange.Invoke();
		}
	}
}
