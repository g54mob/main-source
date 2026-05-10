using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AreaStyle : ChildComponent, ISerieComponent, ISerieDataComponent
	{
		public enum AreaOrigin
		{
			Auto = 0,
			Start = 1,
			End = 2
		}

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private AreaOrigin m_Origin;

		[SerializeField]
		private Color32 m_Color;

		[SerializeField]
		private Color32 m_ToColor;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Opacity = 0.6f;

		[SerializeField]
		[Since("v3.2.0")]
		private bool m_InnerFill;

		[SerializeField]
		[Since("v3.6.0")]
		private bool m_ToTop = true;

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

		public AreaOrigin origin
		{
			get
			{
				return m_Origin;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Origin, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_Color, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 toColor
		{
			get
			{
				return m_ToColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_ToColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float opacity
		{
			get
			{
				return m_Opacity;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Opacity, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool innerFill
		{
			get
			{
				return m_InnerFill;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_InnerFill, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool toTop
		{
			get
			{
				return m_ToTop;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ToTop, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 GetColor()
		{
			if (m_Opacity == 1f)
			{
				return m_Color;
			}
			Color32 result = m_Color;
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetColor(Color32 themeColor)
		{
			if (!ChartHelper.IsClearColor(color))
			{
				return GetColor();
			}
			Color32 result = themeColor;
			result.a = (byte)((float)(int)result.a * opacity);
			return result;
		}
	}
}
