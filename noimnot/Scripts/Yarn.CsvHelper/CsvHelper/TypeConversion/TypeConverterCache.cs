using System;
using System.Collections.Generic;
using System.Reflection;

namespace CsvHelper.TypeConversion
{
	public class TypeConverterCache
	{
		private readonly Dictionary<Type, ITypeConverter> typeConverters;

		public void AddConverter(Type type, ITypeConverter typeConverter)
		{
		}

		public void AddConverter<T>(ITypeConverter typeConverter)
		{
		}

		public void RemoveConverter(Type type)
		{
		}

		public void RemoveConverter<T>()
		{
		}

		public ITypeConverter GetConverter(Type type)
		{
			return null;
		}

		public ITypeConverter GetConverter(MemberInfo member)
		{
			return null;
		}

		public ITypeConverter GetConverter<T>()
		{
			return null;
		}

		private void CreateDefaultConverters()
		{
		}
	}
}
