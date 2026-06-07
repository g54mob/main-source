using System;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels
{
	[Serializable]
	public class CMY
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

		public float c;

		public float m;

		public float y;

		public CMY(float C, float M, float Y)
		{
		}

		public CMY Copy()
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

		public CMY Validate()
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
