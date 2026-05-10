using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XCharts.Runtime
{
	[ExecuteInEditMode]
	public static class XChartsMgr
	{
		public static readonly string version;

		public static readonly int versionDate;

		internal static List<BaseChart> chartList;

		internal static Dictionary<string, Theme> themes;

		internal static List<string> themeNames;

		public static string fullVersion => version + "-" + versionDate;

		static XChartsMgr()
		{
			version = "3.8.0";
			versionDate = 20230903;
			chartList = new List<BaseChart>();
			themes = new Dictionary<string, Theme>();
			themeNames = new List<string>();
			SerieLabelPool.ClearAll();
			chartList.Clear();
			if ((bool)Resources.Load<XCSettings>("XCSettings"))
			{
				XCThemeMgr.ReloadThemeList();
			}
			SceneManager.sceneUnloaded += OnSceneLoaded;
		}

		private static void OnSceneLoaded(Scene scene)
		{
			SerieLabelPool.ClearAll();
		}

		public static void AddChart(BaseChart chart)
		{
			BaseChart chart2 = GetChart(chart.chartName);
			if (chart2 != null)
			{
				string fullName = ChartHelper.GetFullName(chart2.transform);
				Debug.LogError("A chart named `" + chart.chartName + "` already exists:" + fullName);
				RemoveChart(chart.chartName);
			}
			if (!ContainsChart(chart))
			{
				chartList.Add(chart);
			}
		}

		public static BaseChart GetChart(string chartName)
		{
			if (string.IsNullOrEmpty(chartName))
			{
				return null;
			}
			return chartList.Find((BaseChart chart) => chartName.Equals(chart.chartName));
		}

		public static List<BaseChart> GetCharts(string chartName)
		{
			if (string.IsNullOrEmpty(chartName))
			{
				return null;
			}
			return chartList.FindAll((BaseChart chart) => chartName.Equals(chart.chartName));
		}

		public static void RemoveChart(string chartName)
		{
			if (!string.IsNullOrEmpty(chartName))
			{
				chartList.RemoveAll((BaseChart chart) => chartName.Equals(chart.chartName));
			}
		}

		public static bool ContainsChart(string chartName)
		{
			if (string.IsNullOrEmpty(chartName))
			{
				return false;
			}
			List<BaseChart> charts = GetCharts(chartName);
			if (charts != null)
			{
				return charts.Count > 0;
			}
			return false;
		}

		public static bool ContainsChart(BaseChart chart)
		{
			return chartList.Contains(chart);
		}

		public static bool IsRepeatChartName(BaseChart chart, string chartName = null)
		{
			if (chartName == null)
			{
				chartName = chart.chartName;
			}
			if (string.IsNullOrEmpty(chartName))
			{
				return false;
			}
			foreach (BaseChart chart2 in chartList)
			{
				if (chart2 != chart && chartName.Equals(chart2.chartName))
				{
					return true;
				}
			}
			return false;
		}

		public static string GetRepeatChartNameInfo(BaseChart chart, string chartName)
		{
			if (string.IsNullOrEmpty(chartName))
			{
				return string.Empty;
			}
			string text = "";
			foreach (BaseChart chart2 in chartList)
			{
				if (chart2 != chart && chartName.Equals(chart2.chartName))
				{
					text = text + ChartHelper.GetFullName(chart2.transform) + "\n";
				}
			}
			return text;
		}

		public static void RemoveAllChartObject()
		{
			if (chartList.Count == 0)
			{
				return;
			}
			foreach (BaseChart chart in chartList)
			{
				if (chart != null)
				{
					chart.RebuildChartObject();
				}
			}
		}
	}
}
