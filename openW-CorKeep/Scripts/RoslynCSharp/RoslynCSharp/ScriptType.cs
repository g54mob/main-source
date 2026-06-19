using System;
using System.Collections.Generic;
using System.Reflection;
using RoslynCSharp.Implementation;
using UnityEngine;

namespace RoslynCSharp
{
	public abstract class ScriptType
	{
		private static List<ScriptType> matchedTypes = new List<ScriptType>();

		private static List<object> matchedAttributes = new List<object>();

		private static readonly object[] emptyObjectArray = Array.Empty<object>();

		private IScriptDataProxy fields;

		private IScriptDataProxy safeFields;

		private IScriptDataProxy properties;

		private IScriptDataProxy safeProperties;

		private IScriptEventProxy events;

		private IScriptEventProxy safeEvents;

		private Dictionary<string, FieldInfo> fieldCache;

		private Dictionary<string, PropertyInfo> propertyCache;

		private Dictionary<string, MethodInfo> methodCache;

		private Dictionary<string, EventInfo> eventCache;

		public const BindingFlags instanceAttrib = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

		public const BindingFlags staticAttrib = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

		public abstract ScriptAssembly Assembly { get; }

		public abstract ScriptType Parent { get; }

		public abstract Type SystemType { get; }

		public virtual string Name => SystemType.Name;

		public virtual string Namespace => SystemType.Namespace;

		public virtual string FullName => SystemType.FullName;

		public virtual bool IsPublic => SystemType.IsPublic;

		public abstract bool IsNestedType { get; }

		public abstract bool HasNestedTypes { get; }

		public abstract ScriptType[] NestedTypes { get; }

		public virtual IScriptDataProxy FieldsStatic
		{
			get
			{
				if (fields == null)
				{
					fields = new ScriptFieldDataProxy(this, null, isStatic: true, throwOnError: true);
				}
				return fields;
			}
		}

		public virtual IScriptDataProxy SafeFieldsStatic
		{
			get
			{
				if (safeFields == null)
				{
					safeFields = new ScriptFieldDataProxy(this, null, isStatic: true, throwOnError: false);
				}
				return safeFields;
			}
		}

		public virtual IScriptDataProxy PropertiesStatic
		{
			get
			{
				if (properties == null)
				{
					properties = new ScriptPropertyDataProxy(this, null, isStatic: true, throwOnError: true);
				}
				return properties;
			}
		}

		public virtual IScriptDataProxy SafePropertiesStatic
		{
			get
			{
				if (safeProperties == null)
				{
					safeProperties = new ScriptPropertyDataProxy(this, null, isStatic: true, throwOnError: false);
				}
				return safeProperties;
			}
		}

		public virtual IScriptEventProxy EventsStatic
		{
			get
			{
				if (events == null)
				{
					events = new ScriptEventHandlerProxy(this, null, isStatic: true, throwOnError: true);
				}
				return events;
			}
		}

		public virtual IScriptEventProxy SafeEventsStatic
		{
			get
			{
				if (safeEvents == null)
				{
					safeEvents = new ScriptEventHandlerProxy(this, null, isStatic: true, throwOnError: false);
				}
				return safeEvents;
			}
		}

		public bool IsUnityObject => IsSubTypeOf<UnityEngine.Object>();

		public bool IsMonoBehaviour => IsSubTypeOf<MonoBehaviour>();

		public bool IsScriptableObject => IsSubTypeOf<ScriptableObject>();

		public abstract ICollection<object> CustomAttributes { get; }

		protected abstract void ConstructInstance(ScriptAssembly assembly, ScriptType parent, ScriptType[] nestedTypes, Type systemType);

		public override string ToString()
		{
			return string.Format("{0}({1})", "ScriptType", SystemType);
		}

