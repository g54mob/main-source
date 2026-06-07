using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class ColorModifier : SplineSampleModifier
	{
		[Serializable]
		public class ColorKey : Key
		{
			public enum BlendMode
			{
				Lerp = 0,
				Multiply = 1,
				Add = 2,
				Subtract = 3
			}

			public Color color = Color.white;

			public BlendMode blendMode;

			public ColorKey(double f, double t)
				: base(f, t)
			{
			}

			public Color Blend(Color input, float percent)
			{
				return blendMode switch
				{
					BlendMode.Lerp => Color.Lerp(input, color, blend * percent), 
					BlendMode.Add => input + color * blend * percent, 
					BlendMode.Subtract => input - color * blend * percent, 
					BlendMode.Multiply => Color.Lerp(input, input * color, blend * percent), 
					_ => input, 
				};
			}
		}

		public ColorKey[] keys = new ColorKey[0];

		public ColorModifier()
		{
			keys = new ColorKey[0];
		}

		public override List<Key> GetKeys()
		{
			return new List<Key>(keys);
		}

		public override void SetKeys(List<Key> input)
		{
			keys = new ColorKey[input.Count];
			for (int i = 0; i < input.Count; i++)
			{
				keys[i] = (ColorKey)input[i];
			}
			base.SetKeys(input);
		}

		public void AddKey(double f, double t)
		{
			ArrayUtility.Add(ref keys, new ColorKey(f, t));
		}

		public override void Apply(ref SplineSample result)
		{
			if (keys.Length != 0)
			{
				base.Apply(ref result);
				for (int i = 0; i < keys.Length; i++)
				{
					result.color = keys[i].Blend(result.color, keys[i].Evaluate(result.percent) * blend);
				}
			}
		}
	}
}
