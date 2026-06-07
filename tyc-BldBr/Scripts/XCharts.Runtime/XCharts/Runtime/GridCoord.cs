using System;
using System.Collections.Generic;
using UnityEngine;
using XUGL;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(GridCoordHandler), true)]
	public class GridCoord : CoordSystem, IUpdateRuntimeData, ISerieContainer
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		[Since("v3.8.0")]
		private int m_LayoutIndex = -1;

		[SerializeField]
		private float m_Left = 0.1f;

		[SerializeField]
		private float m_Right = 0.08f;

		[SerializeField]
		private float m_Top = 0.22f;

		[SerializeField]
		private float m_Bottom = 0.12f;

		[SerializeField]
		private Color32 m_BackgroundColor;

		[SerializeField]
		private bool m_ShowBorder;

		[SerializeField]
		private float m_BorderWidth;

		[SerializeField]
		private Color32 m_BorderColor;

		public GridCoordContext context = new GridCoordContext();

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

		public int layoutIndex
		{
			get
			{
				return m_LayoutIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LayoutIndex, value))
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

		public bool showBorder
		{
			get
			{
				return m_ShowBorder;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowBorder, value))
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

		public void UpdateRuntimeData(BaseChart chart)
		{
			float x = chart.chartX;
			float y = chart.chartY;
			float width = chart.chartWidth;
			float height = chart.chartHeight;
			if (layoutIndex >= 0)
			{
				GridLayout chartComponent = chart.GetChartComponent<GridLayout>(layoutIndex);
				if (chartComponent != null)
				{
					chartComponent.UpdateRuntimeData(chart);
					chartComponent.UpdateGridContext(base.index, ref x, ref y, ref width, ref height);
				}
			}
			float num = ((left <= 1f) ? (left * width) : left);
			float num2 = ((bottom <= 1f) ? (bottom * height) : bottom);
			float num3 = ((top <= 1f) ? (top * height) : top);
			float num4 = ((right <= 1f) ? (right * width) : right);
			context.x = x + num;
			context.y = y + num2;
			context.width = width - num - num4;
			context.height = height - num3 - num2;
			context.position = new Vector3(context.x, context.y);
			context.center = new Vector3(context.x + context.width / 2f, context.y + context.height / 2f);
		}

		public bool IsPointerEnter()
		{
			return context.isPointerEnter;
		}

		public bool Contains(Vector3 pos)
		{
			return Contains(pos.x, pos.y);
		}

		[Since("v3.7.0")]
		public bool Contains(Vector3 pos, bool isYAxis)
		{
			if (!isYAxis)
			{
				return ContainsX(pos.x);
			}
			return ContainsY(pos.y);
		}

		public bool Contains(float x, float y)
		{
			if (ContainsX(x))
			{
				return ContainsY(y);
			}
			return false;
		}

		[Since("v3.7.0")]
		public bool ContainsX(float x)
		{
			if (x >= context.x)
			{
				return x <= context.x + context.width;
			}
			return false;
		}

		[Since("v3.7.0")]
		public bool ContainsY(float y)
		{
			if (y >= context.y)
			{
				return y <= context.y + context.height;
			}
			return false;
		}

		[Since("v3.7.0")]
		public void Clamp(ref Vector3 pos)
		{
			ClampX(ref pos);
			ClampY(ref pos);
		}

		[Since("v3.7.0")]
		public void ClampX(ref Vector3 pos)
		{
			if (pos.x < context.x)
			{
				pos.x = context.x;
			}
			else if (pos.x > context.x + context.width)
			{
				pos.x = context.x + context.width;
			}
		}

		[Since("v3.7.0")]
		public void ClampY(ref Vector3 pos)
		{
			if (pos.y < context.y)
			{
				pos.y = context.y;
			}
			else if (pos.y > context.y + context.height)
			{
				pos.y = context.y + context.height;
			}
		}

		public bool BoundaryPoint(Vector3 sp, Vector3 ep, ref Vector3 point)
		{
			if (Contains(sp) && Contains(ep))
			{
				return false;
			}
			if (sp.x < context.x && ep.x < context.x)
			{
				return false;
			}
			if (sp.x > context.x + context.width && ep.x > context.x + context.width)
			{
				return false;
			}
			if (sp.y < context.y && ep.y < context.y)
			{
				return false;
			}
			if (sp.y > context.y + context.height && ep.y > context.y + context.height)
			{
				return false;
			}
			Vector3 p = new Vector3(context.x, context.y);
			Vector3 vector = new Vector3(context.x, context.y + context.height);
			Vector3 p2 = new Vector3(context.x + context.width, context.y + context.height);
			Vector3 vector2 = new Vector3(context.x + context.width, context.y);
			if (UGLHelper.GetIntersection(sp, ep, vector2, p2, ref point))
			{
				return true;
			}
			if (UGLHelper.GetIntersection(sp, ep, vector, p2, ref point))
			{
				return true;
			}
			if (UGLHelper.GetIntersection(sp, ep, p, vector2, ref point))
			{
				return true;
			}
			if (UGLHelper.GetIntersection(sp, ep, p, vector, ref point))
			{
				return true;
			}
			return false;
		}

		public bool BoundaryPoint(Vector3 sp, Vector3 ep, ref List<Vector3> point)
		{
			if (Contains(sp) && Contains(ep))
			{
				return false;
			}
			Vector3 p = new Vector3(context.x, context.y);
			Vector3 vector = new Vector3(context.x, context.y + context.height);
			Vector3 p2 = new Vector3(context.x + context.width, context.y + context.height);
			Vector3 vector2 = new Vector3(context.x + context.width, context.y);
			bool result = false;
			if (UGLHelper.GetIntersection(sp, ep, p, vector, ref point))
			{
				result = true;
			}
			if (UGLHelper.GetIntersection(sp, ep, vector, p2, ref point))
			{
				result = true;
			}
			if (UGLHelper.GetIntersection(sp, ep, p, vector2, ref point))
			{
				result = true;
			}
			if (UGLHelper.GetIntersection(sp, ep, vector2, p2, ref point))
			{
				result = true;
			}
			return result;
		}
	}
}
