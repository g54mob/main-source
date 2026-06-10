using System.Collections.Generic;
using System.Linq;
using NSEipix;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace NSMedieval.UI.Statistic
{
	[RequireComponent(typeof(UILineRenderer))]
	public class GraphView : UIView
	{
		private readonly List<ButtonLayoutItemView> nodes = new List<ButtonLayoutItemView>();

		private UILineRenderer lineRenderer;

		private void Awake()
		{
			lineRenderer = GetComponent<UILineRenderer>();
		}

		public void Toggle()
		{
			base.gameObject.SetActive(!base.gameObject.activeSelf);
		}

		public void CreateGraph(GraphData data, Vector2Int correctedMaxValues)
		{
			Rect rect = GetComponent<RectTransform>().rect;
			nodes.SetAllActive(active: false);
			List<RectTransform> list = new List<RectTransform>();
			int count = data.NodeValues.Count;
			for (int i = 0; i < count; i++)
			{
				float x = (float)i / (float)correctedMaxValues.x * rect.width;
				float y = data.NodeValues[i] / (float)correctedMaxValues.y * rect.height;
				list.Add(AddNode(new Vector2(x, y), new Vector2(i, data.NodeValues[i]), data.GraphColor, lineRenderer.GetComponent<LayoutGroupView>()));
			}
			lineRenderer.Points = list.Select((RectTransform node) => node.anchoredPosition).ToArray();
			lineRenderer.color = data.GraphColor;
		}

		private RectTransform AddNode(Vector2 coordinates, Vector2 values, Color color, LayoutGroupView parentGroup)
		{
			RectTransform component = nodes.GetNext(parentGroup).GetComponent<RectTransform>();
			component.name = $"node_{coordinates.x}-{coordinates.y}";
			Vector2 anchorMax = (component.anchorMin = Vector2.zero);
			component.anchorMax = anchorMax;
			component.anchoredPosition = coordinates;
			TooltipViewNew component2 = component.GetComponent<TooltipViewNew>();
			if (component2 != null)
			{
				component2.SetSingleLineTooltip(string.Format("{0} {1}: {2:F1}", base.Localize.GetText("general_day"), values.x, values.y));
			}
			component.GetComponent<Image>().color = color;
			return component;
		}
	}
}
