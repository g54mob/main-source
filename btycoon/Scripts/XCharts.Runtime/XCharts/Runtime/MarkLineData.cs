using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class MarkLineData : ChildComponent
	{
		[SerializeField]
		private MarkLineType m_Type;

		[SerializeField]
		private string m_Name;

		[SerializeField]
		private int m_Dimension = 1;

		[SerializeField]
		private float m_XPosition;

		[SerializeField]
		private float m_YPosition;

		[SerializeField]
		private double m_XValue;

		[SerializeField]
		private double m_YValue;

		[SerializeField]
		private int m_Group;

		[SerializeField]
		private bool m_ZeroPosition;

		[SerializeField]
		private SymbolStyle m_StartSymbol = new SymbolStyle();

		[SerializeField]
		private SymbolStyle m_EndSymbol = new SymbolStyle();

		[SerializeField]
		private LineStyle m_LineStyle = new LineStyle();

		[SerializeField]
		private LabelStyle m_Label = new LabelStyle();

		public Vector3 runtimeStartPosition { get; internal set; }

		public Vector3 runtimeEndPosition { get; internal set; }

		public Vector3 runtimeCurrentEndPosition { get; internal set; }

		public ChartLabel runtimeLabel { get; internal set; }

		public double runtimeValue { get; internal set; }

		public bool runtimeInGrid { get; internal set; }

		public string name
		{
			get
			{
				return m_Name;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Name, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public MarkLineType type
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

		public float xPosition
		{
			get
			{
				return m_XPosition;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_XPosition, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float yPosition
		{
			get
			{
				return m_YPosition;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_YPosition, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public double xValue
		{
			get
			{
				return m_XValue;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_XValue, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public double yValue
		{
			get
			{
				return m_YValue;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_YValue, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int group
		{
			get
			{
				return m_Group;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Group, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool zeroPosition
		{
			get
			{
				return m_ZeroPosition;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ZeroPosition, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public SymbolStyle startSymbol
		{
			get
			{
				return m_StartSymbol;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_StartSymbol, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public SymbolStyle endSymbol
		{
			get
			{
				return m_EndSymbol;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_EndSymbol, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public LineStyle lineStyle
		{
			get
			{
				return m_LineStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LineStyle, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public LabelStyle label
		{
			get
			{
				return m_Label;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Label, value))
				{
					SetVerticesDirty();
				}
			}
		}
	}
}
