using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace XCharts.Runtime
{
	public static class RuntimeUtil
	{
		private static IEnumerable<Type> m_AssemblyTypes;

		public static bool HasSubclass(Type type)
		{
			using (IEnumerator<Type> enumerator = GetAllTypesDerivedFrom(type).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					return true;
				}
			}
			return false;
		}

		public static IEnumerable<Type> GetAllTypesDerivedFrom<T>()
		{
			return from t in GetAllAssemblyTypes()
				where t.IsSubclassOf(typeof(T))
				select t;
		}

		public static IEnumerable<Type> GetAllTypesDerivedFrom(Type type)
		{
			return from t in GetAllAssemblyTypes()
				where t.IsSubclassOf(type)
				select t;
		}

		public static IEnumerable<Type> GetAllAssemblyTypes()
		{
			if (m_AssemblyTypes == null)
			{
				m_AssemblyTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(delegate(Assembly t)
				{
					Type[] result = new Type[0];
					try
					{
						result = t.GetTypes();
					}
					catch
					{
					}
					return result;
				});
			}
			return m_AssemblyTypes;
		}

		public static T GetAttribute<T>(this Type type, bool check = true) where T : Attribute
		{
			if (type.IsDefined(typeof(T), inherit: false))
			{
				return (T)type.GetCustomAttributes(typeof(T), inherit: false)[0];
			}
			return null;
		}

		public static T GetAttribute<T>(this MemberInfo type, bool check = true) where T : Attribute
		{
			if (type.IsDefined(typeof(T), inherit: false))
			{
				return (T)type.GetCustomAttributes(typeof(T), inherit: false)[0];
			}
			return null;
		}
	}
}
