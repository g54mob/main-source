using System;
using UnityEngine;

namespace Brewery.Destruction.Extensible
{
	[Serializable]
	public struct TransformSnapshot
	{
		public Vector3 localPosition;

		public Quaternion localRotation;

		public Vector3 localScale;

		public Transform parent;

		public int layer;

		public bool wasStatic;

		public static TransformSnapshot Capture(Transform t)
		{
			return default(TransformSnapshot);
		}

		public void Apply(Transform t)
		{
		}
	}
}
