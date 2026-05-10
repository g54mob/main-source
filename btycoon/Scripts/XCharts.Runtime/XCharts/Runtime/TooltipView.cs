using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public class TooltipView
	{
		private static Vector2 anchorMax = new Vector2(0f, 1f);

		private static Vector2 anchorMin = new Vector2(0f, 1f);

		private static Vector2 pivot = new Vector2(0f, 1f);

		private static Vector2 v2_0_05 = new Vector2(0f, 0.5f);

		public Tooltip tooltip;

		public ComponentTheme theme;

		public GameObject gameObject;

		public Transform transform;

		public Image background;

		public Outline border;

		public VerticalLayoutGroup layout;

		public ChartLabel title;

		private List<TooltipViewItem> m_Items = new List<TooltipViewItem>();

		private List<float> m_ColumnMaxWidth = new List<float>();

		private bool m_Active;

		private Vector3 m_TargetPos;

		private Vector3 m_CurrentVelocity;

		public void Update()
		{
			if (m_Active)
			{
				transform.localPosition = Vector3.SmoothDamp(transform.localPosition, m_TargetPos, ref m_CurrentVelocity, 0.08f);
			}
		}

		public Vector3 GetCurrentPos()
		{
			return transform.localPosition;
		}

		public Vector3 GetTargetPos()
		{
			return m_TargetPos;
		}

		public void UpdatePosition(Vector3 pos)
		{
			m_TargetPos = pos;
		}

		public void SetActive(bool flag)
		{
			m_Active = flag && tooltip.showContent;
			ChartHelper.SetActive(gameObject, m_Active);
			if (flag)
			{
				return;
			}
			foreach (TooltipViewItem item in m_Items)
			{
				item.gameObject.SetActive(value: false);
			}
		}

		public void Refresh()
		{
			if (tooltip == null)
			{
				return;
			}
			TooltipData data = tooltip.context.data;
			bool flag = string.IsNullOrEmpty(tooltip.ignoreDataDefaultContent);
			bool active = !string.IsNullOrEmpty(data.title);
			ChartHelper.SetActive(title, active);
			title.SetText(data.title);
			m_ColumnMaxWidth.Clear();
			for (int i = 0; i < data.param.Count; i++)
			{
				TooltipViewItem item = GetItem(i);
				SerieParams serieParams = data.param[i];
				if (serieParams.columns.Count <= 0 || (flag && serieParams.ignore))
				{
					item.gameObject.SetActive(value: false);
					continue;
				}
				item.gameObject.SetActive(value: true);
				for (int j = 0; j < serieParams.columns.Count; j++)
				{
					ChartLabel itemColumn = GetItemColumn(item, j);
					itemColumn.SetActive(flag: true);
					itemColumn.SetText(serieParams.columns[j]);
					if (j == 0)
					{
						itemColumn.text.SetColor(serieParams.color);
					}
					if (j >= m_ColumnMaxWidth.Count)
					{
						m_ColumnMaxWidth.Add(0f);
					}
					float width = itemColumn.GetWidth();
					if (m_ColumnMaxWidth[j] < width)
					{
						m_ColumnMaxWidth[j] = width;
					}
				}
				for (int k = serieParams.columns.Count; k < item.columns.Count; k++)
				{
					item.columns[k].SetActive(flag: false);
				}
			}
			for (int l = data.param.Count; l < m_Items.Count; l++)
			{
				m_Items[l].gameObject.SetActive(value: false);
			}
			ResetSize();
			UpdatePosition(tooltip.context.pointer + tooltip.offset);
			tooltip.gameObject.transform.SetAsLastSibling();
		}

		private void ResetSize()
		{
			float num = 0f;
			float num2 = 0f;
			if (tooltip.fixedWidth > 0f)
			{
				num2 = tooltip.fixedWidth;
			}
			else
			{
				num2 = TotalMaxWidth();
				float textWidth = title.GetTextWidth();
				if (num2 < textWidth)
				{
					num2 = textWidth;
				}
			}
			if (tooltip.fixedHeight > 0f)
			{
				num = tooltip.fixedHeight;
			}
			else
			{
				if (!string.IsNullOrEmpty(title.text.GetText()))
				{
					num += tooltip.titleHeight;
				}
				num += tooltip.itemHeight * (float)tooltip.context.data.param.Count;
				num += (float)(tooltip.paddingTopBottom * 2);
			}
			if (tooltip.minWidth > 0f && num2 < tooltip.minWidth)
			{
				num2 = tooltip.minWidth;
			}
			if (tooltip.minHeight > 0f && num < tooltip.minHeight)
			{
				num = tooltip.minHeight;
			}
			for (int i = 0; i < m_Items.Count; i++)
			{
				TooltipViewItem tooltipViewItem = m_Items[i];
				tooltipViewItem.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(num2, tooltip.itemHeight);
				float num3 = 0f;
				for (int j = 0; j < m_ColumnMaxWidth.Count; j++)
				{
					float x = ((j == m_ColumnMaxWidth.Count - 1) ? (num2 - num3) : m_ColumnMaxWidth[j]);
					tooltipViewItem.columns[j].text.SetSizeDelta(new Vector2(x, tooltip.itemHeight));
					tooltipViewItem.columns[j].SetRectPosition(new Vector3(num3, 0f));
					num3 += m_ColumnMaxWidth[j];
				}
			}
			tooltip.context.width = num2 + (float)(tooltip.paddingLeftRight * 2);
			tooltip.context.height = num;
			background.GetComponent<RectTransform>().sizeDelta = new Vector2(tooltip.context.width, tooltip.context.height);
		}

		private float TotalMaxWidth()
		{
			float num = 0f;
			foreach (float item in m_ColumnMaxWidth)
			{
				num += item;
			}
			return num;
		}

		private TooltipViewItem GetItem(int i)
		{
			if (i < 0)
			{
				i = 0;
			}
			if (i < m_Items.Count)
			{
				return m_Items[i];
			}
			TooltipViewItem tooltipViewItem = CreateViewItem(i, gameObject.transform, tooltip, theme);
			m_Items.Add(tooltipViewItem);
			return tooltipViewItem;
		}

		private ChartLabel GetItemColumn(TooltipViewItem item, int i)
		{
			if (i < 0)
			{
				i = 0;
			}
			if (i < item.columns.Count)
			{
				return item.columns[i];
			}
			ChartLabel chartLabel = CreateViewItemColumn(i, item.gameObject.transform, tooltip, theme);
			item.columns.Add(chartLabel);
			return chartLabel;
		}

		public static TooltipView CreateView(Tooltip tooltip, ThemeStyle theme, Transform parent)
		{
			TooltipView tooltipView = new TooltipView();
			tooltipView.tooltip = tooltip;
			tooltipView.theme = theme.tooltip;
			tooltipView.gameObject = ChartHelper.AddObject("view", parent, anchorMin, anchorMax, pivot, Vector3.zero);
			tooltipView.gameObject.transform.localPosition = Vector3.zero;
			tooltipView.transform = tooltipView.gameObject.transform;
			tooltipView.background = ChartHelper.EnsureComponent<Image>(tooltipView.gameObject);
			tooltipView.background.sprite = tooltip.backgroundImage;
			tooltipView.background.type = tooltip.backgroundType;
			tooltipView.background.color = (ChartHelper.IsClearColor(tooltip.backgroundColor) ? Color.white : tooltip.backgroundColor);
			tooltipView.border = ChartHelper.EnsureComponent<Outline>(tooltipView.gameObject);
			tooltipView.border.enabled = tooltip.borderWidth > 0f;
			tooltipView.border.useGraphicAlpha = false;
			tooltipView.border.effectColor = tooltip.borderColor;
			tooltipView.border.effectDistance = new Vector2(tooltip.borderWidth, 0f - tooltip.borderWidth);
			tooltipView.layout = ChartHelper.EnsureComponent<VerticalLayoutGroup>(tooltipView.gameObject);
			tooltipView.layout.childControlHeight = false;
			tooltipView.layout.childControlWidth = false;
			tooltipView.layout.childForceExpandHeight = false;
			tooltipView.layout.childForceExpandWidth = false;
			tooltipView.layout.padding = new RectOffset(tooltip.paddingLeftRight, tooltip.paddingLeftRight, tooltip.paddingTopBottom, tooltip.paddingTopBottom);
			tooltipView.title = ChartHelper.AddChartLabel("title", tooltipView.gameObject.transform, tooltip.titleLabelStyle, theme.tooltip, "", Color.clear, TextAnchor.MiddleLeft);
			TooltipViewItem item = CreateViewItem(0, tooltipView.gameObject.transform, tooltip, theme.tooltip);
			tooltipView.m_Items.Add(item);
			tooltipView.Refresh();
			return tooltipView;
		}

		private static TooltipViewItem CreateViewItem(int i, Transform parent, Tooltip tooltip, ComponentTheme theme)
		{
			GameObject gameObject = ChartHelper.AddObject("item" + i, parent, anchorMin, anchorMax, v2_0_05, Vector3.zero);
			return new TooltipViewItem
			{
				gameObject = gameObject,
				columns = 
				{
					CreateViewItemColumn(0, gameObject.transform, tooltip, theme),
					CreateViewItemColumn(1, gameObject.transform, tooltip, theme),
					CreateViewItemColumn(2, gameObject.transform, tooltip, theme)
				}
			};
		}

		private static ChartLabel CreateViewItemColumn(int i, Transform parent, Tooltip tooltip, ComponentTheme theme)
		{
			LabelStyle contentLabelStyle = tooltip.GetContentLabelStyle(i);
			return ChartHelper.AddChartLabel("column" + i, parent, contentLabelStyle, theme, "", Color.clear, TextAnchor.MiddleLeft);
		}
	}
}
