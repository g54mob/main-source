using System;
using System.Collections.Generic;
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
			private List<Type> keys;

			[SerializeField]
			private List<List<NodePort>> values;

			public void OnBeforeSerialize()
			{
			}

			public void OnAfterDeserialize()
			{
			}
		}

		private static PortDataCache portDataCache;

		private static Dictionary<Type, Dictionary<string, string>> formerlySerializedAsCache;

		private static readonly List<Action> postInitActions;

		private static bool Initialized => false;

		private static bool IsFinishedInitializing { get; set; }

		public static void UpdatePorts(Node node, Dictionary<string, NodePort> ports)
		{
		}

		private static Type GetBackingValueType(Type portValType)
		{
			return null;
		}

		private static bool IsDynamicListPort(NodePort port)
		{
			return false;
		}

		private static void BuildCache()
		{
		}

		public static List<FieldInfo> GetNodeFields(Type nodeType)
		{
			return null;
		}

		private static void CachePorts(Type nodeType)
		{
		}
	}
}
