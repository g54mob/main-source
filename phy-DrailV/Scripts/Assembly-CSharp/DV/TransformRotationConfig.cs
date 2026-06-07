using System;
using UnityEngine;

namespace DV
{
	[Serializable]
	public struct TransformRotationConfig
	{
		public Transform transformToRotate;

		public Vector3 rotationAxis;

		public TransformRotationConfig(Transform transformToRotate)
		{
			this.transformToRotate = transformToRotate;
			rotationAxis = Vector3.right;
		}
	}
}
