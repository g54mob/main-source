using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public class TransformRecord : IValid, ITransform
	{
		public Transform transform;

		public MagicaObjectId id;

		public Vector3 localPosition;

		public Quaternion localRotation;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public Matrix4x4 localToWorldMatrix;

		public Matrix4x4 worldToLocalMatrix;

		public MagicaObjectId pid;

		public TransformRecord(Transform t, bool read)
		{
		}

		public Vector3 InverseTransformDirection(Vector3 dir)
		{
			return default(Vector3);
		}

		public bool IsValid()
		{
			return false;
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}
	}
}
