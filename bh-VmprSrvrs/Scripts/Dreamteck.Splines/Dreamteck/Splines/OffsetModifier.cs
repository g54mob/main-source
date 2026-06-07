using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class OffsetModifier : SplineSampleModifier
	{
		[Serializable]
		public class OffsetKey : Key
		{
			public Vector2 offset;

			public OffsetKey(Vector2 o, double f, double t, OffsetModifier modifier)
				: base(0.0, 0.0, null)
			{
			}
		}

		public List<OffsetKey> keys;

		public override List<Key> GetKeys()
		{
			return null;
		}

		public override void SetKeys(List<Key> input)
		{
		}

		public void AddKey(Vector2 offset, double f, double t)
		{
		}

		public override void Apply(SplineSample result)
		{
		}

		private Vector2 Evaluate(double time)
		{
			return default(Vector2);
		}
	}
}
