using System;
using System.Collections.Generic;

namespace Dreamteck.Splines
{
	[Serializable]
	public class FollowerSpeedModifier : SplineSampleModifier
	{
		[Serializable]
		public class SpeedKey : Key
		{
			public enum Mode
			{
				Add = 0,
				Multiply = 1
			}

			public float speed;

			public Mode mode;

			public SpeedKey(double f, double t)
				: base(0.0, 0.0)
			{
			}
		}

		public List<SpeedKey> keys;

		public override List<Key> GetKeys()
		{
			return null;
		}

		public override void SetKeys(List<Key> input)
		{
		}

		public void AddKey(double f, double t)
		{
		}

		public override void Apply(ref SplineSample result)
		{
		}

		public float GetSpeed(float input, double percent)
		{
			return 0f;
		}
	}
}
