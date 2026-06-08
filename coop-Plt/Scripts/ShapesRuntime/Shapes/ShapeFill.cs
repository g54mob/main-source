using System;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public class ShapeFill
	{
		public const int FILL_NONE = -1;

		public FillType type;

		public FillSpace space;

		public Color colorStart = Color.black;

		public Color colorEnd = Color.white;

		public Vector3 linearStart = Vector3.zero;

		public Vector3 linearEnd = Vector3.up;

		public Vector3 radialOrigin = Vector3.zero;

		public float radialRadius = 1f;

		public static ShapeFill CreateLinear(Vector3 start, Vector3 end, Color colorStart, Color colorEnd, FillSpace space)
		{
			return new ShapeFill
			{
				type = FillType.LinearGradient,
				linearStart = start,
				linearEnd = end,
				colorStart = colorStart,
				colorEnd = colorEnd,
				space = space
			};
		}

		public static ShapeFill CreateRadial(Vector3 origin, float radius, Color colorInner, Color colorOuter, FillSpace space)
		{
			return new ShapeFill
			{
				type = FillType.RadialGradient,
				radialOrigin = origin,
				radialRadius = radius,
				colorStart = colorInner,
				colorEnd = colorOuter,
				space = space
			};
		}

		internal Vector4 GetShaderStartVector()
		{
			if (type == FillType.LinearGradient)
			{
				return linearStart;
			}
			return new Vector4(radialOrigin.x, radialOrigin.y, radialOrigin.z, radialRadius);
		}
	}
}
