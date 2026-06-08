using System;
using System.Collections.Generic;

namespace CsvHelper.TypeConversion
{
	public class TypeConverterOptionsCache
	{
		private Dictionary<Type, TypeConverterOptions> typeConverterOptions = new Dictionary<Type, TypeConverterOptions>();

		public void AddOptions(Type type, TypeConverterOptions options)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			typeConverterOptions[type] = options ?? throw new ArgumentNullException("options");
		}

		public void AddOptions<T>(TypeConverterOptions options)
		{
			AddOptions(typeof(T), options);
		}

		public void AddOptions(TypeConverterOptions options)
		{
			foreach (Type key in typeConverterOptions.Keys)
			{
				typeConverterOptions[key] = options;
			}
		}

		public void RemoveOptions(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			typeConverterOptions.Remove(type);
		}

		public void RemoveOptions<T>()
		{
			RemoveOptions(typeof(T));
		}

		public TypeConverterOptions GetOptions(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException();
			}
			if (!typeConverterOptions.TryGetValue(type, out var value))
			{
				value = new TypeConverterOptions();
				typeConverterOptions.Add(type, value);
			}
			return value;
		}

		public TypeConverterOptions GetOptions<T>()
		{
			return GetOptions(typeof(T));
		}
	}
}
