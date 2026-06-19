using System;
using System.Collections.Generic;
using FullInspector.Internal;
using UnityEngine;

namespace FullInspector.BackupService
{
	public class fiSerializationOperator : ISerializationOperator
	{
		public List<fiUnityObjectReference> SerializedObjects;

		public UnityEngine.Object RetrieveObjectReference(int storageId)
		{
			if (SerializedObjects == null)
			{
				throw new InvalidOperationException("SerializedObjects cannot be  null");
			}
			if (storageId < 0 || storageId >= SerializedObjects.Count)
			{
				return null;
			}
			fiUnityObjectReference fiUnityObjectReference2 = SerializedObjects[storageId];
			if (fiUnityObjectReference2 == null || fiUnityObjectReference2.Target == null)
			{
				return null;
			}
			return fiUnityObjectReference2.Target;
		}

		public int StoreObjectReference(UnityEngine.Object obj)
		{
			if (SerializedObjects == null)
			{
				throw new InvalidOperationException("SerializedObjects cannot be null");
			}
			if (obj == null)
			{
				return -1;
			}
			int count = SerializedObjects.Count;
			SerializedObjects.Add(new fiUnityObjectReference(obj, tryRestore: true));
			return count;
		}
	}
}
