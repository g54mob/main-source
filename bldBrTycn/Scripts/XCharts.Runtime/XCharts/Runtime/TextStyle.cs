using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class TextStyle : ChildComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Font m_Font;

		[SerializeField]
		private bool m_AutoWrap;

		[SerializeField]
		private bool m_AutoAlign = true;

		[SerializeField]
		private float m_Rotate;

		[SerializeField]
		private bool m_AutoColor;

		[SerializeField]
		private Color m_Color = Color.clear;

		[SerializeField]
		private int m_FontSize;

		[SerializeField]
		private FontStyle m_FontStyle;

		[SerializeField]
		private float m_LineSpacing = 1f;

		[SerializeField]
		private TextAnchor m_Alignment = TextAnchor.MiddleCenter;

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
					SetComponentDirty();
				}
			}
		}

		public float rotate
		{
			get
			{
				return m_Rotate;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Rotate, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool autoColor
		{
			get
			{
				return m_AutoColor;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AutoColor, value))
				{
					SetAllDirty();
				}
			}
		}

		public Color color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_Color, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Font font
		{
			get
			{
				return m_Font;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Font, value))
				{
					SetComponentDirty();
				}
			}
		}

		public int fontSize
		{
			get
			{
				return m_FontSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_FontSize, value))
				{
					SetComponentDirty();
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return m_FontStyle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_FontStyle, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float lineSpacing
		{
			get
			{
				return m_LineSpacing;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineSpacing, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool autoWrap
		{
			get
			{
				return m_AutoWrap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AutoWrap, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool autoAlign
		{
			get
			{
				return m_AutoAlign;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AutoAlign, value))
				{
					SetComponentDirty();
				}
			}
		}

		public TextAnchor alignment
		{
			get
			{
				return m_Alignment;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Alignment, value))
				{
					SetComponentDirty();
				}
			}
		}

		public TextStyle()
		{
		}

		public TextStyle(int fontSize)
		{
			this.fontSize = fontSize;
		}

		public TextStyle(int fontSize, FontStyle fontStyle)
		{
			this.fontSize = fontSize;
			this.fontStyle = fontStyle;
		}

		public TextStyle(int fontSize, FontStyle fontStyle, Color color)
		{
			this.fontSize = fontSize;
			this.fontStyle = fontStyle;
			this.color = color;
		}

		public TextStyle(int fontSize, FontStyle fontStyle, Color color, int rorate)
		{
			this.fontSize = fontSize;
			this.fontStyle = fontStyle;
			this.color = color;
			rotate = rotate;
		}

		public void Copy(TextStyle textStyle)
		{
			font = textStyle.font;
			rotate = textStyle.rotate;
			color = textStyle.color;
			fontSize = textStyle.fontSize;
			fontStyle = textStyle.fontStyle;
			lineSpacing = textStyle.lineSpacing;
			alignment = textStyle.alignment;
			autoWrap = textStyle.autoWrap;
			autoAlign = textStyle.autoAlign;
		}

		public void UpdateAlignmentByLocation(Location location)
		{
			m_Alignment = location.runtimeTextAlignment;
		}

		public Color GetColor(Color defaultColor)
		{
			if (ChartHelper.IsClearColor(color))
			{
				return defaultColor;
			}
			return color;
		}

		public int GetFontSize(ComponentTheme defaultTheme)
		{
			if (fontSize == 0)
			{
				return defaultTheme.fontSize;
			}
			return fontSize;
		}

		public TextAnchor GetAlignment(TextAnchor defaultAlignment)
		{
			if (!m_AutoAlign)
			{
				return alignment;
			}
			return defaultAlignment;
		}
	}
}
