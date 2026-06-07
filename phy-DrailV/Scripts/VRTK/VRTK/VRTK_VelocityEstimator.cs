using System;
using System.Collections;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_VelocityEstimator")]
	public class VRTK_VelocityEstimator : MonoBehaviour
	{
		[Tooltip("Begin the sampling routine when the script is enabled.")]
		public bool autoStartSampling = true;

		[Tooltip("The number of frames to average when calculating velocity.")]
		public int velocityAverageFrames = 5;

		[Tooltip("The number of frames to average when calculating angular velocity.")]
		public int angularVelocityAverageFrames = 10;

		protected Vector3[] velocitySamples;

		protected Vector3[] angularVelocitySamples;

		protected int currentSampleCount;

		protected Coroutine calculateSamplesRoutine;

		protected Vector3 previousPosition;

		protected Quaternion previousRotation;

		public Vector3 PreviousPosition => previousPosition;

		public Vector3 CurrentPosition => GetLocalPosition();

		public virtual void StartEstimation()
		{
			EndEstimation();
			calculateSamplesRoutine = StartCoroutine(EstimateVelocity());
		}

		public virtual void EndEstimation()
		{
			if (calculateSamplesRoutine != null)
			{
				StopCoroutine(calculateSamplesRoutine);
				calculateSamplesRoutine = null;
			}
		}

		public virtual Vector3 GetVelocityEstimate()
		{
			Vector3 zero = Vector3.zero;
			int num = Mathf.Min(currentSampleCount, velocitySamples.Length);
			if (num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					zero += velocitySamples[i];
				}
				zero *= 1f / (float)num;
			}
			return zero;
		}

		public virtual Vector3 GetAngularVelocityEstimate()
		{
			Vector3 zero = Vector3.zero;
			int num = Mathf.Min(currentSampleCount, angularVelocitySamples.Length);
			if (num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					zero += angularVelocitySamples[i];
				}
				zero *= 1f / (float)num;
			}
			return zero;
		}

		public virtual Vector3 GetAccelerationEstimate()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 2 + currentSampleCount - velocitySamples.Length; i < currentSampleCount; i++)
			{
				if (i >= 2)
				{
					int num = i - 2;
					int num2 = i - 1;
					Vector3 vector = velocitySamples[num % velocitySamples.Length];
					Vector3 vector2 = velocitySamples[num2 % velocitySamples.Length];
					zero += vector2 - vector;
				}
			}
			return zero * (1f / Time.deltaTime);
		}

		protected virtual void OnEnable()
		{
			InitArrays();
			if (autoStartSampling)
			{
				StartEstimation();
			}
		}

		protected virtual void OnDisable()
		{
			EndEstimation();
		}

		protected virtual void InitArrays()
		{
			velocitySamples = new Vector3[velocityAverageFrames];
			angularVelocitySamples = new Vector3[angularVelocityAverageFrames];
		}

		protected virtual Vector3 GetLocalPosition()
		{
			return base.transform.localPosition;
		}

		protected virtual Quaternion GetLocalRotation()
		{
			return base.transform.localRotation;
		}

		protected virtual IEnumerator EstimateVelocity()
		{
			currentSampleCount = 0;
			previousPosition = GetLocalPosition();
			previousRotation = GetLocalRotation();
			while (true)
			{
				yield return new WaitForEndOfFrame();
				float num = 1f / Time.deltaTime;
				int num2 = currentSampleCount % velocitySamples.Length;
				int num3 = currentSampleCount % angularVelocitySamples.Length;
				currentSampleCount++;
				velocitySamples[num2] = num * (GetLocalPosition() - previousPosition);
				Quaternion quaternion = GetLocalRotation() * Quaternion.Inverse(previousRotation);
				float num4 = 2f * Mathf.Acos(Mathf.Clamp(quaternion.w, -1f, 1f));
				if (num4 > (float)Math.PI)
				{
					num4 -= (float)Math.PI * 2f;
				}
				Vector3 vector = new Vector3(quaternion.x, quaternion.y, quaternion.z);
				if (vector.sqrMagnitude > 0f)
				{
					vector = num4 * num * vector.normalized;
				}
				angularVelocitySamples[num3] = vector;
				previousPosition = GetLocalPosition();
				previousRotation = GetLocalRotation();
			}
		}
	}
}
