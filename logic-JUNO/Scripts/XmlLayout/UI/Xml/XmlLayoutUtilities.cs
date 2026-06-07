using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UI.Xml.Configuration;
using UnityEngine;

namespace UI.Xml
{
	public static class XmlLayoutUtilities
	{
		private static List<Type> m_TagHandlerTypes;

		private static List<string> m_TagHandlerNames;

		private static Dictionary<string, ElementTagHandler> m_TagHandlers;

		private static List<Type> m_CustomXmlAttributeTypes;

		private static Dictionary<string, CustomXmlAttribute> m_CustomXmlAttributes;

		private static List<string> m_CustomAttributeTypeNames;

		private static XmlLayoutConfiguration m_XmlLayoutConfiguration;

		private static Dictionary<string, UnityEngine.Object> m_CachedResources;

		private static List<string> m_AssemblyNames;

		private static List<Type> m_XmlLayoutControllerTypes;

		private static List<string> m_XmlLayoutControllerNames;

		private static List<string> additionalAssemblies;

		private static Dictionary<Type, string> cachedTagNames;

		private static Dictionary<string, bool> isCustomAttributeCache;

		internal static BindingFlags BindingFlags;

		public static XmlLayoutConfiguration XmlLayoutConfiguration
		{
			get
			{
				if (m_XmlLayoutConfiguration == null)
				{
					m_XmlLayoutConfiguration = Resources.Load<XmlLayoutConfiguration>("XmlLayout_Configuration");
				}
				return m_XmlLayoutConfiguration;
			}
		}

		static XmlLayoutUtilities()
		{
			m_TagHandlerTypes = null;
			m_TagHandlerNames = null;
			m_TagHandlers = new Dictionary<string, ElementTagHandler>(StringComparer.OrdinalIgnoreCase);
			m_CustomXmlAttributeTypes = null;
			m_CustomXmlAttributes = new Dictionary<string, CustomXmlAttribute>(StringComparer.OrdinalIgnoreCase);
			m_CustomAttributeTypeNames = null;
			m_CachedResources = new Dictionary<string, UnityEngine.Object>(StringComparer.OrdinalIgnoreCase);
			m_AssemblyNames = new List<string>();
			m_XmlLayoutControllerTypes = null;
			m_XmlLayoutControllerNames = null;
			additionalAssemblies = new List<string>();
			cachedTagNames = new Dictionary<Type, string>();
			isCustomAttributeCache = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
			BindingFlags = BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public;
		}

		public static void AddAdditionalAssembly(string newAssembly)
		{
			additionalAssemblies.Add(newAssembly);
		}

		public static void ClearAssemblyNames()
		{
			m_AssemblyNames.Clear();
		}

		public static List<string> GetAssemblyNames()
		{
			if (m_AssemblyNames.Count == 0)
			{
				m_AssemblyNames = new List<string>();
				m_AssemblyNames.Add(Assembly.GetExecutingAssembly().FullName);
				m_AssemblyNames.Add(Assembly.GetAssembly(typeof(ElementTagHandler)).FullName);
				if (XmlLayoutConfiguration.ComprehensiveCustomElementAndAttributeCheck)
				{
					m_AssemblyNames.AddRange((from a in Assembly.GetExecutingAssembly().GetReferencedAssemblies()
						select a.FullName).ToList());
					m_AssemblyNames.AddRange(from a in AppDomain.CurrentDomain.GetAssemblies()
						select a.FullName);
				}
				if (XmlLayoutConfiguration.CustomAssemblyList != null)
				{
					m_AssemblyNames.AddRange(XmlLayoutConfiguration.CustomAssemblyList);
				}
				m_AssemblyNames = m_AssemblyNames.Distinct().ToList();
				m_AssemblyNames.RemoveAll((string s) => s.StartsWith("Anonymously Hosted DynamicMethods"));
				m_AssemblyNames.RemoveAll((string s) => s.StartsWith("Microsoft.GeneratedCode"));
				if (XmlLayoutConfiguration.AssemblyExcludeList != null)
				{
					foreach (string exclude in XmlLayoutConfiguration.AssemblyExcludeList)
					{
						m_AssemblyNames.RemoveAll((string s) => s.StartsWith(exclude));
					}
				}
			}
			m_AssemblyNames.AddRange(additionalAssemblies);
			m_AssemblyNames = m_AssemblyNames.Distinct().ToList();
			return m_AssemblyNames;
		}

