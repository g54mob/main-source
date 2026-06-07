using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class CommentItem : ChildComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private string m_Content = "comment";

		[SerializeField]
		private Rect m_MarkRect;

		[SerializeField]
		private CommentMarkStyle m_MarkStyle = new CommentMarkStyle
		{
			show = false
		};

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle
		{
			show = false
		};

		[SerializeField]
		[Since("v3.5.0")]
		private Location m_Location = new Location
		{
			align = Location.Align.TopLeft,
			top = 0.125f
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
					SetComponentDirty();
				}
			}
		}

		public string content
		{
			get
			{
				return m_Content;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Content, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Rect markRect
		{
			get
			{
				return m_MarkRect;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MarkRect, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public CommentMarkStyle markStyle
		{
			get
			{
				return m_MarkStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_MarkStyle, value))
				{
					SetVerticesDirty();
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
	}
}
