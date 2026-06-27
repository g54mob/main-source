using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency.Steps
{
	internal sealed class DictionaryInterfaceInfo
	{
		private static readonly MethodInfo ConvertToDictionaryMethod = new Func<IEnumerable<KeyValuePair<object, object>>, Dictionary<object, object>>(ConvertToDictionaryInternal).GetMethodInfo().GetGenericMethodDefinition();

		private static readonly ConcurrentDictionary<Type, DictionaryInterfaceInfo[]> Cache = new ConcurrentDictionary<Type, DictionaryInterfaceInfo[]>();

		public Type Value { get; }

		public Type Key { get; }

		private DictionaryInterfaceInfo(Type key, Type value)
		{
			Key = key;
			Value = value;
		}

		public static DictionaryInterfaceInfo FindFrom(Type target, string role)
		{
			DictionaryInterfaceInfo[] dictionaryInterfacesFrom = GetDictionaryInterfacesFrom(target);
			if (dictionaryInterfacesFrom.Length > 1)
			{
				throw new ArgumentException("The " + role + " implements multiple dictionary types. It is not known which type should be use for equivalence." + Environment.NewLine + "The following IDictionary interfaces are implemented: " + string.Join(", ", (IEnumerable<DictionaryInterfaceInfo>)dictionaryInterfacesFrom), "role");
			}
			if (dictionaryInterfacesFrom.Length == 0)
			{
				return null;
			}
			return dictionaryInterfacesFrom[0];
		}

		public static DictionaryInterfaceInfo FindFromWithKey(Type target, string role, Type key)
		{
			DictionaryInterfaceInfo[] array = (from info in GetDictionaryInterfacesFrom(target)
				where info.Key.IsAssignableFrom(key)
				select info).ToArray();
			if (array.Length > 1)
			{
				throw new InvalidOperationException($"The {role} implements multiple IDictionary interfaces taking a key of {key}. ");
			}
			if (array.Length == 0)
			{
				return null;
			}
			return array[0];
		}

		private static DictionaryInterfaceInfo[] GetDictionaryInterfacesFrom(Type target)
		{
			return Cache.GetOrAdd(target, (Type key) => (Type.GetTypeCode(key) != TypeCode.Object) ? Array.Empty<DictionaryInterfaceInfo>() : (from @interface in key.GetClosedGenericInterfaces(typeof(IDictionary<, >))
				select @interface.GetGenericArguments() into arguments
				select new DictionaryInterfaceInfo(arguments[0], arguments[1])).ToArray());
		}

		public object ConvertFrom(object convertable)
		{
			Type type = (from enumerable in convertable.GetType().GetClosedGenericInterfaces(typeof(IEnumerable<>))
				select enumerable.GenericTypeArguments[0] into itemType
				where itemType.IsGenericType && itemType.GetGenericTypeDefinition() == typeof(KeyValuePair<, >)
				select itemType).SingleOrDefault((Type itemType) => itemType.GenericTypeArguments[0] == Key);
			if (type != null)
			{
				Type type2 = type.GenericTypeArguments[^1];
				return ConvertToDictionaryMethod.MakeGenericMethod(Key, type2).Invoke(null, new object[1] { convertable });
			}
			return null;
		}

		private static Dictionary<TKey, TValue> ConvertToDictionaryInternal<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		{
			return collection.ToDictionary((KeyValuePair<TKey, TValue> kvp) => kvp.Key, (KeyValuePair<TKey, TValue> kvp) => kvp.Value);
		}

		public override string ToString()
		{
			return $"IDictionary<{Key}, {Value}>";
		}
	}
}
