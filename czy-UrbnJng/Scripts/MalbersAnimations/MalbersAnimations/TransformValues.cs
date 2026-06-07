using System;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public struct TransformValues
	{
		public Vector3 position;

		public Vector3 localPosition;

		public Quaternion rotation;

		public Quaternion localRotation;

		public Vector3 eulerAngles;

		public Vector3 localEulerAngles;

		public Vector3 lossyScale;

		public Vector3 localScale;

		public TransformValues(Transform transform)
		{
			transform.GetPositionAndRotation(out position, out rotation);
			transform.GetLocalPositionAndRotation(out localPosition, out localRotation);
			eulerAngles = transform.eulerAngles;
			localEulerAngles = transform.localEulerAngles;
			lossyScale = transform.lossyScale;
			localScale = transform.localScale;
		}

		public readonly void RestoreTransform(Transform transform)
		{
			transform.SetPositionAndRotation(position, rotation);
			transform.localScale = localScale;
		}

		public readonly void RestoreLocalTransform(Transform transform)
		{
			transform.SetLocalPositionAndRotation(localPosition, localRotation);
			transform.localScale = localScale;
		}
	}
}
