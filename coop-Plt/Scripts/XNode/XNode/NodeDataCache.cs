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
				using Enumerator enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<Type, List<NodePort>> current = enumerator.Current;
					keys.Add(current.Key);
					values.Add(current.Value);
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
			Dictionary<string, List<NodePort>> dictionary2 = new Dictionary<string, List<NodePort>>();
			Type type = node.GetType();
			List<NodePort> list = new List<NodePort>();
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
					if (item.IsDynamic || item.direction != value2.direction || item.connectionType != value2.connectionType || item.typeConstraint != value2.typeConstraint)
					{
						if (!item.IsDynamic && item.direction == value2.direction)
						{
							dictionary2.Add(item.fieldName, item.GetConnections());
						}
						item.ClearConnections();
						ports.Remove(item.fieldName);
					}
					else
					{
						item.ValueType = value2.ValueType;
					}
				}
				else if (item.IsStatic)
				{
					item.ClearConnections();
					ports.Remove(item.fieldName);
				}
				else if (IsDynamicListPort(item))
				{
					list.Add(item);
				}
			}
			foreach (NodePort value4 in dictionary.Values)
			{
				if (ports.ContainsKey(value4.fieldName))
				{
					continue;
				}
				NodePort nodePort = new NodePort(value4, node);
				if (dictionary2.TryGetValue(value4.fieldName, out var value3))
				{
					for (int j = 0; j < value3.Count; j++)
					{
						NodePort nodePort2 = value3[j];
						if (nodePort2 != null && nodePort.CanConnectTo(nodePort2))
						{
							nodePort.Connect(nodePort2);
						}
					}
				}
				ports.Add(value4.fieldName, nodePort);
			}
			foreach (NodePort item2 in list)
			{
				string key = item2.fieldName.Split(' ')[0];
				NodePort nodePort3 = dictionary[key];
				item2.ValueType = GetBackingValueType(nodePort3.ValueType);
				item2.direction = nodePort3.direction;
				item2.connectionType = nodePort3.connectionType;
				item2.typeConstraint = nodePort3.typeConstraint;
			}
		}

		private static Type GetBackingValueType(Type portValType)
		{
			if (portValType.HasElementType)
			{
				return portValType.GetElementType();
			}
			if (portValType.IsGenericType && portValType.GetGenericTypeDefinition() == typeof(List<>))
			{
				return portValType.GetGenericArguments()[0];
			}
			return portValType;
		}

		private static bool IsDynamicListPort(NodePort port)
		{
			string[] array = port.fieldName.Split(' ');
			if (array.Length != 2)
			{
				return false;
			}
			FieldInfo field = port.node.GetType().GetField(array[0]);
			if (field == null)
			{
				return false;
			}
			return field.GetCustomAttributes(inherit: true).Any(delegate(object x)
			{
				Node.InputAttribute inputAttribute = x as Node.InputAttribute;
				Node.OutputAttribute outputAttribute = x as Node.OutputAttribute;
				return (inputAttribute != null && inputAttribute.dynamicPortList) || (outputAttribute?.dynamicPortList ?? false);
			});
		}

		private static void BuildCache()
		{
			portDataCache = new PortDataCache();
			Type baseType = typeof(Node);
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				string text = assembly.GetName().Name;
				int num = text.IndexOf('.');
				if (num != -1)
				{
					text = text.Substring(0, num);
				}
				switch (text)
				{
				case "UnityEditor":
				case "UnityEngine":
				case "System":
				case "mscorlib":
				case "Microsoft":
					continue;
				}
				list.AddRange((from t in assembly.GetTypes()
					where !t.IsAbstract && baseType.IsAssignableFrom(t)
					select t).ToArray());
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
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
				foreach (FieldInfo parentField in fields)
				{
					if (list.TrueForAll((FieldInfo x) => x.Name != parentField.Name))
					{
						list.Add(parentField);
					}
				}
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
