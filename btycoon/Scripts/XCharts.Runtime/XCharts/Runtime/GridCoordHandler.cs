using System.Text;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class GridCoordHandler : MainComponentHandler<GridCoord>
	{
		public override void InitComponent()
		{
			GridCoord grid = base.component;
			grid.painter = base.chart.painter;
			grid.refreshComponent = delegate
			{
				grid.UpdateRuntimeData(base.chart);
				base.chart.OnCoordinateChanged();
			};
			grid.refreshComponent();
		}

		public override void CheckComponent(StringBuilder sb)
		{
			GridCoord gridCoord = base.component;
			if (gridCoord.left >= base.chart.chartWidth)
			{
				sb.Append("warning:grid->left > chartWidth\n");
			}
			if (gridCoord.right >= base.chart.chartWidth)
			{
				sb.Append("warning:grid->right > chartWidth\n");
			}
			if (gridCoord.top >= base.chart.chartHeight)
			{
				sb.Append("warning:grid->top > chartHeight\n");
			}
			if (gridCoord.bottom >= base.chart.chartHeight)
			{
				sb.Append("warning:grid->bottom > chartHeight\n");
			}
			if (gridCoord.left + gridCoord.right >= base.chart.chartWidth)
			{
				sb.Append("warning:grid.left + grid.right > chartWidth\n");
			}
			if (gridCoord.top + gridCoord.bottom >= base.chart.chartHeight)
			{
				sb.Append("warning:grid.top + grid.bottom > chartHeight\n");
			}
		}

		public override void Update()
		{
			if (base.chart.isPointerInChart)
			{
				base.component.context.isPointerEnter = base.component.Contains(base.chart.pointerPos);
			}
			else
			{
				base.component.context.isPointerEnter = false;
			}
		}

		public override void DrawBase(VertexHelper vh)
		{
			if (!SeriesHelper.IsAnyClipSerie(base.chart.series))
			{
				DrawCoord(vh, base.component);
			}
		}

		public override void DrawUpper(VertexHelper vh)
		{
			if (SeriesHelper.IsAnyClipSerie(base.chart.series))
			{
				DrawCoord(vh, base.component);
			}
		}

		private void DrawCoord(VertexHelper vh, GridCoord grid)
		{
			if (grid.show)
			{
				if (!ChartHelper.IsClearColor(grid.backgroundColor))
				{
					Vector2 vector = new Vector2(grid.context.x, grid.context.y);
					Vector2 vector2 = new Vector2(grid.context.x, grid.context.y + grid.context.height);
					Vector2 vector3 = new Vector2(grid.context.x + grid.context.width, grid.context.y + grid.context.height);
					UGL.DrawQuadrilateral(p4: new Vector2(grid.context.x + grid.context.width, grid.context.y), vh: vh, p1: vector, p2: vector2, p3: vector3, color: grid.backgroundColor);
				}
				if (grid.showBorder)
				{
					float num = ((grid.borderWidth == 0f) ? (base.chart.theme.axis.lineWidth * 2f) : grid.borderWidth);
					Color32 color = (ChartHelper.IsClearColor(grid.borderColor) ? base.chart.theme.axis.lineColor : grid.borderColor);
					UGL.DrawBorder(vh, grid.context.center, grid.context.width - num, grid.context.height - num, num, color);
				}
			}
		}
	}
}
