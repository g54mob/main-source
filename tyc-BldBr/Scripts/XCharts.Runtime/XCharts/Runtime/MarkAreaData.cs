using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class MarkAreaData : ChildComponent
	{
		[SerializeField]
		private MarkAreaType m_Type;

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

		public double runtimeValue { get; internal set; }

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

		public MarkAreaType type
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
	}
}
