using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.ScriptableSettings
{
	public abstract class SettingObject : ScriptableObject
	{
		public const string MenuName = "CTS/Settings/";

		public abstract void ResetValue();

		public void SaveCurrentValueToDisk()
		{
			OnSaveCurrentValueToDisk();
		}

		protected abstract void OnSaveCurrentValueToDisk();

		public abstract string GetCurrentValueName();

		private void OnDestroy()
		{
			SaveCurrentValueToDisk();
		}
	}
	public abstract class SettingObject<T> : SettingObject
	{
		[SerializeField]
		protected T _defaultValue;

		protected T _currentValue;

		public bool Initialized { get; private set; }

		public event Action<T> ValueChanged;

		public virtual T GetValue()
		{
			if (!Initialized)
			{
				Initialized = true;
				T valueFromDisk = GetValueFromDisk();
				if (!AreValuesEqual(_currentValue, valueFromDisk))
				{
					_currentValue = valueFromDisk;
					this.ValueChanged?.Invoke(_currentValue);
				}
			}
			return _currentValue;
		}

		protected virtual bool AreValuesEqual(T currentValue, T newValue)
		{
			return EqualityComparer<T>.Default.Equals(currentValue, newValue);
		}

		public override string GetCurrentValueName()
		{
			return GetValue().ToString();
		}

		public override void ResetValue()
		{
			SetValue(_defaultValue);
		}

		public virtual void SetValue(T value)
		{
			T value2 = GetValue();
			if (!AreValuesEqual(value2, value))
			{
				_currentValue = value;
				this.ValueChanged?.Invoke(_currentValue);
				SaveCurrentValueToDisk();
			}
		}

		public static implicit operator T(SettingObject<T> setting)
		{
			return setting.GetValue();
		}

		protected abstract T GetValueFromDisk();
	}
}
