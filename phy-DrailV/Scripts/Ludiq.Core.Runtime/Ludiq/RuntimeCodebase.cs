using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Ludiq.AssemblyQualifiedNameParser;
using UnityEngine;

namespace Ludiq
{
	public static class RuntimeCodebase
	{
		private static readonly object @lock;

		private static readonly List<Type> _types;

		private static readonly List<Assembly> _assemblies;

		private static readonly Dictionary<string, Type> typeSerializations;

		private static Dictionary<string, string> _renamedTypes;

		private static readonly Dictionary<Type, Dictionary<string, string>> _renamedMembers;

		public static IEnumerable<Type> types => _types;

		public static IEnumerable<Assembly> assemblies => _assemblies;

		public static Dictionary<string, string> renamedTypes
		{
			get
			{
				if (_renamedTypes == null)
				{
					_renamedTypes = FetchRenamedTypes();
				}
				return _renamedTypes;
			}
		}

		static RuntimeCodebase()
		{
			@lock = new object();
			_types = new List<Type>();
			_assemblies = new List<Assembly>();
			typeSerializations = new Dictionary<string, Type>();
			_renamedTypes = null;
			_renamedMembers = new Dictionary<Type, Dictionary<string, string>>();
			lock (@lock)
			{
				Assembly[] array = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in array)
				{
					_assemblies.Add(assembly);
					foreach (Type item in assembly.GetTypesSafely())
					{
						_types.Add(item);
					}
				}
			}
		}

		public static void PrewarmTypeDeserialization(Type type)
		{
			Ensure.That("type").IsNotNull(type);
			string key = SerializeType(type);
			if (!typeSerializations.ContainsKey(key))
			{
				typeSerializations.Add(key, type);
			}
		}

		public static string SerializeType(Type type)
		{
			Ensure.That("type").IsNotNull(type);
			return type?.FullName;
		}

		public static bool TryDeserializeType(string typeName, out Type type)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				type = null;
				return false;
			}
			lock (@lock)
			{
				if (!TryCachedTypeLookup(typeName, out type))
				{
					if (!TrySystemTypeLookup(typeName, out type) && !TryRenamedTypeLookup(typeName, out type))
					{
						return false;
					}
					typeSerializations.Add(typeName, type);
				}
				return true;
			}
		}

		public static Type DeserializeType(string typeName)
		{
			if (!TryDeserializeType(typeName, out var type))
			{
				throw new SerializationException("Unable to find type: '" + (typeName ?? "(null)") + "'.");
			}
			return type;
		}

		private static bool TryCachedTypeLookup(string typeName, out Type type)
		{
			return typeSerializations.TryGetValue(typeName, out type);
		}

		private static bool TrySystemTypeLookup(string typeName, out Type type)
		{
			foreach (Assembly assembly in _assemblies)
			{
				type = assembly.GetType(typeName);
				if (type != null)
				{
					return true;
				}
			}
			type = null;
			return false;
		}

		private static bool TryRenamedTypeLookup(string previousTypeName, out Type type)
		{
			if (!renamedTypes.TryGetValue(previousTypeName, out var value))
			{
				ParsedAssemblyQualifiedName parsedAssemblyQualifiedName = new ParsedAssemblyQualifiedName(previousTypeName);
				foreach (KeyValuePair<string, string> renamedType in renamedTypes)
				{
					parsedAssemblyQualifiedName.Replace(renamedType.Key, renamedType.Value);
				}
				value = parsedAssemblyQualifiedName.ToString();
			}
			if (TrySystemTypeLookup(value, out type))
			{
				return true;
			}
			type = null;
			return false;
		}

		public static Dictionary<string, string> RenamedMembers(Type type)
		{
			if (!_renamedMembers.TryGetValue(type, out var value))
			{
				value = FetchRenamedMembers(type);
				_renamedMembers.Add(type, value);
			}
			return value;
		}

		private static Dictionary<string, string> FetchRenamedMembers(Type type)
		{
			Ensure.That("type").IsNotNull(type);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			MemberInfo[] extendedMembers = type.GetExtendedMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			MemberInfo[] array = extendedMembers;
			foreach (MemberInfo memberInfo in array)
			{
				IEnumerable<RenamedFromAttribute> enumerable;
				try
				{
					enumerable = Attribute.GetCustomAttributes(memberInfo, typeof(RenamedFromAttribute), inherit: false).Cast<RenamedFromAttribute>();
				}
				catch (Exception arg)
				{
					Debug.LogWarning($"Failed to fetch RenamedFrom attributes for member '{memberInfo}':\n{arg}");
					continue;
				}
				string name = memberInfo.Name;
				foreach (RenamedFromAttribute item in enumerable)
				{
					string previousName = item.previousName;
					if (dictionary.ContainsKey(previousName))
					{
						Debug.LogWarning($"Multiple members on '{type}' indicate having been renamed from '{previousName}'.\nIgnoring renamed attributes for '{memberInfo}'.");
					}
					else
					{
						dictionary.Add(previousName, name);
					}
				}
			}
			return dictionary;
		}

		private static Dictionary<string, string> FetchRenamedTypes()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (Assembly assembly in assemblies)
			{
				foreach (Type item in assembly.GetTypesSafely())
				{
					IEnumerable<RenamedFromAttribute> enumerable;
					try
					{
						enumerable = Attribute.GetCustomAttributes(item, typeof(RenamedFromAttribute), inherit: false).Cast<RenamedFromAttribute>();
					}
					catch (Exception arg)
					{
						Debug.LogWarning($"Failed to fetch RenamedFrom attributes for type '{item}':\n{arg}");
						continue;
					}
					string fullName = item.FullName;
					foreach (RenamedFromAttribute item2 in enumerable)
					{
						string previousName = item2.previousName;
						if (dictionary.ContainsKey(previousName))
						{
							Debug.LogWarning($"Multiple types indicate having been renamed from '{previousName}'.\nIgnoring renamed attributes for '{item}'.");
						}
						else
						{
							dictionary.Add(previousName, fullName);
						}
					}
				}
			}
			return dictionary;
		}
	}
}
