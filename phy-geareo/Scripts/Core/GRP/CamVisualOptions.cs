using System;
using UnityEngine;

namespace GRP
{
	[Serializable]
	public struct CamVisualOptions
	{
		public AnimationCurve curve;

		public int segments;

		public float radius;

		public float thickness;

		public float height;

		public static CamVisualOptions FromPart(CamPart part)
		{
			return default(CamVisualOptions);
		}
	}
}
