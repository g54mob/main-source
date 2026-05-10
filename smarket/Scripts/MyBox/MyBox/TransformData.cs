using System;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class TransformData
	{
		public Vector3 Position;

		public Vector3 Rotation;

		public Vector3 Scale;

		public bool SavePosition;

		public bool SaveRotation;

		public bool SaveScale;

		public Action OnSaved;

		public Action OnApplied;

		public void Apply(Transform transform)
		{
		}

		public void Save(Transform transform)
		{
		}

		public static TransformData FromTransform(Transform transform, bool savePosition = true, bool saveRotation = true, bool saveScale = true)
		{
			return null;
		}
	}
}
