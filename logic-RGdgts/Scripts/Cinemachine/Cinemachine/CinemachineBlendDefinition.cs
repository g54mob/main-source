using System;
using UnityEngine;

namespace Cinemachine
{
	[Serializable]
	public struct CinemachineBlendDefinition
	{
		public enum Style
		{
			Cut = 0,
			EaseInOut = 1,
			EaseIn = 2,
			EaseOut = 3,
			HardIn = 4,
			HardOut = 5,
			Linear = 6,
			Custom = 7
		}

		public Style m_Style;

		public float m_Time;

		public AnimationCurve m_CustomCurve;

		private static AnimationCurve[] sStandardCurves;

		public float BlendTime => 0f;

		public AnimationCurve BlendCurve => null;

		public CinemachineBlendDefinition(Style style, float time)
		{
			m_Style = default(Style);
			m_Time = 0f;
			m_CustomCurve = null;
		}

		private void CreateStandardCurves()
		{
		}
	}
}
