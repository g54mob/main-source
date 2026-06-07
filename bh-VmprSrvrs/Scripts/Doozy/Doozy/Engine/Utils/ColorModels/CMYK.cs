using System;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels
{
	[Serializable]
	public class CMYK
	{
		public class C
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public class M
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public class Y
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public class K
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public float c;

		public float m;

		public float y;

		public float k;

		public CMYK(float C, float M, float Y, float K)
		{
		}

		public CMYK Copy()
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

		public CMYK Validate()
		{
			return null;
		}

		private float ValidateColor(float value, float min, float max)
		{
			return 0f;
		}

		public Vector4 Factorize()
		{
			return default(Vector4);
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
