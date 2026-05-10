using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public abstract class CVarReference : ScriptableObject
	{
		internal abstract ConsoleVar GetVariable();
	}
	public abstract class CVarReference<T> : CVarReference
	{
		protected event Action<T> OnValueChanged;

		private void OnEnable()
		{
			GetVariable()?.Subscribe(TriggerValueChanged);
		}

		private void OnDisable()
		{
			GetVariable()?.Unsubscribe(TriggerValueChanged);
		}

		public void SubscribeToChange(Action<T> action)
		{
			UnsubscribeToChange(action);
			OnValueChanged += action;
		}

		public void UnsubscribeToChange(Action<T> action)
		{
			OnValueChanged -= action;
		}

		private void TriggerValueChanged()
		{
			this.OnValueChanged?.Invoke(GetCurrentValue());
		}

		public abstract T GetCurrentValue();

		public abstract void SetCurrentValue(T newValue);

		public abstract void ResetDefaultValue();
	}
}
