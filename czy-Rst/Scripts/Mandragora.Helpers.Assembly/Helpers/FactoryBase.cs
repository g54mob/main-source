using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Helpers
{
	public abstract class FactoryBase<T>
	{
		protected Dictionary<string, T> namedTypes = new Dictionary<string, T>();

		protected virtual void Initialize()
		{
			IEnumerable<Type> enumerable = from t in Assembly.GetAssembly(typeof(T)).GetTypes()
				where t.IsClass && !t.IsAbstract && !t.IsSubclassOf(typeof(T))
				select t;
			namedTypes.Clear();
			foreach (Type item in enumerable)
			{
				_ = item;
				T value = Activator.CreateInstance<T>();
				namedTypes.Add(typeof(T).Name, value);
			}
		}

		public virtual T GetNewInstance(string id)
		{
			if (namedTypes.ContainsKey(id))
			{
				return Activator.CreateInstance<T>();
			}
			return default(T);
		}
	}
}
