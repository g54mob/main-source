using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace RoslynCSharp
{
	public sealed class ScriptType
	{
		private static BindingFlags memberFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

		private static BindingFlags memberInstanceFlags = BindingFlags.Instance | memberFlags;

		private static BindingFlags memberStaticFlags = BindingFlags.Static | memberFlags;

		private static List<ScriptType> matchedTypes = new List<ScriptType>();

		private static List<object> matchedAttributes = new List<object>();

		private HashSet<object> typeAttributes;

		private Dictionary<string, FieldInfo> fieldCache = new Dictionary<string, FieldInfo>();

		private Dictionary<string, PropertyInfo> propertyCache = new Dictionary<string, PropertyInfo>();

		private Dictionary<string, MethodInfo> methodCache = new Dictionary<string, MethodInfo>();

		private Type rawType;

		private ScriptAssembly assembly;

		private ScriptType parent;

		private ScriptType[] nestedTypes;

		private ScriptFieldProxy fields;

		private ScriptPropertyProxy properies;

		public Type RawType => rawType;

		public string Name => rawType.Name;

		public string Namespace => rawType.Namespace;

		public string FullName => rawType.FullName;

		public bool IsPublic => rawType.IsPublic;

		public ScriptAssembly Assembly => assembly;

		public ScriptType Parent => parent;

		public bool IsNestedType => parent != null;

		public ScriptType[] NestedTypes => nestedTypes;

		public bool HasNestedTypes => nestedTypes.Length != 0;

		public IScriptMemberProxy FieldsStatic
		{
			get
			{
				fields.throwOnError = true;
				return fields;
			}
		}

		public IScriptMemberProxy SafeFieldsStatic
		{
			get
			{
				fields.throwOnError = false;
				return fields;
			}
		}

		public IScriptMemberProxy PropertiesStatic
		{
			get
			{
				properies.throwOnError = true;
				return properies;
			}
		}

		public IScriptMemberProxy SafePropertiesStatic
		{
			get
			{
				properies.throwOnError = false;
				return properies;
			}
		}

		public bool IsUnityObject => IsSubTypeOf<UnityEngine.Object>();

		public bool IsMonoBehaviour => IsSubTypeOf<MonoBehaviour>();

		public bool IsScriptableObject => IsSubTypeOf<ScriptableObject>();

		public ICollection<object> CustomAttributes
		{
			get
			{
				GenerateAttributeInformation();
				return typeAttributes;
			}
		}

		public ScriptType(Type type)
		{
			assembly = null;
			rawType = type;
			fields = new ScriptFieldProxy(isStatic: true, this);
			properies = new ScriptPropertyProxy(isStatic: true, this);
			Type[] array = type.GetNestedTypes(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			nestedTypes = new ScriptType[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				nestedTypes[i] = new ScriptType(array[i]);
			}
		}

		internal ScriptType(ScriptAssembly assembly, ScriptType parent, Type type)
		{
			this.assembly = assembly;
			this.parent = parent;
			rawType = type;
			fields = new ScriptFieldProxy(isStatic: true, this);
			properies = new ScriptPropertyProxy(isStatic: true, this);
			Type[] array = type.GetNestedTypes(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			nestedTypes = new ScriptType[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				nestedTypes[i] = new ScriptType(assembly, this, array[i]);
			}
		}

		public ScriptProxy CreateInstance(GameObject parent = null)
		{
			if (IsMonoBehaviour)
			{
				return CreateBehaviourInstance(parent);
			}
			if (IsScriptableObject)
			{
				return CreateScriptableInstance();
			}
			return CreateCSharpInstance();
		}

		public ScriptProxy CreateInstance(GameObject parent = null, params object[] parameters)
		{
			if (IsMonoBehaviour)
			{
				return CreateBehaviourInstance(parent);
			}
			if (IsScriptableObject)
			{
				return CreateScriptableInstance();
			}
			return CreateCSharpInstance(parameters);
		}

		public object CreateRawInstance(GameObject parent = null)
		{
			return CreateInstance(parent)?.Instance;
		}

		public object CreateRawInstance(GameObject parent = null, params object[] parameters)
		{
			return CreateInstance(parent, parameters)?.Instance;
		}

		public T CreateRawInstance<T>(GameObject parent = null)
		{
			ScriptProxy scriptProxy = CreateInstance(parent);
			if (scriptProxy == null)
			{
				return default(T);
			}
			return scriptProxy.GetInstanceAs<T>(throwOnError: false);
		}

		public T CreateRawInstance<T>(GameObject parent = null, params object[] parameters)
		{
			ScriptProxy scriptProxy = CreateInstance(parent);
			if (scriptProxy == null)
			{
				return default(T);
			}
			return scriptProxy.GetInstanceAs<T>(throwOnError: false);
		}

		private ScriptProxy CreateBehaviourInstance(GameObject parent)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			MonoBehaviour monoBehaviour = parent.AddComponent(rawType) as MonoBehaviour;
			if (monoBehaviour != null)
			{
				return new ScriptProxy(this, monoBehaviour);
			}
			return null;
		}

		private ScriptProxy CreateScriptableInstance()
		{
			ScriptableObject scriptableObject = ScriptableObject.CreateInstance(rawType);
			if (scriptableObject != null)
			{
				return new ScriptProxy(this, scriptableObject);
			}
			return null;
		}

		private ScriptProxy CreateCSharpInstance(params object[] args)
		{
			object obj = null;
			try
			{
				obj = Activator.CreateInstance(rawType, BindingFlags.Default, null, args, null);
			}
			catch (MissingMethodException)
			{
				if (args.Length != 0)
				{
					return null;
				}
				obj = FormatterServices.GetUninitializedObject(rawType);
			}
			if (obj != null)
			{
				return new ScriptProxy(this, obj);
			}
			return null;
		}

		public bool IsSubTypeOf(Type baseClass)
		{
			return baseClass.IsAssignableFrom(rawType);
		}

		public bool IsSubTypeOf<T>()
		{
			return IsSubTypeOf(typeof(T));
		}

		public FieldInfo FindCachedField(string name, bool isStatic)
		{
			if (fieldCache.ContainsKey(name))
			{
				return fieldCache[name];
			}
			BindingFlags bindingAttr = (isStatic ? memberStaticFlags : memberInstanceFlags);
			FieldInfo field = rawType.GetField(name, bindingAttr);
			if (field == null)
			{
				return null;
			}
			fieldCache.Add(name, field);
			return field;
		}

		public PropertyInfo FindCachedProperty(string name, bool isStatic)
		{
			if (propertyCache.ContainsKey(name))
			{
				return propertyCache[name];
			}
			BindingFlags bindingAttr = (isStatic ? memberStaticFlags : memberInstanceFlags);
			PropertyInfo property = rawType.GetProperty(name, bindingAttr);
			if (property == null)
			{
				return null;
			}
			propertyCache.Add(name, property);
			return property;
		}

		public MethodInfo FindCachedMethod(string name, bool isStatic)
		{
			if (methodCache.ContainsKey(name))
			{
				return methodCache[name];
			}
			BindingFlags bindingAttr = (isStatic ? memberStaticFlags : memberInstanceFlags);
			MethodInfo method = rawType.GetMethod(name, bindingAttr);
			if (method == null)
			{
				return null;
			}
			methodCache.Add(name, method);
			return method;
		}

		public object CallStatic(string methodName)
		{
			MethodInfo methodInfo = FindCachedMethod(methodName, isStatic: true);
			if (methodInfo == null)
			{
				throw new TargetException($"Type '{this}' does not define a static method called '{methodName}'");
			}
			if (!methodInfo.IsStatic)
			{
				throw new TargetException($"The target method '{methodName}' is not marked as static and must be called on an object");
			}
			return methodInfo.Invoke(null, null);
		}

		public object CallStatic(string methodName, params object[] arguments)
		{
			MethodInfo methodInfo = FindCachedMethod(methodName, isStatic: true);
			if (methodInfo == null)
			{
				throw new TargetException($"Type '{this}' does not define a static method called '{methodName}'");
			}
			if (!methodInfo.IsStatic)
			{
				throw new TargetException($"The target method '{methodName}' is not marked as static and must be called on an object");
			}
			return methodInfo.Invoke(null, arguments);
		}

		public object SafeCallStatic(string method)
		{
			try
			{
				return CallStatic(method);
			}
			catch
			{
				return null;
			}
		}

		public object SafeCallStatic(string method, params object[] arguments)
		{
			try
			{
				return CallStatic(method, arguments);
			}
			catch
			{
				return null;
			}
		}

		public bool HasAttribute(Type type, bool includeSubTypes = false)
		{
			foreach (object typeAttribute in typeAttributes)
			{
				if (!includeSubTypes)
				{
					if (typeAttribute.GetType() == type)
					{
						return true;
					}
				}
				else if (type.IsAssignableFrom(typeAttribute.GetType()))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAttribute<T>(bool includeSubTypes = false) where T : Attribute
		{
			return HasAttribute(typeof(T), includeSubTypes);
		}

		public object GetAttribute(Type type, bool includeSubTypes = false)
		{
			foreach (object typeAttribute in typeAttributes)
			{
				if (!includeSubTypes)
				{
					if (typeAttribute.GetType() == type)
					{
						return typeAttribute;
					}
				}
				else if (type.IsAssignableFrom(typeAttribute.GetType()))
				{
					return typeAttribute;
				}
			}
			return null;
		}

		public T GetAttribute<T>(bool includeSubTypes = false) where T : Attribute
		{
			return GetAttribute(typeof(T), includeSubTypes) as T;
		}

		public object[] GetAttributes(Type type, bool includeSubTypes = false)
		{
			matchedAttributes.Clear();
			foreach (object typeAttribute in typeAttributes)
			{
				if (!includeSubTypes)
				{
					if (typeAttribute.GetType() == type)
					{
						matchedAttributes.Add(typeAttribute);
					}
				}
				else if (type.IsAssignableFrom(typeAttribute.GetType()))
				{
					matchedAttributes.Add(typeAttribute);
				}
			}
			return matchedAttributes.ToArray();
		}

		public T[] GetAttributes<T>(bool includeSubTypes = false) where T : Attribute
		{
			return GetAttributes(typeof(T), includeSubTypes) as T[];
		}

		public override string ToString()
		{
			return $"ScriptType({rawType.Name})";
		}

		private void GenerateAttributeInformation()
		{
			if (typeAttributes == null)
			{
				typeAttributes = new HashSet<object>();
				object[] customAttributes = rawType.GetCustomAttributes(inherit: false);
				foreach (object item in customAttributes)
				{
					typeAttributes.Add(item);
				}
			}
		}

		public ScriptType FindNestedType(string nestedTypeName)
		{
			return Array.Find(nestedTypes, (ScriptType t) => t.Name == nestedTypeName);
		}

		public ScriptType FindNestedTypeFullName(string nestedTypeFullName)
		{
			return Array.Find(nestedTypes, (ScriptType t) => t.FullName == nestedTypeFullName);
		}

		public static ScriptType FindType(string typeName, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return null;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType scriptType = assemblies[i].FindType(typeName);
				if (scriptType != null)
				{
					return scriptType;
				}
			}
			return null;
		}

		public static ScriptType FindSubTypeOf(string typeName, Type subType, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return null;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType scriptType = assemblies[i].FindSubTypeOf(subType, typeName);
				if (scriptType != null)
				{
					return scriptType;
				}
			}
			return null;
		}

		public static ScriptType FindSubTypeOf<T>(string typeName, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return null;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType scriptType = assemblies[i].FindSubTypeOf<T>(typeName);
				if (scriptType != null)
				{
					return scriptType;
				}
			}
			return null;
		}

		public static ScriptType FindSubTypeOf(Type subType, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return null;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType scriptType = assemblies[i].FindSubTypeOf(subType);
				if (scriptType != null)
				{
					return scriptType;
				}
			}
			return null;
		}

		public static ScriptType FindSubTypeOf<T>(ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return null;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType scriptType = assemblies[i].FindSubTypeOf<T>();
				if (scriptType != null)
				{
					return scriptType;
				}
			}
			return null;
		}

		public static ScriptType[] FindAllSubTypesOf(Type subType, bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return new ScriptType[0];
			}
			matchedTypes.Clear();
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType[] collection = assemblies[i].FindAllSubTypesOf(subType, includeNonPublic);
				matchedTypes.AddRange(collection);
			}
			return matchedTypes.ToArray();
		}

		public static ScriptType[] FindAllSubTypesOf<T>(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return new ScriptType[0];
			}
			matchedTypes.Clear();
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType[] collection = assemblies[i].FindAllSubTypesOf<T>(includeNonPublic);
				matchedTypes.AddRange(collection);
			}
			return matchedTypes.ToArray();
		}

		public static ScriptType[] FindAllTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return new ScriptType[0];
			}
			matchedTypes.Clear();
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType[] collection = assemblies[i].FindAllTypes(includeNonPublic);
				matchedTypes.AddRange(collection);
			}
			return matchedTypes.ToArray();
		}

		public static ScriptType[] FindAllUnityTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return new ScriptType[0];
			}
			matchedTypes.Clear();
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType[] collection = assemblies[i].FindAllUnityTypes(includeNonPublic);
				matchedTypes.AddRange(collection);
			}
			return matchedTypes.ToArray();
		}

		public static ScriptType[] FindAllMonoBehaviourTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return new ScriptType[0];
			}
			matchedTypes.Clear();
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType[] collection = assemblies[i].FindAllMonoBehaviourTypes(includeNonPublic);
				matchedTypes.AddRange(collection);
			}
			return matchedTypes.ToArray();
		}

		public static ScriptType[] FindAllScriptableObjectTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				return new ScriptType[0];
			}
			matchedTypes.Clear();
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			for (int i = 0; i < assemblies.Length; i++)
			{
				ScriptType[] collection = assemblies[i].FindAllScriptableObjectTypes(includeNonPublic);
				matchedTypes.AddRange(collection);
			}
			return matchedTypes.ToArray();
		}

		public static IEnumerable<ScriptType> EnumerateAllSubTypesOf(Type subType, bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				yield break;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			foreach (ScriptAssembly scriptAssembly in assemblies)
			{
				foreach (ScriptType item in scriptAssembly.EnumerateAllSubTypesOf(subType, includeNonPublic))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<ScriptType> EnumerateAllSubTypesOf<T>(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				yield break;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			foreach (ScriptAssembly scriptAssembly in assemblies)
			{
				foreach (ScriptType item in scriptAssembly.EnumerateAllSubTypesOf<T>(includeNonPublic))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<ScriptType> EnumerateAllTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				yield break;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			foreach (ScriptAssembly scriptAssembly in assemblies)
			{
				foreach (ScriptType item in scriptAssembly.EnumerateAllTypes(includeNonPublic))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<ScriptType> EnumerateAllUnityTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				yield break;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			foreach (ScriptAssembly scriptAssembly in assemblies)
			{
				foreach (ScriptType item in scriptAssembly.EnumerateAllUnityTypes(includeNonPublic))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<ScriptType> EnumerateAllMonoBehaviourTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				yield break;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			foreach (ScriptAssembly scriptAssembly in assemblies)
			{
				foreach (ScriptType item in scriptAssembly.EnumerateAllMonoBehaviourTypes(includeNonPublic))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<ScriptType> EnumerateAllScriptableObjectTypes(bool includeNonPublic = true, ScriptDomain searchDomain = null)
		{
			if (!ResolveSearchDomain(ref searchDomain))
			{
				yield break;
			}
			ScriptAssembly[] assemblies = searchDomain.Assemblies;
			foreach (ScriptAssembly scriptAssembly in assemblies)
			{
				foreach (ScriptType item in scriptAssembly.EnumerateAllScriptableObjectTypes(includeNonPublic))
				{
					yield return item;
				}
			}
		}

		private static bool ResolveSearchDomain(ref ScriptDomain searchDomain)
		{
			if (searchDomain == null)
			{
				searchDomain = ScriptDomain.Active;
				if (searchDomain == null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
