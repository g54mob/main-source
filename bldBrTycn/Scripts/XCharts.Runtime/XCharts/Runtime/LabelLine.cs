using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class LabelLine : ChildComponent, ISerieComponent, ISerieDataComponent
	{
		public enum LineType
		{
			BrokenLine = 0,
			Curves = 1,
			HorizontalLine = 2
		}

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private LineType m_LineType;

		[SerializeField]
		private Color32 m_LineColor = ChartConst.clearColor32;

		[SerializeField]
		private float m_LineAngle = 60f;

		[SerializeField]
		private float m_LineWidth = 1f;

		[SerializeField]
		private float m_LineGap = 1f;

		[SerializeField]
		private float m_LineLength1 = 25f;

		[SerializeField]
		private float m_LineLength2 = 15f;

		[SerializeField]
		[Since("v3.8.0")]
		private float m_LineEndX;

		[SerializeField]
		private SymbolStyle m_StartSymbol = new SymbolStyle
		{
			show = false,
			type = SymbolType.Circle,
			size = 3f
		};

		[SerializeField]
		private SymbolStyle m_EndSymbol = new SymbolStyle
		{
			show = false,
			type = SymbolType.Circle,
			size = 3f
		};

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

		public LineType lineType
		{
			get
			{
				return m_LineType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 lineColor
		{
			get
			{
				return m_LineColor;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineAngle
		{
			get
			{
				return m_LineAngle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineAngle, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineWidth
		{
			get
			{
				return m_LineWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineGap
		{
			get
			{
				return m_LineGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineGap, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineLength1
		{
			get
			{
				return m_LineLength1;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineLength1, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineLength2
		{
			get
			{
				return m_LineLength2;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineLength2, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineEndX
		{
			get
			{
				return m_LineEndX;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineEndX, value))
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

		public void Reset()
		{
			m_Show = false;
			m_LineType = LineType.BrokenLine;
			m_LineColor = Color.clear;
			m_LineAngle = 60f;
			m_LineWidth = 1f;
			m_LineGap = 1f;
			m_LineLength1 = 25f;
			m_LineLength2 = 15f;
			m_LineEndX = 0f;
		}

		public Vector3 GetStartSymbolOffset()
		{
			if (m_StartSymbol == null || !m_StartSymbol.show)
			{
				return Vector3.zero;
			}
			return m_StartSymbol.offset3;
		}

		public Vector3 GetEndSymbolOffset()
		{
			if (m_EndSymbol == null || !m_EndSymbol.show)
			{
				return Vector3.zero;
			}
			return m_EndSymbol.offset3;
		}
	}
}
