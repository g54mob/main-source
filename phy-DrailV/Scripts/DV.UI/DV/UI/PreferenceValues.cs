using System;

namespace DV.UI
{
	public abstract class PreferenceValues
	{
		public string name;

		public dynamic defaultValue;

		public dynamic originalValue;

		public dynamic latestValue;

		public virtual bool HasChange => originalValue != latestValue;

		public event Action ImmediateEffectLatestValueChanged;

		public PreferenceValues(string name, dynamic defaultValue, dynamic initialValue)
		{
			this.name = name;
			this.defaultValue = defaultValue;
			originalValue = initialValue;
			latestValue = initialValue;
		}

		public virtual void Apply()
		{
			originalValue = latestValue;
		}

		public virtual void ImmediateEffectApply()
		{
			this.ImmediateEffectLatestValueChanged?.Invoke();
		}

		public virtual void RevertChange()
		{
			latestValue = originalValue;
		}
	}
	public class PreferenceValues<T> : PreferenceValues
	{
		public PreferenceValues(string name, T defaultValue, T initialValue)
			: base(name, defaultValue, initialValue)
		{
		}
	}
}
