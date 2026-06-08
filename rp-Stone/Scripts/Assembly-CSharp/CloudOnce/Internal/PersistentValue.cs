using System;

namespace CloudOnce.Internal
{
	public abstract class PersistentValue<T> : IPersistent
	{
		protected delegate T ValueLoaderDelegate(string key, T defaultValue);

		protected delegate void ValueSetterDelegate(string key, T value, PersistenceType persistenceType);

		private T value;

		public string Key { get; private set; }

		public T Value
		{
			get
			{
				return value;
			}
			set
			{
				if (IsValidSet(value))
				{
					this.value = value;
				}
			}
		}

		public PersistenceType PersistenceType { get; private set; }

		public T DefaultValue { get; private set; }

		private ValueLoaderDelegate ValueLoader { get; set; }

		private ValueSetterDelegate ValueSetter { get; set; }

		protected PersistentValue(string key, PersistenceType type, T value, T defaultValue, ValueLoaderDelegate valueLoader, ValueSetterDelegate valueSetter)
		{
			Key = key;
			Value = value;
			PersistenceType = type;
			DefaultValue = defaultValue;
			ValueLoader = valueLoader;
			ValueSetter = valueSetter;
			DataManager.CloudPrefs[key] = this;
			DataManager.InitDataManager();
			Load();
		}

		public void Load(bool force = false)
		{
			if (ValueLoader != null)
			{
				if (force)
				{
					value = ValueLoader(Key, DefaultValue);
				}
				else
				{
					Value = ValueLoader(Key, DefaultValue);
				}
			}
		}

		public void Flush()
		{
			if (ValueSetter != null)
			{
				ValueSetter(Key, Value, PersistenceType);
			}
		}

		public void Reset()
		{
			value = DefaultValue;
			Flush();
		}

		private bool IsValidSet(T newValue)
		{
			if (PersistenceType == PersistenceType.Latest)
			{
				return true;
			}
			if (newValue is DateTime dateTime)
			{
				DateTime dateTime2 = (DateTime)(object)value;
				if (PersistenceType != PersistenceType.Highest)
				{
					return dateTime < dateTime2;
				}
				return dateTime.Ticks > dateTime2.Ticks;
			}
			if (newValue is long)
			{
				long num = long.Parse(newValue.ToString());
				long num2 = long.Parse(value.ToString());
				if (PersistenceType != PersistenceType.Highest)
				{
					return num < num2;
				}
				return num > num2;
			}
			if (newValue is decimal)
			{
				decimal num3 = decimal.Parse(newValue.ToString());
				decimal num4 = decimal.Parse(value.ToString());
				if (PersistenceType != PersistenceType.Highest)
				{
					return num3 < num4;
				}
				return num3 > num4;
			}
			if (!(newValue is bool) && !(newValue is string))
			{
				double num5 = double.Parse(newValue.ToString());
				double num6 = double.Parse(value.ToString());
				if (PersistenceType != PersistenceType.Highest)
				{
					return num5 < num6;
				}
				return num5 > num6;
			}
			if (!(newValue is string))
			{
				bool flag = bool.Parse(newValue.ToString());
				bool flag2 = bool.Parse(value.ToString());
				if (PersistenceType != PersistenceType.Highest)
				{
					return !flag && flag2;
				}
				if (flag)
				{
					return !flag2;
				}
				return false;
			}
			int length = newValue.ToString().Length;
			int length2 = value.ToString().Length;
			if (PersistenceType != PersistenceType.Highest)
			{
				return length < length2;
			}
			return length > length2;
		}
	}
}
