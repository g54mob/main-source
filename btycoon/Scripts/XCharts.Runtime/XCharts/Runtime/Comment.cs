using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(CommentHander), true)]
	public class Comment : MainComponent, IPropertyChanged
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle();

		[SerializeField]
		private CommentMarkStyle m_MarkStyle;

		[SerializeField]
		private List<CommentItem> m_Items = new List<CommentItem>
		{
			new CommentItem()
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

		public List<CommentItem> items
		{
			get
			{
				return m_Items;
			}
			set
			{
				m_Items = value;
				SetComponentDirty();
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

		public LabelStyle GetLabelStyle(int index)
		{
			if (index >= 0 && index < items.Count)
			{
				LabelStyle labelStyle = items[index].labelStyle;
				if (labelStyle.show)
				{
					return labelStyle;
				}
			}
			return m_LabelStyle;
		}

		public CommentMarkStyle GetMarkStyle(int index)
		{
			if (index >= 0 && index < items.Count)
			{
				CommentMarkStyle commentMarkStyle = items[index].markStyle;
				if (commentMarkStyle.show)
				{
					return commentMarkStyle;
				}
			}
			return m_MarkStyle;
		}

		public void OnChanged()
		{
			foreach (CommentItem item in items)
			{
				item.location.OnChanged();
			}
		}
	}
}
