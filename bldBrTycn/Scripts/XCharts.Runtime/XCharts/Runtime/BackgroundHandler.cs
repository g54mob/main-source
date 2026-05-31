using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class BackgroundHandler : MainComponentHandler<Background>
	{
		private readonly string s_BackgroundObjectName = "background";

		public override void InitComponent()
		{
			base.component.painter = base.chart.painter;
			base.component.refreshComponent = delegate
			{
				GameObject gameObject = ChartHelper.AddObject(s_BackgroundObjectName, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				base.component.gameObject = gameObject;
				gameObject.hideFlags = base.chart.chartHideFlags;
				Image image = ChartHelper.EnsureComponent<Image>(gameObject);
				ChartHelper.UpdateRectTransform(gameObject, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				image.sprite = base.component.image;
				image.type = base.component.imageType;
				image.color = base.chart.theme.GetBackgroundColor(base.component);
				gameObject.transform.SetSiblingIndex(0);
				gameObject.SetActive(base.component.show);
			};
			base.component.refreshComponent();
		}

		public override void Update()
		{
			if (base.component.gameObject != null && base.component.gameObject.transform.GetSiblingIndex() != 0)
			{
				base.component.gameObject.transform.SetSiblingIndex(0);
			}
		}

		public override void DrawBase(VertexHelper vh)
		{
			if (base.component.show && !(base.component.image != null))
			{
				Vector3 p = new Vector3(base.chart.chartX, base.chart.chartY + base.chart.chartHeight);
				Vector3 p2 = new Vector3(base.chart.chartX + base.chart.chartWidth, base.chart.chartY + base.chart.chartHeight);
				Vector3 p3 = new Vector3(base.chart.chartX + base.chart.chartWidth, base.chart.chartY);
				Vector3 p4 = new Vector3(base.chart.chartX, base.chart.chartY);
				Color32 backgroundColor = base.chart.theme.GetBackgroundColor(base.component);
				UGL.DrawQuadrilateral(vh, p, p2, p3, p4, backgroundColor);
			}
		}
	}
}
