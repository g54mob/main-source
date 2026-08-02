using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public struct SpringForce
	{
		public Vector3 Force;

		[Range(1f, 20f)]
		public int Distribution;

		public SpringForce(Vector3 force, int distribution)
		{
			Force = force;
			Distribution = Mathf.Max(distribution, 1);
		}

		public static SpringForce operator *(SpringForce a, float b)
		{
			return new SpringForce(a.Force * b, a.Distribution);
		}
	}
}
