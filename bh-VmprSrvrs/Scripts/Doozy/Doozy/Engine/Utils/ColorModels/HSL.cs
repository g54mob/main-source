using System;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels
{
	[Serializable]
	public class HSL
	{
		public class H
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 360;
		}

		public class S
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public class L
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public float h;

		public float s;

		public float l;

		public HSL(float H, float S, float L)
		{
		}

		public HSL Copy()
		{
			return null;
		}

		public Color Color(float alpha = 1f)
		{
			return default(Color);
		}

		public RGB ToRGB()
		{
			return null;
		}

		public HSL Validate()
		{
			return null;
		}

		private float ValidateColor(float value, float min, float max)
		{
			return 0f;
		}

		public Vector3 Factorize()
		{
			return default(Vector3);
		}

		private int FactorizeColor(float value, float min, float max, float f)
		{
			return 0;
		}

		public string ToString(bool factorize = false)
		{
			return null;
		}
	}
}
