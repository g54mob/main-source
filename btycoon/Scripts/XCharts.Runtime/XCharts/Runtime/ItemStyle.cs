using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class ItemStyle : ChildComponent, ISerieDataComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Color32 m_Color;

		[SerializeField]
		private Color32 m_Color0;

		[SerializeField]
		private Color32 m_ToColor;

		[SerializeField]
		private Color32 m_ToColor2;

		[SerializeField]
		[Since("v3.6.0")]
		private Color32 m_MarkColor;

		[SerializeField]
		private Color32 m_BackgroundColor;

		[SerializeField]
		private float m_BackgroundWidth;

		[SerializeField]
		private Color32 m_CenterColor;

		[SerializeField]
		private float m_CenterGap;

		[SerializeField]
		private float m_BorderWidth;

		[SerializeField]
		private float m_BorderGap;

		[SerializeField]
		private Color32 m_BorderColor;

		[SerializeField]
		private Color32 m_BorderColor0;

		[SerializeField]
		private Color32 m_BorderToColor;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Opacity = 1f;

		[SerializeField]
		private string m_ItemMarker;

		[SerializeField]
		private string m_ItemFormatter;

		[SerializeField]
		private string m_NumericFormatter = "";

		[SerializeField]
		private float[] m_CornerRadius = new float[4];

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

		public Color32 color0
		{
			get
			{
				return m_Color0;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_Color0, value))
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

		public Color32 toColor2
		{
			get
			{
				return m_ToColor2;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_ToColor2, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 markColor
		{
			get
			{
				return m_MarkColor;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MarkColor, value))
				{
					SetAllDirty();
				}
			}
		}

		public Color32 backgroundColor
		{
			get
			{
				return m_BackgroundColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BackgroundColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float backgroundWidth
		{
			get
			{
				return m_BackgroundWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BackgroundWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 centerColor
		{
			get
			{
				return m_CenterColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_CenterColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float centerGap
		{
			get
			{
				return m_CenterGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_CenterGap, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 borderColor
		{
			get
			{
				return m_BorderColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BorderColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 borderColor0
		{
			get
			{
				return m_BorderColor0;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BorderColor0, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 borderToColor
		{
			get
			{
				return m_BorderToColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BorderToColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float borderWidth
		{
			get
			{
				return m_BorderWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BorderWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float borderGap
		{
			get
			{
				return m_BorderGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BorderGap, value))
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

		public string itemFormatter
		{
			get
			{
				return m_ItemFormatter;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_ItemFormatter, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public string itemMarker
		{
			get
			{
				return m_ItemMarker;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_ItemMarker, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public string numericFormatter
		{
			get
			{
				return m_NumericFormatter;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_NumericFormatter, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float[] cornerRadius
		{
			get
			{
				return m_CornerRadius;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_CornerRadius, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public float runtimeBorderWidth
		{
			get
			{
				if (!NeedShowBorder())
				{
					return 0f;
				}
				return borderWidth;
			}
		}

		public void Reset()
		{
			m_Show = false;
			m_Color = Color.clear;
			m_Color0 = Color.clear;
			m_ToColor = Color.clear;
			m_ToColor2 = Color.clear;
			m_MarkColor = Color.clear;
			m_BackgroundColor = Color.clear;
			m_BackgroundWidth = 0f;
			m_CenterColor = Color.clear;
			m_CenterGap = 0f;
			m_BorderWidth = 0f;
			m_BorderGap = 0f;
			m_BorderColor = Color.clear;
			m_BorderColor0 = Color.clear;
			m_BorderToColor = Color.clear;
			m_Opacity = 1f;
			m_ItemFormatter = null;
			m_ItemMarker = null;
			m_NumericFormatter = "";
			if (m_CornerRadius == null)
			{
				m_CornerRadius = new float[4];
				return;
			}
			for (int i = 0; i < m_CornerRadius.Length; i++)
			{
				m_CornerRadius[i] = 0f;
			}
		}

		public bool NeedShowBorder()
		{
			if (borderWidth != 0f)
			{
				return !ChartHelper.IsClearColor(borderColor);
			}
			return false;
		}

		public Color32 GetColor()
		{
			if (m_Opacity == 1f || m_Color.a == 0)
			{
				return m_Color;
			}
			Color32 result = m_Color;
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetToColor()
		{
			if (m_Opacity == 1f || m_ToColor.a == 0)
			{
				return m_ToColor;
			}
			Color32 result = m_ToColor;
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetColor0()
		{
			if (m_Opacity == 1f || m_Color0.a == 0)
			{
				return m_Color0;
			}
			Color32 result = m_Color0;
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetColor(Color32 defaultColor)
		{
			Color32 result = (ChartHelper.IsClearColor(m_Color) ? defaultColor : m_Color);
			if (m_Opacity == 1f || result.a == 0)
			{
				return result;
			}
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetColor0(Color32 defaultColor)
		{
			Color32 result = (ChartHelper.IsClearColor(m_Color0) ? defaultColor : m_Color0);
			if (m_Opacity == 1f || result.a == 0)
			{
				return result;
			}
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetBorderColor(Color32 defaultColor)
		{
			Color32 result = (ChartHelper.IsClearColor(m_BorderColor) ? defaultColor : m_BorderColor);
			if (m_Opacity == 1f || result.a == 0)
			{
				return result;
			}
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public Color32 GetBorderColor0(Color32 defaultColor)
		{
			Color32 result = (ChartHelper.IsClearColor(m_BorderColor0) ? defaultColor : m_BorderColor0);
			if (m_Opacity == 1f || result.a == 0)
			{
				return result;
			}
			result.a = (byte)((float)(int)result.a * m_Opacity);
			return result;
		}

		public bool IsNeedGradient()
		{
			if (ChartHelper.IsClearColor(m_ToColor))
			{
				return !ChartHelper.IsClearColor(m_ToColor2);
			}
			return true;
		}

		public Color32 GetGradientColor(float value, Color32 defaultColor)
		{
			if (!IsNeedGradient())
			{
				return ChartConst.clearColor32;
			}
			value = Mathf.Clamp01(value);
			Color32 a = (ChartHelper.IsClearColor(m_Color) ? defaultColor : m_Color);
			Color32 result = (ChartHelper.IsClearColor(m_ToColor2) ? Color32.Lerp(a, m_ToColor, value) : ((!(value <= 0.5f)) ? Color32.Lerp(m_ToColor, m_ToColor2, 2f * (value - 0.5f)) : Color32.Lerp(a, m_ToColor, 2f * value)));
			if (m_Opacity != 1f)
			{
				result.a = (byte)((float)(int)result.a * m_Opacity);
			}
			return result;
		}

		public bool IsNeedCorner()
		{
			if (m_CornerRadius == null)
			{
				return false;
			}
			float[] array = m_CornerRadius;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0f)
				{
					return true;
				}
			}
			return false;
		}
	}
}
