using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class VisualMapHandler : MainComponentHandler<VisualMap>
	{
		public override void OnBeginDrag(PointerEventData eventData)
		{
			OnDragVisualMapStart(base.component);
		}

		public override void OnDrag(PointerEventData eventData)
		{
			OnDragVisualMap(base.component);
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			OnDragVisualMapEnd(base.component);
		}

		public override void Update()
		{
			CheckVisualMap(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			VisualMap visualMap = base.component;
			if (visualMap.show && visualMap.showUI)
			{
				if (visualMap.type != VisualMap.Type.Continuous)
				{
					_ = 1;
				}
				else
				{
					DrawContinuousVisualMap(vh, visualMap);
				}
			}
		}

		private void CheckVisualMap(VisualMap visualMap)
		{
			if (visualMap == null || !visualMap.show || base.chart.canvas == null)
			{
				return;
			}
			if (!base.chart.ScreenPointToChartPoint(Input.mousePosition, out var chartPoint))
			{
				if (visualMap.context.pointerIndex >= 0)
				{
					visualMap.context.pointerIndex = -1;
					base.chart.RefreshChart();
				}
				return;
			}
			if (chartPoint.x < base.chart.chartX || chartPoint.x > base.chart.chartX + base.chart.chartWidth || chartPoint.y < base.chart.chartY || chartPoint.y > base.chart.chartY + base.chart.chartHeight || !visualMap.IsInRangeRect(chartPoint, base.chart.chartRect))
			{
				if (visualMap.context.pointerIndex >= 0)
				{
					visualMap.context.pointerIndex = -1;
					base.chart.RefreshChart();
				}
				return;
			}
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			float num = visualMap.itemHeight / 2f;
			Vector3 vector = base.chart.chartPosition + visualMap.location.GetPosition(base.chart.chartWidth, base.chart.chartHeight);
			int pointerIndex = -1;
			double num2 = 0.0;
			switch (visualMap.orient)
			{
			case Orient.Horizonal:
				zero = vector + Vector3.left * num;
				zero2 = vector + Vector3.right * num;
				num2 = visualMap.min + (double)((chartPoint.x - zero.x) / (zero2.x - zero.x)) * (visualMap.max - visualMap.min);
				pointerIndex = visualMap.GetIndex(num2);
				break;
			case Orient.Vertical:
				zero = vector + Vector3.down * num;
				zero2 = vector + Vector3.up * num;
				num2 = visualMap.min + (double)((chartPoint.y - zero.y) / (zero2.y - zero.y)) * (visualMap.max - visualMap.min);
				pointerIndex = visualMap.GetIndex(num2);
				break;
			}
			visualMap.context.pointerValue = num2;
			visualMap.context.pointerIndex = pointerIndex;
			base.chart.RefreshChart();
		}

		private void DrawContinuousVisualMap(VertexHelper vh, VisualMap visualMap)
		{
			Vector3 vector = base.chart.chartPosition + visualMap.location.GetPosition(base.chart.chartWidth, base.chart.chartHeight);
			Vector3 vector2 = Vector3.zero;
			Vector3 p = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			float num = visualMap.itemWidth / 2f;
			float num2 = visualMap.itemHeight / 2f;
			float xRadius = 0f;
			float yRadius = 0f;
			int count = visualMap.inRange.Count;
			float num3 = visualMap.itemHeight / (float)(count - 1);
			bool vertical = false;
			List<VisualMapRange> inRange = visualMap.inRange;
			float triangeLen = base.chart.theme.visualMap.triangeLen;
			switch (visualMap.orient)
			{
			case Orient.Horizonal:
				vector2 = vector + Vector3.left * num2;
				p = vector + Vector3.right * num2;
				vector3 = Vector3.right;
				xRadius = num3 / 2f;
				yRadius = num;
				vertical = false;
				if (visualMap.calculable)
				{
					Vector3 vector7 = vector2 + Vector3.right * visualMap.runtimeRangeMinHeight;
					Vector3 p4 = vector7 + Vector3.up * num;
					Vector3 vector8 = vector7 + Vector3.up * (num + triangeLen);
					Vector3 p5 = vector8 + Vector3.left * triangeLen;
					Color32 color2 = visualMap.GetColor(visualMap.rangeMin);
					UGL.DrawTriangle(vh, p4, vector8, p5, color2);
					Vector3 vector9 = vector2 + Vector3.right * visualMap.runtimeRangeMaxHeight;
					p4 = vector9 + Vector3.up * num;
					vector8 = vector9 + Vector3.up * (num + triangeLen);
					p5 = vector8 + Vector3.right * triangeLen;
					color2 = visualMap.GetColor(visualMap.rangeMax);
					UGL.DrawTriangle(vh, p4, vector8, p5, color2);
				}
				break;
			case Orient.Vertical:
				vector2 = vector + Vector3.down * num2;
				p = vector + Vector3.up * num2;
				vector3 = Vector3.up;
				xRadius = num;
				yRadius = num3 / 2f;
				vertical = true;
				if (visualMap.calculable)
				{
					Vector3 vector4 = vector2 + Vector3.up * visualMap.runtimeRangeMinHeight;
					Vector3 p2 = vector4 + Vector3.right * num;
					Vector3 vector5 = vector4 + Vector3.right * (num + triangeLen);
					Vector3 p3 = vector5 + Vector3.down * triangeLen;
					Color32 color = visualMap.GetColor(visualMap.rangeMin);
					UGL.DrawTriangle(vh, p2, vector5, p3, color);
					Vector3 vector6 = vector2 + Vector3.up * visualMap.runtimeRangeMaxHeight;
					p2 = vector6 + Vector3.right * num;
					vector5 = vector6 + Vector3.right * (num + triangeLen);
					p3 = vector5 + Vector3.up * triangeLen;
					color = visualMap.GetColor(visualMap.rangeMax);
					UGL.DrawTriangle(vh, p2, vector5, p3, color);
				}
				break;
			}
			if (visualMap.calculable && (visualMap.rangeMin > visualMap.min || visualMap.rangeMax < visualMap.max))
			{
				double rangeMin = visualMap.rangeMin;
				double rangeMax = visualMap.rangeMax;
				double num4 = (visualMap.max - visualMap.min) / (double)(count - 1);
				for (int i = 1; i < count; i++)
				{
					double num5 = visualMap.min + (double)(i - 1) * num4;
					double num6 = num5 + num4;
					if (rangeMin > num6 || rangeMax < num5)
					{
						continue;
					}
					if (rangeMin <= num5 && rangeMax >= num6)
					{
						Vector3 p6 = vector2 + vector3 * ((float)(i - 1) + 0.5f) * num3;
						Color32 color3 = inRange[i - 1].color;
						Color32 toColor = (visualMap.IsPiecewise() ? color3 : inRange[i].color);
						UGL.DrawRectangle(vh, p6, xRadius, yRadius, color3, toColor, vertical);
					}
					else if (rangeMin > num5 && rangeMax >= num6)
					{
						Vector3 vector10 = vector2 + vector3 * visualMap.runtimeRangeMinHeight;
						Vector3 vector11 = vector2 + vector3 * i * num3;
						Vector3 p7 = vector10 + (vector11 - vector10) / 2f;
						Color32 color4 = visualMap.GetColor(visualMap.rangeMin);
						Color32 toColor2 = (visualMap.IsPiecewise() ? color4 : inRange[i].color);
						float num7 = Vector3.Distance(vector10, vector11) / 2f;
						if (visualMap.orient == Orient.Vertical)
						{
							UGL.DrawRectangle(vh, p7, xRadius, num7, color4, toColor2, vertical);
						}
						else
						{
							UGL.DrawRectangle(vh, p7, num7, yRadius, color4, toColor2, vertical);
						}
					}
					else if (rangeMax < num6 && rangeMin <= num5)
					{
						Vector3 vector12 = vector2 + vector3 * visualMap.runtimeRangeMaxHeight;
						Vector3 vector13 = vector2 + vector3 * (i - 1) * num3;
						Vector3 p8 = vector13 + (vector12 - vector13) / 2f;
						Color32 color5 = inRange[i - 1].color;
						Color32 toColor3 = (visualMap.IsPiecewise() ? color5 : visualMap.GetColor(visualMap.rangeMax));
						float num8 = Vector3.Distance(vector12, vector13) / 2f;
						if (visualMap.orient == Orient.Vertical)
						{
							UGL.DrawRectangle(vh, p8, xRadius, num8, color5, toColor3, vertical);
						}
						else
						{
							UGL.DrawRectangle(vh, p8, num8, yRadius, color5, toColor3, vertical);
						}
					}
					else
					{
						Vector3 vector14 = vector2 + vector3 * visualMap.runtimeRangeMinHeight;
						Vector3 vector15 = vector2 + vector3 * visualMap.runtimeRangeMaxHeight;
						Vector3 p9 = (vector14 + vector15) / 2f;
						Color32 color6 = visualMap.GetColor(visualMap.rangeMin);
						Color32 color7 = visualMap.GetColor(visualMap.rangeMax);
						float num9 = Vector3.Distance(vector14, vector15) / 2f;
						if (visualMap.orient == Orient.Vertical)
						{
							UGL.DrawRectangle(vh, p9, xRadius, num9, color6, color7, vertical);
						}
						else
						{
							UGL.DrawRectangle(vh, p9, num9, yRadius, color6, color7, vertical);
						}
					}
				}
			}
			else
			{
				for (int j = 1; j < count; j++)
				{
					Vector3 p10 = vector2 + vector3 * ((float)(j - 1) + 0.5f) * num3;
					Color32 color8 = inRange[j - 1].color;
					Color32 toColor4 = (visualMap.IsPiecewise() ? color8 : inRange[j].color);
					UGL.DrawRectangle(vh, p10, xRadius, yRadius, color8, toColor4, vertical);
				}
			}
			if (visualMap.rangeMin > visualMap.min)
			{
				Vector3 p11 = vector2 + vector3 * visualMap.runtimeRangeMinHeight;
				UGL.DrawRectangle(vh, vector2, p11, visualMap.itemWidth / 2f, base.chart.theme.visualMap.backgroundColor);
			}
			if (visualMap.rangeMax < visualMap.max)
			{
				Vector3 p12 = vector2 + vector3 * visualMap.runtimeRangeMaxHeight;
				UGL.DrawRectangle(vh, p12, p, visualMap.itemWidth / 2f, base.chart.theme.visualMap.backgroundColor);
			}
			if (visualMap.hoverLink && visualMap.context.pointerIndex >= 0)
			{
				Vector3 vector16 = vector2 + vector3 * visualMap.runtimeRangeMinHeight;
				Vector3 vector17 = vector2 + vector3 * visualMap.runtimeRangeMaxHeight;
				Vector2 pointerPos = base.chart.pointerPos;
				if (visualMap.orient == Orient.Vertical)
				{
					Vector3 p13 = new Vector3(vector.x + num, Mathf.Clamp(pointerPos.y + triangeLen / 2f, vector16.y, vector17.y));
					Vector3 p14 = new Vector3(vector.x + num, Mathf.Clamp(pointerPos.y - triangeLen / 2f, vector16.y, vector17.y));
					Vector3 p15 = new Vector3(vector.x + num + triangeLen / 2f, pointerPos.y);
					UGL.DrawTriangle(vh, p13, p14, p15, inRange[visualMap.context.pointerIndex].color);
				}
				else
				{
					Vector3 p16 = new Vector3(Mathf.Clamp(pointerPos.x + triangeLen / 2f, vector16.x, vector17.x), vector.y + num);
					Vector3 p17 = new Vector3(Mathf.Clamp(pointerPos.x - triangeLen / 2f, vector16.x, vector17.x), vector.y + num);
					Vector3 p18 = new Vector3(pointerPos.x, vector.y + num + triangeLen / 2f);
					UGL.DrawTriangle(vh, p16, p17, p18, inRange[visualMap.context.pointerIndex].color);
				}
			}
		}

		private void DrawPiecewiseVisualMap(VertexHelper vh, VisualMap visualMap)
		{
			Vector3 vector = base.chart.chartPosition + visualMap.location.GetPosition(base.chart.chartWidth, base.chart.chartHeight);
			_ = Vector3.zero;
			_ = Vector3.zero;
			_ = Vector3.zero;
			float xRadius = visualMap.itemWidth / 2f;
			float yRadius = visualMap.itemHeight / 2f;
			switch (visualMap.orient)
			{
			case Orient.Horizonal:
			{
				for (int j = 0; j < visualMap.inRange.Count; j++)
				{
					_ = visualMap.inRange[j];
				}
				break;
			}
			case Orient.Vertical:
			{
				float num = visualMap.itemHeight + visualMap.itemGap;
				for (int i = 0; i < visualMap.inRange.Count; i++)
				{
					VisualMapRange visualMapRange = visualMap.inRange[i];
					Vector3 p = new Vector3(vector.x, vector.y - num * (float)i);
					UGL.DrawRectangle(vh, p, xRadius, yRadius, visualMapRange.color);
				}
				break;
			}
			}
		}

		private void OnDragVisualMapStart(VisualMap visualMap)
		{
			if (!visualMap.show || !visualMap.showUI || !visualMap.calculable)
			{
				return;
			}
			bool flag = visualMap.IsInRangeMinRect(base.chart.pointerPos, base.chart.chartRect, base.chart.theme.visualMap.triangeLen);
			bool flag2 = visualMap.IsInRangeMaxRect(base.chart.pointerPos, base.chart.chartRect, base.chart.theme.visualMap.triangeLen);
			if (flag || flag2)
			{
				if (flag)
				{
					visualMap.context.minDrag = true;
				}
				else
				{
					visualMap.context.maxDrag = true;
				}
			}
		}

		private void OnDragVisualMap(VisualMap visualMap)
		{
			if (visualMap.show && visualMap.showUI && visualMap.calculable && (visualMap.context.minDrag || visualMap.context.maxDrag))
			{
				double value = visualMap.GetValue(base.chart.pointerPos, base.chart.chartRect);
				if (visualMap.context.minDrag)
				{
					visualMap.rangeMin = value;
				}
				else
				{
					visualMap.rangeMax = value;
				}
				base.chart.RefreshChart();
			}
		}

		private void OnDragVisualMapEnd(VisualMap visualMap)
		{
			if (visualMap.show && visualMap.showUI && visualMap.calculable && (visualMap.context.minDrag || visualMap.context.maxDrag))
			{
				base.chart.RefreshChart();
				visualMap.context.minDrag = false;
				visualMap.context.maxDrag = false;
			}
		}
	}
}
