using System;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public struct GradientFill
	{
		internal const int FILL_NONE = -1;

		public static readonly GradientFill defaultFill = new GradientFill
		{
			type = FillType.LinearGradient,
			space = FillSpace.Local,
			colorStart = Color.black,
			colorEnd = Color.white,
			linearStart = Vector3.zero,
			linearEnd = Vector3.up,
			radialOrigin = Vector3.zero,
			radialRadius = 1f
		};

		public FillType type;

		public FillSpace space;

		public Color colorStart;

		public Color colorEnd;

		public Vector3 linearStart;

		public Vector3 linearEnd;

		public Vector3 radialOrigin;

		public float radialRadius;

		public static GradientFill Linear(Vector3 start, Vector3 end, Color colorStart, Color colorEnd, FillSpace space = FillSpace.Local)
		{
			return new GradientFill
			{
				type = FillType.LinearGradient,
				colorStart = colorStart,
				colorEnd = colorEnd,
				space = space,
				linearStart = start,
				linearEnd = end,
				radialOrigin = defaultFill.radialOrigin,
				radialRadius = defaultFill.radialRadius
			};
		}

		public static GradientFill Radial(Vector3 origin, float radius, Color colorInner, Color colorOuter, FillSpace space = FillSpace.Local)
		{
			return new GradientFill
			{
				type = FillType.RadialGradient,
				space = space,
				colorStart = colorInner,
				colorEnd = colorOuter,
				linearStart = defaultFill.linearStart,
				linearEnd = defaultFill.linearEnd,
				radialOrigin = origin,
				radialRadius = radius
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

		internal int GetShaderFillTypeInt(bool use)
		{
			if (!use)
			{
				return -1;
			}
			return (int)type;
		}

		[Obsolete("Use GradientFill.Linear instead", true)]
		public static GradientFill CreateLinear(Vector3 start, Vector3 end, Color colorStart, Color colorEnd, FillSpace space)
		{
			return default(GradientFill);
		}

		[Obsolete("Use GradientFill.Radial instead", true)]
		public static GradientFill CreateRadial(Vector3 origin, float radius, Color colorInner, Color colorOuter, FillSpace space)
		{
			return default(GradientFill);
		}
	}
}
