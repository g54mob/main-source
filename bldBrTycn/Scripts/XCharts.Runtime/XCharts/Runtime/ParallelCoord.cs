using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(ParallelCoordHandler), true)]
	public class ParallelCoord : CoordSystem, IUpdateRuntimeData, ISerieContainer
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		protected Orient m_Orient = Orient.Vertical;

		[SerializeField]
		private float m_Left = 0.1f;

		[SerializeField]
		private float m_Right = 0.08f;

		[SerializeField]
		private float m_Top = 0.22f;

		[SerializeField]
		private float m_Bottom = 0.12f;

		[SerializeField]
		private Color m_BackgroundColor;

		public ParallelCoordContext context = new ParallelCoordContext();

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

		public Color backgroundColor
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

		public bool IsPointerEnter()
		{
			return context.runtimeIsPointerEnter;
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
			context.x = chartX + context.left;
			context.y = chartY + context.bottom;
			context.width = chartWidth - context.left - context.right;
			context.height = chartHeight - context.top - context.bottom;
			context.position = new Vector3(context.x, context.y);
		}

		public bool Contains(Vector3 pos)
		{
			return Contains(pos.x, pos.y);
		}

		public bool Contains(float x, float y)
		{
			if (x < context.x - 1f || x > context.x + context.width + 1f || y < context.y - 1f || y > context.y + context.height + 1f)
			{
				return false;
			}
			return true;
		}
	}
}
