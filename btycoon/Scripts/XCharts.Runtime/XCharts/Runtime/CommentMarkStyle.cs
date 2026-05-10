using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class CommentMarkStyle : ChildComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private LineStyle m_LineStyle;

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
	}
}
