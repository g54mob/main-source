using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(TitleHander), true)]
	public class Title : MainComponent, IPropertyChanged
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private string m_Text = "Chart Title";

		[SerializeField]
		private string m_SubText = "";

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle();

		[SerializeField]
		private LabelStyle m_SubLabelStyle = new LabelStyle();

		[SerializeField]
		private float m_ItemGap;

		[SerializeField]
		private Location m_Location = Location.defaultTop;

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
					SetComponentDirty();
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

		public LabelStyle labelStyle
		{
			get
			{
				return m_LabelStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LabelStyle, value))
				{
					SetComponentDirty();
				}
			}
		}

		public string subText
		{
			get
			{
				return m_SubText;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SubText, value))
				{
					SetComponentDirty();
				}
			}
		}

		public LabelStyle subLabelStyle
		{
			get
			{
				return m_SubLabelStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SubLabelStyle, value))
				{
					SetComponentDirty();
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
					SetComponentDirty();
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
					SetComponentDirty();
				}
			}
		}

		public override bool vertsDirty => false;

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty && !location.componentDirty && !m_LabelStyle.componentDirty)
				{
					return m_SubLabelStyle.componentDirty;
				}
				return true;
			}
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			location.ClearComponentDirty();
			m_LabelStyle.ClearComponentDirty();
			m_SubLabelStyle.ClearComponentDirty();
		}

		public void OnChanged()
		{
			m_Location.OnChanged();
		}
	}
}
