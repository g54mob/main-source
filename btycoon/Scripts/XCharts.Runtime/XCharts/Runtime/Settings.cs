using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Settings : MainComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		[Range(1f, 20f)]
		protected int m_MaxPainter = 10;

		[SerializeField]
		protected bool m_ReversePainter;

		[SerializeField]
		protected Material m_BasePainterMaterial;

		[SerializeField]
		protected Material m_SeriePainterMaterial;

		[SerializeField]
		protected Material m_UpperPainterMaterial;

		[SerializeField]
		protected Material m_TopPainterMaterial;

		[SerializeField]
		[Range(1f, 10f)]
		protected float m_LineSmoothStyle = 2.5f;

		[SerializeField]
		[Range(1f, 20f)]
		protected float m_LineSmoothness = 2f;

		[SerializeField]
		[Range(0.5f, 20f)]
		protected float m_LineSegmentDistance = 3f;

		[SerializeField]
		[Range(1f, 10f)]
		protected float m_CicleSmoothness = 2f;

		[SerializeField]
		protected float m_LegendIconLineWidth = 2f;

		[SerializeField]
		private float[] m_LegendIconCornerRadius = new float[4] { 0.25f, 0.25f, 0.25f, 0.25f };

		[SerializeField]
		[Since("v3.1.0")]
		protected float m_AxisMaxSplitNumber = 50f;

		public bool show => m_Show;

		public int maxPainter
		{
			get
			{
				return m_MaxPainter;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxPainter, (value < 0) ? 1 : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool reversePainter
		{
			get
			{
				return m_ReversePainter;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ReversePainter, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Material basePainterMaterial
		{
			get
			{
				return m_BasePainterMaterial;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_BasePainterMaterial, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Material seriePainterMaterial
		{
			get
			{
				return m_SeriePainterMaterial;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SeriePainterMaterial, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Material topPainterMaterial
		{
			get
			{
				return m_TopPainterMaterial;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_TopPainterMaterial, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Material upperPainterMaterial
		{
			get
			{
				return m_UpperPainterMaterial;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_UpperPainterMaterial, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float lineSmoothStyle
		{
			get
			{
				return m_LineSmoothStyle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineSmoothStyle, (value < 0f) ? 1f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineSmoothness
		{
			get
			{
				return m_LineSmoothness;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineSmoothStyle, (value < 0f) ? 1f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineSegmentDistance
		{
			get
			{
				return m_LineSegmentDistance;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineSegmentDistance, (value < 0f) ? 1f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float cicleSmoothness
		{
			get
			{
				return m_CicleSmoothness;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_CicleSmoothness, (value < 0f) ? 1f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float legendIconLineWidth
		{
			get
			{
				return m_LegendIconLineWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LegendIconLineWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float[] legendIconCornerRadius
		{
			get
			{
				return m_LegendIconCornerRadius;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LegendIconCornerRadius, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public float axisMaxSplitNumber
		{
			get
			{
				return m_AxisMaxSplitNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AxisMaxSplitNumber, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public static Settings DefaultSettings
		{
			get
			{
				Settings settings = new Settings();
				settings.m_ReversePainter = false;
				settings.m_MaxPainter = XCSettings.maxPainter;
				settings.m_LineSmoothStyle = XCSettings.lineSmoothStyle;
				settings.m_LineSmoothness = XCSettings.lineSmoothness;
				settings.m_LineSegmentDistance = XCSettings.lineSegmentDistance;
				settings.m_CicleSmoothness = XCSettings.cicleSmoothness;
				settings.m_LegendIconLineWidth = 2f;
				settings.m_LegendIconCornerRadius = new float[4] { 0.25f, 0.25f, 0.25f, 0.25f };
				return settings;
			}
		}

		public void Copy(Settings settings)
		{
			m_ReversePainter = settings.reversePainter;
			m_MaxPainter = settings.maxPainter;
			m_BasePainterMaterial = settings.basePainterMaterial;
			m_SeriePainterMaterial = settings.seriePainterMaterial;
			m_UpperPainterMaterial = settings.upperPainterMaterial;
			m_TopPainterMaterial = settings.topPainterMaterial;
			m_LineSmoothStyle = settings.lineSmoothStyle;
			m_LineSmoothness = settings.lineSmoothness;
			m_LineSegmentDistance = settings.lineSegmentDistance;
			m_CicleSmoothness = settings.cicleSmoothness;
			m_LegendIconLineWidth = settings.legendIconLineWidth;
			ChartHelper.CopyArray(m_LegendIconCornerRadius, settings.legendIconCornerRadius);
		}

		public override void Reset()
		{
			Copy(DefaultSettings);
		}
	}
}
