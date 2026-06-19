using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Loxodon.Framework.Observables;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	public class Localization : ILocalization
	{
		protected class ProviderEntry
		{
			public IDataProvider Provider { get; private set; }

			public List<string> Keys { get; private set; }

			public ProviderEntry(IDataProvider provider)
			{
				Provider = provider;
				Keys = new List<string>();
			}
		}

		private static readonly object _instanceLock = new object();

		private static Localization instance;

		private readonly object _lock = new object();

		private readonly ConcurrentDictionary<string, IObservableProperty> data = new ConcurrentDictionary<string, IObservableProperty>();

		private readonly List<ProviderEntry> providers = new List<ProviderEntry>();

		private CultureInfo cultureInfo;

		private EventHandler cultureInfoChanged;

		public static Localization Current
		{
			get
			{
				if (instance != null)
				{
					return instance;
				}
				lock (_instanceLock)
				{
					if (instance == null)
					{
						instance = new Localization();
					}
					return instance;
				}
			}
			set
			{
				lock (_instanceLock)
				{
					instance = value;
				}
			}
		}

		public virtual CultureInfo CultureInfo
		{
			get
			{
				return cultureInfo;
			}
			set
			{
				if (value != null && (cultureInfo == null || !cultureInfo.Equals(value)))
				{
					cultureInfo = value;
					OnCultureInfoChanged();
				}
			}
		}

		public event EventHandler CultureInfoChanged
		{
			add
			{
				lock (_lock)
				{
					cultureInfoChanged = (EventHandler)Delegate.Combine(cultureInfoChanged, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					cultureInfoChanged = (EventHandler)Delegate.Remove(cultureInfoChanged, value);
				}
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void OnInitialize()
		{
			if (instance != null)
			{
				instance = null;
			}
		}

		protected Localization()
			: this(null)
		{
		}

		protected Localization(CultureInfo cultureInfo)
		{
			this.cultureInfo = cultureInfo;
			if (this.cultureInfo == null)
			{
				this.cultureInfo = Locale.GetCultureInfo();
			}
		}

		protected void RaiseCultureInfoChanged()
		{
			try
			{
				cultureInfoChanged?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception)
			{
			}
		}

		protected virtual void OnCultureInfoChanged()
		{
			RaiseCultureInfoChanged();
			Refresh();
		}

		public Task AddDataProvider(IDataProvider provider)
		{
			return DoAddDataProvider(provider);
		}

		protected virtual async Task DoAddDataProvider(IDataProvider provider)
		{
			if (provider == null)
			{
				return;
			}
			ProviderEntry providerEntry = new ProviderEntry(provider);
			lock (_lock)
			{
				if (providers.Exists((ProviderEntry e) => e.Provider == provider))
				{
					return;
				}
				providers.Add(providerEntry);
			}
			await Load(providerEntry);
		}

		public virtual void RemoveDataProvider(IDataProvider provider)
		{
			if (provider == null)
			{
				return;
			}
			lock (_lock)
			{
				for (int num = providers.Count - 1; num >= 0; num--)
				{
					ProviderEntry providerEntry = providers[num];
					if (providerEntry.Provider == provider)
					{
						providers.RemoveAt(num);
						OnUnloadCompleted(providerEntry.Keys);
						(provider as IDisposable)?.Dispose();
						break;
					}
				}
			}
		}

		public Task Refresh()
		{
			return Load(providers.ToArray());
		}

		protected virtual async Task Load(params ProviderEntry[] providers)
		{
			if (providers == null || providers.Length == 0)
			{
				return;
			}
			int count = providers.Length;
			CultureInfo cultureInfo = CultureInfo;
			for (int i = 0; i < count; i++)
			{
				try
				{
					ProviderEntry entry = providers[i];
					OnLoadCompleted(entry, await entry.Provider.Load(cultureInfo));
				}
				catch (Exception)
				{
				}
			}
		}

		protected virtual void OnLoadCompleted(ProviderEntry entry, Dictionary<string, object> dict)
		{
			if (dict == null || dict.Count <= 0)
			{
				return;
			}
			lock (_lock)
			{
				List<string> keys = entry.Keys;
				keys.Clear();
				foreach (KeyValuePair<string, object> item in dict)
				{
					string key = item.Key;
					object value = item.Value;
					keys.Add(key);
					AddValue(key, value);
				}
			}
		}

		protected virtual void AddValue(string key, object value)
		{
			if (!data.TryGetValue(key, out var value2))
			{
				Type type = ((value != null) ? value.GetType() : typeof(object));
				value2 = Type.GetTypeCode(type) switch
				{
					TypeCode.Boolean => new ObservableProperty<bool>(), 
					TypeCode.Byte => new ObservableProperty<byte>(), 
					TypeCode.Char => new ObservableProperty<char>(), 
					TypeCode.DateTime => new ObservableProperty<DateTime>(), 
					TypeCode.Decimal => new ObservableProperty<decimal>(), 
					TypeCode.Double => new ObservableProperty<double>(), 
					TypeCode.Int16 => new ObservableProperty<short>(), 
					TypeCode.Int32 => new ObservableProperty<int>(), 
					TypeCode.Int64 => new ObservableProperty<long>(), 
					TypeCode.SByte => new ObservableProperty<sbyte>(), 
					TypeCode.Single => new ObservableProperty<float>(), 
					TypeCode.String => new ObservableProperty<string>(), 
					TypeCode.UInt16 => new ObservableProperty<ushort>(), 
					TypeCode.UInt32 => new ObservableProperty<uint>(), 
					TypeCode.UInt64 => new ObservableProperty<ulong>(), 
					TypeCode.Object => (!type.Equals(typeof(Vector2))) ? ((!type.Equals(typeof(Vector3))) ? ((!type.Equals(typeof(Vector4))) ? ((!type.Equals(typeof(Color))) ? ((IObservableProperty)new ObservableProperty()) : ((IObservableProperty)new ObservableProperty<Color>())) : new ObservableProperty<Vector4>()) : new ObservableProperty<Vector3>()) : new ObservableProperty<Vector2>(), 
					_ => new ObservableProperty(), 
				};
				data[key] = value2;
			}
			value2.Value = value;
		}

		protected virtual void OnUnloadCompleted(List<string> keys)
		{
			foreach (string key in keys)
			{
				if (data.TryRemove(key, out var value) && value != null)
				{
					value.Value = null;
				}
			}
		}

		public virtual ILocalization Subset(string prefix)
		{
			return new SubsetLocalization(this, prefix);
		}

		public virtual bool ContainsKey(string key)
		{
			return data.ContainsKey(key);
		}

		public virtual string GetText(string key)
		{
			return GetText(key, key);
		}

		public virtual string GetText(string key, string defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual string GetFormattedText(string key, params object[] args)
		{
			string text = Get<string>(key, null);
			if (text == null)
			{
				return key;
			}
			return string.Format(text, args);
		}

		public virtual bool GetBoolean(string key)
		{
			return Get(key, defaultValue: false);
		}

		public virtual bool GetBoolean(string key, bool defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual int GetInt(string key)
		{
			return Get<int>(key);
		}

		public virtual int GetInt(string key, int defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual long GetLong(string key)
		{
			return Get<long>(key);
		}

		public virtual long GetLong(string key, long defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual double GetDouble(string key)
		{
			return Get<double>(key);
		}

		public virtual double GetDouble(string key, double defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual float GetFloat(string key)
		{
			return Get<float>(key);
		}

		public virtual float GetFloat(string key, float defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual Color GetColor(string key)
		{
			return Get<Color>(key);
		}

		public virtual Color GetColor(string key, Color defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual Vector3 GetVector3(string key)
		{
			return Get<Vector3>(key);
		}

		public virtual Vector3 GetVector3(string key, Vector3 defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual DateTime GetDateTime(string key)
		{
			return Get(key, new DateTime(0L));
		}

		public virtual DateTime GetDateTime(string key, DateTime defaultValue)
		{
			return Get(key, defaultValue);
		}

		public virtual T Get<T>(string key)
		{
			return Get(key, default(T));
		}

		public virtual T Get<T>(string key, T defaultValue)
		{
			if (typeof(IObservableProperty).IsAssignableFrom(typeof(T)))
			{
				return (T)GetValue(key);
			}
			if (data.TryGetValue(key, out var value))
			{
				if (value is IObservableProperty<T> observableProperty)
				{
					return observableProperty.Value;
				}
				if (value.Value is T)
				{
					return (T)value.Value;
				}
				return (T)Convert.ChangeType(value.Value, typeof(T));
			}
			return defaultValue;
		}

		public virtual IObservableProperty GetValue(string key)
		{
			return GetValue(key, isAutoCreated: true);
		}

		public virtual IObservableProperty GetValue(string key, bool isAutoCreated)
		{
			if (data.TryGetValue(key, out var value))
			{
				return value;
			}
			if (!isAutoCreated)
			{
				return null;
			}
			lock (_lock)
			{
				if (data.TryGetValue(key, out value))
				{
					return value;
				}
				value = new ObservableProperty();
				data[key] = value;
				return value;
			}
		}
	}
}
