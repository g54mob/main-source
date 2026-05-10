using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class BaseLine : ChildComponent
	{
		[SerializeField]
		protected bool m_Show;

		[SerializeField]
		protected LineStyle m_LineStyle = new LineStyle();

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

		public LineStyle lineStyle
		{
			get
			{
				return m_LineStyle;
			}
			set
			{
				if (value != null)
				{
					m_LineStyle = value;
					SetVerticesDirty();
				}
			}
		}

		public static BaseLine defaultBaseLine => new BaseLine
		{
			m_Show = true,
			m_LineStyle = new LineStyle()
		};

		public BaseLine()
		{
			lineStyle = new LineStyle();
		}

		public BaseLine(bool show)
		{
			m_Show = show;
		}

		public void Copy(BaseLine axisLine)
		{
			show = axisLine.show;
			lineStyle.Copy(axisLine.lineStyle);
		}

		public LineStyle.Type GetType(LineStyle.Type themeType)
		{
			return lineStyle.GetType(themeType);
		}

		public float GetWidth(float themeWidth)
		{
			return lineStyle.GetWidth(themeWidth);
		}

		public float GetLength(float themeLength)
		{
			return lineStyle.GetLength(themeLength);
		}

		public Color32 GetColor(Color32 themeColor)
		{
			return lineStyle.GetColor(themeColor);
		}
	}
}
