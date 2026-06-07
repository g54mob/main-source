using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AxisName : ChildComponent
	{
		[SerializeField]
		private bool m_Show;

		[SerializeField]
		private string m_Name;

		[SerializeField]
		[Since("v3.1.0")]
		private bool m_OnZero;

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle();

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
					SetComponentDirty();
				}
			}
		}

		public bool onZero
		{
			get
			{
				return m_OnZero;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_OnZero, value))
				{
					SetComponentDirty();
				}
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

		public static AxisName defaultAxisName => new AxisName
		{
			m_Show = false,
			m_Name = "axisName",
			m_LabelStyle = new LabelStyle(),
			labelStyle = 
			{
				position = LabelStyle.Position.End
			}
		};

		public AxisName Clone()
		{
			AxisName axisName = new AxisName();
			axisName.show = show;
			axisName.name = name;
			axisName.m_LabelStyle.Copy(m_LabelStyle);
			return axisName;
		}

		public void Copy(AxisName axisName)
		{
			show = axisName.show;
			name = axisName.name;
			m_LabelStyle.Copy(axisName.labelStyle);
		}
	}
}
