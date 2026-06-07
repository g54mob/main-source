using System;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels
{
	[Serializable]
	public class RGB
	{
		public class R
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 255;
		}

		public class G
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 255;
		}

		public class B
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 255;
		}

		public float r;

		public float g;

		public float b;

		public RGB(float R, float G, float B)
		{
		}

		public RGB Copy()
		{
			return null;
		}

		public Color Color(float alpha = 1f)
		{
			return default(Color);
		}

		public HSL ToHSL()
		{
			return null;
		}

		public HSV ToHSV()
		{
			return null;
		}

		public CMY ToCMY()
		{
			return null;
		}

		public CMYK ToCMYK()
		{
			return null;
		}

		public XYZ ToXYZ()
		{
			return null;
		}

		public RGB Validate()
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

		public string ToHEX(bool addHashTag = true)
		{
			return null;
		}
	}
}
