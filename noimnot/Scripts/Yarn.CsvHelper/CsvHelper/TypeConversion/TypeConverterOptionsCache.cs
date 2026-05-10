using System;
using System.Collections.Generic;

namespace CsvHelper.TypeConversion
{
	public class TypeConverterOptionsCache
	{
		private Dictionary<Type, TypeConverterOptions> typeConverterOptions;

		public void AddOptions(Type type, TypeConverterOptions options)
		{
		}

		public void AddOptions<T>(TypeConverterOptions options)
		{
		}

		public void RemoveOptions(Type type)
		{
		}

		public void RemoveOptions<T>()
		{
		}

		public TypeConverterOptions GetOptions(Type type)
		{
			return null;
		}

		public TypeConverterOptions GetOptions<T>()
		{
			return null;
		}
	}
}
