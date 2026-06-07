using System;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels
{
	[Serializable]
	public class XYZ
	{
		public class X
		{
			public const float MIN = 0f;

			public const float MAX = 0.95047f;

			public const int F = 100;
		}

		public class Y
		{
			public const float MIN = 0f;

			public const float MAX = 1f;

			public const int F = 100;
		}

		public class Z
		{
			public const float MIN = 0f;

			public const float MAX = 1.08883f;

			public const int F = 100;
		}

		public float x;

		public float y;

		public float z;

		public XYZ(float X, float Y, float Z)
		{
		}

		public XYZ Copy()
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

		public XYZ Validate()
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
