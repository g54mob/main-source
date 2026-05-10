using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(MarkAreaHandler), true)]
	public class MarkArea : MainComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private string m_Text = "";

		[SerializeField]
		private int m_SerieIndex;

		[SerializeField]
		private MarkAreaData m_Start = new MarkAreaData();

		[SerializeField]
		private MarkAreaData m_End = new MarkAreaData();

		[SerializeField]
		private ItemStyle m_ItemStyle = new ItemStyle();

		[SerializeField]
		private LabelStyle m_Label = new LabelStyle();

		public ChartLabel runtimeLabel { get; internal set; }

		public Vector3 runtimeLabelPosition { get; internal set; }

		public Rect runtimeRect { get; internal set; }

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

		public string text
		{
			get
			{
				return m_Text;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Text, value))
				{
					SetComponentDirty();
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

		public MarkAreaData start
		{
			get
			{
				return m_Start;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Start, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public MarkAreaData end
		{
			get
			{
				return m_End;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_End, value))
				{
					SetVerticesDirty();
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
				if (PropertyUtil.SetClass(ref m_ItemStyle, value))
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
					SetComponentDirty();
				}
			}
		}

		public override void SetDefaultValue()
		{
			m_ItemStyle = new ItemStyle();
			m_ItemStyle.opacity = 0.6f;
			m_Label = new LabelStyle();
			m_Label.show = true;
		}
	}
}
