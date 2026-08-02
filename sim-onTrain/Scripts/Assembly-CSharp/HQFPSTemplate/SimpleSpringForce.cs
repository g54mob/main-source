using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public struct SimpleSpringForce
	{
		[Range(0f, 10f)]
		public float PosForce;

		[Range(0f, 10f)]
		public float RotForce;

		[Range(1f, 20f)]
		public int Distribution;

		public SimpleSpringForce(float posForceAmount = 1f, float rotForceAmount = 1f, int distribution = 1)
		{
			PosForce = posForceAmount;
			RotForce = rotForceAmount;
			Distribution = Mathf.Max(distribution, 1);
		}
	}
}
