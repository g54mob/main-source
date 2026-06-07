using System;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class TooltipHelper
	{
		internal static void ResetTooltipParamsByItemFormatter(Tooltip tooltip, BaseChart chart)
		{
			if (!string.IsNullOrEmpty(tooltip.titleFormatter))
			{
				if (IsIgnoreFormatter(tooltip.titleFormatter))
				{
					tooltip.context.data.title = string.Empty;
				}
				else
				{
					tooltip.context.data.title = tooltip.titleFormatter;
					FormatterHelper.ReplaceContent(ref tooltip.context.data.title, 0, tooltip.numericFormatter, null, chart);
				}
			}
			for (int num = tooltip.context.data.param.Count - 1; num >= 0; num--)
			{
				if (IsIgnoreFormatter(tooltip.context.data.param[num].itemFormatter))
				{
					tooltip.context.data.param.RemoveAt(num);
				}
			}
			foreach (SerieParams item2 in tooltip.context.data.param)
			{
				if (!string.IsNullOrEmpty(item2.itemFormatter))
				{
					item2.columns.Clear();
					string content = item2.itemFormatter;
					FormatterHelper.ReplaceSerieLabelContent(ref content, item2.numericFormatter, item2.dataCount, item2.value, item2.total, item2.serieName, item2.category, item2.serieData.name, item2.color, item2.serieData);
					string[] array = content.Split('|');
					foreach (string item in array)
					{
						item2.columns.Add(item);
					}
				}
			}
		}

		public static bool IsIgnoreFormatter(string itemFormatter)
		{
			if (!"-".Equals(itemFormatter))
			{
				return "{i}".Equals(itemFormatter, StringComparison.CurrentCultureIgnoreCase);
			}
			return true;
		}

		public static void LimitInRect(Tooltip tooltip, Rect chartRect)
		{
			if (tooltip.view != null)
			{
				Vector3 targetPos = tooltip.view.GetTargetPos();
				if (targetPos.x + tooltip.context.width > chartRect.x + chartRect.width)
				{
					targetPos.x = tooltip.context.pointer.x - tooltip.context.width - tooltip.offset.x;
				}
				else if (targetPos.x < chartRect.x)
				{
					targetPos.x = tooltip.context.pointer.x - tooltip.context.width + Mathf.Abs(tooltip.offset.x);
				}
				if (targetPos.y - tooltip.context.height < chartRect.y)
				{
					targetPos.y = chartRect.y + tooltip.context.height;
				}
				if (targetPos.y > chartRect.y + chartRect.height)
				{
					targetPos.y = chartRect.y + chartRect.height;
				}
				tooltip.UpdateContentPos(targetPos, chartRect.width / 2f, chartRect.height / 2f);
			}
		}

		public static string GetItemNumericFormatter(Tooltip tooltip, Serie serie, SerieData serieData)
		{
			ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
			if (!string.IsNullOrEmpty(itemStyle.numericFormatter))
			{
				return itemStyle.numericFormatter;
			}
			return tooltip.numericFormatter;
		}

		public static Color32 GetLineColor(Tooltip tooltip, Color32 defaultColor)
		{
			LineStyle lineStyle = tooltip.lineStyle;
			if (!ChartHelper.IsClearColor(lineStyle.color))
			{
				return lineStyle.GetColor();
			}
			Color32 color = defaultColor;
			ChartHelper.SetColorOpacity(ref color, lineStyle.opacity);
			return color;
		}
	}
}
