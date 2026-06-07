using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.2.0")]
	public class StateStyle : ChildComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private LabelStyle m_Label = new LabelStyle();

		[SerializeField]
		private LabelLine m_LabelLine = new LabelLine();

		[SerializeField]
		private ItemStyle m_ItemStyle = new ItemStyle();

		[SerializeField]
		private LineStyle m_LineStyle = new LineStyle();

		[SerializeField]
		private AreaStyle m_AreaStyle = new AreaStyle();

		[SerializeField]
		private SerieSymbol m_Symbol = new SerieSymbol();

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				m_Show = value;
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
				if (PropertyUtil.SetClass(ref m_Label, value, notNull: true))
				{
					SetAllDirty();
				}
			}
		}

		public LabelLine labelLine
		{
			get
			{
				return m_LabelLine;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LabelLine, value, notNull: true))
				{
					SetAllDirty();
				}
			}
		}

		public ItemStyle itemStyle
		{
			get
			{
				return m_ItemStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_ItemStyle, value, notNull: true))
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
				if (PropertyUtil.SetClass(ref m_LineStyle, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public AreaStyle areaStyle
		{
			get
			{
				return m_AreaStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_AreaStyle, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public SerieSymbol symbol
		{
			get
			{
				return m_Symbol;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Symbol, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty && !m_Label.vertsDirty && !m_ItemStyle.vertsDirty && !m_LineStyle.vertsDirty && !m_AreaStyle.vertsDirty)
				{
					return m_Symbol.vertsDirty;
				}
				return true;
			}
		}

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty)
				{
					return m_Label.componentDirty;
				}
				return true;
			}
		}

		public void Reset()
		{
			m_Show = false;
			m_Label.Reset();
			m_LabelLine.Reset();
			m_ItemStyle.Reset();
			m_Symbol.Reset();
		}

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			m_Label.ClearVerticesDirty();
			m_ItemStyle.ClearVerticesDirty();
			m_LineStyle.ClearVerticesDirty();
			m_AreaStyle.ClearVerticesDirty();
			m_Symbol.ClearVerticesDirty();
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			m_Label.ClearComponentDirty();
			m_Symbol.ClearComponentDirty();
		}
	}
}
