using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(SingleAxisHander), true)]
	public class SingleAxis : Axis, IUpdateRuntimeData
	{
		[SerializeField]
		protected Orient m_Orient;

		[SerializeField]
		private float m_Left = 0.1f;

		[SerializeField]
		private float m_Right = 0.1f;

		[SerializeField]
		private float m_Top;

		[SerializeField]
		private float m_Bottom = 0.2f;

		[SerializeField]
		private float m_Width;

		[SerializeField]
		private float m_Height = 50f;

		public Orient orient
		{
			get
			{
				return m_Orient;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Orient, value))
				{
					SetAllDirty();
				}
			}
		}

		public float left
		{
			get
			{
				return m_Left;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Left, value))
				{
					SetAllDirty();
				}
			}
		}

		public float right
		{
			get
			{
				return m_Right;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Right, value))
				{
					SetAllDirty();
				}
			}
		}

		public float top
		{
			get
			{
				return m_Top;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Top, value))
				{
					SetAllDirty();
				}
			}
		}

		public float bottom
		{
			get
			{
				return m_Bottom;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Bottom, value))
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
					SetAllDirty();
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
					SetAllDirty();
				}
			}
		}

		public void UpdateRuntimeData(BaseChart chart)
		{
			float chartX = chart.chartX;
			float chartY = chart.chartY;
			float chartWidth = chart.chartWidth;
			float chartHeight = chart.chartHeight;
			context.left = ((left <= 1f) ? (left * chartWidth) : left);
			context.bottom = ((bottom <= 1f) ? (bottom * chartHeight) : bottom);
			context.top = ((top <= 1f) ? (top * chartHeight) : top);
			context.right = ((right <= 1f) ? (right * chartWidth) : right);
			context.height = ((height <= 1f) ? (height * chartHeight) : height);
			if (m_Orient == Orient.Horizonal)
			{
				context.width = ((width == 0f) ? (chartWidth - context.left - context.right) : ((width <= 1f) ? (chartWidth * width) : width));
			}
			else
			{
				context.width = ((width == 0f) ? (chartHeight - context.top - context.bottom) : ((width <= 1f) ? (chartHeight * width) : width));
			}
			if (context.left != 0f && context.right == 0f)
			{
				context.x = chartX + context.left;
			}
			else if (context.left == 0f && context.right != 0f)
			{
				context.x = chartX + chartWidth - context.right - context.width;
			}
			else
			{
				context.x = chartX + context.left;
			}
			if (context.bottom != 0f && context.top == 0f)
			{
				context.y = chartY + context.bottom;
			}
			else if (context.bottom == 0f && context.top != 0f)
			{
				context.y = chartY + chartHeight - context.top - context.height;
			}
			else
			{
				context.y = chartY + context.bottom;
			}
			context.position = new Vector3(context.x, context.y);
		}

		public override void SetDefaultValue()
		{
			m_Show = true;
			m_Type = AxisType.Category;
			m_Min = 0.0;
			m_Max = 0.0;
			m_SplitNumber = 0;
			m_BoundaryGap = true;
			m_Position = AxisPosition.Bottom;
			m_Offset = 0f;
			m_Left = 0.1f;
			m_Right = 0.1f;
			m_Top = 0f;
			m_Bottom = 0.2f;
			m_Width = 0f;
			m_Height = 50f;
			m_Data = new List<string> { "x1", "x2", "x3", "x4", "x5" };
			m_Icons = new List<Sprite>(5);
			base.splitLine.show = false;
			base.splitLine.lineStyle.type = LineStyle.Type.None;
			base.axisLabel.textLimit.enable = true;
			base.axisTick.showStartTick = true;
			base.axisTick.showEndTick = true;
		}
	}
}
