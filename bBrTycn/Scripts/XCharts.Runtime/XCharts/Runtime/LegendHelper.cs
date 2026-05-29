using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public static class LegendHelper
	{
		public static Color GetContentColor(BaseChart chart, int legendIndex, string legendName, Legend legend, ThemeStyle theme, bool active)
		{
			TextStyle textStyle = legend.labelStyle.textStyle;
			if (active)
			{
				if (legend.labelStyle.textStyle.autoColor)
				{
					return SeriesHelper.GetNameColor(chart, legendIndex, legendName);
				}
				if (ChartHelper.IsClearColor(textStyle.color))
				{
					return theme.legend.textColor;
				}
				return textStyle.color;
			}
			return theme.legend.unableColor;
		}

		public static Color GetIconColor(BaseChart chart, Legend legend, int readIndex, string legendName, bool active)
		{
			if (active)
			{
				if (legend.itemAutoColor)
				{
					return SeriesHelper.GetNameColor(chart, readIndex, legendName);
				}
				return legend.GetColor(readIndex);
			}
			return chart.theme.legend.unableColor;
		}

		public static LegendItem AddLegendItem(BaseChart chart, Legend legend, int i, string legendName, Transform parent, ThemeStyle theme, string content, Color itemColor, bool active, int legendIndex)
		{
			string name = i + "_" + legendName;
			Vector2 anchorMin = new Vector2(0f, 0.5f);
			Vector2 anchorMax = new Vector2(0f, 0.5f);
			Vector2 pivot = new Vector2(0f, 0.5f);
			Vector2 sizeDelta = new Vector2(100f, 30f);
			Vector2 sizeDelta2 = new Vector2(legend.itemWidth, legend.itemHeight);
			_ = legend.labelStyle.textStyle;
			Color contentColor = GetContentColor(chart, legendIndex, legendName, legend, theme, active);
			Vector2 anchorMin2 = new Vector2(0f, 1f);
			Vector2 anchorMax2 = new Vector2(0f, 1f);
			Vector2 pivot2 = new Vector2(0f, 1f);
			GameObject gameObject = ChartHelper.AddObject(name, parent, anchorMin2, anchorMax2, pivot2, sizeDelta);
			GameObject gameObject2 = ChartHelper.AddObject("icon", gameObject.transform, anchorMin, anchorMax, pivot, sizeDelta2);
			Image image = ChartHelper.EnsureComponent<Image>(gameObject);
			image.color = Color.clear;
			image.raycastTarget = true;
			ChartHelper.EnsureComponent<Button>(gameObject);
			ChartHelper.EnsureComponent<Image>(gameObject2);
			ChartHelper.AddChartLabel("content", gameObject.transform, legend.labelStyle, theme.legend, content, contentColor, TextAnchor.MiddleLeft).SetActive(flag: true);
			LegendItem legendItem = new LegendItem();
			legendItem.index = i;
			legendItem.name = name;
			legendItem.legendName = legendName;
			legendItem.SetObject(gameObject);
			legendItem.SetIconSize(legend.itemWidth, legend.itemHeight);
			legendItem.SetIconColor(itemColor);
			legendItem.SetIconImage(legend.GetIcon(i));
			legendItem.SetContentPosition(legend.labelStyle.offset);
			legendItem.SetContent(content);
			return legendItem;
		}

		public static void SetLegendBackground(Legend legend, ImageStyle style)
		{
			Image background = legend.context.background;
			if (!(background == null))
			{
				ChartHelper.SetActive(background, style.show);
				if (style.show)
				{
					RectTransform component = background.gameObject.GetComponent<RectTransform>();
					component.localPosition = legend.context.center;
					component.sizeDelta = new Vector2(legend.context.width, legend.context.height);
					ChartHelper.SetBackground(background, style);
				}
			}
		}

		public static void ResetItemPosition(Legend legend, Vector3 chartPos, float chartWidth, float chartHeight)
		{
			legend.location.UpdateRuntimeData(chartWidth, chartHeight);
			float num = 0f;
			float num2 = 0f;
			float num3 = chartWidth - legend.location.runtimeLeft - legend.location.runtimeRight;
			float num4 = chartHeight - legend.location.runtimeTop - legend.location.runtimeBottom;
			UpdateLegendWidthAndHeight(legend, num3, num4);
			float width = legend.context.width;
			float height = legend.context.height;
			bool flag = legend.orient == Orient.Vertical;
			switch (legend.location.align)
			{
			case Location.Align.TopCenter:
				num = chartPos.x + chartWidth / 2f - width / 2f;
				num2 = chartPos.y + chartHeight - legend.location.runtimeTop;
				break;
			case Location.Align.TopLeft:
				num = chartPos.x + legend.location.runtimeLeft;
				num2 = chartPos.y + chartHeight - legend.location.runtimeTop;
				break;
			case Location.Align.TopRight:
				num = chartPos.x + chartWidth - width - legend.location.runtimeRight;
				num2 = chartPos.y + chartHeight - legend.location.runtimeTop;
				break;
			case Location.Align.Center:
				num = chartPos.x + chartWidth / 2f - width / 2f;
				num2 = chartPos.y + chartHeight / 2f + height / 2f;
				break;
			case Location.Align.CenterLeft:
				num = chartPos.x + legend.location.runtimeLeft;
				num2 = chartPos.y + chartHeight / 2f + height / 2f;
				break;
			case Location.Align.CenterRight:
				num = chartPos.x + chartWidth - width - legend.location.runtimeRight;
				num2 = chartPos.y + chartHeight / 2f + height / 2f;
				break;
			case Location.Align.BottomCenter:
				num = chartPos.x + chartWidth / 2f - width / 2f;
				num2 = chartPos.y + height + legend.location.runtimeBottom;
				break;
			case Location.Align.BottomLeft:
				num = chartPos.x + legend.location.runtimeLeft;
				num2 = chartPos.y + height + legend.location.runtimeBottom;
				break;
			case Location.Align.BottomRight:
				num = chartPos.x + chartWidth - width - legend.location.runtimeRight;
				num2 = chartPos.y + height + legend.location.runtimeBottom;
				break;
			}
			if (!legend.padding.show)
			{
				legend.context.center = new Vector2(num + legend.context.width / 2f, num2 - legend.context.height / 2f);
			}
			else
			{
				legend.context.center = new Vector2(num + legend.context.width / 2f - legend.padding.left, num2 - legend.context.height / 2f + legend.padding.top);
			}
			if (flag)
			{
				SetVerticalItemPosition(legend, num4, num, num2);
			}
			else
			{
				SetHorizonalItemPosition(legend, num3, num, num2);
			}
			SetLegendBackground(legend, legend.background);
		}

		private static void SetVerticalItemPosition(Legend legend, float legendMaxHeight, float startX, float startY)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			int num4 = 0;
			foreach (KeyValuePair<string, LegendItem> button in legend.context.buttonList)
			{
				LegendItem value = button.Value;
				if (num + value.height > legendMaxHeight)
				{
					num = 0f;
					num2 += legend.context.eachWidthDict[num3];
					num3++;
				}
				value.SetPosition(legend.GetPosition(num4++, new Vector3(startX + num2, startY - num)));
				num += value.height + legend.itemGap;
			}
		}

		private static void SetHorizonalItemPosition(Legend legend, float legendMaxWidth, float startX, float startY)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			foreach (KeyValuePair<string, LegendItem> button in legend.context.buttonList)
			{
				LegendItem value = button.Value;
				if (num + value.width > legendMaxWidth)
				{
					num = 0f;
					num2 += legend.context.eachHeight;
				}
				value.SetPosition(legend.GetPosition(num3++, new Vector3(startX + num, startY - num2)));
				num += value.width + legend.itemGap;
			}
		}

		private static void UpdateLegendWidthAndHeight(Legend legend, float maxWidth, float maxHeight)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			legend.context.eachWidthDict.Clear();
			legend.context.eachHeight = 0f;
			if (legend.orient == Orient.Horizonal)
			{
				foreach (KeyValuePair<string, LegendItem> button in legend.context.buttonList)
				{
					if (num + button.Value.width > maxWidth)
					{
						num4 = num - legend.itemGap;
						num3 += num2 + legend.itemGap;
						if (legend.context.eachHeight < num2 + legend.itemGap)
						{
							legend.context.eachHeight = num2 + legend.itemGap;
						}
						num2 = 0f;
						num = 0f;
					}
					num += button.Value.width + legend.itemGap;
					if (button.Value.height > num2)
					{
						num2 = button.Value.height;
					}
				}
				num -= legend.itemGap;
				legend.context.height = num3 + num2;
				legend.context.width = ((num4 > 0f) ? num4 : num);
			}
			else
			{
				int num5 = 0;
				foreach (KeyValuePair<string, LegendItem> button2 in legend.context.buttonList)
				{
					if (num2 + button2.Value.height > maxHeight)
					{
						num3 = num2 - legend.itemGap;
						num4 += num + legend.itemGap;
						legend.context.eachWidthDict[num5] = num + legend.itemGap;
						num5++;
						num2 = 0f;
						num = 0f;
					}
					num2 += button2.Value.height + legend.itemGap;
					if (button2.Value.width > num)
					{
						num = button2.Value.width;
					}
				}
				num2 -= legend.itemGap;
				legend.context.height = ((num3 > 0f) ? num3 : num2);
				legend.context.width = num4 + num;
			}
			if (legend.padding.show)
			{
				legend.context.width += legend.padding.left + legend.padding.right;
				legend.context.height += legend.padding.top + legend.padding.bottom;
			}
		}

		private static bool IsBeyondWidth(Legend legend, float maxWidth)
		{
			float num = 0f;
			foreach (KeyValuePair<string, LegendItem> button in legend.context.buttonList)
			{
				LegendItem value = button.Value;
				num += value.width + legend.itemGap;
				if (num > maxWidth)
				{
					return true;
				}
			}
			return false;
		}

		public static bool CheckDataShow(Serie serie, string legendName, bool show)
		{
			bool result = false;
			if (legendName.Equals(serie.serieName))
			{
				serie.show = show;
				serie.highlight = false;
				if (serie.show)
				{
					result = true;
				}
			}
			else
			{
				foreach (SerieData datum in serie.data)
				{
					if (legendName.Equals(datum.name))
					{
						datum.show = show;
						datum.context.highlight = false;
						if (datum.show)
						{
							result = true;
						}
					}
				}
			}
			return result;
		}

		public static int CheckDataHighlighted(Serie serie, string legendName, bool heighlight)
		{
			int result = 0;
			if (legendName.Equals(serie.serieName))
			{
				serie.highlight = heighlight;
			}
			else
			{
				foreach (SerieData datum in serie.data)
				{
					if (legendName.Equals(datum.name))
					{
						datum.context.highlight = heighlight;
						if (datum.context.highlight)
						{
							result = datum.index;
						}
					}
				}
			}
			return result;
		}
	}
}
