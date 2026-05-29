using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	public static class CGUtility
	{
		[Obsolete("Method will get remove in next major update. Copy its content if you need it")]
		[UsedImplicitly]
		public static Vector2[] CalculateUV2(Vector2[] uv)
		{
			return null;
		}

		[Obsolete("Method will get remove in next major update. Copy its content if you need it")]
		[UsedImplicitly]
		public static void CalculateUV2(Vector2[] uv, Vector2[] uv2, int elementsNumber)
		{
		}

		public static List<ControlPointOption> GetControlPointsWithOptions(CGDataRequestMetaCGOptions options, CurvySpline shape, float startDist, float endDist, bool optimize, out int initialMaterialID, out float initialMaxStep)
		{
			initialMaterialID = default(int);
			initialMaxStep = default(float);
			return null;
		}
	}
}
