using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class CommentHander : MainComponentHandler<Comment>
	{
		private static readonly string s_CommentObjectName = "comment";

		public override void InitComponent()
		{
			Comment comment = base.component;
			comment.OnChanged();
			comment.painter = null;
			comment.refreshComponent = delegate
			{
				GameObject gameObject = ChartHelper.AddObject(ChartCached.GetComponentObjectName(comment), base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				gameObject.SetActive(comment.show);
				gameObject.hideFlags = base.chart.chartHideFlags;
				ChartHelper.HideAllObject(gameObject);
				for (int i = 0; i < comment.items.Count; i++)
				{
					CommentItem commentItem = comment.items[i];
					LabelStyle labelStyle = comment.GetLabelStyle(i);
					Vector3 position = base.chart.chartPosition + commentItem.location.GetPosition(base.chart.chartWidth, base.chart.chartHeight);
					ChartLabel chartLabel = ChartHelper.AddChartLabel(s_CommentObjectName + i, gameObject.transform, labelStyle, base.chart.theme.common, GetContent(commentItem), Color.clear);
					chartLabel.SetActive(comment.show && commentItem.show);
					chartLabel.SetPosition(position);
					chartLabel.text.SetLocalPosition(labelStyle.offset);
				}
			};
			comment.refreshComponent();
		}

		private string GetContent(CommentItem item)
		{
			if (item.content.IndexOf("{") >= 0)
			{
				string content = item.content;
				FormatterHelper.ReplaceContent(ref content, 0, item.labelStyle.numericFormatter, null, base.chart);
				return content;
			}
			return item.content;
		}

		public override void DrawUpper(VertexHelper vh)
		{
			for (int i = 0; i < base.component.items.Count; i++)
			{
				CommentItem commentItem = base.component.items[i];
				CommentMarkStyle markStyle = base.component.GetMarkStyle(i);
				if (markStyle != null && markStyle.show)
				{
					Color32 color = (ChartHelper.IsClearColor(markStyle.lineStyle.color) ? base.chart.theme.axis.splitLineColor : markStyle.lineStyle.color);
					float borderWidth = ((markStyle.lineStyle.width == 0f) ? 1f : markStyle.lineStyle.width);
					UGL.DrawBorder(vh, commentItem.markRect, borderWidth, color);
				}
			}
		}
	}
}
