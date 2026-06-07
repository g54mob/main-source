using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[Serializable]
	public class CameraTarget
	{
		public Transform TargetTransform;

		[Range(0f, 1f)]
		public float TargetInfluenceH;

		[Range(0f, 1f)]
		public float TargetInfluenceV;

		public Vector2 TargetOffset;

		private Vector3 _targetPosition;

		public float TargetInfluence
		{
			set
			{
			}
		}

		public Vector3 TargetPosition => default(Vector3);
	}
}
