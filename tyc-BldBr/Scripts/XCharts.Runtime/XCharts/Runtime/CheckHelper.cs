using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class CheckHelper
	{
		private static bool IsColorAlphaZero(Color color)
		{
			if (!ChartHelper.IsClearColor(color))
			{
				return color.a == 0f;
			}
			return false;
		}

		public static string CheckChart(BaseGraph chart)
		{
			if (chart is BaseChart)
			{
				return CheckChart((BaseChart)chart);
			}
			return string.Empty;
		}

		public static string CheckChart(BaseChart chart)
		{
			StringBuilder sb = ChartHelper.sb;
			sb.Length = 0;
			CheckName(chart, sb);
			CheckSize(chart, sb);
			CheckTheme(chart, sb);
			CheckTitle(chart, sb);
			CheckLegend(chart, sb);
			CheckGrid(chart, sb);
			CheckSerie(chart, sb);
			return sb.ToString();
		}

		private static void CheckName(BaseChart chart, StringBuilder sb)
		{
			if (!string.IsNullOrEmpty(chart.chartName) && XChartsMgr.GetCharts(chart.chartName).Count > 1)
			{
				sb.AppendFormat("warning:chart name is repeated: {0}\n", chart.chartName);
			}
		}

		private static void CheckSize(BaseChart chart, StringBuilder sb)
		{
			if (chart.chartWidth == 0f || chart.chartHeight == 0f)
			{
				sb.Append("warning:chart width or height is 0\n");
			}
		}

		private static void CheckTheme(BaseChart chart, StringBuilder sb)
		{
			chart.theme.CheckWarning(sb);
		}

		private static void CheckTitle(BaseChart chart, StringBuilder sb)
		{
		}

		private static void CheckLegend(BaseChart chart, StringBuilder sb)
		{
		}

		private static void CheckGrid(BaseChart chart, StringBuilder sb)
		{
		}

		private static void CheckSerie(BaseChart chart, StringBuilder sb)
		{
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			HashSet<int> hashSet = new HashSet<int>();
			foreach (Serie item in chart.series)
			{
				if (item.show)
				{
					flag3 = false;
				}
				if (item.dataCount > 0)
				{
					flag = false;
					int num = 0;
					hashSet.Clear();
					for (int i = 0; i < item.dataCount; i++)
					{
						SerieData serieData = item.GetSerieData(i);
						if (hashSet.Contains(serieData.index))
						{
							num++;
						}
						else
						{
							hashSet.Add(serieData.index);
						}
						for (int j = 1; j < serieData.data.Count; j++)
						{
							if (serieData.GetData(j) != 0.0)
							{
								flag2 = false;
								break;
							}
						}
					}
					int count = item.GetSerieData(0).data.Count;
					if (item.showDataDimension > 1 && item.showDataDimension != count)
					{
						sb.AppendFormat("warning:serie {0} serieData.data.count[{1}] not match showDataDimension[{2}]\n", item.index, count, item.showDataDimension);
					}
					if (num > 0)
					{
						sb.AppendFormat("error: data index error, count={0}/{1}\n", num, item.dataCount);
					}
				}
				else
				{
					sb.AppendFormat("warning:serie {0} no data\n", item.index);
				}
				if (IsColorAlphaZero(item.itemStyle.color))
				{
					sb.AppendFormat("warning:serie {0} itemStyle->color alpha is 0\n", item.index);
				}
				if (item.itemStyle.opacity == 0f)
				{
					sb.AppendFormat("warning:serie {0} itemStyle->opacity is 0\n", item.index);
				}
				if (item.itemStyle.borderWidth != 0f && IsColorAlphaZero(item.itemStyle.borderColor))
				{
					sb.AppendFormat("warning:serie {0} itemStyle->borderColor alpha is 0\n", item.index);
				}
				if (item is Line)
				{
					if (item.lineStyle.opacity == 0f)
					{
						sb.AppendFormat("warning:serie {0} lineStyle->opacity is 0\n", item.index);
					}
					if (IsColorAlphaZero(item.lineStyle.color))
					{
						sb.AppendFormat("warning:serie {0} lineStyle->color alpha is 0\n", item.index);
					}
				}
				else if (item is Pie)
				{
					if (item.radius.Length >= 2 && item.radius[1] == 0f)
					{
						sb.AppendFormat("warning:serie {0} radius[1] is 0\n", item.index);
					}
				}
				else if ((item is Scatter || item is EffectScatter) && !item.symbol.show)
				{
					sb.AppendFormat("warning:serie {0} symbol type is None\n", item.index);
				}
			}
			if (flag)
			{
				sb.Append("warning:all serie data is empty\n");
			}
			if (!flag && flag2)
			{
				sb.Append("warning:all serie data is 0\n");
			}
			if (flag3)
			{
				sb.Append("warning:all serie is hide\n");
			}
		}
	}
}
