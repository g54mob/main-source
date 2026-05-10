using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class DebugInfo
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private bool m_ShowDebugInfo;

		[SerializeField]
		protected bool m_ShowAllChartObject;

		[SerializeField]
		protected bool m_FoldSeries;

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle
		{
			background = new ImageStyle
			{
				color = new Color32(32, 32, 32, 170)
			},
			textStyle = new TextStyle
			{
				fontSize = 18,
				color = Color.white
			}
		};

		private static StringBuilder s_Sb = new StringBuilder();

		private static readonly float INTERVAL = 0.2f;

		private static readonly float MAXCACHE = 20f;

		private int m_FrameCount;

		private float m_LastTime;

		private float m_LastCheckShowTime;

		private int m_LastRefreshCount;

		private BaseChart m_Chart;

		private ChartLabel m_Label;

		private List<float> m_FpsList = new List<float>();

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				m_Show = value;
			}
		}

		public bool showAllChartObject
		{
			get
			{
				return m_ShowAllChartObject;
			}
			set
			{
				m_ShowAllChartObject = value;
			}
		}

		public bool foldSeries
		{
			get
			{
				return m_FoldSeries;
			}
			set
			{
				m_FoldSeries = value;
			}
		}

		public float fps { get; private set; }

		public float avgFps { get; private set; }

		public int refreshCount { get; internal set; }

		internal int clickChartCount { get; set; }

		public void Init(BaseChart chart)
		{
			m_Chart = chart;
			m_Label = AddDebugInfoObject("debug", chart.transform, m_LabelStyle, chart.theme);
		}

		public void Update()
		{
			if (clickChartCount > 2)
			{
				m_ShowDebugInfo = !m_ShowDebugInfo;
				ChartHelper.SetActive(m_Label.transform, m_ShowDebugInfo);
				clickChartCount = 0;
				m_LastCheckShowTime = Time.realtimeSinceStartup;
				return;
			}
			if (Time.realtimeSinceStartup - m_LastCheckShowTime > 0.5f)
			{
				m_LastCheckShowTime = Time.realtimeSinceStartup;
				clickChartCount = 0;
			}
			if (!m_ShowDebugInfo || m_Label == null)
			{
				return;
			}
			m_FrameCount++;
			if (!(Time.realtimeSinceStartup - m_LastTime >= INTERVAL))
			{
				return;
			}
			fps = (float)m_FrameCount / (Time.realtimeSinceStartup - m_LastTime);
			m_FrameCount = 0;
			m_LastTime = Time.realtimeSinceStartup;
			if (m_LastRefreshCount == refreshCount)
			{
				m_LastRefreshCount = 0;
				refreshCount = 0;
			}
			m_LastRefreshCount = refreshCount;
			if ((float)m_FpsList.Count > MAXCACHE)
			{
				m_FpsList.RemoveAt(0);
			}
			m_FpsList.Add(fps);
			avgFps = GetAvg(m_FpsList);
			if (!(m_Label != null))
			{
				return;
			}
			s_Sb.Length = 0;
			s_Sb.AppendFormat("v{0}\n", XChartsMgr.version);
			s_Sb.AppendFormat("fps : {0:f0} / {1:f0}\n", fps, avgFps);
			s_Sb.AppendFormat("draw : {0}\n", refreshCount);
			int allSerieDataCount = m_Chart.GetAllSerieDataCount();
			SetValueWithKInfo(s_Sb, "data", allSerieDataCount);
			int num = 0;
			foreach (Serie item in m_Chart.series)
			{
				num += item.context.vertCount;
			}
			SetValueWithKInfo(s_Sb, "b-vert", m_Chart.m_BasePainterVertCount);
			SetValueWithKInfo(s_Sb, "s-vert", num);
			SetValueWithKInfo(s_Sb, "t-vert", m_Chart.m_TopPainterVertCount, newLine: false);
			m_Label.SetText(s_Sb.ToString());
		}

		private static void SetValueWithKInfo(StringBuilder s_Sb, string key, int value, bool newLine = true)
		{
			if (value >= 1000)
			{
				s_Sb.AppendFormat("{0} : {1:f1}k", key, (float)value * 0.001f);
			}
			else
			{
				s_Sb.AppendFormat("{0} : {1}", key, value);
			}
			if (newLine)
			{
				s_Sb.Append("\n");
			}
		}

		private static float GetAvg(List<float> list)
		{
			float num = 0f;
			foreach (float item in list)
			{
				num += item;
			}
			return num / (float)list.Count;
		}

		private ChartLabel AddDebugInfoObject(string name, Transform parent, LabelStyle labelStyle, ThemeStyle theme)
		{
			Vector2 anchorMax = new Vector2(0f, 1f);
			Vector2 anchorMin = new Vector2(0f, 1f);
			Vector2 pivot = new Vector2(0f, 1f);
			Vector2 sizeDelta = new Vector2(100f, 100f);
			GameObject gameObject = ChartHelper.AddObject(name, parent, anchorMin, anchorMax, pivot, sizeDelta);
			gameObject.transform.SetAsLastSibling();
			gameObject.hideFlags = m_Chart.chartHideFlags;
			ChartHelper.SetActive(gameObject, m_ShowDebugInfo);
			ChartLabel chartLabel = ChartHelper.AddChartLabel("info", gameObject.transform, labelStyle, theme.common, "", Color.clear, TextAnchor.UpperLeft);
			chartLabel.SetActive(labelStyle.show);
			return chartLabel;
		}
	}
}
