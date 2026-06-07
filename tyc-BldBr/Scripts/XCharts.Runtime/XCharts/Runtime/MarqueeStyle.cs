using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.5.0")]
	public class MarqueeStyle : ChildComponent
	{
		[SerializeField]
		[Since("v3.5.0")]
		private bool m_Apply;

		[SerializeField]
		[Since("v3.5.0")]
		private bool m_RealRect;

		[SerializeField]
		[Since("v3.5.0")]
		private AreaStyle m_AreaStyle = new AreaStyle();

		[SerializeField]
		[Since("v3.5.0")]
		private LineStyle m_LineStyle = new LineStyle();

		protected Action<DataZoom> m_OnStart;

		protected Action<DataZoom> m_OnGoing;

		protected Action<DataZoom> m_OnEnd;

		public AreaStyle areaStyle
		{
			get
			{
				return m_AreaStyle;
			}
			set
			{
				m_AreaStyle = value;
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
				m_LineStyle = value;
			}
		}

		public bool apply
		{
			get
			{
				return m_Apply;
			}
			set
			{
				m_Apply = value;
			}
		}

		public bool realRect
		{
			get
			{
				return m_RealRect;
			}
			set
			{
				m_RealRect = value;
			}
		}

		public Action<DataZoom> onStart
		{
			get
			{
				return m_OnStart;
			}
			set
			{
				m_OnStart = value;
			}
		}

		public Action<DataZoom> onGoing
		{
			get
			{
				return m_OnStart;
			}
			set
			{
				m_OnStart = value;
			}
		}

		public Action<DataZoom> onEnd
		{
			get
			{
				return m_OnEnd;
			}
			set
			{
				m_OnEnd = value;
			}
		}
	}
}
