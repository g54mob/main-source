using UnityEngine;

namespace XCharts.Runtime
{
	public class RadarCoordContext : MainComponentContext
	{
		public Vector3 center { get; internal set; }

		public float radius { get; internal set; }

		public float dataRadius { get; internal set; }

		public bool isPointerEnter { get; set; }
	}
}
