using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class DataZoomHandler : MainComponentHandler<DataZoom>
	{
		private static readonly string s_DefaultDataZoom = "datazoom";

		private Vector2 m_LastTouchPos0;

		private Vector2 m_LastTouchPos1;

		private bool m_CheckDataZoomLabel;

		private float m_DataZoomLastStartIndex;

		private float m_DataZoomLastEndIndex;

		public override void InitComponent()
		{
			DataZoom dataZoom = base.component;
			dataZoom.painter = base.chart.m_PainterUpper;
			dataZoom.refreshComponent = delegate
			{
				GameObject gameObject = ChartHelper.AddObject(s_DefaultDataZoom + dataZoom.index, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				dataZoom.gameObject = gameObject;
				gameObject.hideFlags = base.chart.chartHideFlags;
				ChartHelper.HideAllObject(gameObject);
				ChartLabel chartLabel = ChartHelper.AddChartLabel(s_DefaultDataZoom + "start", gameObject.transform, dataZoom.labelStyle, base.chart.theme.dataZoom, "", Color.clear, TextAnchor.MiddleRight);
				chartLabel.gameObject.SetActive(value: true);
				ChartLabel chartLabel2 = ChartHelper.AddChartLabel(s_DefaultDataZoom + "end", gameObject.transform, dataZoom.labelStyle, base.chart.theme.dataZoom, "", Color.clear, TextAnchor.MiddleLeft);
				chartLabel2.gameObject.SetActive(value: true);
				dataZoom.SetStartLabel(chartLabel);
				dataZoom.SetEndLabel(chartLabel2);
				dataZoom.SetLabelActive(flag: false);
				foreach (int xAxisIndex in dataZoom.xAxisIndexs)
				{
					base.chart.GetChartComponent<XAxis>(xAxisIndex)?.UpdateFilterData(dataZoom);
				}
				foreach (Serie item in base.chart.series)
				{
					SerieHelper.UpdateFilterData(item, dataZoom);
				}
			};
			dataZoom.refreshComponent();
		}

		public override void Update()
		{
			CheckDataZoomScale(base.component);
			CheckDataZoomLabel(base.component);
		}

		public override void DrawUpper(VertexHelper vh)
		{
			if (!(base.chart == null))
			{
				DataZoom dataZoom = base.component;
				switch (dataZoom.orient)
				{
				case Orient.Horizonal:
					DrawHorizonalDataZoomSlider(vh, dataZoom);
					DrawMarquee(vh, dataZoom);
					break;
				case Orient.Vertical:
					DrawVerticalDataZoomSlider(vh, dataZoom);
					DrawMarquee(vh, dataZoom);
					break;
				}
			}
		}

		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (base.chart == null || Input.touchCount > 1)
			{
				return;
			}
			DataZoom dataZoom = base.component;
			if (!dataZoom.enable || !base.chart.ScreenPointToChartPoint(eventData.position, out var chartPoint))
			{
				return;
			}
			GridCoord gridOfDataZoom = base.chart.GetGridOfDataZoom(dataZoom);
			if (dataZoom.supportInside && dataZoom.supportInsideDrag && gridOfDataZoom.Contains(chartPoint))
			{
				dataZoom.context.isCoordinateDrag = true;
			}
			if (dataZoom.supportMarquee)
			{
				dataZoom.context.isMarqueeDrag = true;
				dataZoom.context.marqueeStartPos = chartPoint;
				dataZoom.context.marqueeEndPos = chartPoint;
				if (dataZoom.marqueeStyle.realRect)
				{
					dataZoom.context.marqueeRect = new Rect(chartPoint.x, chartPoint.y, 0f, 0f);
				}
				else
				{
					dataZoom.context.marqueeRect = new Rect(chartPoint.x, gridOfDataZoom.context.y, 0f, gridOfDataZoom.context.height);
				}
				if (dataZoom.marqueeStyle.onStart != null)
				{
					dataZoom.marqueeStyle.onStart(dataZoom);
				}
			}
			else
			{
				if (!dataZoom.supportSlider)
				{
					return;
				}
				if (!dataZoom.zoomLock)
				{
					if (dataZoom.IsInStartZoom(chartPoint))
					{
						dataZoom.context.isStartDrag = true;
					}
					else if (dataZoom.IsInEndZoom(chartPoint))
					{
						dataZoom.context.isEndDrag = true;
					}
					else if (dataZoom.IsInSelectedZoom(chartPoint))
					{
						dataZoom.context.isDrag = true;
					}
				}
				else if (dataZoom.IsInSelectedZoom(chartPoint))
				{
					dataZoom.context.isDrag = true;
				}
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			if (base.chart == null || Input.touchCount > 1)
			{
				return;
			}
			DataZoom dataZoom = base.component;
			GridCoord gridOfDataZoom = base.chart.GetGridOfDataZoom(dataZoom);
			if (dataZoom.supportMarquee)
			{
				if (base.chart.ScreenPointToChartPoint(eventData.position, out var chartPoint))
				{
					dataZoom.context.marqueeEndPos = chartPoint;
					Rect marqueeRect = dataZoom.context.marqueeRect;
					float width = chartPoint.x - dataZoom.context.marqueeStartPos.x;
					if (dataZoom.marqueeStyle.realRect)
					{
						dataZoom.context.marqueeRect = Rect.MinMaxRect(dataZoom.context.marqueeStartPos.x, chartPoint.y, chartPoint.x, dataZoom.context.marqueeStartPos.y);
					}
					else
					{
						dataZoom.context.marqueeRect = new Rect(marqueeRect.x, marqueeRect.y, width, marqueeRect.height);
					}
					dataZoom.SetVerticesDirty();
					if (dataZoom.marqueeStyle.onGoing != null)
					{
						dataZoom.marqueeStyle.onGoing(dataZoom);
					}
				}
			}
			else
			{
				switch (dataZoom.orient)
				{
				case Orient.Horizonal:
				{
					float deltaPercent = eventData.delta.x / gridOfDataZoom.context.width * 100f;
					OnDragInside(dataZoom, deltaPercent);
					OnDragSlider(dataZoom, deltaPercent);
					break;
				}
				case Orient.Vertical:
				{
					float deltaPercent = eventData.delta.y / gridOfDataZoom.context.height * 100f;
					OnDragInside(dataZoom, deltaPercent);
					OnDragSlider(dataZoom, deltaPercent);
					break;
				}
				}
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			if (base.chart == null)
			{
				return;
			}
			DataZoom dataZoom = base.component;
			if (dataZoom.supportMarquee)
			{
				dataZoom.context.isMarqueeDrag = false;
				if (dataZoom.marqueeStyle.apply)
				{
					GridCoord gridOfDataZoom = base.chart.GetGridOfDataZoom(dataZoom);
					float start = (dataZoom.context.marqueeRect.x - gridOfDataZoom.context.x) / gridOfDataZoom.context.width * 100f;
					float end = (dataZoom.context.marqueeRect.x - gridOfDataZoom.context.x + dataZoom.context.marqueeRect.width) / gridOfDataZoom.context.width * 100f;
					UpdateDataZoomRange(dataZoom, start, end);
				}
				if (dataZoom.marqueeStyle.onEnd != null)
				{
					dataZoom.marqueeStyle.onEnd(dataZoom);
				}
			}
			else
			{
				if (dataZoom.context.isDrag || dataZoom.context.isStartDrag || dataZoom.context.isEndDrag || dataZoom.context.isCoordinateDrag)
				{
					base.chart.RefreshChart();
				}
				dataZoom.context.isDrag = false;
				dataZoom.context.isCoordinateDrag = false;
				dataZoom.context.isStartDrag = false;
				dataZoom.context.isEndDrag = false;
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (base.chart == null || Input.touchCount > 1 || !base.chart.ScreenPointToChartPoint(eventData.position, out var chartPoint))
			{
				return;
			}
			DataZoom dataZoom = base.component;
			GridCoord gridOfDataZoom = base.chart.GetGridOfDataZoom(dataZoom);
			if (!dataZoom.IsInStartZoom(chartPoint) && !dataZoom.IsInEndZoom(chartPoint) && dataZoom.IsInZoom(chartPoint) && !dataZoom.IsInSelectedZoom(chartPoint))
			{
				float x = chartPoint.x;
				float num = gridOfDataZoom.context.width * (dataZoom.end - dataZoom.start) / 100f;
				float num2 = x - num / 2f;
				float num3 = x + num / 2f;
				if (num2 < gridOfDataZoom.context.x)
				{
					num2 = gridOfDataZoom.context.x;
					num3 = gridOfDataZoom.context.x + num;
				}
				else if (num3 > gridOfDataZoom.context.x + gridOfDataZoom.context.width)
				{
					num3 = gridOfDataZoom.context.x + gridOfDataZoom.context.width;
					num2 = gridOfDataZoom.context.x + gridOfDataZoom.context.width - num;
				}
				float start = (num2 - gridOfDataZoom.context.x) / gridOfDataZoom.context.width * 100f;
				float end = (num3 - gridOfDataZoom.context.x) / gridOfDataZoom.context.width * 100f;
				UpdateDataZoomRange(dataZoom, start, end);
			}
		}

		public override void OnScroll(PointerEventData eventData)
		{
			if (base.chart == null || Input.touchCount > 1)
			{
				return;
			}
			DataZoom dataZoom = base.component;
			if (dataZoom.enable && !dataZoom.zoomLock && base.chart.ScreenPointToChartPoint(eventData.position, out var chartPoint))
			{
				GridCoord gridOfDataZoom = base.chart.GetGridOfDataZoom(dataZoom);
				if ((dataZoom.supportInside && dataZoom.supportInsideScroll && gridOfDataZoom.Contains(chartPoint)) || dataZoom.IsInZoom(chartPoint))
				{
					ScaleDataZoom(dataZoom, eventData.scrollDelta.y * dataZoom.scrollSensitivity);
				}
			}
		}

		private void OnDragInside(DataZoom dataZoom, float deltaPercent)
		{
			if (deltaPercent == 0f || Input.touchCount > 1 || !dataZoom.supportInside || !dataZoom.supportInsideDrag || !dataZoom.context.isCoordinateDrag)
			{
				return;
			}
			float num = dataZoom.end - dataZoom.start;
			if (deltaPercent > 0f)
			{
				if (dataZoom.start > 0f)
				{
					float num2 = dataZoom.start - deltaPercent;
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					float end = num2 + num;
					UpdateDataZoomRange(dataZoom, num2, end);
				}
			}
			else if (dataZoom.end < 100f)
			{
				float num3 = dataZoom.end - deltaPercent;
				if (num3 > 100f)
				{
					num3 = 100f;
				}
				float start = num3 - num;
				UpdateDataZoomRange(dataZoom, start, num3);
			}
		}

		private void OnDragSlider(DataZoom dataZoom, float deltaPercent)
		{
			if (Input.touchCount > 1 || !dataZoom.supportSlider)
			{
				return;
			}
			if (dataZoom.context.isStartDrag)
			{
				float num = dataZoom.start + deltaPercent;
				if (num > dataZoom.end)
				{
					num = dataZoom.end;
					dataZoom.context.isEndDrag = true;
					dataZoom.context.isStartDrag = false;
				}
				UpdateDataZoomRange(dataZoom, num, dataZoom.end);
			}
			else if (dataZoom.context.isEndDrag)
			{
				float num2 = dataZoom.end + deltaPercent;
				if (num2 < dataZoom.start)
				{
					num2 = dataZoom.start;
					dataZoom.context.isStartDrag = true;
					dataZoom.context.isEndDrag = false;
				}
				UpdateDataZoomRange(dataZoom, dataZoom.start, num2);
			}
			else
			{
				if (!dataZoom.context.isDrag)
				{
					return;
				}
				if (deltaPercent > 0f)
				{
					if (dataZoom.end + deltaPercent > 100f)
					{
						deltaPercent = 100f - dataZoom.end;
					}
				}
				else if (dataZoom.start + deltaPercent < 0f)
				{
					deltaPercent = 0f - dataZoom.start;
				}
				UpdateDataZoomRange(dataZoom, dataZoom.start + deltaPercent, dataZoom.end + deltaPercent);
			}
		}

		private void ScaleDataZoom(DataZoom dataZoom, float delta)
		{
			GridCoord gridOfDataZoom = base.chart.GetGridOfDataZoom(dataZoom);
			float num = ((dataZoom.orient == Orient.Horizonal) ? Mathf.Abs(delta / gridOfDataZoom.context.width * 100f) : Mathf.Abs(delta / gridOfDataZoom.context.height * 100f));
			if (delta > 0f)
			{
				if (!(dataZoom.end <= dataZoom.start))
				{
					UpdateDataZoomRange(dataZoom, dataZoom.start + num, dataZoom.end - num);
				}
			}
			else
			{
				UpdateDataZoomRange(dataZoom, dataZoom.start - num, dataZoom.end + num);
			}
		}

		public void UpdateDataZoomRange(DataZoom dataZoom, float start, float end)
		{
			if (end > 100f)
			{
				end = 100f;
			}
			if (start < 0f)
			{
				start = 0f;
			}
			if (end < start)
			{
				end = start;
			}
			if (dataZoom.startEndFunction != null)
			{
				dataZoom.startEndFunction(ref start, ref end);
			}
			if (!dataZoom.startLock)
			{
				dataZoom.start = start;
			}
			if (!dataZoom.endLock)
			{
				dataZoom.end = end;
			}
			if (dataZoom.realtime)
			{
				base.chart.OnDataZoomRangeChanged(dataZoom);
				base.chart.RefreshChart();
			}
		}

		public void RefreshDataZoomLabel()
		{
			m_CheckDataZoomLabel = true;
		}

		private void CheckDataZoomScale(DataZoom dataZoom)
		{
			if (dataZoom.enable && !dataZoom.zoomLock && dataZoom.supportInside && dataZoom.supportInsideDrag && Input.touchCount == 2)
			{
				Touch touch = Input.GetTouch(0);
				Touch touch2 = Input.GetTouch(1);
				if (touch2.phase == TouchPhase.Began)
				{
					m_LastTouchPos0 = touch.position;
					m_LastTouchPos1 = touch2.position;
				}
				else if (touch.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
				{
					Vector2 position = touch.position;
					Vector2 position2 = touch2.position;
					float num = Vector2.Distance(position, position2);
					float num2 = Vector2.Distance(m_LastTouchPos0, m_LastTouchPos1);
					float num3 = num - num2;
					ScaleDataZoom(dataZoom, num3 / dataZoom.scrollSensitivity);
					m_LastTouchPos0 = position;
					m_LastTouchPos1 = position2;
				}
			}
		}

		private void CheckDataZoomLabel(DataZoom dataZoom)
		{
			if (dataZoom.enable && dataZoom.supportSlider && dataZoom.showDetail)
			{
				if (!base.chart.ScreenPointToChartPoint(Input.mousePosition, out var chartPoint))
				{
					dataZoom.SetLabelActive(flag: false);
					return;
				}
				if (dataZoom.IsInSelectedZoom(chartPoint) || dataZoom.IsInStartZoom(chartPoint) || dataZoom.IsInEndZoom(chartPoint))
				{
					dataZoom.SetLabelActive(flag: true);
					RefreshDataZoomLabel();
				}
				else
				{
					dataZoom.SetLabelActive(flag: false);
				}
			}
			if (!m_CheckDataZoomLabel || dataZoom.xAxisIndexs.Count <= 0)
			{
				return;
			}
			m_CheckDataZoomLabel = false;
			XAxis chartComponent = base.chart.GetChartComponent<XAxis>(dataZoom.xAxisIndexs[0]);
			int num = (int)((float)(chartComponent.data.Count - 1) * dataZoom.start / 100f);
			int num2 = (int)((float)(chartComponent.data.Count - 1) * dataZoom.end / 100f);
			if (m_DataZoomLastStartIndex != (float)num || m_DataZoomLastEndIndex != (float)num2)
			{
				m_DataZoomLastStartIndex = num;
				m_DataZoomLastEndIndex = num2;
				if (chartComponent.data.Count > 0)
				{
					dataZoom.SetStartLabelText(chartComponent.data[num]);
					dataZoom.SetEndLabelText(chartComponent.data[num2]);
				}
				else if (chartComponent.IsTime())
				{
					dataZoom.SetStartLabelText("");
					dataZoom.SetEndLabelText("");
				}
				chartComponent.SetAllDirty();
			}
			float num3 = dataZoom.context.x + dataZoom.context.width * dataZoom.start / 100f;
			float num4 = dataZoom.context.x + dataZoom.context.width * dataZoom.end / 100f;
			float height = dataZoom.context.height;
			dataZoom.UpdateStartLabelPosition(new Vector3(num3 - 10f, base.chart.chartY + dataZoom.bottom + height / 2f));
			dataZoom.UpdateEndLabelPosition(new Vector3(num4 + 10f, base.chart.chartY + dataZoom.bottom + height / 2f));
		}

		private void DrawHorizonalDataZoomSlider(VertexHelper vh, DataZoom dataZoom)
		{
			if (!dataZoom.enable || !dataZoom.supportSlider)
			{
				return;
			}
			Vector3 p = new Vector3(dataZoom.context.x, dataZoom.context.y);
			Vector3 p2 = new Vector3(dataZoom.context.x, dataZoom.context.y + dataZoom.context.height);
			Vector3 p3 = new Vector3(dataZoom.context.x + dataZoom.context.width, dataZoom.context.y + dataZoom.context.height);
			Vector3 p4 = new Vector3(dataZoom.context.x + dataZoom.context.width, dataZoom.context.y);
			Color32 color = dataZoom.lineStyle.GetColor(base.chart.theme.dataZoom.dataLineColor);
			float width = dataZoom.lineStyle.GetWidth(base.chart.theme.dataZoom.dataLineWidth);
			float borderWidth = ((dataZoom.borderWidth == 0f) ? base.chart.theme.dataZoom.borderWidth : dataZoom.borderWidth);
			Color32 borderColor = dataZoom.GetBorderColor(base.chart.theme.dataZoom.borderColor);
			Color32 backgroundColor = dataZoom.GetBackgroundColor(base.chart.theme.dataZoom.backgroundColor);
			Color32 color2 = dataZoom.areaStyle.GetColor(base.chart.theme.dataZoom.dataAreaColor);
			UGL.DrawQuadrilateral(vh, p, p2, p3, p4, backgroundColor);
			Vector3 center = new Vector3(dataZoom.context.x + dataZoom.context.width / 2f, dataZoom.context.y + dataZoom.context.height / 2f);
			UGL.DrawBorder(vh, center, dataZoom.context.width, dataZoom.context.height, borderWidth, borderColor);
			if (dataZoom.showDataShadow && base.chart.series.Count > 0)
			{
				Serie serie = base.chart.series[0];
				Axis chartComponent = base.chart.GetChartComponent<YAxis>();
				List<SerieData> showData = serie.GetDataList();
				float num = dataZoom.context.width / (float)(showData.Count - 1);
				Vector3 startPoint = Vector3.zero;
				Vector3 zero = Vector3.zero;
				double minValue = 0.0;
				double maxValue = 0.0;
				SeriesHelper.GetYMinMaxValue(base.chart, 0, base.chart.IsAllAxisValue(), chartComponent.inverse, out minValue, out maxValue, isPolar: false, filterByDataZoom: false);
				AxisHelper.AdjustMinMaxValue(chartComponent, ref minValue, ref maxValue, needFormat: true);
				int num2 = 1;
				float num3 = ((serie.sampleDist < 2f) ? 2f : serie.sampleDist);
				int count = showData.Count;
				if (num3 > 0f)
				{
					num2 = (int)((float)(count - serie.minShow) / (dataZoom.context.width / num3));
				}
				if (num2 < 1)
				{
					num2 = 1;
				}
				double totalAverage = ((serie.sampleAverage > 0f) ? ((double)serie.sampleAverage) : DataHelper.DataAverage(ref showData, serie.sampleType, serie.minShow, count, num2));
				bool dataChanging = false;
				float changeDuration = serie.animation.GetChangeDuration();
				float additionDuration = serie.animation.GetAdditionDuration();
				bool unscaledTime = serie.animation.unscaledTime;
				for (int i = 0; i < count; i += num2)
				{
					double num4 = DataHelper.SampleValue(ref showData, serie.sampleType, num2, serie.minShow, count, totalAverage, i, additionDuration, changeDuration, ref dataChanging, chartComponent, unscaledTime);
					float x = dataZoom.context.x + (float)i * num;
					float num5 = (float)((maxValue - minValue == 0.0) ? 0.0 : ((num4 - minValue) / (maxValue - minValue) * (double)dataZoom.context.height));
					zero = new Vector3(x, base.chart.chartY + dataZoom.bottom + num5);
					if (i > 0)
					{
						UGL.DrawLine(vh, startPoint, zero, width, color);
						Vector3 p5 = new Vector3(startPoint.x, startPoint.y - width);
						Vector3 p6 = new Vector3(zero.x, zero.y - width);
						Vector3 p7 = new Vector3(zero.x, base.chart.chartY + dataZoom.bottom + width);
						Vector3 p8 = new Vector3(startPoint.x, base.chart.chartY + dataZoom.bottom + width);
						UGL.DrawQuadrilateral(vh, p5, p6, p7, p8, color2);
					}
					startPoint = zero;
				}
				if (dataChanging)
				{
					base.chart.RefreshTopPainter();
				}
			}
			if (dataZoom.rangeMode == DataZoom.RangeMode.Percent)
			{
				float x2 = dataZoom.context.x + dataZoom.context.width * dataZoom.start / 100f;
				float x3 = dataZoom.context.x + dataZoom.context.width * dataZoom.end / 100f;
				Color32 fillerColor = dataZoom.GetFillerColor(base.chart.theme.dataZoom.fillerColor);
				p = new Vector2(x2, dataZoom.context.y);
				p2 = new Vector2(x2, dataZoom.context.y + dataZoom.context.height);
				p3 = new Vector2(x3, dataZoom.context.y + dataZoom.context.height);
				p4 = new Vector2(x3, dataZoom.context.y);
				UGL.DrawQuadrilateral(vh, p, p2, p3, p4, fillerColor);
				UGL.DrawLine(vh, p, p2, width, fillerColor);
				UGL.DrawLine(vh, p3, p4, width, fillerColor);
			}
		}

		private void DrawVerticalDataZoomSlider(VertexHelper vh, DataZoom dataZoom)
		{
			if (!dataZoom.enable || !dataZoom.supportSlider)
			{
				return;
			}
			Vector3 p = new Vector3(dataZoom.context.x, dataZoom.context.y);
			Vector3 p2 = new Vector3(dataZoom.context.x, dataZoom.context.y + dataZoom.context.height);
			Vector3 p3 = new Vector3(dataZoom.context.x + dataZoom.context.width, dataZoom.context.y + dataZoom.context.height);
			Vector3 p4 = new Vector3(dataZoom.context.x + dataZoom.context.width, dataZoom.context.y);
			Color32 color = dataZoom.lineStyle.GetColor(base.chart.theme.dataZoom.dataLineColor);
			float width = dataZoom.lineStyle.GetWidth(base.chart.theme.dataZoom.dataLineWidth);
			float borderWidth = ((dataZoom.borderWidth == 0f) ? base.chart.theme.dataZoom.borderWidth : dataZoom.borderWidth);
			Color32 borderColor = dataZoom.GetBorderColor(base.chart.theme.dataZoom.borderColor);
			Color32 backgroundColor = dataZoom.GetBackgroundColor(base.chart.theme.dataZoom.backgroundColor);
			Color32 color2 = dataZoom.areaStyle.GetColor(base.chart.theme.dataZoom.dataAreaColor);
			UGL.DrawQuadrilateral(vh, p, p2, p3, p4, backgroundColor);
			Vector3 center = new Vector3(dataZoom.context.x + dataZoom.context.width / 2f, dataZoom.context.y + dataZoom.context.height / 2f);
			UGL.DrawBorder(vh, center, dataZoom.context.width, dataZoom.context.height, borderWidth, borderColor);
			if (dataZoom.showDataShadow && base.chart.series.Count > 0)
			{
				Serie serie = base.chart.series[0];
				Axis chartComponent = base.chart.GetChartComponent<YAxis>();
				List<SerieData> showData = serie.GetDataList();
				float num = dataZoom.context.height / (float)(showData.Count - 1);
				Vector3 startPoint = Vector3.zero;
				Vector3 zero = Vector3.zero;
				double minValue = 0.0;
				double maxValue = 0.0;
				SeriesHelper.GetYMinMaxValue(base.chart, 0, base.chart.IsAllAxisValue(), chartComponent.inverse, out minValue, out maxValue);
				AxisHelper.AdjustMinMaxValue(chartComponent, ref minValue, ref maxValue, needFormat: true);
				int num2 = 1;
				float num3 = ((serie.sampleDist < 2f) ? 2f : serie.sampleDist);
				int count = showData.Count;
				if (num3 > 0f)
				{
					num2 = (int)((float)(count - serie.minShow) / (dataZoom.context.height / num3));
				}
				if (num2 < 1)
				{
					num2 = 1;
				}
				double totalAverage = ((serie.sampleAverage > 0f) ? ((double)serie.sampleAverage) : DataHelper.DataAverage(ref showData, serie.sampleType, serie.minShow, count, num2));
				bool dataChanging = false;
				float changeDuration = serie.animation.GetChangeDuration();
				float additionDuration = serie.animation.GetAdditionDuration();
				bool unscaledTime = serie.animation.unscaledTime;
				for (int i = 0; i < count; i += num2)
				{
					double num4 = DataHelper.SampleValue(ref showData, serie.sampleType, num2, serie.minShow, count, totalAverage, i, additionDuration, changeDuration, ref dataChanging, chartComponent, unscaledTime);
					float y = dataZoom.context.y + (float)i * num;
					float num5 = ((maxValue - minValue == 0.0) ? 0f : ((float)((num4 - minValue) / (maxValue - minValue) * (double)dataZoom.context.width)));
					zero = new Vector3(base.chart.chartX + base.chart.chartWidth - dataZoom.right - num5, y);
					if (i > 0)
					{
						UGL.DrawLine(vh, startPoint, zero, width, color);
						Vector3 p5 = new Vector3(startPoint.x, startPoint.y - width);
						Vector3 p6 = new Vector3(zero.x, zero.y - width);
						Vector3 p7 = new Vector3(zero.x, base.chart.chartY + dataZoom.bottom + width);
						Vector3 p8 = new Vector3(startPoint.x, base.chart.chartY + dataZoom.bottom + width);
						UGL.DrawQuadrilateral(vh, p5, p6, p7, p8, color2);
					}
					startPoint = zero;
				}
				if (dataChanging)
				{
					base.chart.RefreshTopPainter();
				}
			}
			if (dataZoom.rangeMode == DataZoom.RangeMode.Percent)
			{
				float y2 = dataZoom.context.y + dataZoom.context.height * dataZoom.start / 100f;
				float y3 = dataZoom.context.y + dataZoom.context.height * dataZoom.end / 100f;
				Color32 fillerColor = dataZoom.GetFillerColor(base.chart.theme.dataZoom.fillerColor);
				p = new Vector2(dataZoom.context.x, y2);
				p2 = new Vector2(dataZoom.context.x + dataZoom.context.width, y2);
				p3 = new Vector2(dataZoom.context.x + dataZoom.context.width, y3);
				p4 = new Vector2(dataZoom.context.x, y3);
				UGL.DrawQuadrilateral(vh, p, p2, p3, p4, fillerColor);
				UGL.DrawLine(vh, p, p2, width, fillerColor);
				UGL.DrawLine(vh, p3, p4, width, fillerColor);
			}
		}

		private void DrawMarquee(VertexHelper vh, DataZoom dataZoom)
		{
			if (dataZoom.enable && dataZoom.supportMarquee)
			{
				Color32 color = dataZoom.marqueeStyle.areaStyle.GetColor(base.chart.theme.dataZoom.dataAreaColor);
				UGL.DrawRectangle(vh, dataZoom.context.marqueeRect, color);
			}
		}
	}
}
