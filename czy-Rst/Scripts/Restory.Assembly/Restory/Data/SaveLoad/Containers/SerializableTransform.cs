using System;
using Helpers.Utils;
using UnityEngine;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class SerializableTransform : ICloneable
	{
		[SerializeField]
		private Vector3 position;

		[SerializeField]
		private Quaternion rotation;

		[SerializeField]
		private Vector3 localScale = Vector3.one;

		public Vector3 Position => position;

		public Quaternion Rotation => rotation;

		public Vector3 LocalScale => localScale;

		public SerializableTransform()
		{
		}

		public SerializableTransform(Transform transform)
		{
			Update(transform);
		}

		public SerializableTransform(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}

		public void Update(Transform transform)
		{
			position = MathfUtils.FallbackIfNan(transform.position, Vector3.zero);
			rotation = transform.rotation;
			localScale = transform.localScale;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
