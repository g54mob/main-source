using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public class LegendContext : MainComponentContext
	{
		internal Dictionary<string, LegendItem> buttonList = new Dictionary<string, LegendItem>();

		internal Dictionary<int, float> eachWidthDict = new Dictionary<int, float>();

		public float width { get; internal set; }

		public float height { get; internal set; }

		public Vector2 center { get; internal set; }

		internal float eachHeight { get; set; }

		public Image background { get; set; }
	}
}
