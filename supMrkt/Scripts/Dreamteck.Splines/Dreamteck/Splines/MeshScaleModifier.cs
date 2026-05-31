using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class MeshScaleModifier : SplineSampleModifier
	{
		[Serializable]
		public class ScaleKey : Key
		{
			public Vector3 scale;

			public ScaleKey(double f, double t)
				: base(0.0, 0.0)
			{
			}
		}

		public List<ScaleKey> keys;

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

		public Vector3 GetScale(SplineSample sample)
		{
			return default(Vector3);
		}
	}
}
