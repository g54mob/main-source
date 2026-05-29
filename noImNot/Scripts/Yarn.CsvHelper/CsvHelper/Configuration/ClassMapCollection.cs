using System;
using System.Collections.Generic;

namespace CsvHelper.Configuration
{
	public class ClassMapCollection
	{
		private readonly Dictionary<Type, ClassMap> data;

		private readonly Configuration configuration;

		public virtual ClassMap this[Type type] => null;

		public ClassMapCollection(Configuration configuration)
		{
		}

		public virtual ClassMap<T> Find<T>()
		{
			return null;
		}

		internal virtual void Add(ClassMap map)
		{
		}

		internal virtual void Remove(Type classMapType)
		{
		}

		internal virtual void Clear()
		{
		}

		private Type GetGenericCsvClassMapType(Type type)
		{
			return null;
		}

		private void SetMapDefaults(ClassMap map)
		{
		}
	}
}
