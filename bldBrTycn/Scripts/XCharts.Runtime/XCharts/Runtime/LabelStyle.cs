using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class LabelStyle : ChildComponent, ISerieComponent, ISerieDataComponent
	{
		public enum Position
		{
			Default = 0,
			Outside = 1,
			Inside = 2,
			Center = 3,
			Top = 4,
			Bottom = 5,
			Left = 6,
			Right = 7,
			Start = 8,
			Middle = 9,
			End = 10
		}

		[SerializeField]
		protected bool m_Show = true;

		[SerializeField]
		private Position m_Position;

		[SerializeField]
		protected bool m_AutoOffset;

		[SerializeField]
		protected Vector3 m_Offset;

		[SerializeField]
		protected float m_Rotate;

		[SerializeField]
		[Since("v3.6.0")]
		protected bool m_AutoRotate;

		[SerializeField]
		protected float m_Distance;

		[SerializeField]
		protected string m_Formatter;

		[SerializeField]
		protected string m_NumericFormatter = "";

		[SerializeField]
		protected float m_Width;

		[SerializeField]
		protected float m_Height;

		[SerializeField]
		protected IconStyle m_Icon = new IconStyle();

		[SerializeField]
		protected ImageStyle m_Background = new ImageStyle();

		[SerializeField]
		protected TextPadding m_TextPadding = new TextPadding();

		[SerializeField]
		protected TextStyle m_TextStyle = new TextStyle();

		protected LabelFormatterFunction m_FormatterFunction;

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
					SetAllDirty();
				}
			}
		}

		public Position position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Position, value))
				{
					SetAllDirty();
				}
			}
		}

		public string formatter
		{
			get
			{
				return m_Formatter;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Formatter, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Vector3 offset
		{
			get
			{
				return m_Offset;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Offset, value))
				{
					SetAllDirty();
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

		public bool autoRotate
		{
			get
			{
				return m_AutoRotate;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AutoRotate, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float distance
		{
			get
			{
				return m_Distance;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Distance, value))
				{
					SetAllDirty();
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
					SetComponentDirty();
				}
			}
		}

		public float height
		{
			get
			{
				return m_Height;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Height, value))
				{
					SetComponentDirty();
				}
			}
		}

		public TextPadding textPadding
		{
			get
			{
				return m_TextPadding;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_TextPadding, value))
				{
					SetComponentDirty();
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

		public bool autoOffset
		{
			get
			{
				return m_AutoOffset;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AutoOffset, value))
				{
					SetAllDirty();
				}
			}
		}

		public ImageStyle background
		{
			get
			{
				return m_Background;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Background, value))
				{
					SetAllDirty();
				}
			}
		}

		public IconStyle icon
		{
			get
			{
				return m_Icon;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Icon, value))
				{
					SetAllDirty();
				}
			}
		}

		public TextStyle textStyle
		{
			get
			{
				return m_TextStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_TextStyle, value))
				{
					SetAllDirty();
				}
			}
		}

		public LabelFormatterFunction formatterFunction
		{
			get
			{
				return m_FormatterFunction;
			}
			set
			{
				m_FormatterFunction = value;
			}
		}

		public void Reset()
		{
			m_Show = false;
			m_Position = Position.Default;
			m_Offset = Vector3.zero;
			m_Distance = 0f;
			m_Rotate = 0f;
			m_Width = 0f;
			m_Height = 0f;
			m_NumericFormatter = "";
			m_AutoOffset = false;
		}

		public bool IsInside()
		{
			if (m_Position != Position.Inside)
			{
				return m_Position == Position.Center;
			}
			return true;
		}

		public bool IsDefaultPosition(Position position)
		{
			if (m_Position != Position.Default)
			{
				return m_Position == position;
			}
			return true;
		}

		public bool IsAutoSize()
		{
			if (width == 0f)
			{
				return height == 0f;
			}
			return false;
		}

		public Vector3 GetOffset(float radius)
		{
			float actualValue = ChartHelper.GetActualValue(m_Offset.x, radius);
			float actualValue2 = ChartHelper.GetActualValue(m_Offset.y, radius);
			float actualValue3 = ChartHelper.GetActualValue(m_Offset.z, radius);
			return new Vector3(actualValue, actualValue2, actualValue3);
		}

		public Color GetColor(Color defaultColor)
		{
			if (ChartHelper.IsClearColor(textStyle.color))
			{
				if (!IsInside())
				{
					return defaultColor;
				}
				return Color.black;
			}
			return textStyle.color;
		}

		public virtual LabelStyle Clone()
		{
			LabelStyle labelStyle = new LabelStyle();
			labelStyle.m_Show = m_Show;
			labelStyle.m_Position = m_Position;
			labelStyle.m_Offset = m_Offset;
			labelStyle.m_Rotate = m_Rotate;
			labelStyle.m_Distance = m_Distance;
			labelStyle.m_Formatter = m_Formatter;
			labelStyle.m_Width = m_Width;
			labelStyle.m_Height = m_Height;
			labelStyle.m_NumericFormatter = m_NumericFormatter;
			labelStyle.m_AutoOffset = m_AutoOffset;
			labelStyle.m_Icon.Copy(m_Icon);
			labelStyle.m_Background.Copy(m_Background);
			labelStyle.m_TextPadding = m_TextPadding;
			labelStyle.m_TextStyle.Copy(m_TextStyle);
			return labelStyle;
		}

		public virtual void Copy(LabelStyle label)
		{
			m_Show = label.m_Show;
			m_Position = label.m_Position;
			m_Offset = label.m_Offset;
			m_Rotate = label.m_Rotate;
			m_Distance = label.m_Distance;
			m_Formatter = label.m_Formatter;
			m_Width = label.m_Width;
			m_Height = label.m_Height;
			m_NumericFormatter = label.m_NumericFormatter;
			m_AutoOffset = label.m_AutoOffset;
			m_Icon.Copy(label.m_Icon);
			m_Background.Copy(label.m_Background);
			m_TextPadding = label.m_TextPadding;
			m_TextStyle.Copy(label.m_TextStyle);
		}

		public virtual string GetFormatterContent(int labelIndex, string category)
		{
			if (string.IsNullOrEmpty(category))
			{
				return GetFormatterFunctionContent(labelIndex, category, category);
			}
			if (string.IsNullOrEmpty(m_Formatter))
			{
				return GetFormatterFunctionContent(labelIndex, category, category);
			}
			string content = m_Formatter;
			FormatterHelper.ReplaceAxisLabelContent(ref content, category);
			return GetFormatterFunctionContent(labelIndex, category, category);
		}

		public virtual string GetFormatterContent(int labelIndex, double value, double minValue, double maxValue, bool isLog = false)
		{
			string value2 = numericFormatter;
			if (value == 0.0)
			{
				value2 = "f0";
			}
			else if (string.IsNullOrEmpty(value2) && !isLog)
			{
				value2 = ((!(Math.Abs(maxValue) >= Math.Abs(minValue))) ? (MathUtil.IsInteger(minValue) ? "0.#" : ("f" + MathUtil.GetPrecision(minValue))) : (MathUtil.IsInteger(maxValue) ? "0.#" : ("f" + MathUtil.GetPrecision(maxValue))));
			}
			if (string.IsNullOrEmpty(m_Formatter))
			{
				if (isLog)
				{
					return GetFormatterFunctionContent(labelIndex, value, ChartCached.NumberToStr(value, value2));
				}
				if (minValue >= -1.0 && minValue <= 1.0 && maxValue >= -1.0 && maxValue <= 1.0)
				{
					int precision = MathUtil.GetPrecision(minValue);
					int precision2 = MathUtil.GetPrecision(maxValue);
					int precision3 = Mathf.Max(b: MathUtil.GetPrecision(value), a: Mathf.Max(precision, precision2));
					return GetFormatterFunctionContent(labelIndex, value, ChartCached.FloatToStr(value, value2, precision3));
				}
				return GetFormatterFunctionContent(labelIndex, value, ChartCached.NumberToStr(value, value2));
			}
			string content = m_Formatter;
			FormatterHelper.ReplaceAxisLabelContent(ref content, value2, value);
			return GetFormatterFunctionContent(labelIndex, value, content);
		}

		public string GetFormatterDateTime(int labelIndex, double value, double minValue, double maxValue)
		{
			DateTime dateTime = DateTimeUtil.GetDateTime((int)value);
			string empty = string.Empty;
			empty = ((!string.IsNullOrEmpty(numericFormatter) && !numericFormatter.Equals("f2")) ? dateTime.ToString(numericFormatter) : DateTimeUtil.GetDateTimeFormatString(dateTime, maxValue - minValue));
			if (!string.IsNullOrEmpty(m_Formatter))
			{
				string content = m_Formatter;
				FormatterHelper.ReplaceAxisLabelContent(ref content, empty);
				return GetFormatterFunctionContent(labelIndex, value, content);
			}
			return GetFormatterFunctionContent(labelIndex, value, empty);
		}

		protected string GetFormatterFunctionContent(int labelIndex, string category, string currentContent)
		{
			if (m_FormatterFunction != null)
			{
				return m_FormatterFunction(labelIndex, labelIndex, category, currentContent);
			}
			return currentContent;
		}

		protected string GetFormatterFunctionContent(int labelIndex, double value, string currentContent)
		{
			if (m_FormatterFunction != null)
			{
				return m_FormatterFunction(labelIndex, value, null, currentContent);
			}
			return currentContent;
		}
	}
}
