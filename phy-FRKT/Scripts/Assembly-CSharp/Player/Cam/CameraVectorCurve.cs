using System;
using UnityEngine;

namespace Player.Cam
{
	[Serializable]
	public struct CameraVectorCurve
	{
		public AnimationCurve x;

		public AnimationCurve y;

		public AnimationCurve z;

		public static CameraVectorCurve fsz(float a, float b, float c, float d)
		{
			return default(CameraVectorCurve);
		}

		public static CameraVectorCurve fta(float a, float b, float c)
		{
			return default(CameraVectorCurve);
		}

		public float ftb()
		{
			return 0f;
		}

		public Vector3 ftc(float a)
		{
			return default(Vector3);
		}

		public bool ftd()
		{
			return false;
		}

		public CameraVectorCurve(Keyframe[] keyFrame)
		{
			x = null;
			y = null;
			z = null;
		}
	}
}
