using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(PolarCoordHandler), true)]
	public class PolarCoord : CoordSystem, ISerieContainer
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private float[] m_Center = new float[2] { 0.5f, 0.45f };

		[SerializeField]
		private float[] m_Radius = new float[2] { 0f, 0.35f };

		[SerializeField]
		private Color m_BackgroundColor;

		[SerializeField]
		[Since("v3.8.0")]
		private float m_IndicatorLabelOffset = 30f;

		public PolarCoordContext context = new PolarCoordContext();

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

		public float[] center
		{
			get
			{
				return m_Center;
			}
			set
			{
				if (value != null)
				{
					m_Center = value;
					SetAllDirty();
				}
			}
		}

		public float[] radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				if (value != null && value.Length == 2)
				{
					m_Radius = value;
					SetAllDirty();
				}
			}
		}

		public Color backgroundColor
		{
			get
			{
				return m_BackgroundColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BackgroundColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float indicatorLabelOffset
		{
			get
			{
				return m_IndicatorLabelOffset;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_IndicatorLabelOffset, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool IsPointerEnter()
		{
			return context.isPointerEnter;
		}

		public bool Contains(Vector3 pos)
		{
			float num = Vector3.Distance(pos, context.center);
			if (num >= context.insideRadius)
			{
				return num <= context.outsideRadius;
			}
			return false;
		}
	}
}
