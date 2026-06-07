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
			public Vector3 scale = Vector3.one;

			public ScaleKey(double f, double t)
				: base(f, t)
			{
			}
		}

		public List<ScaleKey> keys = new List<ScaleKey>();

		public MeshScaleModifier()
		{
			keys = new List<ScaleKey>();
		}

		public override List<Key> GetKeys()
		{
			List<Key> list = new List<Key>();
			for (int i = 0; i < keys.Count; i++)
			{
				list.Add(keys[i]);
			}
			return list;
		}

		public override void SetKeys(List<Key> input)
		{
			keys = new List<ScaleKey>();
			for (int i = 0; i < input.Count; i++)
			{
				keys.Add((ScaleKey)input[i]);
			}
		}

		public void AddKey(double f, double t)
		{
			keys.Add(new ScaleKey(f, t));
		}

		public override void Apply(ref SplineSample result)
		{
			if (keys.Count != 0)
			{
				for (int i = 0; i < keys.Count; i++)
				{
					result.size += keys[i].Evaluate(result.percent) * keys[i].scale.magnitude * blend;
				}
			}
		}

		public Vector3 GetScale(SplineSample sample)
		{
			Vector3 one = Vector3.one;
			for (int i = 0; i < keys.Count; i++)
			{
				float t = keys[i].Evaluate(sample.percent);
				Vector3 vector = Vector3.Lerp(Vector3.one, keys[i].scale, t);
				one.x *= vector.x;
				one.y *= vector.y;
				one.z *= vector.z;
			}
			return Vector3.Lerp(Vector3.one, one, blend);
		}
	}
}
