using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Reflection;
using CsvHelper.Configuration.Attributes;

namespace CsvHelper.TypeConversion
{
	public class TypeConverterCache
	{
		private readonly Dictionary<Type, ITypeConverter> typeConverters = new Dictionary<Type, ITypeConverter>();

		public TypeConverterCache()
		{
			CreateDefaultConverters();
		}

		public void AddConverter(Type type, ITypeConverter typeConverter)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (typeConverter == null)
			{
				throw new ArgumentNullException("typeConverter");
			}
			typeConverters[type] = typeConverter;
		}

		public void AddConverter<T>(ITypeConverter typeConverter)
		{
			if (typeConverter == null)
			{
				throw new ArgumentNullException("typeConverter");
			}
			typeConverters[typeof(T)] = typeConverter;
		}

		public void AddConverter(ITypeConverter typeConverter)
		{
			foreach (Type key in typeConverters.Keys)
			{
				typeConverters[key] = typeConverter;
			}
		}

		public void RemoveConverter(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			typeConverters.Remove(type);
		}

		public void RemoveConverter<T>()
		{
			RemoveConverter(typeof(T));
		}

		public ITypeConverter GetConverter(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (typeConverters.TryGetValue(type, out var value))
			{
				return value;
			}
			if (typeof(Enum).IsAssignableFrom(type))
			{
				if (typeConverters.TryGetValue(typeof(Enum), out value))
				{
					return value;
				}
				AddConverter(type, new EnumConverter(type));
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				AddConverter(type, new NullableConverter(type, this));
				return GetConverter(type);
			}
			if (type.IsArray)
			{
				AddConverter(type, new ArrayConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				AddConverter(type, new IDictionaryGenericConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<, >))
			{
				AddConverter(type, new IDictionaryGenericConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
			{
				AddConverter(type, new CollectionGenericConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Collection<>))
			{
				AddConverter(type, new CollectionGenericConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
			{
				AddConverter(type, new IEnumerableGenericConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
			{
				AddConverter(type, new IEnumerableGenericConverter());
				return GetConverter(type);
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
			{
				AddConverter(type, new IEnumerableGenericConverter());
				return GetConverter(type);
			}
			if (typeof(IEnumerable).IsAssignableFrom(type))
			{
				return new EnumerableConverter();
			}
			return new DefaultTypeConverter();
		}

		public ITypeConverter GetConverter(MemberInfo member)
		{
			TypeConverterAttribute customAttribute = member.GetCustomAttribute<TypeConverterAttribute>();
			if (customAttribute != null)
			{
				return customAttribute.TypeConverter;
			}
			return GetConverter(member.MemberType());
		}

		public ITypeConverter GetConverter<T>()
		{
			return GetConverter(typeof(T));
		}

		private void CreateDefaultConverters()
		{
			AddConverter(typeof(BigInteger), new BigIntegerConverter());
			AddConverter(typeof(bool), new BooleanConverter());
			AddConverter(typeof(byte), new ByteConverter());
			AddConverter(typeof(byte[]), new ByteArrayConverter());
			AddConverter(typeof(char), new CharConverter());
			AddConverter(typeof(DateTime), new DateTimeConverter());
			AddConverter(typeof(DateTimeOffset), new DateTimeOffsetConverter());
			AddConverter(typeof(decimal), new DecimalConverter());
			AddConverter(typeof(double), new DoubleConverter());
			AddConverter(typeof(float), new SingleConverter());
			AddConverter(typeof(Guid), new GuidConverter());
			AddConverter(typeof(short), new Int16Converter());
			AddConverter(typeof(int), new Int32Converter());
			AddConverter(typeof(long), new Int64Converter());
			AddConverter(typeof(sbyte), new SByteConverter());
			AddConverter(typeof(string), new StringConverter());
			AddConverter(typeof(TimeSpan), new TimeSpanConverter());
			AddConverter(typeof(Type), new TypeConverter());
			AddConverter(typeof(ushort), new UInt16Converter());
			AddConverter(typeof(uint), new UInt32Converter());
			AddConverter(typeof(ulong), new UInt64Converter());
			AddConverter(typeof(Uri), new UriConverter());
			AddConverter(typeof(IList), new IEnumerableConverter());
			AddConverter(typeof(ICollection), new IEnumerableConverter());
			AddConverter(typeof(IEnumerable), new IEnumerableConverter());
			AddConverter(typeof(IDictionary), new IDictionaryConverter());
		}
	}
}
