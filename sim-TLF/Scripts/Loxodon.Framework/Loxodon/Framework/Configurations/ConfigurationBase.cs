using System;
using System.Collections.Generic;
using System.Text;
using Loxodon.Framework.Utilities;
using Loxodon.Log;

namespace Loxodon.Framework.Configurations
{
	public abstract class ConfigurationBase : IConfiguration
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ConfigurationBase));

		private static readonly DefaultTypeConverter defaultTypeConverter = new DefaultTypeConverter();

		protected static readonly string KEY_DELIMITER = ".";

		protected static readonly Version DEFAULT_VERSION = new Version("1.0.0");

		protected static readonly DateTime DEFAULT_DATETIME = default(DateTime);

		private List<ITypeConverter> converters = new List<ITypeConverter>();

		public virtual bool IsEmpty => !GetKeys().MoveNext();

		public ConfigurationBase()
			: this(null)
		{
		}

		public ConfigurationBase(ITypeConverter[] converters)
		{
			this.converters.Add(defaultTypeConverter);
			if (converters != null && converters.Length != 0)
			{
				foreach (ITypeConverter item in converters)
				{
					this.converters.Insert(0, item);
				}
			}
		}

		protected virtual T GetProperty<T>(string key, T defaultValue)
		{
			object property = GetProperty(key);
			if (property == null)
			{
				return defaultValue;
			}
			return (T)ConvertTo(typeof(T), property);
		}

		protected virtual object GetProperty(string key, Type type, object defaultValue)
		{
			object property = GetProperty(key);
			if (property == null)
			{
				return defaultValue;
			}
			return ConvertTo(type, property);
		}

		protected virtual object ConvertTo(Type type, object value)
		{
			try
			{
				for (int i = 0; i < converters.Count; i++)
				{
					ITypeConverter typeConverter = converters[i];
					if (typeConverter.Support(type))
					{
						return typeConverter.Convert(type, value);
					}
				}
			}
			catch (FormatException ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("This value \"{0}\" cannot be converted to type \"{1}\"", value, type.Name);
				}
				throw ex;
			}
			catch (Exception innerException)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("This value \"{0}\" cannot be converted to type \"{1}\"", value, type.Name);
				}
				throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException);
			}
			throw new NotSupportedException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
		}

		public virtual void AddTypeConverter(ITypeConverter converter)
		{
			converters.Insert(0, converter);
		}

		public virtual IConfiguration Subset(string prefix)
		{
			if (string.IsNullOrEmpty(prefix))
			{
				throw new ArgumentException("the prefix is null or empty", "prefix");
			}
			return new SubsetConfiguration(this, prefix);
		}

		public virtual IEnumerator<string> GetKeys(string prefix)
		{
			return new FilterEnumerator<string>(GetKeys(), (string it) => it.StartsWith(prefix + KEY_DELIMITER));
		}

		public bool GetBoolean(string key)
		{
			return GetBoolean(key, defaultValue: false);
		}

		public bool GetBoolean(string key, bool defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public float GetFloat(string key)
		{
			return GetFloat(key, 0f);
		}

		public float GetFloat(string key, float defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public double GetDouble(string key)
		{
			return GetDouble(key, 0.0);
		}

		public double GetDouble(string key, double defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public short GetShort(string key)
		{
			return GetShort(key, 0);
		}

		public short GetShort(string key, short defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public int GetInt(string key)
		{
			return GetInt(key, 0);
		}

		public int GetInt(string key, int defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public long GetLong(string key)
		{
			return GetLong(key, 0L);
		}

		public long GetLong(string key, long defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public string GetString(string key)
		{
			return GetString(key, null);
		}

		public string GetString(string key, string defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public string GetFormattedString(string key, params object[] args)
		{
			string text = GetString(key, null);
			if (text == null)
			{
				return null;
			}
			return string.Format(text, args);
		}

		public DateTime GetDateTime(string key)
		{
			return GetDateTime(key, DEFAULT_DATETIME);
		}

		public DateTime GetDateTime(string key, DateTime defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public Version GetVersion(string key)
		{
			return GetVersion(key, DEFAULT_VERSION);
		}

		public virtual Version GetVersion(string key, Version defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public T GetObject<T>(string key)
		{
			return GetObject(key, default(T));
		}

		public virtual T GetObject<T>(string key, T defaultValue)
		{
			return GetProperty(key, defaultValue);
		}

		public object[] GetArray(string key, Type type)
		{
			return GetArray(key, type, new object[0]);
		}

		public object[] GetArray(string key, Type type, object[] defaultValue)
		{
			object property = GetProperty(key);
			if (property == null)
			{
				return defaultValue;
			}
			if (property is string)
			{
				string text = (string)property;
				if (string.IsNullOrEmpty(text))
				{
					return defaultValue;
				}
				List<object> list = new List<object>();
				string[] array = StringSpliter.Split(text, ',');
				foreach (string value in array)
				{
					object item = null;
					try
					{
						item = ConvertTo(type, value);
					}
					catch (NotSupportedException ex)
					{
						throw ex;
					}
					catch (Exception)
					{
					}
					list.Add(item);
				}
				return list.ToArray();
			}
			if (property is Array array2)
			{
				List<object> list2 = new List<object>();
				for (int j = 0; j < array2.Length; j++)
				{
					object value2 = array2.GetValue(j);
					object item2 = null;
					try
					{
						item2 = ConvertTo(type, value2);
					}
					catch (NotSupportedException ex3)
					{
						throw ex3;
					}
					catch (Exception)
					{
					}
					list2.Add(item2);
				}
				return list2.ToArray();
			}
			throw new FormatException($"This value \"{property}\" cannot be converted to an \"{type.Name}\" array.");
		}

		public T[] GetArray<T>(string key)
		{
			return GetArray(key, new T[0]);
		}

		public virtual T[] GetArray<T>(string key, T[] defaultValue)
		{
			object property = GetProperty(key);
			if (property == null)
			{
				return defaultValue;
			}
			if (property is string)
			{
				string text = (string)property;
				if (string.IsNullOrEmpty(text))
				{
					return defaultValue;
				}
				List<T> list = new List<T>();
				string[] array = StringSpliter.Split(text, ',');
				foreach (string value in array)
				{
					T item = default(T);
					try
					{
						item = (T)ConvertTo(typeof(T), value);
					}
					catch (NotSupportedException ex)
					{
						throw ex;
					}
					catch (Exception)
					{
					}
					list.Add(item);
				}
				return list.ToArray();
			}
			if (property is T[])
			{
				return (T[])property;
			}
			if (property is Array array2)
			{
				List<T> list2 = new List<T>();
				for (int j = 0; j < array2.Length; j++)
				{
					object value2 = array2.GetValue(j);
					T item2 = default(T);
					try
					{
						item2 = (T)ConvertTo(typeof(T), value2);
					}
					catch (NotSupportedException ex3)
					{
						throw ex3;
					}
					catch (Exception)
					{
					}
					list2.Add(item2);
				}
				return list2.ToArray();
			}
			throw new FormatException($"This value \"{property}\" cannot be converted to an \"{typeof(T).Name}\" array.");
		}

		public override string ToString()
		{
			IEnumerator<string> keys = GetKeys();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetType().Name).Append("{ \r\n");
			while (keys.MoveNext())
			{
				string current = keys.Current;
				stringBuilder.AppendFormat("  {0} = {1}\r\n", current, GetProperty(current));
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public abstract IEnumerator<string> GetKeys();

		public abstract bool ContainsKey(string key);

		public abstract object GetProperty(string key);

		public abstract void AddProperty(string key, object value);

		public abstract void RemoveProperty(string key);

		public abstract void SetProperty(string key, object value);

		public abstract void Clear();
	}
}
