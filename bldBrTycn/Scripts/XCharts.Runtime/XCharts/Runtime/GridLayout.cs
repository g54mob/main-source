using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.8.0")]
	[ComponentHandler(typeof(GridLayoutHandler), true)]
	public class GridLayout : MainComponent, IUpdateRuntimeData
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private float m_Left = 0.1f;

		[SerializeField]
		private float m_Right = 0.08f;

		[SerializeField]
		private float m_Top = 0.22f;

		[SerializeField]
		private float m_Bottom = 0.12f;

		[SerializeField]
		private int m_Row = 2;

		[SerializeField]
		private int m_Column = 2;

		[SerializeField]
		private Vector2 m_Spacing = Vector2.zero;

		[SerializeField]
		protected bool m_Inverse;

		public GridLayoutContext context = new GridLayoutContext();

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

		public int row
		{
			get
			{
				return m_Row;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Row, value))
				{
					SetAllDirty();
				}
			}
		}

		public int column
		{
			get
			{
				return m_Column;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Column, value))
				{
					SetAllDirty();
				}
			}
		}

		public Vector2 spacing
		{
			get
			{
				return m_Spacing;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Spacing, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool inverse
		{
			get
			{
				return m_Inverse;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Inverse, value))
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
			float num = ((left <= 1f) ? (left * chartWidth) : left);
			float num2 = ((bottom <= 1f) ? (bottom * chartHeight) : bottom);
			float num3 = ((top <= 1f) ? (top * chartHeight) : top);
			float num4 = ((right <= 1f) ? (right * chartWidth) : right);
			context.x = chartX + num;
			context.y = chartY + num2;
			context.width = chartWidth - num - num4;
			context.height = chartHeight - num3 - num2;
			context.eachWidth = (context.width - spacing.x * (float)(column - 1)) / (float)column;
			context.eachHeight = (context.height - spacing.y * (float)(row - 1)) / (float)row;
		}

		internal void UpdateGridContext(int index, ref float x, ref float y, ref float width, ref float height)
		{
			int num = index / m_Column;
			int num2 = index % m_Column;
			x = context.x + (float)num2 * (context.eachWidth + spacing.x);
			if (m_Inverse)
			{
				y = context.y + (float)num * (context.eachHeight + spacing.y);
			}
			else
			{
				y = context.y + context.height - (float)(num + 1) * context.eachHeight - (float)num * spacing.y;
			}
			width = context.eachWidth;
			height = context.eachHeight;
		}

		internal void UpdateGridContext(int index, ref Vector3 position, ref float width, ref float height)
		{
			float x = 0f;
			float y = 0f;
			UpdateGridContext(index, ref x, ref y, ref width, ref height);
			position = new Vector3(x, y);
		}
	}
}