		public virtual ScriptProxy CreateInstance(GameObject parent = null)
		{
			ScriptProxy scriptProxy = null;
			if (IsMonoBehaviour)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("Cannot create mono behaviour instance because a null parent game object was supplied");
				}
				scriptProxy = CreateMonoBehaviourInstanceImpl(parent);
				if (scriptProxy != null)
				{
					Assembly.Domain.Execution.AddScriptProxy(scriptProxy);
				}
				return scriptProxy;
			}
			if (IsScriptableObject)
			{
				scriptProxy = CreateScriptableObjectInstanceImpl();
				if (scriptProxy != null)
				{
					Assembly.Domain.Execution.AddScriptProxy(scriptProxy);
				}
				return scriptProxy;
			}
			scriptProxy = CreateInstanceImpl(emptyObjectArray);
			if (scriptProxy != null)
			{
				Assembly.Domain.Execution.AddScriptProxy(scriptProxy);
			}
			return scriptProxy;
		}

		public virtual ScriptProxy CreateInstance(GameObject parent = null, params object[] args)
		{
			ScriptProxy scriptProxy = null;
			if (IsMonoBehaviour)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("Cannot create mono behaviour instance because a null parent game object was supplied");
				}
				scriptProxy = CreateMonoBehaviourInstanceImpl(parent);
				if (scriptProxy != null)
				{
					Assembly.Domain.Execution.AddScriptProxy(scriptProxy);
				}
				return scriptProxy;
			}
			if (IsScriptableObject)
			{
				scriptProxy = CreateScriptableObjectInstanceImpl();
				if (scriptProxy != null)
				{
					Assembly.Domain.Execution.AddScriptProxy(scriptProxy);
				}
				return scriptProxy;
			}
			if (args == null)
			{
				args = emptyObjectArray;
			}
			scriptProxy = CreateInstanceImpl(args);
			if (scriptProxy != null)
			{
				Assembly.Domain.Execution.AddScriptProxy(scriptProxy);
			}
			return scriptProxy;
		}

		public virtual object CreateInstanceRaw(GameObject parent = null)
		{
			return CreateInstance(parent).Instance;
		}

		public virtual T CreateInstanceRaw<T>(GameObject parent = null)
		{
			try
			{
				return CreateInstance(parent).GetInstanceAs<T>(throwOnError: false);
			}
			catch (NullReferenceException)
			{
				return default(T);
			}
		}

		public virtual T CreateInstanceRaw<T>(GameObject parent = null, params object[] args)
		{
			try
			{
				return CreateInstance(parent, args).GetInstanceAs<T>(throwOnError: false);
			}
			catch (NullReferenceException)
			{
				return default(T);
			}
		}

		public virtual object CreateInstanceRaw(GameObject parent = null, params object[] args)
		{
			return CreateInstance(parent, args).Instance;
		}

		protected abstract ScriptProxy CreateMonoBehaviourInstanceImpl(GameObject parent);

		protected abstract ScriptProxy CreateScriptableObjectInstanceImpl();

		protected abstract ScriptProxy CreateInstanceImpl(object[] args);

		public virtual bool IsSubTypeOf(Type subType)
		{
			return subType.IsAssignableFrom(SystemType);
		}

		public bool IsSubTypeOf<T>()
		{
			return IsSubTypeOf(typeof(T));
		}

		public FieldInfo FindCachedField(string name, bool isStatic)
		{
			FieldInfo value = null;
			if (fieldCache != null && fieldCache.TryGetValue(name, out value) && value.IsStatic == isStatic)
			{
				return value;
			}
			BindingFlags bindingAttrib = (isStatic ? (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
			value = FindFieldImpl(name, bindingAttrib);
			if (value == null)
			{
				return null;
			}
			if (fieldCache == null)
			{
				fieldCache = new Dictionary<string, FieldInfo>();
			}
			if (!fieldCache.ContainsKey(name))
			{
				fieldCache.Add(name, value);
			}
			return value;
		}

		protected abstract FieldInfo FindFieldImpl(string name, BindingFlags bindingAttrib);

		public PropertyInfo FindCachedProperty(string name, bool isStatic)
		{
			PropertyInfo value = null;
			if (propertyCache != null && propertyCache.TryGetValue(name, out value) && value.GetGetMethod().IsStatic == isStatic)
			{
				return value;
			}
			BindingFlags bindingAttib = (isStatic ? (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
			value = FindPropertyImpl(name, bindingAttib);
			if (value == null)
			{
				return null;
			}
			if (propertyCache == null)
			{
				propertyCache = new Dictionary<string, PropertyInfo>();
			}
			if (!propertyCache.ContainsKey(name))
			{
				propertyCache.Add(name, value);
			}
			return value;
		}

		protected abstract PropertyInfo FindPropertyImpl(string name, BindingFlags bindingAttib);

		public MethodInfo FindCachedMethod(string name, bool isStatic)
		{
			MethodInfo value = null;
			if (methodCache != null && methodCache.TryGetValue(name, out value) && value.IsStatic == isStatic)
			{
				return value;
			}
			BindingFlags bindingAttrib = (isStatic ? (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
			value = FindMethodImpl(name, bindingAttrib);
			if (value == null)
			{
				return null;
			}
			if (methodCache == null)
			{
				methodCache = new Dictionary<string, MethodInfo>();
			}
			if (!methodCache.ContainsKey(name))
			{
				methodCache.Add(name, value);
			}
			return value;
		}

		protected abstract MethodInfo FindMethodImpl(string name, BindingFlags bindingAttrib);

		public EventInfo FindCachedEvent(string name, bool isStatic)
		{
			EventInfo value = null;
			if (eventCache != null && eventCache.TryGetValue(name, out value) && value.GetAddMethod().IsStatic == isStatic)
			{
				return value;
			}
			BindingFlags bindingAttrib = (isStatic ? (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
			value = FindEventImpl(name, bindingAttrib);
			if (value == null)
			{
				return null;
			}
			if (eventCache == null)
			{
				eventCache = new Dictionary<string, EventInfo>();
			}
			if (!eventCache.ContainsKey(name))
			{
				eventCache.Add(name, value);
			}
			return value;
		}

		protected abstract EventInfo FindEventImpl(string name, BindingFlags bindingAttrib);

		public virtual object CallStatic(string methodName)
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

		public virtual object CallStatic(string methodName, params object[] arguments)
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

		public virtual object SafeCallStatic(string method)
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

		public virtual object SafeCallStatic(string method, params object[] arguments)
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

		public virtual bool HasAttribute(Type type, bool includeSubTypes = false)
		{
			foreach (object customAttribute in CustomAttributes)
			{
				if (!includeSubTypes)
				{
					if (customAttribute.GetType() == type)
					{
						return true;
					}
				}
				else if (type.IsAssignableFrom(customAttribute.GetType()))
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

		public virtual object GetAttribute(Type type, bool includeSubTypes = false)
		{
			foreach (object customAttribute in CustomAttributes)
			{
				if (!includeSubTypes)
				{
					if (customAttribute.GetType() == type)
					{
						return customAttribute;
					}
				}
				else if (type.IsAssignableFrom(customAttribute.GetType()))
				{
					return customAttribute;
				}
			}
			return null;
		}

		public T GetAttribute<T>(bool includeSubTypes = false) where T : Attribute
		{
			return GetAttribute(typeof(T), includeSubTypes) as T;
		}

		public virtual object[] GetAttributes(Type type, bool includeSubTypes = false)
		{
			matchedAttributes.Clear();
			foreach (object customAttribute in CustomAttributes)
			{
				if (!includeSubTypes)
				{
					if (customAttribute.GetType() == type)
					{
						matchedAttributes.Add(customAttribute);
					}
				}
				else if (type.IsAssignableFrom(customAttribute.GetType()))
				{
					matchedAttributes.Add(customAttribute);
				}
			}
			return matchedAttributes.ToArray();
		}

		public T[] GetAttributes<T>(bool includeSubTypes = false) where T : Attribute
		{
			return GetAttributes(typeof(T), includeSubTypes) as T[];
		}

		public virtual ScriptType FindNestedType(string nestedTypeName)
		{
			return Array.Find(NestedTypes, (ScriptType t) => t.Name == nestedTypeName);
		}

		public virtual ScriptType FindNestedTypeFullName(string nestedTypeFullName)
		{
			return Array.Find(NestedTypes, (ScriptType t) => t.FullName == nestedTypeFullName);
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

		public static ScriptType CreateScriptType(ScriptAssembly assembly, ScriptType parent, Type systemType)
		{
			return CreateScriptType<ScriptTypeImpl>(assembly, parent, systemType);
		}

		public static T CreateScriptType<T>(ScriptAssembly assembly, ScriptType parent, Type systemType) where T : ScriptType, new()
		{
			T val = new T();
			Type[] nestedTypes = systemType.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
			ScriptType[] array = new ScriptType[nestedTypes.Length];
			for (int i = 0; i < nestedTypes.Length; i++)
			{
				array[i] = CreateScriptType<T>(assembly, val, nestedTypes[i]);
			}
			val.ConstructInstance(assembly, parent, array, systemType);
			return val;
		}
	}
}
