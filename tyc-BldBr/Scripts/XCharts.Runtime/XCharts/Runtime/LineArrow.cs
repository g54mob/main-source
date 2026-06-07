using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class LineArrow : ChildComponent, ISerieComponent
	{
		public enum Position
		{
			End = 0,
			Start = 1
		}

		[SerializeField]
		private bool m_Show;

		[SerializeField]
		private Position m_Position;

		[SerializeField]
		private ArrowStyle m_Arrow = new ArrowStyle
		{
			width = 10f,
			height = 15f,
			offset = 0f,
			dent = 3f
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
					SetVerticesDirty();
				}
			}
		}

		public Position position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Position, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public ArrowStyle arrow
		{
			get
			{
				return m_Arrow;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Arrow, value))
				{
					SetVerticesDirty();
				}
			}
		}
	}
}
