using System;
using System.Collections.Generic;

namespace Dreamteck.Splines
{
	[Serializable]
	public class SizeModifier : SplineSampleModifier
	{
		[Serializable]
		public class SizeKey : Key
		{
			public float size;

			public SizeKey(double f, double t)
				: base(0.0, 0.0)
			{
			}
		}

		public SizeKey[] keys;

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
	}
}
