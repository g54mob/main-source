using UnityEngine;
using UnityEngine.Scripting;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class TitleHander : MainComponentHandler<Title>
	{
		private static readonly string s_TitleObjectName = "title";

		private static readonly string s_SubTitleObjectName = "title_sub";

		private ChartLabel m_LabelObject;

		private ChartLabel m_SubLabelObject;

		public override void InitComponent()
		{
			Title title = base.component;
			title.painter = null;
			title.refreshComponent = delegate
			{
				title.OnChanged();
				Vector2 runtimeAnchorMin = title.location.runtimeAnchorMin;
				Vector2 runtimeAnchorMax = title.location.runtimeAnchorMax;
				Vector2 runtimePivot = title.location.runtimePivot;
				GameObject gameObject = ChartHelper.AddObject(ChartCached.GetComponentObjectName(title), base.chart.transform, runtimeAnchorMin, runtimeAnchorMax, runtimePivot, base.chart.chartSizeDelta);
				title.gameObject = gameObject;
				title.gameObject.transform.SetSiblingIndex(base.chart.m_PainterUpper.transform.GetSiblingIndex() + 1);
				runtimeAnchorMin = title.location.runtimeAnchorMin;
				runtimeAnchorMax = title.location.runtimeAnchorMax;
				runtimePivot = title.location.runtimePivot;
				int fontSize = title.labelStyle.textStyle.GetFontSize(base.chart.theme.title);
				ChartHelper.UpdateRectTransform(gameObject, runtimeAnchorMin, runtimeAnchorMax, runtimePivot, new Vector2(base.chart.chartWidth, base.chart.chartHeight));
				Vector3 titlePosition = base.chart.GetTitlePosition(title);
				Vector3 vector = -new Vector3(0f, (float)fontSize + title.itemGap, 0f);
				gameObject.transform.localPosition = titlePosition;
				gameObject.hideFlags = base.chart.chartHideFlags;
				ChartHelper.HideAllObject(gameObject);
				m_LabelObject = ChartHelper.AddChartLabel(s_TitleObjectName, gameObject.transform, title.labelStyle, base.chart.theme.title, GetTitleText(title), Color.clear, title.location.runtimeTextAlignment);
				m_LabelObject.SetActive(title.show && title.labelStyle.show);
				m_SubLabelObject = ChartHelper.AddChartLabel(s_SubTitleObjectName, gameObject.transform, title.subLabelStyle, base.chart.theme.subTitle, GetSubTitleText(title), Color.clear, title.location.runtimeTextAlignment);
				m_SubLabelObject.SetActive(title.show && title.subLabelStyle.show);
				m_SubLabelObject.transform.localPosition = vector + title.subLabelStyle.offset;
			};
			title.refreshComponent();
		}

		public override void OnSerieDataUpdate(int serieIndex)
		{
			if (m_LabelObject != null && FormatterHelper.NeedFormat(base.component.text))
			{
				m_LabelObject.SetText(GetTitleText(base.component));
			}
			if (m_SubLabelObject != null && FormatterHelper.NeedFormat(base.component.subText))
			{
				m_SubLabelObject.SetText(GetSubTitleText(base.component));
			}
		}

		private string GetTitleText(Title title)
		{
			if (FormatterHelper.NeedFormat(title.text))
			{
				string content = title.text;
				FormatterHelper.ReplaceContent(ref content, 0, title.labelStyle.numericFormatter, null, base.chart);
				return content;
			}
			return title.text;
		}

		private string GetSubTitleText(Title title)
		{
			if (FormatterHelper.NeedFormat(title.subText))
			{
				string content = title.subText;
				FormatterHelper.ReplaceContent(ref content, 0, title.subLabelStyle.numericFormatter, null, base.chart);
				return content;
			}
			return title.subText;
		}
	}
}
