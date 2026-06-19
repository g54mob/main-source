using System;
using FullSerializer;
using FullSerializer.Internal;
using UnityEngine;

namespace FullInspector.Serializers.FullSerializer
{
	public class SerializationCallbackReceiverObjectProcessor : fsObjectProcessor
	{
		public override bool CanProcess(Type type)
		{
			if (!typeof(UnityEngine.Object).Resolve().IsAssignableFrom(type.Resolve()) && typeof(ISerializationCallbackReceiver).Resolve().IsAssignableFrom(type.Resolve()))
			{
				return !typeof(BaseObject).Resolve().IsAssignableFrom(type.Resolve());
			}
			return false;
		}

		public override void OnBeforeSerialize(Type storageType, object instance)
		{
			((ISerializationCallbackReceiver)instance)?.OnBeforeSerialize();
		}

		public override void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		public override void OnAfterDeserialize(Type storageType, object instance)
		{
			((ISerializationCallbackReceiver)instance)?.OnAfterDeserialize();
		}
	}
}
