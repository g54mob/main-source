using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class SerieLabelPool
	{
		private static readonly Stack<GameObject> m_Stack = new Stack<GameObject>(200);

		private static Dictionary<int, bool> m_ReleaseDic = new Dictionary<int, bool>(1000);

		public static GameObject Get(string name, Transform parent, LabelStyle label, Color color, float iconWidth, float iconHeight, ThemeStyle theme)
		{
			GameObject gameObject;
			if (m_Stack.Count == 0 || !Application.isPlaying)
			{
				gameObject = CreateSerieLabel(name, parent, label, color, iconWidth, iconHeight, theme);
			}
			else
			{
				gameObject = m_Stack.Pop();
				if (gameObject == null)
				{
					gameObject = CreateSerieLabel(name, parent, label, color, iconWidth, iconHeight, theme);
				}
				m_ReleaseDic.Remove(gameObject.GetInstanceID());
				gameObject.name = name;
				gameObject.transform.SetParent(parent);
				ChartText chartText = new ChartText(gameObject);
				chartText.SetColor(color);
				chartText.SetFontAndSizeAndStyle(label.textStyle, theme.common);
				ChartHelper.SetActive(gameObject, active: true);
			}
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, label.rotate);
			return gameObject;
		}

		public static void Release(GameObject element)
		{
			if (!(element == null))
			{
				ChartHelper.SetActive(element, active: false);
				if (Application.isPlaying && !m_ReleaseDic.ContainsKey(element.GetInstanceID()))
				{
					m_Stack.Push(element);
					m_ReleaseDic.Add(element.GetInstanceID(), value: true);
				}
			}
		}

		public static void ReleaseAll(Transform parent)
		{
			int childCount = parent.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Release(parent.GetChild(i).gameObject);
			}
		}

		public static void ClearAll()
		{
			m_Stack.Clear();
			m_ReleaseDic.Clear();
		}

		private static GameObject CreateSerieLabel(string name, Transform parent, LabelStyle labelStyle, Color color, float iconWidth, float iconHeight, ThemeStyle theme)
		{
			ChartLabel chartLabel = ChartHelper.AddChartLabel(name, parent, labelStyle, theme.common, "", color);
			chartLabel.SetActive(labelStyle.show);
			return chartLabel.gameObject;
		}
	}
}
