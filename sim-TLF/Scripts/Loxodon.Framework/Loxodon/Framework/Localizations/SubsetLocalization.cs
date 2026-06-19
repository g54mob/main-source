using System;
using Loxodon.Framework.Observables;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	internal class SubsetLocalization : ILocalization
	{
		private readonly string prefix;

		private readonly Localization parent;

		public SubsetLocalization(Localization parent, string prefix)
		{
			this.parent = parent;
			this.prefix = prefix;
		}

		protected string GetParentKey(string key)
		{
			if ("".Equals(key) || key == null)
			{
				throw new ArgumentNullException(key);
			}
			return $"{prefix}.{key}";
		}

		public virtual ILocalization Subset(string prefix)
		{
			return parent.Subset(GetParentKey(prefix));
		}

		public virtual bool ContainsKey(string key)
		{
			return parent.ContainsKey(GetParentKey(key));
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
			return GetFormattedText(key, key, args);
		}

		public virtual bool GetBoolean(string key)
		{
			return Get<bool>(key);
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
			return parent.Get(GetParentKey(key), defaultValue);
		}

		public virtual IObservableProperty GetValue(string key)
		{
			return parent.GetValue(key);
		}
	}
}