		private static void LoadTagHandlerTypesIfNecessary()
		{
			if (m_TagHandlerTypes != null)
			{
				return;
			}
			m_TagHandlerTypes = new List<Type>();
			List<string> assemblyNames = GetAssemblyNames();
			Type elementTagHandlerType = typeof(ElementTagHandler);
			foreach (string item in assemblyNames)
			{
				try
				{
					m_TagHandlerTypes.AddRange((from t in Assembly.Load(item).GetTypes()
						where !t.IsAbstract && t.IsSubclassOf(elementTagHandlerType)
						select t).ToList());
				}
				catch
				{
				}
			}
			m_TagHandlerNames = m_TagHandlerTypes.Select((Type t) => GetTagName(t)).ToList();
		}

		internal static string GetTagName(Type tagHandler)
		{
			if (cachedTagNames.ContainsKey(tagHandler))
			{
				return cachedTagNames[tagHandler];
			}
			ElementTagHandlerAttribute elementTagHandlerAttribute = (ElementTagHandlerAttribute)Attribute.GetCustomAttribute(tagHandler, typeof(ElementTagHandlerAttribute));
			string text = null;
			text = ((elementTagHandlerAttribute == null || string.IsNullOrEmpty(elementTagHandlerAttribute.TagName)) ? tagHandler.Name.Replace("TagHandler", string.Empty) : elementTagHandlerAttribute.TagName);
			cachedTagNames.Add(tagHandler, text);
			return text;
		}

		public static List<Type> GetXmlLayoutControllerTypes()
		{
			if (m_XmlLayoutControllerTypes == null)
			{
				List<string> assemblyNames = GetAssemblyNames();
				m_XmlLayoutControllerNames = new List<string>();
				m_XmlLayoutControllerTypes = new List<Type>();
				Type xmlLayoutControllerType = typeof(XmlLayoutController);
				foreach (string item in assemblyNames)
				{
					try
					{
						m_XmlLayoutControllerTypes.AddRange((from t in Assembly.Load(item).GetTypes()
							where !t.IsAbstract && t.IsSubclassOf(xmlLayoutControllerType)
							select t).ToList());
					}
					catch
					{
					}
				}
				m_XmlLayoutControllerNames = m_XmlLayoutControllerTypes.Select((Type t) => t.Name).ToList();
			}
			return m_XmlLayoutControllerTypes;
		}

		public static List<string> GetXmlLayoutControllerNames()
		{
			if (m_XmlLayoutControllerNames == null)
			{
				GetXmlLayoutControllerTypes();
			}
			return m_XmlLayoutControllerNames;
		}

		public static Type GetXmlLayoutControllerType(string controllerName)
		{
			return GetXmlLayoutControllerTypes().FirstOrDefault((Type c) => c.Name == controllerName);
		}

		public static ElementTagHandler GetXmlTagHandler(string tag)
		{
			if (!m_TagHandlers.ContainsKey(tag))
			{
				LoadTagHandlerTypesIfNecessary();
				Type type = m_TagHandlerTypes.FirstOrDefault((Type t) => GetTagName(t).Equals(tag, StringComparison.OrdinalIgnoreCase));
				if (type == null)
				{
					Debug.LogError("[XmlLayout] Unknown tag '" + tag + "'.\r\nTag Handlers must inherit from 'ElementTagHandler', and must be named {Tag}TagHandler.");
					return null;
				}
				m_TagHandlers.Add(tag, (ElementTagHandler)Activator.CreateInstance(type));
			}
			return m_TagHandlers[tag];
		}

		public static List<ElementTagHandler> GetXmlTagHandlers()
		{
			LoadTagHandlerTypesIfNecessary();
			return m_TagHandlers.Select((KeyValuePair<string, ElementTagHandler> t) => t.Value).ToList();
		}

		public static List<string> GetXmlTagHandlerNames()
		{
			LoadTagHandlerTypesIfNecessary();
			return m_TagHandlerNames;
		}

		private static void PopulateCustomAttributeDataIfNecessary()
		{
			if (m_CustomXmlAttributeTypes != null)
			{
				return;
			}
			m_CustomXmlAttributeTypes = new List<Type>();
			List<string> assemblyNames = GetAssemblyNames();
			Type customXmlAttributeType = typeof(CustomXmlAttribute);
			foreach (string item in assemblyNames)
			{
				try
				{
					m_CustomXmlAttributeTypes.AddRange((from t in Assembly.Load(item).GetTypes()
						where !t.IsAbstract && t.IsSubclassOf(customXmlAttributeType)
						select t).ToList());
				}
				catch
				{
				}
			}
			m_CustomAttributeTypeNames = m_CustomXmlAttributeTypes.Select((Type s) => s.Name.Replace("Attribute", string.Empty)).ToList();
		}

