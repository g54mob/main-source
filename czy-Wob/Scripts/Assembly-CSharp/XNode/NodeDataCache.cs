using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace XNode
{
	public static class NodeDataCache
	{
		[Serializable]
		private class PortDataCache : Dictionary<Type, List<NodePort>>, ISerializationCallbackReceiver
		{
			[SerializeField]
			private List<Type> keys = new List<Type>();

			[SerializeField]
			private List<List<NodePort>> values = new List<List<NodePort>>();

			public void OnBeforeSerialize()
			{
				keys.Clear();
				values.Clear();
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<Type, List<NodePort>> current = enumerator.Current;
						keys.Add(current.Key);
						values.Add(current.Value);
					}
				}
			}

			public void OnAfterDeserialize()
			{
				Clear();
				if (keys.Count != values.Count)
				{
					throw new Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
				}
				for (int i = 0; i < keys.Count; i++)
				{
					Add(keys[i], values[i]);
				}
			}
		}

		private static PortDataCache portDataCache;

		private static bool Initialized => portDataCache != null;

		public static void UpdatePorts(Node node, Dictionary<string, NodePort> ports)
		{
			if (!Initialized)
			{
				BuildCache();
			}
			Dictionary<string, NodePort> dictionary = new Dictionary<string, NodePort>();
			Type type = node.GetType();
			if (portDataCache.TryGetValue(type, out var value))
			{
				for (int i = 0; i < value.Count; i++)
				{
					dictionary.Add(value[i].fieldName, portDataCache[type][i]);
				}
			}
			foreach (NodePort item in ports.Values.ToList())
			{
				if (dictionary.TryGetValue(item.fieldName, out var value2))
				{
					if (item.connectionType != value2.connectionType || item.IsDynamic || item.direction != value2.direction || item.typeConstraint != value2.typeConstraint)
					{
						ports.Remove(item.fieldName);
					}
					else
					{
						item.ValueType = value2.ValueType;
					}
				}
				else if (item.IsStatic)
				{
					ports.Remove(item.fieldName);
				}
			}
			foreach (NodePort value3 in dictionary.Values)
			{
				if (!ports.ContainsKey(value3.fieldName))
				{
					ports.Add(value3.fieldName, new NodePort(value3, node));
				}
			}
		}

		private static void BuildCache()
		{
			portDataCache = new PortDataCache();
			Type baseType = typeof(Node);
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly assembly = Assembly.GetAssembly(baseType);
			if (assembly.FullName.StartsWith("Assembly-CSharp") && !assembly.FullName.Contains("-firstpass"))
			{
				list.AddRange(from t in assembly.GetTypes()
					where !t.IsAbstract && baseType.IsAssignableFrom(t)
					select t);
			}
			else
			{
				Assembly[] array = assemblies;
				foreach (Assembly assembly2 in array)
				{
					if (!assembly2.FullName.StartsWith("Unity") && assembly2.FullName.Contains("Version=0.0.0"))
					{
						list.AddRange((from t in assembly2.GetTypes()
							where !t.IsAbstract && baseType.IsAssignableFrom(t)
							select t).ToArray());
					}
				}
			}
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				CachePorts(list[num2]);
			}
		}

		public static List<FieldInfo> GetNodeFields(Type nodeType)
		{
			List<FieldInfo> list = new List<FieldInfo>(nodeType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			Type type = nodeType;
			while ((type = type.BaseType) != typeof(Node))
			{
				list.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic));
			}
			return list;
		}

		private static void CachePorts(Type nodeType)
		{
			List<FieldInfo> nodeFields = GetNodeFields(nodeType);
			for (int i = 0; i < nodeFields.Count; i++)
			{
				object[] customAttributes = nodeFields[i].GetCustomAttributes(inherit: true);
				Node.InputAttribute inputAttribute = customAttributes.FirstOrDefault((object x) => x is Node.InputAttribute) as Node.InputAttribute;
				Node.OutputAttribute outputAttribute = customAttributes.FirstOrDefault((object x) => x is Node.OutputAttribute) as Node.OutputAttribute;
				if (inputAttribute == null && outputAttribute == null)
				{
					continue;
				}
				if (inputAttribute != null && outputAttribute != null)
				{
					Debug.LogError("Field " + nodeFields[i].Name + " of type " + nodeType.FullName + " cannot be both input and output.");
				}
				else
				{
					if (!portDataCache.ContainsKey(nodeType))
					{
						portDataCache.Add(nodeType, new List<NodePort>());
					}
					portDataCache[nodeType].Add(new NodePort(nodeFields[i]));
				}
			}
		}
	}
}
