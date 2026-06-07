using System;
using UnityEngine;

namespace Ludiq.FullSerializer
{
	public class fsSerializationCallbackReceiverProcessor : fsObjectProcessor
	{
		public override bool CanProcess(Type type)
		{
			return typeof(ISerializationCallbackReceiver).IsAssignableFrom(type);
		}

		public override void OnBeforeSerialize(Type storageType, object instance)
		{
			if (instance != null && !(instance is UnityEngine.Object))
			{
				((ISerializationCallbackReceiver)instance).OnBeforeSerialize();
			}
		}

		public override void OnAfterDeserialize(Type storageType, object instance)
		{
			if (instance != null && !(instance is UnityEngine.Object))
			{
				((ISerializationCallbackReceiver)instance).OnAfterDeserialize();
			}
		}
	}
}
