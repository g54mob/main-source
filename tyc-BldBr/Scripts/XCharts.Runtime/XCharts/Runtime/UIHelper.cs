using UnityEngine;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	public static class UIHelper
	{
		internal static void DrawBackground(VertexHelper vh, UIComponent component)
		{
			if (!component.background.show || (component.background.sprite == null && ChartHelper.IsClearColor(component.background.color)))
			{
				Vector3 p = new Vector3(component.graphX, component.graphY);
				Vector3 p2 = new Vector3(component.graphX + component.graphWidth, component.graphY);
				Vector3 p3 = new Vector3(component.graphX + component.graphWidth, component.graphY + component.graphHeight);
				Vector3 p4 = new Vector3(component.graphX, component.graphY + component.graphHeight);
				UGL.DrawQuadrilateral(vh, p, p2, p3, p4, GetBackgroundColor(component));
			}
		}

		internal static void InitBackground(UIComponent table)
		{
			if (!table.background.show || (table.background.sprite == null && ChartHelper.IsClearColor(table.background.color)))
			{
				ChartHelper.DestoryGameObject(table.transform, "Background");
				return;
			}
			Vector2 sizeDelta = ((table.background.width > 0f && table.background.height > 0f) ? new Vector2(table.background.width, table.background.height) : table.graphSizeDelta);
			GameObject gameObject = ChartHelper.AddObject("Background", table.transform, table.graphMinAnchor, table.graphMaxAnchor, table.graphPivot, sizeDelta);
			gameObject.hideFlags = table.chartHideFlags;
			Image background = ChartHelper.EnsureComponent<Image>(gameObject);
			ChartHelper.UpdateRectTransform(gameObject, table.graphMinAnchor, table.graphMaxAnchor, table.graphPivot, sizeDelta);
			ChartHelper.SetBackground(background, table.background);
			gameObject.transform.SetSiblingIndex(0);
		}

		public static Color32 GetBackgroundColor(UIComponent component)
		{
			if (component.background.show && !ChartHelper.IsClearColor(component.background.color))
			{
				return component.background.color;
			}
			return component.theme.backgroundColor;
		}
	}
}
