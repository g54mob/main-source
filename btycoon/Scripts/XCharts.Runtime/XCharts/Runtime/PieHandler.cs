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
	internal sealed class PieHandler : SerieHandler<Pie>
	{
		public override void Update()
		{
			base.Update();
		}

		public override void DrawBase(VertexHelper vh)
		{
			UpdateRuntimeData(base.serie);
			DrawPieLabelLine(vh, base.serie, isTop: false);
		}

		public override void DrawSerie(VertexHelper vh)
		{
			UpdateRuntimeData(base.serie);
			DrawPie(vh, base.serie);
			base.chart.RefreshBasePainter();
		}

		public override void DrawUpper(VertexHelper vh)
		{
			DrawPieLabelLine(vh, base.serie, isTop: true);
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			UpdateItemSerieParams(ref paramList, ref title, dataIndex, category, marker, itemFormatter, numericFormatter, ignoreDataDefaultContent);
		}

		public override Vector3 GetSerieDataLabelPosition(SerieData serieData, LabelStyle label)
		{
			LabelLine serieLabelLine = SerieHelper.GetSerieLabelLine(base.serie, serieData);
			if (serieLabelLine != null && serieLabelLine.show && serieData.labelObject != null)
			{
				bool flag = (serieData.context.halfAngle - base.serie.context.startAngle) % 360f < 180f;
				float num = serieData.labelObject.text.GetPreferredWidth() / 2f;
				return serieData.context.labelPosition + (flag ? Vector3.right : Vector3.left) * num;
			}
			return serieData.context.labelPosition;
		}

		public override Vector3 GetSerieDataLabelOffset(SerieData serieData, LabelStyle label)
		{
			Vector3 offset = label.GetOffset(base.serie.context.insideRadius);
			if (label.autoOffset)
			{
				if ((serieData.context.halfAngle - base.serie.context.startAngle) % 360f < 180f)
				{
					return offset;
				}
				return new Vector3(0f - offset.x, offset.y, offset.z);
			}
			return offset;
		}

		public override Vector3 GetSerieDataTitlePosition(SerieData serieData, TitleStyle titleStyle)
		{
			return base.serie.context.center;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (base.chart.pointerPos == Vector2.zero)
			{
				return;
			}
			int piePosIndex = GetPiePosIndex(base.serie, base.chart.pointerPos);
			bool flag = false;
			if (piePosIndex >= 0)
			{
				flag = true;
				for (int i = 0; i < base.serie.data.Count; i++)
				{
					if (i == piePosIndex)
					{
						base.serie.data[i].context.selected = !base.serie.data[i].context.selected;
					}
					else
					{
						base.serie.data[i].context.selected = false;
					}
				}
			}
			if (flag)
			{
				base.chart.RefreshChart();
			}
			base.OnPointerDown(eventData);
		}

		public override int GetPointerItemDataIndex()
		{
			return GetPiePosIndex(base.serie, base.chart.pointerPos);
		}

		public override void UpdateSerieContext()
		{
			bool flag = m_LegendEnter || m_LegendExiting || m_ForceUpdateSerieContext || (base.chart.isPointerInChart && PointerIsInPieSerie(base.serie, base.chart.pointerPos));
			bool needInteract = false;
			bool flag2 = base.serie.animation.enable && base.serie.animation.interaction.enable;
			Color32 color;
			Color32 toColor;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag && !m_ForceUpdateSerieContext)
				{
					return;
				}
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				bool flag3 = SerieHelper.IsAllZeroValue(base.serie);
				int num = (flag3 ? (360 / base.serie.dataCount) : 0);
				foreach (SerieData datum in base.serie.data)
				{
					datum.context.highlight = false;
					if (flag2)
					{
						double value = (flag3 ? ((double)num) : datum.GetCurrData(1, base.serie.animation));
						int legendRealShowNameIndex = base.chart.GetLegendRealShowNameIndex(datum.legendName);
						SerieHelper.GetItemColor(out color, out toColor, base.serie, datum, base.chart.theme, legendRealShowNameIndex, SerieState.Normal);
						UpdateSerieDataRadius(datum, value);
						datum.interact.SetValueAndColor(ref needInteract, datum.context.outsideRadius, color, toColor);
						datum.interact.SetPosition(ref needInteract, datum.context.offsetCenter);
					}
				}
				if (needInteract)
				{
					base.chart.RefreshPainter(base.serie);
					return;
				}
				m_LastCheckContextFlag = flag;
				m_LegendExiting = false;
				base.chart.RefreshPainter(base.serie);
				return;
			}
			m_LastCheckContextFlag = flag;
			int pointerItemDataIndex = base.serie.context.pointerItemDataIndex;
			int piePosIndex = GetPiePosIndex(base.serie, base.chart.pointerPos);
			base.serie.context.pointerItemDataIndex = -1;
			base.serie.context.pointerEnter = piePosIndex >= 0;
			bool flag4 = SerieHelper.IsAllZeroValue(base.serie);
			int num2 = (flag4 ? (360 / base.serie.dataCount) : 0);
			for (int i = 0; i < base.serie.dataCount; i++)
			{
				SerieData serieData = base.serie.data[i];
				double value2 = (flag4 ? ((double)num2) : serieData.GetCurrData(1, base.serie.animation));
				SerieState state = SerieState.Normal;
				if (piePosIndex == i || (m_LegendEnter && m_LegendEnterIndex == i))
				{
					base.serie.context.pointerItemDataIndex = i;
					serieData.context.highlight = true;
					state = SerieState.Emphasis;
				}
				else
				{
					serieData.context.highlight = false;
				}
				if (flag2)
				{
					UpdateSerieDataRadius(serieData, value2);
					int legendRealShowNameIndex2 = base.chart.GetLegendRealShowNameIndex(serieData.legendName);
					SerieHelper.GetItemColor(out color, out toColor, base.serie, serieData, base.chart.theme, legendRealShowNameIndex2, state);
					serieData.interact.SetValueAndColor(ref needInteract, serieData.context.outsideRadius, color, toColor);
					serieData.interact.SetPosition(ref needInteract, serieData.context.offsetCenter);
				}
			}
			if (pointerItemDataIndex != base.serie.context.pointerItemDataIndex)
			{
				needInteract = true;
			}
			if (needInteract)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		private void UpdateRuntimeData(Serie serie)
		{
			List<SerieData> data = serie.data;
			serie.context.dataMax = serie.yMax;
			serie.context.startAngle = GetStartAngle(serie);
			double yTotal = serie.yTotal;
			SerieHelper.UpdateCenter(serie, base.chart);
			float num = serie.context.startAngle;
			float totalAngle = 0f;
			float num2 = 0f;
			int num3 = 0;
			foreach (SerieData datum in serie.data)
			{
				if (datum.show && serie.pieRoseType == RoseType.Area)
				{
					num3++;
				}
				datum.context.canShowLabel = false;
			}
			bool flag = SerieHelper.IsAllZeroValue(serie);
			double num4 = yTotal;
			if (flag)
			{
				totalAngle = 360f;
				num2 = totalAngle / (float)data.Count;
				serie.context.dataMax = num2;
				yTotal = 360.0;
				num4 = 360.0;
			}
			else
			{
				num4 = GetTotalAngle(serie, yTotal, ref totalAngle);
			}
			for (int i = 0; i < data.Count; i++)
			{
				SerieData serieData = data[i];
				double num5 = (flag ? ((double)num2) : serieData.GetCurrData(1, serie.animation));
				serieData.context.startAngle = num;
				serieData.context.toAngle = num;
				serieData.context.halfAngle = num;
				serieData.context.currentAngle = num;
				if (serieData.show)
				{
					float num6 = ((serie.pieRoseType == RoseType.Area) ? (totalAngle / (float)num3) : ((float)((double)totalAngle * num5 / num4)));
					if (serie.minAngle > 0f && num6 < serie.minAngle)
					{
						num6 = serie.minAngle;
					}
					serieData.context.toAngle = num + num6;
					float num7 = (serieData.context.toAngle - num) / 2f;
					serieData.context.halfAngle = num + num7;
					serieData.context.angle = num + num7;
					serieData.context.currentAngle = (serie.animation.CheckDetailBreak(serieData.context.toAngle) ? serie.animation.GetCurrDetail() : serieData.context.toAngle);
					serieData.context.insideRadius = serie.context.insideRadius;
					serieData.context.canShowLabel = serieData.context.currentAngle >= serieData.context.halfAngle;
					UpdateSerieDataRadius(serieData, num5);
					UpdatePieLabelPosition(serie, serieData);
					num = serieData.context.toAngle;
				}
			}
			AvoidLabelOverlap(serie, base.chart.theme.common);
		}

		private void UpdateSerieDataRadius(SerieData serieData, double value)
		{
			float total = Mathf.Min(base.chart.chartWidth, base.chart.chartHeight);
			float num = ((base.serie.minRadius > 0f) ? ChartHelper.GetActualValue(base.serie.minRadius, total) : 0f);
			if (serieData.radius > 0f)
			{
				serieData.context.outsideRadius = ChartHelper.GetActualValue(serieData.radius, total);
			}
			else
			{
				float num2 = ((num > 0f) ? num : base.serie.context.insideRadius);
				serieData.context.outsideRadius = ((base.serie.pieRoseType > RoseType.None) ? (num2 + (float)((double)(base.serie.context.outsideRadius - num2) * value / base.serie.context.dataMax)) : base.serie.context.outsideRadius);
			}
			if (num > 0f && serieData.context.outsideRadius < num)
			{
				serieData.context.outsideRadius = num;
			}
			float num3 = 0f;
			float offset = base.serie.animation.interaction.GetOffset(base.serie.context.outsideRadius);
			if (base.serie.pieClickOffset && (serieData.selected || serieData.context.selected))
			{
				num3 += offset;
			}
			if (num3 > 0f)
			{
				serieData.context.outsideRadius += offset;
				float f = serieData.context.halfAngle * (MathF.PI / 180f);
				float num4 = Mathf.Sin(f);
				float num5 = Mathf.Cos(f);
				serieData.context.offsetRadius = 0f;
				if (base.serie.pieClickOffset && (serieData.selected || serieData.context.selected))
				{
					serieData.context.offsetRadius += offset;
					if (serieData.context.insideRadius > 0f)
					{
						serieData.context.insideRadius += offset;
					}
				}
				serieData.context.offsetCenter = new Vector3(base.serie.context.center.x + serieData.context.offsetRadius * num4, base.serie.context.center.y + serieData.context.offsetRadius * num5);
			}
			else
			{
				serieData.context.offsetCenter = base.serie.context.center;
			}
			if (serieData.context.highlight)
			{
				serieData.context.outsideRadius = base.serie.animation.GetInteractionRadius(serieData.context.outsideRadius);
			}
			float radius = base.serie.context.insideRadius + (serieData.context.outsideRadius - base.serie.context.insideRadius) / 2f;
			serieData.context.position = ChartHelper.GetPosition(base.serie.context.center, serieData.context.halfAngle, radius);
		}

		private double GetTotalAngle(Serie serie, double dataTotal, ref float totalAngle)
		{
			totalAngle = serie.context.startAngle + 360f;
			if (serie.minAngle > 0f)
			{
				float num = serie.minAngle / 360f;
				double num2 = dataTotal * (double)num;
				{
					foreach (SerieData datum in serie.data)
					{
						double data = datum.GetData(1);
						if (data < num2)
						{
							totalAngle -= serie.minAngle;
							dataTotal -= data;
						}
					}
					return dataTotal;
				}
			}
			return dataTotal;
		}

		private void DrawPieCenter(VertexHelper vh, Serie serie, ItemStyle itemStyle, float insideRadius)
		{
			if (!ChartHelper.IsClearColor(itemStyle.centerColor))
			{
				float radius = insideRadius - itemStyle.centerGap;
				UGL.DrawCricle(vh, serie.context.center, radius, itemStyle.centerColor, base.chart.settings.cicleSmoothness);
			}
		}

		private void DrawPie(VertexHelper vh, Serie serie)
		{
			if (!serie.show || serie.animation.HasFadeOut())
			{
				return;
			}
			bool flag = false;
			bool needInteract = false;
			Color32 color = ColorUtil.clearColor32;
			Color32 toColor = ColorUtil.clearColor32;
			float interactionDuration = serie.animation.GetInteractionDuration();
			bool flag2 = serie.animation.enable && serie.animation.interaction.enable && !serie.animation.IsFadeIn() && !serie.animation.IsFadeOut();
			List<SerieData> data = serie.data;
			serie.animation.InitProgress(0f, 360f);
			for (int i = 0; i < data.Count; i++)
			{
				SerieData serieData = data[i];
				if (!serieData.show)
				{
					continue;
				}
				if (serieData.IsDataChanged())
				{
					flag = true;
				}
				ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
				int legendRealShowNameIndex = base.chart.GetLegendRealShowNameIndex(serieData.legendName);
				float value = 0f;
				Vector3 pos = ((serie.pieClickOffset && (serieData.selected || serieData.context.selected)) ? serieData.context.offsetCenter : serie.context.center);
				float borderWidth = itemStyle.borderWidth;
				Color32 borderColor = itemStyle.borderColor;
				float num = AnimationStyleHelper.CheckDataAnimation(base.chart, serie, i, 1f);
				float num2 = serieData.context.insideRadius * num;
				if (!flag2 || !serieData.interact.TryGetValueAndColor(ref value, ref pos, ref color, ref toColor, ref needInteract, interactionDuration))
				{
					SerieHelper.GetItemColor(out color, out toColor, serie, serieData, base.chart.theme, legendRealShowNameIndex);
					value = serieData.context.outsideRadius * num;
					if (flag2)
					{
						serieData.interact.SetValueAndColor(ref needInteract, value, color, toColor);
						serieData.interact.SetPosition(ref needInteract, pos);
					}
				}
				float currentAngle = serieData.context.currentAngle;
				bool roundCap = serie.roundCap && num2 > 0f;
				UGL.DrawDoughnut(vh, pos, num2, value, color, toColor, Color.clear, serieData.context.startAngle, currentAngle, borderWidth, borderColor, serie.gap / 2f, base.chart.settings.cicleSmoothness, roundCap);
				DrawPieCenter(vh, serie, itemStyle, num2);
				if (serie.animation.CheckDetailBreak(serieData.context.toAngle))
				{
					break;
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress();
				serie.animation.CheckSymbol(serie.symbol.GetSize(null, base.chart.theme.serie.lineSymbolSize));
				base.chart.RefreshPainter(serie);
			}
			if (flag || needInteract)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		private static void UpdatePieLabelPosition(Serie serie, SerieData serieData)
		{
			if (!(serieData.labelObject == null))
			{
				float startAngle = serie.context.startAngle;
				float halfAngle = serieData.context.halfAngle;
				float f = halfAngle * (MathF.PI / 180f);
				float offsetRadius = serieData.context.offsetRadius;
				float insideRadius = serieData.context.insideRadius;
				float value = serieData.context.outsideRadius;
				LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, serieData);
				LabelLine serieLabelLine = SerieHelper.GetSerieLabelLine(serie, serieData);
				Vector3 pos = serieData.context.offsetCenter;
				bool interacting = false;
				serieData.interact.TryGetValueAndColor(ref value, ref pos, ref interacting, serie.animation.GetInteractionDuration());
				float num = (halfAngle - startAngle) % 360f;
				bool isLeft = num > 180f || (num == 0f && serieData.context.startAngle > 0f);
				switch (serieLabel.position)
				{
				case LabelStyle.Position.Center:
					serieData.context.labelPosition = serie.context.center;
					break;
				case LabelStyle.Position.Inside:
				case LabelStyle.Position.Middle:
				{
					float num2 = offsetRadius + insideRadius + (value - insideRadius) / 2f + serieLabel.distance;
					Vector2 vector2 = new Vector2(pos.x + num2 * Mathf.Sin(f), pos.y + num2 * Mathf.Cos(f));
					UpdateLabelPosition(serie, serieData, serieLabelLine, vector2, isLeft);
					break;
				}
				default:
				{
					Vector2 vector = new Vector2(pos.x + value * Mathf.Sin(f), pos.y + value * Mathf.Cos(f));
					UpdateLabelPosition(serie, serieData, serieLabelLine, vector, isLeft);
					break;
				}
				}
			}
		}

		private static void UpdateLabelPosition(Serie serie, SerieData serieData, LabelLine labelLine, Vector3 startPosition, bool isLeft)
		{
			serieData.context.labelLinePosition = startPosition;
			if (labelLine == null || !labelLine.show)
			{
				serieData.context.labelPosition = startPosition;
				return;
			}
			Vector3 vector = (isLeft ? Vector3.left : Vector3.right);
			float f = MathF.PI / 180f * serieData.context.halfAngle;
			float actualValue = ChartHelper.GetActualValue(labelLine.lineLength1, serie.context.outsideRadius);
			float actualValue2 = ChartHelper.GetActualValue(labelLine.lineLength2, serie.context.outsideRadius);
			Vector3 vector2 = startPosition + new Vector3(Mathf.Sin(f) * actualValue, Mathf.Cos(f) * actualValue);
			Vector3 labelPosition = ((labelLine.lineType == LabelLine.LineType.HorizontalLine) ? (startPosition + vector * (actualValue + actualValue2) + labelLine.GetEndSymbolOffset()) : (vector2 + vector * actualValue2 + labelLine.GetEndSymbolOffset()));
			if (labelLine.lineEndX != 0f)
			{
				labelPosition.x = (isLeft ? (0f - Mathf.Abs(labelLine.lineEndX)) : Mathf.Abs(labelLine.lineEndX));
			}
			serieData.context.labelLinePosition2 = vector2;
			serieData.context.labelPosition = labelPosition;
		}

		private void DrawPieLabelLine(VertexHelper vh, Serie serie, bool isTop)
		{
			foreach (SerieData datum in serie.data)
			{
				LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, datum);
				LabelLine serieLabelLine = SerieHelper.GetSerieLabelLine(serie, datum);
				if (!SerieLabelHelper.CanShowLabel(serie, datum, serieLabel, 1))
				{
					continue;
				}
				int index = base.chart.m_LegendRealShowName.IndexOf(datum.name);
				if (serieLabel == null || !serieLabel.show || serieLabelLine == null || !serieLabelLine.show)
				{
					continue;
				}
				if (serieLabel.position == LabelStyle.Position.Inside || serieLabel.position == LabelStyle.Position.Middle)
				{
					if (!isTop)
					{
						continue;
					}
				}
				else if (isTop && !serieLabelLine.startSymbol.show)
				{
					continue;
				}
				Color32 color = (ChartHelper.IsClearColor(serieLabelLine.lineColor) ? base.chart.theme.GetColor(index) : serieLabelLine.lineColor);
				switch (serieLabelLine.lineType)
				{
				case LabelLine.LineType.BrokenLine:
					UGL.DrawLine(vh, datum.context.labelLinePosition, datum.context.labelLinePosition2, datum.context.labelPosition, serieLabelLine.lineWidth, color);
					break;
				case LabelLine.LineType.Curves:
					if (datum.context.labelLinePosition2 == datum.context.labelPosition)
					{
						UGL.DrawCurves(vh, datum.context.labelLinePosition, datum.context.labelPosition, datum.context.labelLinePosition, (datum.context.labelLinePosition + datum.context.labelPosition) * 0.6f, serieLabelLine.lineWidth, color, base.chart.settings.lineSmoothness);
					}
					else
					{
						UGL.DrawCurves(vh, datum.context.labelLinePosition, datum.context.labelPosition, datum.context.labelLinePosition, datum.context.labelLinePosition2, serieLabelLine.lineWidth, color, base.chart.settings.lineSmoothness);
					}
					break;
				case LabelLine.LineType.HorizontalLine:
					UGL.DrawLine(vh, datum.context.labelLinePosition, datum.context.labelPosition, serieLabelLine.lineWidth, color);
					break;
				}
				DrawLabelLineSymbol(vh, serieLabelLine, datum.context.labelLinePosition, datum.context.labelPosition, color);
			}
		}

		private int GetPiePosIndex(Serie serie, Vector2 local)
		{
			if (!(serie is Pie))
			{
				return -1;
			}
			float num = Vector2.Distance(local, serie.context.center);
			float offset = serie.animation.interaction.GetOffset(serie.context.outsideRadius);
			float num2 = serie.context.outsideRadius + 2f * offset;
			if (num < serie.context.insideRadius || num > num2)
			{
				return -1;
			}
			Vector2 to = local - new Vector2(serie.context.center.x, serie.context.center.y);
			float angle = ChartHelper.GetAngle360(Vector2.up, to);
			for (int i = 0; i < serie.data.Count; i++)
			{
				SerieData serieData = serie.data[i];
				if (angle >= serieData.context.startAngle && angle <= serieData.context.toAngle)
				{
					float num3 = ((serieData.selected || serieData.context.selected) ? Vector2.Distance(local, serieData.context.offsetCenter) : num);
					if (num3 >= serieData.context.insideRadius && num3 <= serieData.context.outsideRadius)
					{
						return i;
					}
				}
			}
			return -1;
		}

		private bool PointerIsInPieSerie(Serie serie, Vector2 local)
		{
			if (!(serie is Pie))
			{
				return false;
			}
			float num = Vector2.Distance(local, serie.context.center);
			if (num >= serie.context.insideRadius && num <= serie.context.outsideRadius)
			{
				return true;
			}
			return false;
		}

		private float GetStartAngle(Serie serie)
		{
			if (!serie.clockwise)
			{
				return 360f - serie.startAngle;
			}
			return (serie.startAngle + 360f) % 360f;
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

		private void AvoidLabelOverlap(Serie serie, ComponentTheme theme)
		{
			if (!serie.avoidLabelOverlap)
			{
				return;
			}
			Vector3 lastCheckPos = Vector3.zero;
			float lastX = 0f;
			List<SerieData> data = serie.data;
			int num = 0;
			for (int i = 0; i < data.Count; i++)
			{
				SerieData serieData = data[i];
				if (serieData.context.labelPosition.x != 0f && serieData.context.labelPosition.x < serie.context.center.x)
				{
					num = i;
					break;
				}
			}
			float limitX = float.MinValue;
			for (int j = 0; j < num; j++)
			{
				CheckSerieDataLabel(serie, data[j], num, isLeft: false, j == num - 1, theme, ref lastCheckPos, ref lastX, ref limitX);
			}
			lastCheckPos = Vector3.zero;
			limitX = float.MaxValue;
			for (int num2 = data.Count - 1; num2 >= num; num2--)
			{
				CheckSerieDataLabel(serie, data[num2], data.Count - num, isLeft: true, num2 == num, theme, ref lastCheckPos, ref lastX, ref limitX);
			}
		}

		private void CheckSerieDataLabel(Serie serie, SerieData serieData, int total, bool isLeft, bool isLastOne, ComponentTheme theme, ref Vector3 lastCheckPos, ref float lastX, ref float limitX)
		{
			if (!serieData.context.canShowLabel)
			{
				serieData.SetLabelActive(flag: false);
			}
			else
			{
				if (!serieData.show)
				{
					return;
				}
				LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, serieData);
				if (serieLabel == null || !serieLabel.show)
				{
					return;
				}
				LabelLine serieLabelLine = SerieHelper.GetSerieLabelLine(serie, serieData);
				float height = serieData.labelObject.GetHeight();
				float num = 0f;
				float num2 = 0f;
				if (serieLabelLine != null && serieLabelLine.show)
				{
					num = ChartHelper.GetActualValue(serieLabelLine.lineLength1, serie.context.outsideRadius);
					num2 = ChartHelper.GetActualValue(serieLabelLine.lineLength2, serie.context.outsideRadius);
				}
				if (lastCheckPos == Vector3.zero)
				{
					lastCheckPos = serieData.context.labelPosition;
				}
				else
				{
					if (serieData.context.labelPosition.x == 0f)
					{
						return;
					}
					if (lastCheckPos.y - serieData.context.labelPosition.y < height)
					{
						float num3 = serie.context.outsideRadius + num;
						float num4 = lastCheckPos.y - height;
						float y = serie.context.center.y;
						float num5 = Mathf.Abs(num4 - y);
						float num6 = num3 * num3 - num5 * num5;
						num6 = ((num6 <= 0f) ? 0f : num6);
						float num7 = serie.context.center.x + Mathf.Sqrt(num6) * (float)((!isLeft) ? 1 : (-1));
						Vector3 labelLinePosition = new Vector3(num7, num4);
						serieData.context.labelLinePosition2 = labelLinePosition;
						if (isLeft)
						{
							if (num7 < limitX)
							{
								limitX = num7;
								serieData.context.labelPosition = new Vector3(labelLinePosition.x - num2, labelLinePosition.y);
								lastX = serieData.context.labelPosition.x;
							}
							else
							{
								serieData.context.labelPosition = new Vector3(lastX, num4);
								lastX += 2f;
							}
						}
						else if (num7 > limitX)
						{
							limitX = num7;
							serieData.context.labelPosition = new Vector3(labelLinePosition.x + num2, labelLinePosition.y);
							lastX = serieData.context.labelPosition.x;
						}
						else
						{
							serieData.context.labelPosition = new Vector3(lastX, num4);
							lastX -= 2f;
						}
						if (serieLabelLine != null && serieLabelLine.show && serieLabelLine.lineEndX != 0f)
						{
							serieData.context.labelPosition.x = (isLeft ? (0f - Mathf.Abs(serieLabelLine.lineEndX)) : Mathf.Abs(serieLabelLine.lineEndX));
						}
						if (!isLastOne && serieData.context.labelPosition.y < serieData.context.labelLinePosition.y)
						{
							serieData.context.labelLinePosition2 = serieData.context.labelPosition;
						}
						else if (isLeft && serieData.context.labelLinePosition2.x > serieData.context.labelLinePosition.x)
						{
							serieData.context.labelLinePosition2.x = serieData.context.labelLinePosition.x;
						}
						else if (!isLeft && serieData.context.labelLinePosition2.x < serieData.context.labelLinePosition.x)
						{
							serieData.context.labelLinePosition2.x = serieData.context.labelLinePosition.x;
						}
					}
					else
					{
						lastX = serieData.context.labelPosition.x;
					}
					lastCheckPos = serieData.context.labelPosition;
					UpdateLabelPosition(serieData, serieLabel);
				}
			}
		}
	}
}
