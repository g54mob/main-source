using System;
using System.Collections.Generic;
using FullInspector.Internal;
using FullSerializer.Internal;
using UnityEngine;

namespace FullInspector
{
	public static class fiSerializationHelpers
	{
		public static T DeserializeFromContent<T, TSerializer>(string content) where TSerializer : BaseSerializer
		{
			return (T)DeserializeFromContent<TSerializer>(typeof(T), content);
		}

		public static object DeserializeFromContent<TSerializer>(Type storageType, string content) where TSerializer : BaseSerializer
		{
			return fiSingletons.Get<TSerializer>().Deserialize(serializationOperator: fiSingletons.Get<NotSupportedSerializationOperator>(), storageType: fsPortableReflection.AsMemberInfo(storageType), serializedState: content);
		}

		public static string SerializeToContent<T, TSerializer>(T value) where TSerializer : BaseSerializer
		{
			return SerializeToContent<TSerializer>(typeof(T), value);
		}

		public static string SerializeToContent<TSerializer>(Type storageType, object value) where TSerializer : BaseSerializer
		{
			return fiSingletons.Get<TSerializer>().Serialize(serializationOperator: fiSingletons.Get<NotSupportedSerializationOperator>(), storageType: fsPortableReflection.AsMemberInfo(storageType), value: value);
		}

		public static T Clone<T, TSerializer>(T obj) where TSerializer : BaseSerializer
		{
			return (T)Clone<TSerializer>(typeof(T), obj);
		}

		public static object Clone<TSerializer>(Type storageType, object obj) where TSerializer : BaseSerializer
		{
			TSerializer val = fiSingletons.Get<TSerializer>();
			ListSerializationOperator listSerializationOperator = fiSingletons.Get<ListSerializationOperator>();
			listSerializationOperator.SerializedObjects = new List<UnityEngine.Object>();
			object result = val.Deserialize(serializedState: val.Serialize(fsPortableReflection.AsMemberInfo(storageType), obj, listSerializationOperator), storageType: fsPortableReflection.AsMemberInfo(storageType), serializationOperator: listSerializationOperator);
			listSerializationOperator.SerializedObjects = null;
			return result;
		}
	}
}
