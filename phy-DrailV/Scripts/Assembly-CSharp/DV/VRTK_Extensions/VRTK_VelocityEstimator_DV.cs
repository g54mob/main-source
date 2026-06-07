using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_VelocityEstimator_DV : VRTK_VelocityEstimator
	{
		protected virtual Vector3 TransformDirection(Vector3 value)
		{
			return base.transform.parent.TransformDirection(value);
		}

		public Vector3 GetWorldVelocityEstimate()
		{
			Vector3 velocityEstimate = GetVelocityEstimate();
			return TransformDirection(velocityEstimate);
		}

		public Vector3 GetWorldAngularVelocityEstimate()
		{
			Vector3 angularVelocityEstimate = GetAngularVelocityEstimate();
			return TransformDirection(angularVelocityEstimate);
		}

		public Vector3 GetWorldAccelerationEstimate()
		{
			Vector3 accelerationEstimate = GetAccelerationEstimate();
			return TransformDirection(accelerationEstimate);
		}

		public Vector3 GetWorldAngularAccelerationEstimate()
		{
			Vector3 angularAccelerationEstimate = GetAngularAccelerationEstimate();
			return TransformDirection(angularAccelerationEstimate);
		}

		public Vector3 GetAngularAccelerationEstimate()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 2 + currentSampleCount - angularVelocitySamples.Length; i < currentSampleCount; i++)
			{
				if (i >= 2)
				{
					int num = i - 2;
					int num2 = i - 1;
					Vector3 vector = angularVelocitySamples[num % angularVelocitySamples.Length];
					Vector3 vector2 = angularVelocitySamples[num2 % angularVelocitySamples.Length];
					zero += vector2 - vector;
				}
			}
			return zero * (1f / Time.deltaTime);
		}
	}
}
