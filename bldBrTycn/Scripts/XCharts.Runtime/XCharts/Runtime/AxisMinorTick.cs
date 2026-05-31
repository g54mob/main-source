using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.2.0")]
	public class AxisMinorTick : BaseLine
	{
		[SerializeField]
		protected int m_SplitNumber = 5;

		[SerializeField]
		private bool m_AutoColor;

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

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty)
				{
					return m_LineStyle.anyDirty;
				}
				return true;
			}
		}

		public static AxisMinorTick defaultMinorTick => new AxisMinorTick
		{
			m_Show = false
		};

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			m_LineStyle.ClearVerticesDirty();
		}

		public AxisMinorTick Clone()
		{
			return new AxisMinorTick
			{
				show = base.show,
				splitNumber = splitNumber,
				autoColor = autoColor,
				lineStyle = base.lineStyle.Clone()
			};
		}

		public void Copy(AxisMinorTick axisTick)
		{
			base.show = axisTick.show;
			splitNumber = axisTick.splitNumber;
			autoColor = axisTick.autoColor;
			base.lineStyle.Copy(axisTick.lineStyle);
		}
	}
}
