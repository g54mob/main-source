using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class EndLabelStyle : LabelStyle
	{
		public EndLabelStyle()
		{
			m_Offset = new Vector3(5f, 0f, 0f);
			m_TextStyle.alignment = TextAnchor.MiddleLeft;
			m_NumericFormatter = "f0";
			m_Formatter = "{a}:{c}";
		}
	}
}
