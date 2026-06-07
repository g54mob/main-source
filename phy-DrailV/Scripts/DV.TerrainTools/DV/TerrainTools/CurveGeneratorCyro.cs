using System.Collections.Generic;
using UnityEngine;

namespace DV.TerrainTools
{
	public class CurveGeneratorCyro : CurveGenerator
	{
		private const float CATMULL_ROM_ALPHA = 0.5f;

		public float tolerance = 0.01f;

		public float resolution = 0.5f;

		[HideInInspector]
		public int version = 1;

		private List<BezierPointData> bezierPoints;
	}
}
