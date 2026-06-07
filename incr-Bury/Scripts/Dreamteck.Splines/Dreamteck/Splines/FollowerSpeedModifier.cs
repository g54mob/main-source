using System;
using System.Collections.Generic;
using UnityEngine;

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
				: base(f, t)
			{
			}
		}

		public List<SpeedKey> keys = new List<SpeedKey>();

		public FollowerSpeedModifier()
		{
			keys = new List<SpeedKey>();
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
			keys = new List<SpeedKey>();
			for (int i = 0; i < input.Count; i++)
			{
				keys.Add((SpeedKey)input[i]);
			}
		}

		public void AddKey(double f, double t)
		{
			keys.Add(new SpeedKey(f, t));
		}

		public override void Apply(ref SplineSample result)
		{
		}

		public float GetSpeed(float input, double percent)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				float num = keys[i].Evaluate(percent);
				input = ((keys[i].mode != SpeedKey.Mode.Add) ? (input * Mathf.Lerp(1f, keys[i].speed, num)) : (input + keys[i].speed * num));
			}
			return input;
		}
	}
}
