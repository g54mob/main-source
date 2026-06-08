using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Castle.Core.Internal
{
	internal sealed class InterfaceAttributeUtil
	{
		[DebuggerDisplay("{Value}, Age: {Age}")]
		private sealed class Aged<T>
		{
			public readonly T Value;

			public readonly int Age;

			public Aged(T value, int age)
			{
				Value = value;
				Age = age;
			}
		}

		private readonly Aged<Type>[] types;

		private readonly Dictionary<Type, Aged<object>> singletons;

		private readonly List<object> results;

		private int index;

		private static readonly object ConflictMarker = new object();

		private Type CurrentType => types[index].Value;

		private int CurrentAge => types[index].Age;

		private bool IsMostDerivedType => index == 0;

		public static object[] GetAttributes(Type type, bool inherit)
		{
			if (!type.IsInterface)
			{
				throw new ArgumentOutOfRangeException("type");
			}
			object[] array = type.GetCustomAttributes(inherit: false).ToArray();
			Type[] interfaces = type.GetInterfaces();
			if (interfaces.Length == 0 || !inherit)
			{
				return array;
			}
			return new InterfaceAttributeUtil(type, interfaces).GetAttributes(array);
		}

		private InterfaceAttributeUtil(Type derivedType, Type[] baseTypes)
		{
			types = CollectTypes(derivedType, baseTypes);
			singletons = new Dictionary<Type, Aged<object>>();
			results = new List<object>();
		}

		private Aged<Type>[] CollectTypes(Type derivedType, Type[] baseTypes)
		{
			Dictionary<Type, int> dictionary = new Dictionary<Type, int>();
			dictionary[derivedType] = 0;
			Type[] array = baseTypes;
			foreach (Type type in array)
			{
				if (ShouldConsiderType(type))
				{
					dictionary[type] = 1;
				}
			}
			array = baseTypes;
			foreach (Type type2 in array)
			{
				if (!dictionary.ContainsKey(type2))
				{
					continue;
				}
				Type[] interfaces = type2.GetInterfaces();
				foreach (Type key in interfaces)
				{
					if (dictionary.TryGetValue(key, out var value))
					{
						value = (dictionary[key] = value + 1);
					}
				}
			}
			return (from a in dictionary
				select new Aged<Type>(a.Key, a.Value) into t
				orderby t.Age
				select t).ToArray();
		}

		private object[] GetAttributes(object[] attributes)
		{
			for (index = types.Length - 1; index > 0; index--)
			{
				ProcessType(CurrentType.GetCustomAttributes(inherit: false).ToArray());
			}
			ProcessType(attributes);
			CollectSingletons();
			return results.ToArray();
		}

		private void ProcessType(object[] attributes)
		{
			foreach (object obj in attributes)
			{
				Type type = obj.GetType();
				AttributeUsageAttribute attributeUsage = type.GetAttributeUsage();
				if (IsMostDerivedType || attributeUsage.Inherited)
				{
					if (attributeUsage.AllowMultiple)
					{
						results.Add(obj);
					}
					else
					{
						AddSingleton(obj, type);
					}
				}
			}
		}

		private void AddSingleton(object attribute, Type attributeType)
		{
			if (singletons.TryGetValue(attributeType, out var value) && value.Age == CurrentAge)
			{
				if (value.Value == ConflictMarker)
				{
					return;
				}
				attribute = ConflictMarker;
			}
			singletons[attributeType] = MakeAged(attribute);
		}

		private void CollectSingletons()
		{
			foreach (KeyValuePair<Type, Aged<object>> singleton in singletons)
			{
				object value = singleton.Value.Value;
				if (value == ConflictMarker)
				{
					HandleAttributeConflict(singleton.Key);
				}
				else
				{
					results.Add(value);
				}
			}
		}

		private void HandleAttributeConflict(Type attributeType)
		{
			throw new InvalidOperationException($"Cannot determine inherited attributes for interface type {CurrentType.FullName}.  Conflicting attributes of type {attributeType.FullName} exist in the inheritance graph.");
		}

		private static bool ShouldConsiderType(Type type)
		{
			string text = type.Namespace;
			if (text != "Castle.Components.DictionaryAdapter")
			{
				return text != "System.ComponentModel";
			}
			return false;
		}

		private Aged<T> MakeAged<T>(T value)
		{
			return new Aged<T>(value, CurrentAge);
		}
	}
}
