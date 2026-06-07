using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class TransformRecordSerializeData : ITransform
	{
		public Transform transform;

		public Vector3 localPosition;

		public Quaternion localRotation;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public Matrix4x4 localToWorldMatrix;

		public Matrix4x4 worldToLocalMatrix;

		public void Serialize(TransformRecord tr)
		{
		}

		public void Deserialize(TransformRecord tr)
		{
		}

		public int GetLocalHash()
		{
			return 0;
		}

		public int GetGlobalHash()
		{
			return 0;
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}
	}
}
