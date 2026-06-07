using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Borodar.FarlandSkies.Core.Json.Serialization
{
	internal sealed class MetaType
	{
		internal enum NodeType
		{
			Unknown = 0,
			Integer = 1,
			Double = 2,
			Boolean = 3,
			String = 4,
			Array = 5,
			Object = 6
		}

		private static Dictionary<Type, MetaType> s_MetaTypeCache;

		private List<MethodInfo> onSerializingMethods;

		private List<MethodInfo> onSerializedMethods;

		private List<MethodInfo> onDeserializingMethods;

		private List<MethodInfo> onDeserializedMethods;

		public Type Type { get; private set; }

		public Type GenericCollectionElementType { get; private set; }

		public bool IsGenericCollection => false;

		public bool IsCollection { get; private set; }

		public PropertyInfo KeyPropertyInfo { get; private set; }

		public PropertyInfo ValuePropertyInfo { get; private set; }

		public bool IsDictionaryStyleCollection => false;

		public NodeType TargetNodeType { get; private set; }

		public IList<SerializableMember> SerializableMembers { get; private set; }

		public static MetaType FromType(Type type)
		{
			return null;
		}

		private MetaType(Type type)
		{
		}

		private void ScanForCollection()
		{
		}

		private void ScanForDictionaryStyleCollection()
		{
		}

		private NodeType DetermineTargetNodeType()
		{
			return default(NodeType);
		}

		private void SearchForSerializableMembers()
		{
		}

		private static string ResolvePropertyName(MemberInfo memberInfo)
		{
			return null;
		}

		private void SearchForSerializationCallbacks()
		{
		}

		private void Invoke(List<MethodInfo> callbacks, object obj, StreamingContext context)
		{
		}

		public void InvokeOnSerializing(object obj, StreamingContext context)
		{
		}

		public void InvokeOnSerialized(object obj, StreamingContext context)
		{
		}

		public void InvokeOnDeserializing(object obj, StreamingContext context)
		{
		}

		public void InvokeOnDeserialized(object obj, StreamingContext context)
		{
		}
	}
}