		public static List<string> GetCustomAttributeNames()
		{
			PopulateCustomAttributeDataIfNecessary();
			return m_CustomAttributeTypeNames;
		}

		public static Dictionary<CustomXmlAttribute.eAttributeGroup, List<string>> GetGroupedCustomAttributeNames()
		{
			PopulateCustomAttributeDataIfNecessary();
			Dictionary<CustomXmlAttribute.eAttributeGroup, List<string>> dictionary = new Dictionary<CustomXmlAttribute.eAttributeGroup, List<string>>();
			foreach (string customAttributeTypeName in m_CustomAttributeTypeNames)
			{
				CustomXmlAttribute customAttribute = GetCustomAttribute(customAttributeTypeName);
				if (!dictionary.ContainsKey(customAttribute.AttributeGroup))
				{
					dictionary.Add(customAttribute.AttributeGroup, new List<string>());
				}
				dictionary[customAttribute.AttributeGroup].Add(customAttributeTypeName);
			}
			return dictionary;
		}

		private static List<Type> GetCustomAttributeTypes()
		{
			PopulateCustomAttributeDataIfNecessary();
			return m_CustomXmlAttributeTypes;
		}

		public static bool IsCustomAttribute(string attributeName)
		{
			if (isCustomAttributeCache.ContainsKey(attributeName))
			{
				return isCustomAttributeCache[attributeName];
			}
			bool flag = GetCustomAttributeNames().Contains(attributeName, StringComparer.OrdinalIgnoreCase);
			isCustomAttributeCache.Add(attributeName, flag);
			return flag;
		}

		public static CustomXmlAttribute GetCustomAttribute(string attributeName)
		{
			PopulateCustomAttributeDataIfNecessary();
			if (!m_CustomXmlAttributes.ContainsKey(attributeName))
			{
				string attributeTypeName = attributeName + "Attribute";
				Type type = m_CustomXmlAttributeTypes.FirstOrDefault((Type t) => t.Name.Equals(attributeTypeName, StringComparison.OrdinalIgnoreCase));
				if (type == null)
				{
					Debug.LogWarning("[XmlLayout] Unknown Custom Attribute '" + attributeName + "'.");
					return null;
				}
				m_CustomXmlAttributes.Add(attributeName, (CustomXmlAttribute)Activator.CreateInstance(type));
			}
			return m_CustomXmlAttributes[attributeName];
		}

		public static AttributeDictionary MergeAttributes(AttributeDictionary defaults, AttributeDictionary elementAttributes)
		{
			AttributeDictionary attributeDictionary = defaults.Clone();
			if (elementAttributes == null)
			{
				return attributeDictionary;
			}
			foreach (KeyValuePair<string, string> elementAttribute in elementAttributes)
			{
				if (!attributeDictionary.ContainsKey(elementAttribute.Key))
				{
					attributeDictionary.Add(elementAttribute.Key, elementAttribute.Value);
				}
				else
				{
					attributeDictionary[elementAttribute.Key] = elementAttribute.Value;
				}
			}
			return attributeDictionary;
		}

		public static T LoadResource<T>(string path, bool ignoreCache = false) where T : UnityEngine.Object
		{
			if (path == null)
			{
				return null;
			}
			UnityEngine.Object obj = null;
			obj = XmlLayoutResourceDatabase.instance.GetResource<T>(path);
			if (obj != null)
			{
				return obj as T;
			}
			if (!ignoreCache)
			{
				string key = $"{typeof(T).Name}|{path}";
				if (!m_CachedResources.TryGetValue(key, out obj))
				{
					if (path.Contains(":"))
					{
						T[] array = Resources.LoadAll<T>(path.Substring(0, path.IndexOf(":")));
						string text = path.Substring(path.IndexOf(":") + 1);
						T[] array2 = array;
						foreach (T val in array2)
						{
							if (text == val.name)
							{
								obj = val;
								break;
							}
						}
					}
					else
					{
						obj = Resources.Load<T>(path);
					}
					if (obj != null)
					{
						m_CachedResources.Add(key, obj);
					}
				}
			}
			else
			{
				obj = Resources.Load<T>(path);
			}
			return obj as T;
		}
	}
}
