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
			public float speed;

			public SpeedKey(double f, double t, FollowerSpeedModifier modifier)
				: base(0.0, 0.0, null)
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

		public override void Apply(SplineSample result)
		{
		}

		public float GetSpeed(SplineSample sample)
		{
			return 0f;
		}
	}
}
