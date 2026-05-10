using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AxisSplitArea : ChildComponent
	{
		[SerializeField]
		private bool m_Show;

		[SerializeField]
		private List<Color32> m_Color;

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Show, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<Color32> color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (value != null)
				{
					m_Color = value;
					SetVerticesDirty();
				}
			}
		}

		public static AxisSplitArea defaultSplitArea => new AxisSplitArea
		{
			m_Show = false,
			m_Color = new List<Color32>()
		};

		public AxisSplitArea Clone()
		{
			AxisSplitArea obj = new AxisSplitArea
			{
				show = show,
				color = new List<Color32>()
			};
			ChartHelper.CopyList(obj.color, color);
			return obj;
		}

		public void Copy(AxisSplitArea splitArea)
		{
			show = splitArea.show;
			color.Clear();
			ChartHelper.CopyList(color, splitArea.color);
		}

		public Color32 GetColor(int index, BaseAxisTheme theme)
		{
			if (color.Count > 0)
			{
				int num = index % color.Count;
				return color[num];
			}
			int num2 = index % theme.splitAreaColors.Count;
			return theme.splitAreaColors[num2];
		}
	}
}
