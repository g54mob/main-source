using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class ParallelHandler : SerieHandler<Parallel>
	{
		public override void Update()
		{
			base.Update();
		}

		public override void DrawSerie(VertexHelper vh)
		{
			DrawParallelSerie(vh, base.serie);
		}

		private void DrawParallelSerie(VertexHelper vh, Parallel serie)
		{
			if (!serie.show || serie.animation.HasFadeOut())
			{
				return;
			}
			ParallelCoord chartComponent = base.chart.GetChartComponent<ParallelCoord>(serie.parallelIndex);
			if (chartComponent == null)
			{
				return;
			}
			int count = chartComponent.context.parallelAxes.Count;
			if (count <= 0)
			{
				return;
			}
			int currIndex = serie.animation.GetCurrIndex();
			bool flag = chartComponent.orient == Orient.Horizonal;
			float width = serie.lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
			float num = ((!flag) ? chartComponent.context.x : chartComponent.context.y);
			float num2 = ((!flag) ? (chartComponent.context.x + chartComponent.context.width) : (chartComponent.context.y + chartComponent.context.height));
			serie.animation.InitProgress(num, num2);
			serie.containerIndex = chartComponent.index;
			serie.containterInstanceId = chartComponent.instanceId;
			float currDetail = serie.animation.GetCurrDetail();
			bool flag2 = serie.lineType == LineType.Smooth;
			foreach (SerieData datum in serie.data)
			{
				int num3 = Mathf.Min(count, datum.data.Count);
				Vector3 p = Vector3.zero;
				int index = (serie.colorByData ? datum.index : serie.context.colorIndex);
				Color32 lineColor = SerieHelper.GetLineColor(serie, datum, base.chart.theme, index);
				datum.context.dataPoints.Clear();
				for (int i = 0; i < num3; i++)
				{
					if (currIndex >= 0 && i > currIndex)
					{
						continue;
					}
					Vector3 pos = GetPos(chartComponent, i, datum.data[i], flag);
					if (!flag)
					{
						if (flag2)
						{
							datum.context.dataPoints.Add(pos);
						}
						else
						{
							if (!(pos.x <= currDetail))
							{
								Vector3 p2 = new Vector3(currDetail, chartComponent.context.y - 50f);
								Vector3 p3 = new Vector3(currDetail, chartComponent.context.y + chartComponent.context.height + 50f);
								Vector3 intersection = Vector3.zero;
								if (UGLHelper.GetIntersection(p, pos, p2, p3, ref intersection))
								{
									datum.context.dataPoints.Add(intersection);
								}
								else
								{
									datum.context.dataPoints.Add(pos);
								}
								break;
							}
							datum.context.dataPoints.Add(pos);
						}
					}
					else if (flag2)
					{
						datum.context.dataPoints.Add(pos);
					}
					else
					{
						if (!(pos.y <= currDetail))
						{
							Vector3 p4 = new Vector3(chartComponent.context.x - 50f, currDetail);
							Vector3 p5 = new Vector3(chartComponent.context.x + chartComponent.context.width + 50f, currDetail);
							Vector3 intersection2 = Vector3.zero;
							if (UGLHelper.GetIntersection(p, pos, p4, p5, ref intersection2))
							{
								datum.context.dataPoints.Add(intersection2);
							}
							else
							{
								datum.context.dataPoints.Add(pos);
							}
							break;
						}
						datum.context.dataPoints.Add(pos);
					}
					p = pos;
				}
				if (flag2)
				{
					UGL.DrawCurves(vh, datum.context.dataPoints, width, lineColor, base.chart.settings.lineSmoothStyle, base.chart.settings.lineSmoothness, UGL.Direction.XAxis, currDetail, flag);
				}
				else
				{
					UGL.DrawLine(vh, datum.context.dataPoints, width, lineColor, flag2);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(num2 - num);
				base.chart.RefreshPainter(serie);
			}
		}

		private static ParallelAxis GetAxis(ParallelCoord parallel, int index)
		{
			if (index >= 0 && index < parallel.context.parallelAxes.Count)
			{
				return parallel.context.parallelAxes[index];
			}
			return null;
		}

		private static Vector3 GetPos(ParallelCoord parallel, int axisIndex, double dataValue, bool isHorizonal)
		{
			ParallelAxis axis = GetAxis(parallel, axisIndex);
			if (axis == null)
			{
				return Vector3.zero;
			}
			float distance = axis.GetDistance(dataValue, axis.context.width);
			return new Vector3(isHorizonal ? (axis.context.x + distance) : axis.context.x, isHorizonal ? axis.context.y : (axis.context.y + distance));
		}
	}
}
