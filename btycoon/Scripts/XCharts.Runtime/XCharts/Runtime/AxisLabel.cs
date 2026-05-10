using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AxisLabel : LabelStyle
	{
		[SerializeField]
		private int m_Interval;

		[SerializeField]
		private bool m_Inside;

		[SerializeField]
		private bool m_ShowAsPositiveNumber;

		[SerializeField]
		private bool m_OnZero;

		[SerializeField]
		private bool m_ShowStartLabel = true;

		[SerializeField]
		private bool m_ShowEndLabel = true;

		[SerializeField]
		private TextLimit m_TextLimit = new TextLimit();

		public int interval
		{
			get
			{
				return m_Interval;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Interval, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool inside
		{
			get
			{
				return m_Inside;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Inside, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool showAsPositiveNumber
		{
			get
			{
				return m_ShowAsPositiveNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowAsPositiveNumber, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool onZero
		{
			get
			{
				return m_OnZero;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_OnZero, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool showStartLabel
		{
			get
			{
				return m_ShowStartLabel;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowStartLabel, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool showEndLabel
		{
			get
			{
				return m_ShowEndLabel;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowEndLabel, value))
				{
					SetComponentDirty();
				}
			}
		}

		public TextLimit textLimit
		{
			get
			{
				return m_TextLimit;
			}
			set
			{
				if (value != null)
				{
					m_TextLimit = value;
					SetComponentDirty();
				}
			}
		}

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty)
				{
					return m_TextLimit.componentDirty;
				}
				return true;
			}
		}

		public static AxisLabel defaultAxisLabel => new AxisLabel
		{
			m_Show = true,
			m_Interval = 0,
			m_Inside = false,
			m_Distance = 8f,
			m_TextStyle = new TextStyle()
		};

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			textLimit.ClearComponentDirty();
		}

		public new AxisLabel Clone()
		{
			AxisLabel axisLabel = new AxisLabel();
			axisLabel.show = base.show;
			axisLabel.formatter = base.formatter;
			axisLabel.interval = interval;
			axisLabel.inside = inside;
			axisLabel.distance = base.distance;
			axisLabel.numericFormatter = base.numericFormatter;
			axisLabel.width = base.width;
			axisLabel.height = base.height;
			axisLabel.showStartLabel = showStartLabel;
			axisLabel.showEndLabel = showEndLabel;
			axisLabel.textLimit = textLimit.Clone();
			axisLabel.textStyle.Copy(base.textStyle);
			return axisLabel;
		}

		public void Copy(AxisLabel axisLabel)
		{
			base.show = axisLabel.show;
			base.formatter = axisLabel.formatter;
			interval = axisLabel.interval;
			inside = axisLabel.inside;
			base.distance = axisLabel.distance;
			base.numericFormatter = axisLabel.numericFormatter;
			base.width = axisLabel.width;
			base.height = axisLabel.height;
			showStartLabel = axisLabel.showStartLabel;
			showEndLabel = axisLabel.showEndLabel;
			textLimit.Copy(axisLabel.textLimit);
			base.textStyle.Copy(axisLabel.textStyle);
		}

		public void SetRelatedText(ChartText txt, float labelWidth)
		{
			m_TextLimit.SetRelatedText(txt, labelWidth);
		}

		public override string GetFormatterContent(int labelIndex, string category)
		{
			if (string.IsNullOrEmpty(category))
			{
				return GetFormatterFunctionContent(labelIndex, category, category);
			}
			if (string.IsNullOrEmpty(m_Formatter))
			{
				return GetFormatterFunctionContent(labelIndex, category, m_TextLimit.GetLimitContent(category));
			}
			string content = m_Formatter;
			FormatterHelper.ReplaceAxisLabelContent(ref content, category);
			return GetFormatterFunctionContent(labelIndex, category, m_TextLimit.GetLimitContent(content));
		}

		public override string GetFormatterContent(int labelIndex, double value, double minValue, double maxValue, bool isLog = false)
		{
			if (showAsPositiveNumber && value < 0.0)
			{
				value = Math.Abs(value);
			}
			return base.GetFormatterContent(labelIndex, value, minValue, maxValue, isLog);
		}

		public bool IsNeedShowLabel(int index, int total)
		{
			bool flag = base.show && (interval == 0 || index % (interval + 1) == 0);
			if (flag)
			{
				if (!showStartLabel && index == 0)
				{
					flag = false;
				}
				else if (!showEndLabel && index == total - 1)
				{
					flag = false;
				}
			}
			return flag;
		}
	}
}
