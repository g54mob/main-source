using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Padding : ChildComponent
	{
		[SerializeField]
		protected bool m_Show = true;

		[SerializeField]
		protected float m_Top;

		[SerializeField]
		protected float m_Right = 2f;

		[SerializeField]
		protected float m_Left = 2f;

		[SerializeField]
		protected float m_Bottom;

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

		public float top
		{
			get
			{
				return m_Top;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Top, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float right
		{
			get
			{
				return m_Right;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Right, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float bottom
		{
			get
			{
				return m_Bottom;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Bottom, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float left
		{
			get
			{
				return m_Left;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Left, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Padding()
		{
		}

		public Padding(float top, float right, float bottom, float left)
		{
			SetPadding(top, right, bottom, left);
		}

		public void SetPadding(float top, float right, float bottom, float left)
		{
			m_Top = top;
			m_Right = right;
			m_Bottom = bottom;
			m_Left = left;
		}
	}
}
