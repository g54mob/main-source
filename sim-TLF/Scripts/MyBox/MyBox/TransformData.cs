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

		public bool SavePosition = true;

		public bool SaveRotation = true;

		public bool SaveScale = true;

		public Action OnSaved;

		public Action OnApplied;

		public void Apply(Transform transform)
		{
			if (SavePosition)
			{
				transform.position = Position;
			}
			if (SaveRotation)
			{
				transform.rotation = Quaternion.Euler(Rotation);
			}
			if (SaveScale)
			{
				transform.localScale = Scale;
			}
			OnApplied?.Invoke();
		}

		public void Save(Transform transform)
		{
			Position = transform.position;
			Rotation = transform.rotation.eulerAngles;
			Scale = transform.localScale;
			OnSaved?.Invoke();
		}

		public static TransformData FromTransform(Transform transform, bool savePosition = true, bool saveRotation = true, bool saveScale = true)
		{
			TransformData transformData = new TransformData();
			transformData.Save(transform);
			transformData.SavePosition = savePosition;
			transformData.SaveRotation = saveRotation;
			transformData.SaveScale = saveScale;
			return transformData;
		}
	}
}
