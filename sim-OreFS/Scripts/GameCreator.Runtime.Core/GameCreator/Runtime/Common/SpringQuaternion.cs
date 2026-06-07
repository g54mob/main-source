using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class SpringQuaternion
	{
		private const float EPSILON = 1E-05f;

		private const float LOG_N_2 = 0.6931472f;

		public const float DEFAULT_DECAY = 0.25f;

		[field: NonSerialized]
		public Quaternion Current { get; set; }

		[field: NonSerialized]
		public Quaternion Target { get; set; }

		[field: NonSerialized]
		public float Decay { get; set; }

		[field: NonSerialized]
		private Vector3 Velocity { get; set; }

		public SpringQuaternion(float decay = 0.25f)
			: this(Quaternion.identity, decay)
		{
		}

		public SpringQuaternion(Quaternion value, float decay = 0.25f)
		{
			Current = value;
			Target = value;
			Decay = decay;
			Velocity = Vector3.zero;
		}

		public void Update(float deltaTime)
		{
			float num = DecayToDamping(Decay) / 2f;
			Vector3 vector = QuaternionToAngleAxis(Current * Quaternion.Inverse(Target));
			Vector3 vector2 = Velocity + vector * num;
			float num2 = NegativeExponent(num * deltaTime);
			Current = QuaternionFromAngleAxis(num2 * (vector + vector2 * deltaTime)) * Target;
			Velocity = num2 * (Velocity - vector2 * num * deltaTime);
		}

		public void Update(float decay, float deltaTime)
		{
			Decay = decay;
			Update(deltaTime);
		}

		public void Update(Quaternion target, float decay, float deltaTime)
		{
			Target = target;
			Update(decay, deltaTime);
		}

		private static float DecayToDamping(float decay)
		{
			return 2.7725887f / (decay + 1E-05f);
		}

		private static float NegativeExponent(float x)
		{
			return 1f / (1f + x + 0.48f * x * x + 0.235f * x * x * x);
		}

		private static Vector3 QuaternionToAngleAxis(Quaternion q)
		{
			if (q == Quaternion.identity)
			{
				return Vector3.zero;
			}
			float num = 2f * Mathf.Acos(q.w);
			float num2 = Mathf.Sqrt(1f - Mathf.Clamp(q.w * q.w, -1f, 1f));
			return ((num2 < 1E-05f) ? new Vector3(q.x, q.y, q.z) : new Vector3(q.x / num2, q.y / num2, q.z / num2)) * num * (MathF.PI / 180f);
		}

		private static Quaternion QuaternionFromAngleAxis(Vector3 scaledAxis)
		{
			float magnitude = scaledAxis.magnitude;
			Vector3 normalized = scaledAxis.normalized;
			return Quaternion.AngleAxis(magnitude * 57.29578f, normalized);
		}
	}
}
