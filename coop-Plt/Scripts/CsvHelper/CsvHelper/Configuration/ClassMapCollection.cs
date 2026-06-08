using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CsvHelper.Configuration
{
	public class ClassMapCollection
	{
		private readonly Dictionary<Type, ClassMap> data = new Dictionary<Type, ClassMap>();

		private readonly CsvContext context;

		public virtual ClassMap this[Type type]
		{
			get
			{
				Type type2 = type;
				do
				{
					if (data.ContainsKey(type2))
					{
						return data[type2];
					}
					type2 = type2.GetTypeInfo().BaseType;
				}
				while (!(type2 == null));
				return null;
			}
		}

		public ClassMapCollection(CsvContext context)
		{
			this.context = context;
		}

		public virtual ClassMap<T> Find<T>()
		{
			return (ClassMap<T>)this[typeof(T)];
		}

		internal virtual void Add(ClassMap map)
		{
			SetMapDefaults(map);
			Type key = GetGenericCsvClassMapType(map.GetType()).GetGenericArguments().First();
			if (data.ContainsKey(key))
			{
				data[key] = map;
			}
			else
			{
				data.Add(key, map);
			}
		}

		internal virtual void Remove(Type classMapType)
		{
			if (!typeof(ClassMap).IsAssignableFrom(classMapType))
			{
				throw new ArgumentException("The class map type must inherit from CsvClassMap.");
			}
			Type key = GetGenericCsvClassMapType(classMapType).GetGenericArguments().First();
			data.Remove(key);
		}

		internal virtual void Clear()
		{
			data.Clear();
		}

		private Type GetGenericCsvClassMapType(Type type)
		{
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(ClassMap<>))
			{
				return type;
			}
			return GetGenericCsvClassMapType(type.GetTypeInfo().BaseType);
		}

		private void SetMapDefaults(ClassMap map)
		{
			foreach (ParameterMap parameterMap in map.ParameterMaps)
			{
				if (parameterMap.ConstructorTypeMap != null)
				{
					SetMapDefaults(parameterMap.ConstructorTypeMap);
					continue;
				}
				if (parameterMap.ReferenceMap != null)
				{
					SetMapDefaults(parameterMap.ReferenceMap.Data.Mapping);
					continue;
				}
				if (parameterMap.Data.TypeConverter == null)
				{
					parameterMap.Data.TypeConverter = context.TypeConverterCache.GetConverter(parameterMap.Data.Parameter.ParameterType);
				}
				if (parameterMap.Data.Names.Count == 0)
				{
					parameterMap.Data.Names.Add(parameterMap.Data.Parameter.Name);
				}
			}
			foreach (MemberMap memberMap in map.MemberMaps)
			{
				if (!(memberMap.Data.Member == null))
				{
					if (memberMap.Data.TypeConverter == null)
					{
						memberMap.Data.TypeConverter = context.TypeConverterCache.GetConverter(memberMap.Data.Member.MemberType());
					}
					if (memberMap.Data.Names.Count == 0)
					{
						memberMap.Data.Names.Add(memberMap.Data.Member.Name);
					}
				}
			}
			foreach (MemberReferenceMap referenceMap in map.ReferenceMaps)
			{
				SetMapDefaults(referenceMap.Data.Mapping);
				if (context.Configuration.ReferenceHeaderPrefix != null)
				{
					ReferenceHeaderPrefixArgs args = new ReferenceHeaderPrefixArgs(referenceMap.Data.Member.MemberType(), referenceMap.Data.Member.Name);
					referenceMap.Data.Prefix = context.Configuration.ReferenceHeaderPrefix(args);
				}
			}
		}
	}
}
