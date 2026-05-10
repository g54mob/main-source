using UnityEngine;
using UnityEngine.Scripting;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class EffectScatterHandler : BaseScatterHandler<EffectScatter>
	{
		private float m_EffectScatterSpeed = 15f;

		public override void Update()
		{
			base.Update();
			float size = base.serie.symbol.GetSize(null, base.chart.theme.serie.scatterSymbolSize);
			float num = (base.serie.animation.unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			for (int i = 0; i < base.serie.symbol.animationSize.Count; i++)
			{
				base.serie.symbol.animationSize[i] += m_EffectScatterSpeed * num;
				if (base.serie.symbol.animationSize[i] > size)
				{
					base.serie.symbol.animationSize[i] = i * 5;
				}
				base.chart.RefreshPainter(base.serie);
			}
		}
	}
}
