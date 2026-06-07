using System;

namespace Cinemachine
{
	[Serializable]
	public struct AxisBase
	{
		[NoSaveDuringPlay]
		public float m_Value;

		public float m_MinValue;

		public float m_MaxValue;

		public bool m_Wrap;

		public void Validate()
		{
		}
	}
}
