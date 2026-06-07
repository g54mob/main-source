using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class ColoredMultiGraphRenderer : AMultiGraphRenderer
	{
		[SerializeField]
		private List<Color> colors = new List<Color>();

		public static readonly int GraphColorsPropertyId = Shader.PropertyToID("_GraphColors");

		public static readonly int GraphCountPropertyId = Shader.PropertyToID("_GraphCount");

		public List<Color> Colors => colors;

		protected override void OnInitializeGraph(Shader _Shader)
		{
			base.OnInitializeGraph(_Shader);
			base.Target.material.SetColorArray(GraphColorsPropertyId, colors);
			base.Target.material.SetFloat(GraphCountPropertyId, base.Provider.Count);
		}

		public override void RefreshGraph()
		{
			base.RefreshGraph();
			base.Target.material.SetColorArray(GraphColorsPropertyId, colors);
		}

		public override void OnNext(PerformanceData _Next)
		{
			base.OnNext(_Next);
			UpdateLegends();
		}

		private void UpdateLegends()
		{
			for (int i = 0; i < base.LegendImages.Count; i++)
			{
				base.LegendImages[i].color = colors[i];
			}
		}
	}
}
