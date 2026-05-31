using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class RingHandler : SerieHandler<Ring>
	{
		public override int defaultDimension => 0;

		public override void Update()
		{
			base.Update();
		}

		public override void UpdateSerieContext()
		{
			bool flag = base.chart.isPointerInChart || m_LegendEnter;
			bool flag2 = false;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag)
				{
					return;
				}
				m_LastCheckContextFlag = flag;
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				foreach (SerieData datum in base.serie.data)
				{
					datum.context.highlight = false;
				}
				base.chart.RefreshPainter(base.serie);
				return;
			}
			m_LastCheckContextFlag = flag;
			if (m_LegendEnter)
			{
				base.serie.context.pointerEnter = true;
				foreach (SerieData datum2 in base.serie.data)
				{
					datum2.context.highlight = true;
				}
			}
			else
			{
				base.serie.context.pointerEnter = false;
				base.serie.context.pointerItemDataIndex = -1;
				int ringIndex = GetRingIndex(base.chart.pointerPos);
				foreach (SerieData datum3 in base.serie.data)
				{
					if (!flag2 && ringIndex == datum3.index)
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = ringIndex;
						datum3.context.highlight = true;
						flag2 = true;
					}
					else
					{
						datum3.context.highlight = false;
					}
				}
			}
			if (flag2)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			if (dataIndex < 0)
			{
				dataIndex = base.serie.context.pointerItemDataIndex;
			}
			if (dataIndex >= 0)
			{
				SerieData serieData = base.serie.GetSerieData(dataIndex);
				if (serieData != null)
				{
					SerieHelper.GetItemColor(out var color, out var _, base.serie, serieData, base.chart.theme, dataIndex);
					SerieParams param = base.serie.context.param;
					param.serieName = base.serie.serieName;
					param.serieIndex = base.serie.index;
					param.category = category;
					param.dimension = defaultDimension;
					param.serieData = serieData;
					param.dataCount = base.serie.dataCount;
					param.value = serieData.GetData(0);
					param.total = serieData.GetData(1);
					param.color = color;
					param.marker = SerieHelper.GetItemMarker(base.serie, serieData, marker);
					param.itemFormatter = SerieHelper.GetItemFormatter(base.serie, serieData, itemFormatter);
					param.numericFormatter = SerieHelper.GetNumericFormatter(base.serie, serieData, numericFormatter);
					param.columns.Clear();
					param.columns.Add(param.marker);
					param.columns.Add(serieData.name);
					param.columns.Add(ChartCached.NumberToStr(param.value, param.numericFormatter));
					paramList.Add(param);
				}
			}
		}

		private Vector3 GetLabelLineEndPosition(Serie serie, SerieData serieData, LabelLine labelLine)
		{
			if (labelLine == null || !labelLine.show)
			{
				return serieData.context.labelLinePosition;
			}
			bool flag = !serie.clockwise;
			Vector3 vector = (flag ? Vector3.right : Vector3.left);
			float f = MathF.PI / 180f * (flag ? labelLine.lineAngle : (180f - labelLine.lineAngle));
			float actualValue = ChartHelper.GetActualValue(labelLine.lineLength1, serie.context.outsideRadius);
			float actualValue2 = ChartHelper.GetActualValue(labelLine.lineLength2, serie.context.outsideRadius);
			Vector3 labelLinePosition = serieData.context.labelLinePosition;
			Vector3 vector2 = labelLinePosition + new Vector3(Mathf.Cos(f) * actualValue, Mathf.Sin(f) * actualValue);
			Vector3 result = ((labelLine.lineType == LabelLine.LineType.HorizontalLine) ? (labelLinePosition + vector * (actualValue + actualValue2) + labelLine.GetEndSymbolOffset()) : (vector2 + vector * actualValue2 + labelLine.GetEndSymbolOffset()));
			if (labelLine.lineEndX != 0f)
			{
				result.x = labelLine.lineEndX;
			}
			return result;
		}

		public override void DrawSerie(VertexHelper vh)
		{
			if (!base.serie.show || base.serie.animation.HasFadeOut())
			{
				return;
			}
			UpdateRuntimeData();
			List<SerieData> data = base.serie.data;
			base.serie.animation.InitProgress(base.serie.startAngle, base.serie.startAngle + 360f);
			float num = base.serie.context.outsideRadius - base.serie.context.insideRadius;
			bool flag = false;
			for (int i = 0; i < data.Count; i++)
			{
				SerieData serieData = data[i];
				if (serieData.show)
				{
					if (serieData.IsDataChanged())
					{
						flag = true;
					}
					float num2 = base.serie.context.outsideRadius - (float)i * (num + base.serie.gap);
					if (!(num2 < 0f))
					{
						double currData = serieData.GetCurrData(0, base.serie.animation);
						double lastData = serieData.GetLastData();
						float angle = (float)(360.0 * currData / lastData);
						float startAngle = GetStartAngle(base.serie);
						float toAngle = GetToAngle(base.serie, angle);
						ItemStyle itemStyle = SerieHelper.GetItemStyle(base.serie, serieData);
						SerieHelper.GetItemColor(index: base.chart.GetLegendRealShowNameIndex(serieData.legendName), color: out var color, toColor: out var toColor, serie: base.serie, serieData: serieData, theme: base.chart.theme);
						float num3 = num2 - num;
						float borderWidth = itemStyle.borderWidth;
						Color32 borderColor = itemStyle.borderColor;
						bool roundCap = base.serie.roundCap && num3 > 0f;
						DrawBackground(vh, base.serie, serieData, i, num3, num2);
						UGL.DrawDoughnut(vh, base.serie.context.center, num3, num2, color, toColor, Color.clear, startAngle, toAngle, borderWidth, borderColor, 0f, base.chart.settings.cicleSmoothness, roundCap, base.serie.clockwise);
						DrawCenter(vh, base.serie, serieData, num3, i == data.Count - 1);
					}
				}
			}
			for (int j = 0; j < data.Count; j++)
			{
				SerieData serieData2 = data[j];
				if (serieData2.show)
				{
					LabelStyle serieLabel = SerieHelper.GetSerieLabel(base.serie, serieData2);
					int legendRealShowNameIndex = base.chart.GetLegendRealShowNameIndex(serieData2.legendName);
					SerieHelper.GetItemColor(out var color2, out var _, base.serie, serieData2, base.chart.theme, legendRealShowNameIndex);
					if (SerieLabelHelper.CanShowLabel(base.serie, serieData2, serieLabel, 0))
					{
						DrawRingLabelLine(vh, base.serie, serieData2, color2);
					}
				}
			}
			if (!base.serie.animation.IsFinish())
			{
				base.serie.animation.CheckProgress(360.0);
				base.chart.RefreshChart();
			}
			if (flag)
			{
				base.chart.RefreshChart();
			}
		}

		private void UpdateRuntimeData()
		{
			List<SerieData> data = base.serie.data;
			SerieHelper.UpdateCenter(base.serie, base.chart);
			float num = base.serie.context.outsideRadius - base.serie.context.insideRadius;
			for (int i = 0; i < data.Count; i++)
			{
				SerieData serieData = data[i];
				if (serieData.show)
				{
					float num2 = base.serie.context.outsideRadius - (float)i * (num + base.serie.gap);
					if (!(num2 < 0f))
					{
						double currData = serieData.GetCurrData(0, base.serie.animation);
						double lastData = serieData.GetLastData();
						float angle = (float)(360.0 * currData / lastData);
						float startAngle = GetStartAngle(base.serie);
						float toAngle = GetToAngle(base.serie, angle);
						float insideRadius = num2 - num;
						serieData.context.startAngle = startAngle;
						serieData.context.toAngle = toAngle;
						serieData.context.insideRadius = insideRadius;
						serieData.context.outsideRadius = ((serieData.radius > 0f) ? serieData.radius : num2);
						UpdateLabelPosition(serieData);
					}
				}
			}
			AvoidLabelOverlap();
		}

		public override void OnLegendButtonClick(int index, string legendName, bool show)
		{
			if (base.serie.IsLegendName(legendName))
			{
				LegendHelper.CheckDataShow(base.serie, legendName, show);
				base.chart.UpdateLegendColor(legendName, show);
				base.chart.RefreshPainter(base.serie);
			}
		}

		public override void OnLegendButtonEnter(int index, string legendName)
		{
			if (base.serie.IsLegendName(legendName))
			{
				LegendHelper.CheckDataHighlighted(base.serie, legendName, heighlight: true);
				base.chart.RefreshPainter(base.serie);
			}
		}

		public override void OnLegendButtonExit(int index, string legendName)
		{
			if (base.serie.IsLegendName(legendName))
			{
				LegendHelper.CheckDataHighlighted(base.serie, legendName, heighlight: false);
				base.chart.RefreshPainter(base.serie);
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		private float GetStartAngle(Serie serie)
		{
			if (!serie.clockwise)
			{
				return 360f - serie.startAngle;
			}
			return serie.startAngle;
		}

		private float GetToAngle(Serie serie, float angle)
		{
			float num = angle + serie.startAngle;
			if (!serie.clockwise)
			{
				num = 360f - angle - serie.startAngle;
			}
			if (!serie.animation.IsFinish())
			{
				float currDetail = serie.animation.GetCurrDetail();
				num = ((!serie.clockwise) ? ((num < 360f - currDetail) ? (360f - currDetail) : num) : ((num > currDetail) ? currDetail : num));
			}
			return num;
		}

		private void DrawCenter(VertexHelper vh, Serie serie, SerieData serieData, float insideRadius, bool last)
		{
			ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
			if (!ChartHelper.IsClearColor(itemStyle.centerColor) && last)
			{
				float radius = insideRadius - itemStyle.centerGap;
				float cicleSmoothness = base.chart.settings.cicleSmoothness;
				UGL.DrawCricle(vh, serie.context.center, radius, itemStyle.centerColor, cicleSmoothness);
			}
		}

		private void DrawBackground(VertexHelper vh, Serie serie, SerieData serieData, int index, float insideRadius, float outsideRadius)
		{
			ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
			Color32 color = itemStyle.backgroundColor;
			if (ChartHelper.IsClearColor(color))
			{
				color = base.chart.theme.GetColor(index);
				color.a = 50;
			}
			if (itemStyle.backgroundWidth != 0f)
			{
				float num = (outsideRadius + insideRadius) / 2f;
				float insideRadius2 = num - itemStyle.backgroundWidth / 2f;
				float outsideRadius2 = num + itemStyle.backgroundWidth / 2f;
				UGL.DrawDoughnut(vh, serie.context.center, insideRadius2, outsideRadius2, color, Color.clear, base.chart.settings.cicleSmoothness);
			}
			else
			{
				UGL.DrawDoughnut(vh, serie.context.center, insideRadius, outsideRadius, color, Color.clear, base.chart.settings.cicleSmoothness);
			}
		}

		private void DrawBorder(VertexHelper vh, Serie serie, SerieData serieData, float insideRadius, float outsideRadius)
		{
			ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
			if (itemStyle.show && itemStyle.borderWidth > 0f && !ChartHelper.IsClearColor(itemStyle.borderColor))
			{
				UGL.DrawDoughnut(vh, serie.context.center, outsideRadius, outsideRadius + itemStyle.borderWidth, itemStyle.borderColor, Color.clear, base.chart.settings.cicleSmoothness);
				UGL.DrawDoughnut(vh, serie.context.center, insideRadius, insideRadius + itemStyle.borderWidth, itemStyle.borderColor, Color.clear, base.chart.settings.cicleSmoothness);
			}
		}

		private int GetRingIndex(Vector2 local)
		{
			float num = Vector2.Distance(local, base.serie.context.center);
			if (num > base.serie.context.outsideRadius)
			{
				return -1;
			}
			Vector2 to = local - new Vector2(base.serie.context.center.x, base.serie.context.center.y);
			float angle = VectorAngle(Vector2.up, to);
			for (int i = 0; i < base.serie.data.Count; i++)
			{
				SerieData serieData = base.serie.data[i];
				if (num >= serieData.context.insideRadius && num <= serieData.context.outsideRadius && IsInAngle(serieData, angle, base.serie.clockwise))
				{
					return i;
				}
			}
			return -1;
		}

		private bool IsInAngle(SerieData serieData, float angle, bool clockwise)
		{
			if (clockwise)
			{
				if (angle >= serieData.context.startAngle)
				{
					return angle <= serieData.context.toAngle;
				}
				return false;
			}
			if (angle >= serieData.context.toAngle)
			{
				return angle <= serieData.context.startAngle;
			}
			return false;
		}

		private float VectorAngle(Vector2 from, Vector2 to)
		{
			Vector3 vector = Vector3.Cross(from, to);
			float num = Vector2.Angle(from, to);
			num = ((vector.z > 0f) ? (0f - num) : num);
			return (num + 360f) % 360f;
		}

		private void UpdateLabelPosition(SerieData serieData)
		{
			if (serieData.labelObject == null)
			{
				return;
			}
			LabelStyle serieLabel = SerieHelper.GetSerieLabel(base.serie, serieData);
			LabelLine serieLabelLine = SerieHelper.GetSerieLabelLine(base.serie, serieData);
			float num = (serieData.context.outsideRadius + serieData.context.insideRadius) / 2f;
			float startAngle = serieData.context.startAngle;
			float toAngle = serieData.context.toAngle;
			switch (serieLabel.position)
			{
			case LabelStyle.Position.Bottom:
			case LabelStyle.Position.Start:
			{
				float num2 = Mathf.Sin(startAngle * (MathF.PI / 180f)) * num;
				float y2 = Mathf.Cos(startAngle * (MathF.PI / 180f)) * num;
				float num3 = (base.serie.clockwise ? (0f - serieLabel.distance) : serieLabel.distance);
				if (serieLabelLine != null && serieLabelLine.show)
				{
					serieData.context.labelLinePosition = base.serie.context.center + new Vector3(num2, y2) + serieLabelLine.GetStartSymbolOffset();
					serieData.context.labelPosition = GetLabelLineEndPosition(base.serie, serieData, serieLabelLine) + new Vector3(num3, 0f);
				}
				else
				{
					serieData.context.labelLinePosition = base.serie.context.center + new Vector3(num2 + num3, y2);
					serieData.context.labelPosition = serieData.context.labelLinePosition;
				}
				break;
			}
			case LabelStyle.Position.Outside:
			case LabelStyle.Position.Top:
			case LabelStyle.Position.End:
			{
				startAngle += (base.serie.clockwise ? (0f - serieLabel.distance) : serieLabel.distance);
				toAngle += (base.serie.clockwise ? serieLabel.distance : (0f - serieLabel.distance));
				float x = Mathf.Sin(toAngle * (MathF.PI / 180f)) * num;
				float y = Mathf.Cos(toAngle * (MathF.PI / 180f)) * num;
				if (serieLabelLine != null && serieLabelLine.show)
				{
					serieData.context.labelLinePosition = base.serie.context.center + new Vector3(x, y) + serieLabelLine.GetStartSymbolOffset();
					serieData.context.labelPosition = GetLabelLineEndPosition(base.serie, serieData, serieLabelLine);
				}
				else
				{
					serieData.context.labelLinePosition = base.serie.context.center + new Vector3(x, y);
					serieData.context.labelPosition = serieData.context.labelLinePosition;
				}
				break;
			}
			default:
				serieData.context.labelLinePosition = base.serie.context.center + serieLabel.offset;
				serieData.context.labelPosition = serieData.context.labelLinePosition;
				break;
			}
		}

		private void AvoidLabelOverlap()
		{
			if (!base.serie.avoidLabelOverlap)
			{
				return;
			}
			base.serie.context.sortedData.Clear();
			foreach (SerieData datum in base.serie.data)
			{
				base.serie.context.sortedData.Add(datum);
			}
			base.serie.context.sortedData.Sort((SerieData a, SerieData b) => (a != null && b != null) ? a.context.labelPosition.y.CompareTo(b.context.labelPosition.y) : 0);
			float y = base.serie.context.sortedData[0].context.labelPosition.y;
			for (int num = 1; num < base.serie.context.sortedData.Count; num++)
			{
				SerieData serieData = base.serie.context.sortedData[num];
				float height = serieData.labelObject.GetHeight();
				if (serieData.context.labelPosition.y - y < height)
				{
					serieData.context.labelPosition.y = y + height;
				}
				y = serieData.context.labelPosition.y;
			}
		}

		private void DrawRingLabelLine(VertexHelper vh, Serie serie, SerieData serieData, Color32 defaltColor)
		{
			LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, serieData);
			LabelLine serieLabelLine = SerieHelper.GetSerieLabelLine(serie, serieData);
			if (serieLabel != null && serieLabel.show && serieLabelLine != null && serieLabelLine.show)
			{
				Color32 color = (ChartHelper.IsClearColor(serieLabelLine.lineColor) ? ChartHelper.GetHighlightColor(defaltColor, 0.9f) : serieLabelLine.lineColor);
				bool flag = !serie.clockwise;
				float f = MathF.PI / 180f * (flag ? serieLabelLine.lineAngle : (180f - serieLabelLine.lineAngle));
				float actualValue = ChartHelper.GetActualValue(serieLabelLine.lineLength1, serie.context.outsideRadius);
				Vector3 labelLinePosition = serieData.context.labelLinePosition;
				Vector3 vector = labelLinePosition + new Vector3(Mathf.Cos(f) * actualValue, Mathf.Sin(f) * actualValue);
				Vector3 labelPosition = serieData.context.labelPosition;
				switch (serieLabelLine.lineType)
				{
				case LabelLine.LineType.BrokenLine:
					UGL.DrawLine(vh, labelLinePosition, vector, labelPosition, serieLabelLine.lineWidth, color);
					break;
				case LabelLine.LineType.Curves:
					UGL.DrawCurves(vh, labelLinePosition, labelPosition, labelLinePosition, vector, serieLabelLine.lineWidth, color, base.chart.settings.lineSmoothness);
					break;
				case LabelLine.LineType.HorizontalLine:
					UGL.DrawLine(vh, labelLinePosition, labelPosition, serieLabelLine.lineWidth, color);
					break;
				}
				DrawLabelLineSymbol(vh, serieLabelLine, labelLinePosition, labelPosition, color);
			}
		}
	}
}
