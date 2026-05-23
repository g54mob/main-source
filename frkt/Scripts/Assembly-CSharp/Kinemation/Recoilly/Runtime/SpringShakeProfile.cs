using System;
using UnityEngine;

namespace Kinemation.Recoilly.Runtime
{
	[Serializable]
	public struct SpringShakeProfile
	{
		[SerializeField]
		public VectorSpringData springData;

		[SerializeField]
		public float dampSpeed;

		[SerializeField]
		public Vector2 pitch;

		[SerializeField]
		public Vector2 yaw;

		[SerializeField]
		public Vector2 roll;

		public Vector3 dbp()
		{
			return default(Vector3);
		}
	}
}
