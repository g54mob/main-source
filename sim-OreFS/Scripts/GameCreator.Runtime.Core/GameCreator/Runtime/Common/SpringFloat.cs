using System;

namespace GameCreator.Runtime.Common
{
	public class SpringFloat
	{
		private const float EPSILON = 1E-05f;

		private const float LOG_N_2 = 0.6931472f;

		public const float DEFAULT_DECAY = 0.25f;

		[field: NonSerialized]
		public float Current { get; set; }

		[field: NonSerialized]
		public float Target { get; set; }

		[field: NonSerialized]
		public float Decay { get; set; }

		[field: NonSerialized]
		private float Velocity { get; set; }

		public SpringFloat(float value, float decay = 0.25f)
		{
			Current = value;
			Target = value;
			Decay = decay;
			Velocity = 0f;
		}

		public float Update(float deltaTime)
		{
			float num = DecayToDamping(Decay) / 2f;
			float num2 = Current - Target;
			float num3 = Velocity + num2 * num;
			float num4 = NegativeExponent(num * deltaTime);
			Current = num4 * (num2 + num3 * deltaTime) + Target;
			Velocity = num4 * (Velocity - num3 * num * deltaTime);
			return Current;
		}

		public float Update(float decay, float deltaTime)
		{
			Decay = decay;
			return Update(deltaTime);
		}

		public float Update(float target, float decay, float deltaTime)
		{
			Target = target;
			return Update(decay, deltaTime);
		}

		private static float DecayToDamping(float decay)
		{
			return 2.7725887f / (decay + 1E-05f);
		}

		private static float NegativeExponent(float x)
		{
			return 1f / (1f + x + 0.48f * x * x + 0.235f * x * x * x);
		}
	}
}
