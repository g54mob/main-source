using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class VariableProperty
	{
		public enum Mode
		{
			interpolate = 0,
			constant = 1
		}

		public bool overrideValue = true;

		public Mode mode = Mode.constant;

		[ColorUsage(true, true)]
		public Color colorVal = Color.white;

		[GradientUsage(true)]
		public Gradient gradientVal;

		public float floatVal = 1f;

		public AnimationCurve curveVal = new AnimationCurve
		{
			keys = new Keyframe[2]
			{
				new Keyframe(0f, 1f),
				new Keyframe(1f, 1f)
			}
		};

		public static implicit operator bool(VariableProperty data)
		{
			return data.overrideValue;
		}

		public void GetValue(out Color color, float time)
		{
			color = ((mode == Mode.constant) ? colorVal : gradientVal.Evaluate(time));
		}

		public void GetValue(out float value, float time)
		{
			value = ((mode == Mode.constant) ? floatVal : curveVal.Evaluate(time));
		}

		public Color GetColorValue(float time)
		{
			if (mode != Mode.constant)
			{
				return gradientVal.Evaluate(time);
			}
			return colorVal;
		}

		public float GetFloatValue(float time)
		{
			if (mode != Mode.constant)
			{
				return curveVal.Evaluate(time);
			}
			return floatVal;
		}
	}
}
