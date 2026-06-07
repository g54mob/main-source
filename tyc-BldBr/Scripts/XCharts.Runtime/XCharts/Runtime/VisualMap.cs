using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(VisualMapHandler), true)]
	public class VisualMap : MainComponent
	{
		public enum Type
		{
			Continuous = 0,
			Piecewise = 1
		}

		public enum SelectedMode
		{
			Multiple = 0,
			Single = 1
		}

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private bool m_ShowUI;

		[SerializeField]
		private Type m_Type;

		[SerializeField]
		private SelectedMode m_SelectedMode;

		[SerializeField]
		private int m_SerieIndex;

		[SerializeField]
		private double m_Min;

		[SerializeField]
		private double m_Max;

		[SerializeField]
		private double[] m_Range = new double[2];

		[SerializeField]
		private string[] m_Text = new string[2] { "", "" };

		[SerializeField]
		private float[] m_TextGap = new float[2] { 10f, 10f };

		[SerializeField]
		private int m_SplitNumber = 5;

		[SerializeField]
		private bool m_Calculable;

		[SerializeField]
		private bool m_Realtime = true;

		[SerializeField]
		private float m_ItemWidth = 20f;

		[SerializeField]
		private float m_ItemHeight = 140f;

		[SerializeField]
		private float m_ItemGap = 10f;

		[SerializeField]
		private float m_BorderWidth;

		[SerializeField]
		private int m_Dimension = -1;

		[SerializeField]
		private bool m_HoverLink = true;

		[SerializeField]
		private bool m_AutoMinMax = true;

		[SerializeField]
		private Orient m_Orient;

		[SerializeField]
		private Location m_Location = Location.defaultLeft;

		[SerializeField]
		private bool m_WorkOnLine = true;

		[SerializeField]
		private bool m_WorkOnArea;

		[SerializeField]
		private List<VisualMapRange> m_OutOfRange = new List<VisualMapRange>
		{
			new VisualMapRange
			{
				color = Color.gray
			}
		};

		[SerializeField]
		private List<VisualMapRange> m_InRange = new List<VisualMapRange>();

		public VisualMapContext context = new VisualMapContext();

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

		public bool showUI
		{
			get
			{
				return m_ShowUI;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowUI, value))
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

		public SelectedMode selectedMode
		{
			get
			{
				return m_SelectedMode;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SelectedMode, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int serieIndex
		{
			get
			{
				return m_SerieIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SerieIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public double min
		{
			get
			{
				return m_Min;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Min, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public double max
		{
			get
			{
				return m_Max;
			}
			set
			{
				m_Max = ((value < min) ? (min + 1.0) : value);
				SetVerticesDirty();
			}
		}

		public double[] range => m_Range;

		public string[] text => m_Text;

		public float[] textGap => m_TextGap;

		public int splitNumber
		{
			get
			{
				return m_SplitNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitNumber, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool calculable
		{
			get
			{
				return m_Calculable;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Calculable, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool realtime
		{
			get
			{
				return m_Realtime;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Realtime, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float itemWidth
		{
			get
			{
				return m_ItemWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float itemHeight
		{
			get
			{
				return m_ItemHeight;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemHeight, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float itemGap
		{
			get
			{
				return m_ItemGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ItemGap, value))
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

		public int dimension
		{
			get
			{
				return m_Dimension;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Dimension, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool hoverLink
		{
			get
			{
				return m_HoverLink;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_HoverLink, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool autoMinMax
		{
			get
			{
				return m_AutoMinMax;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AutoMinMax, value))
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
					SetVerticesDirty();
				}
			}
		}

		public Location location
		{
			get
			{
				return m_Location;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Location, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool workOnLine
		{
			get
			{
				return m_WorkOnLine;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_WorkOnLine, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool workOnArea
		{
			get
			{
				return m_WorkOnArea;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_WorkOnArea, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<VisualMapRange> outOfRange
		{
			get
			{
				return m_OutOfRange;
			}
			set
			{
				if (value != null)
				{
					m_OutOfRange = value;
					SetVerticesDirty();
				}
			}
		}

		public List<VisualMapRange> inRange
		{
			get
			{
				return m_InRange;
			}
			set
			{
				if (value != null)
				{
					m_InRange = value;
					SetVerticesDirty();
				}
			}
		}

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty)
				{
					return location.anyDirty;
				}
				return true;
			}
		}

		public double rangeMin
		{
			get
			{
				if (m_Range[0] == 0.0 && m_Range[1] == 0.0)
				{
					return min;
				}
				if (m_Range[0] < min || m_Range[0] > max)
				{
					return min;
				}
				return m_Range[0];
			}
			set
			{
				if (value >= min && value <= m_Range[1])
				{
					m_Range[0] = value;
				}
			}
		}

		public double rangeMax
		{
			get
			{
				if (m_Range[0] == 0.0 && m_Range[1] == 0.0)
				{
					return max;
				}
				if (m_Range[1] >= m_Range[0] && m_Range[1] < max)
				{
					return m_Range[1];
				}
				return max;
			}
			set
			{
				if (value >= m_Range[0] && value <= max)
				{
					m_Range[1] = value;
				}
			}
		}

		public float runtimeRangeMinHeight => (float)((rangeMin - min) / (max - min) * (double)itemHeight);

		public float runtimeRangeMaxHeight => (float)((rangeMax - min) / (max - min) * (double)itemHeight);

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			location.ClearVerticesDirty();
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			location.ClearComponentDirty();
		}

		public void AddColors(List<Color32> colors)
		{
			m_InRange.Clear();
			foreach (Color32 color in colors)
			{
				m_InRange.Add(new VisualMapRange
				{
					color = color
				});
			}
		}

		public void AddColors(List<string> colors)
		{
			m_InRange.Clear();
			foreach (string color in colors)
			{
				m_InRange.Add(new VisualMapRange
				{
					color = ThemeStyle.GetColor(color)
				});
			}
		}

		public Color32 GetColor(double value)
		{
			int num = GetIndex(value);
			if (num == -1)
			{
				if (m_OutOfRange.Count > 0)
				{
					return m_OutOfRange[0].color;
				}
				return ChartConst.clearColor32;
			}
			if (m_Type == Type.Piecewise)
			{
				return m_InRange[num].color;
			}
			int count = m_InRange.Count;
			double num2 = (m_Max - m_Min) / (double)(count - 1);
			double num3 = m_Min + (double)num * num2;
			double num4 = (value - num3) / num2;
			if (num == count - 1)
			{
				return m_InRange[num].color;
			}
			return Color32.Lerp(m_InRange[num].color, m_InRange[num + 1].color, (float)num4);
		}

		private bool IsNeedPieceColor(double value, out int index)
		{
			bool result = false;
			index = -1;
			for (int i = 0; i < m_InRange.Count; i++)
			{
				VisualMapRange visualMapRange = m_InRange[i];
				if (visualMapRange.min != 0.0 || visualMapRange.max != 0.0)
				{
					result = true;
					if (visualMapRange.Contains(value, max - min))
					{
						index = i;
						return true;
					}
				}
			}
			return result;
		}

		private Color32 GetPiecesColor(double value)
		{
			foreach (VisualMapRange item in m_InRange)
			{
				if (item.Contains(value, max - min))
				{
					return item.color;
				}
			}
			if (m_OutOfRange.Count > 0)
			{
				return m_OutOfRange[0].color;
			}
			return ChartConst.clearColor32;
		}

		public int GetIndex(double value)
		{
			int count = m_InRange.Count;
			if (count <= 0)
			{
				return -1;
			}
			int result = -1;
			if (IsNeedPieceColor(value, out result))
			{
				return result;
			}
			value = MathUtil.Clamp(value, m_Min, m_Max);
			double num = (m_Max - m_Min) / (double)(count - 1);
			for (int i = 0; i < count; i++)
			{
				if (value <= m_Min + (double)(i + 1) * num)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public bool IsPiecewise()
		{
			return m_Type == Type.Piecewise;
		}

		public bool IsInSelectedValue(double value)
		{
			if (context.pointerIndex < 0)
			{
				return true;
			}
			return context.pointerIndex == GetIndex(value);
		}

		public double GetValue(Vector3 pos, Rect chartRect)
		{
			bool flag = orient == Orient.Vertical;
			Vector3 vector = new Vector3(chartRect.x, chartRect.y) + location.GetPosition(chartRect.width, chartRect.height);
			Vector3 vector2 = vector + (flag ? Vector3.down : Vector3.left) * itemHeight / 2f;
			Vector3 vector3 = vector + (flag ? Vector3.up : Vector3.right) * itemHeight / 2f;
			if (flag)
			{
				if (pos.y < vector2.y)
				{
					return min;
				}
				if (pos.y > vector3.y)
				{
					return max;
				}
				return min + (double)((pos.y - vector2.y) / (vector3.y - vector2.y)) * (max - min);
			}
			if (pos.x < vector2.x)
			{
				return min;
			}
			if (pos.x > vector3.x)
			{
				return max;
			}
			return min + (double)((pos.x - vector2.x) / (vector3.x - vector2.x)) * (max - min);
		}

		public bool IsInRect(Vector3 local, Rect chartRect, float triangleLen = 20f)
		{
			Vector3 vector = new Vector3(chartRect.x, chartRect.y) + location.GetPosition(chartRect.width, chartRect.height);
			float num = (calculable ? triangleLen : 0f);
			if (local.x >= vector.x - itemWidth / 2f - num && local.x <= vector.x + itemWidth / 2f + num && local.y >= vector.y - itemHeight / 2f - num && local.y <= vector.y + itemHeight / 2f + num)
			{
				return true;
			}
			return false;
		}

		public bool IsInRangeRect(Vector3 local, Rect chartRect)
		{
			Vector3 vector = new Vector3(chartRect.x, chartRect.y) + location.GetPosition(chartRect.width, chartRect.height);
			if (orient == Orient.Vertical)
			{
				Vector3 vector2 = vector + Vector3.down * itemHeight / 2f;
				if (local.x >= vector.x - itemWidth / 2f && local.x <= vector.x + itemWidth / 2f && local.y >= vector2.y + runtimeRangeMinHeight)
				{
					return local.y <= vector2.y + runtimeRangeMaxHeight;
				}
				return false;
			}
			Vector3 vector3 = vector + Vector3.left * itemHeight / 2f;
			if (local.x >= vector3.x + runtimeRangeMinHeight && local.x <= vector3.x + runtimeRangeMaxHeight && local.y >= vector.y - itemWidth / 2f)
			{
				return local.y <= vector.y + itemWidth / 2f;
			}
			return false;
		}

		public bool IsInRangeMinRect(Vector3 local, Rect chartRect, float triangleLen)
		{
			Vector3 vector = new Vector3(chartRect.x, chartRect.y) + location.GetPosition(chartRect.width, chartRect.height);
			if (orient == Orient.Vertical)
			{
				float num = triangleLen / 2f;
				Vector3 vector2 = vector + Vector3.down * itemHeight / 2f;
				Vector3 vector3 = new Vector3(vector2.x + itemWidth / 2f + num, vector2.y + runtimeRangeMinHeight - num);
				if (local.x >= vector3.x - num && local.x <= vector3.x + num && local.y >= vector3.y - num)
				{
					return local.y <= vector3.y + num;
				}
				return false;
			}
			float num2 = triangleLen / 2f;
			Vector3 vector4 = vector + Vector3.left * itemHeight / 2f;
			Vector3 vector5 = new Vector3(vector4.x + runtimeRangeMinHeight, vector4.y + itemWidth / 2f + num2);
			if (local.x >= vector5.x - num2 && local.x <= vector5.x + num2 && local.y >= vector5.y - num2)
			{
				return local.y <= vector5.y + num2;
			}
			return false;
		}

		public bool IsInRangeMaxRect(Vector3 local, Rect chartRect, float triangleLen)
		{
			Vector3 vector = new Vector3(chartRect.x, chartRect.y) + location.GetPosition(chartRect.width, chartRect.height);
			if (orient == Orient.Vertical)
			{
				float num = triangleLen / 2f;
				Vector3 vector2 = vector + Vector3.down * itemHeight / 2f;
				Vector3 vector3 = new Vector3(vector2.x + itemWidth / 2f + num, vector2.y + runtimeRangeMaxHeight + num);
				if (local.x >= vector3.x - num && local.x <= vector3.x + num && local.y >= vector3.y - num)
				{
					return local.y <= vector3.y + num;
				}
				return false;
			}
			float num2 = triangleLen / 2f;
			Vector3 vector4 = vector + Vector3.left * itemHeight / 2f;
			Vector3 vector5 = new Vector3(vector4.x + runtimeRangeMaxHeight + num2, vector4.y + itemWidth / 2f + num2);
			if (local.x >= vector5.x - num2 && local.x <= vector5.x + num2 && local.y >= vector5.y - num2)
			{
				return local.y <= vector5.y + num2;
			}
			return false;
		}
	}
}
