using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class LineStyle : ChildComponent, ISerieDataComponent
	{
		public enum Type
		{
			Solid = 0,
			Dashed = 1,
			Dotted = 2,
			DashDot = 3,
			DashDotDot = 4,
			None = 5
		}

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Type m_Type;

		[SerializeField]
		private Color32 m_Color;

		[SerializeField]
		private Color32 m_ToColor;

		[SerializeField]
		private Color32 m_ToColor2;

		[SerializeField]
		private float m_Width;

		[SerializeField]
		private float m_Length;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Opacity = 1f;

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

		public Type type
		{
			get
			{
				return m_Type;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Type, value))
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

		public float width
		{
			get
			{
				return m_Width;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Width, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float length
		{
			get
			{
				return m_Length;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Length, value))
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

		public LineStyle()
		{
		}

		public LineStyle(float width)
		{
			this.width = width;
		}

		public LineStyle(Type type)
		{
			this.type = type;
		}

		public LineStyle(Type type, float width)
		{
			this.type = type;
			this.width = width;
		}

		public LineStyle Clone()
		{
			return new LineStyle
			{
				show = show,
				type = type,
				color = color,
				toColor = toColor,
				toColor2 = toColor2,
				width = width,
				opacity = opacity
			};
		}

		public void Copy(LineStyle lineStyle)
		{
			show = lineStyle.show;
			type = lineStyle.type;
			color = lineStyle.color;
			toColor = lineStyle.toColor;
			toColor2 = lineStyle.toColor2;
			width = lineStyle.width;
			opacity = lineStyle.opacity;
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
			Color32 clearColor = ChartConst.clearColor32;
			if (!IsNeedGradient())
			{
				return clearColor;
			}
			value = Mathf.Clamp01(value);
			Color32 a = (ChartHelper.IsClearColor(m_Color) ? defaultColor : m_Color);
			clearColor = (ChartHelper.IsClearColor(m_ToColor2) ? Color32.Lerp(a, m_ToColor, value) : ((!(value <= 0.5f)) ? Color32.Lerp(m_ToColor, m_ToColor2, 2f * (value - 0.5f)) : Color32.Lerp(a, m_ToColor, 2f * value)));
			if (m_Opacity != 1f)
			{
				clearColor.a = (byte)((float)(int)clearColor.a * m_Opacity);
			}
			return clearColor;
		}

		public Type GetType(Type themeType)
		{
			if (type != Type.None)
			{
				return type;
			}
			return themeType;
		}

		public float GetWidth(float themeWidth)
		{
			if (width != 0f)
			{
				return width;
			}
			return themeWidth;
		}

		public float GetLength(float themeLength)
		{
			if (length != 0f)
			{
				return length;
			}
			return themeLength;
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
