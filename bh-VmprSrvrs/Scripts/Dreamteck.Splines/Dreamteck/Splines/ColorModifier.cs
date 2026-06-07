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

			public Color color;

			public BlendMode blendMode;

			public ColorKey(double f, double t, ColorModifier modifier)
				: base(0.0, 0.0, null)
			{
			}

			public Color Blend(Color input, float percent)
			{
				return default(Color);
			}
		}

		public List<ColorKey> keys;

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
	}
}
