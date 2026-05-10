using System;

namespace Kinemation.Recoilly.Runtime
{
	[Serializable]
	public struct SpringData
	{
		public float stiffness;

		public float criticalDamping;

		public float speed;

		public float mass;

		public float maxValue;

		[NonSerialized]
		public float error;

		[NonSerialized]
		public float velocity;

		public SpringData(float stiffness, float damping, float speed, float mass)
		{
			this.stiffness = 0f;
			criticalDamping = 0f;
			this.speed = 0f;
			this.mass = 0f;
			maxValue = 0f;
			error = 0f;
			velocity = 0f;
		}

		public SpringData(float stiffness, float damping, float speed)
		{
			this.stiffness = 0f;
			criticalDamping = 0f;
			this.speed = 0f;
			mass = 0f;
			maxValue = 0f;
			error = 0f;
			velocity = 0f;
		}
	}
}
