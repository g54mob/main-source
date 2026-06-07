using System;
using UnityEngine;

namespace Kinemation.Recoilly.Runtime
{
	[Serializable]
	public struct VectorCurve
	{
		public AnimationCurve x;

		public AnimationCurve y;

		public AnimationCurve z;

		public float dal()
		{
			return 0f;
		}

		public Vector3 dam(float a)
		{
			return default(Vector3);
		}

		public bool dan()
		{
			return false;
		}
	}
}
