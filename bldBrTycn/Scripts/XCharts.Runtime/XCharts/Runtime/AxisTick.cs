using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AxisTick : BaseLine
	{
		[SerializeField]
		private bool m_AlignWithLabel;

		[SerializeField]
		private bool m_Inside;

		[SerializeField]
		private bool m_ShowStartTick;

		[SerializeField]
		private bool m_ShowEndTick;

		[SerializeField]
		private float m_Distance;

		[SerializeField]
		protected int m_SplitNumber;

		[SerializeField]
		private bool m_AutoColor;

		public float distance
		{
			get
			{
				return m_Distance;
			}
			set
			{
				m_Distance = value;
			}
		}

		public bool alignWithLabel
		{
			get
			{
				return m_AlignWithLabel;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AlignWithLabel, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool inside
		{
			get
			{
				return m_Inside;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Inside, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showStartTick
		{
			get
			{
				return m_ShowStartTick;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowStartTick, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showEndTick
		{
			get
			{
				return m_ShowEndTick;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowEndTick, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int splitNumber
		{
			get
			{
				return m_SplitNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitNumber, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool autoColor
		{
			get
			{
				return m_AutoColor;
			}
			set
			{
				m_AutoColor = value;
			}
		}

		public static AxisTick defaultTick => new AxisTick
		{
			m_Show = true,
			m_AlignWithLabel = false,
			m_Inside = false,
			m_ShowStartTick = true,
			m_ShowEndTick = true
		};

		public AxisTick Clone()
		{
			return new AxisTick
			{
				show = base.show,
				alignWithLabel = alignWithLabel,
				inside = inside,
				showStartTick = showStartTick,
				showEndTick = showEndTick,
				lineStyle = base.lineStyle.Clone()
			};
		}

		public void Copy(AxisTick axisTick)
		{
			base.show = axisTick.show;
			alignWithLabel = axisTick.alignWithLabel;
			inside = axisTick.inside;
			showStartTick = axisTick.showStartTick;
			showEndTick = axisTick.showEndTick;
		}
	}
}
