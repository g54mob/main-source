using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	[Serializable]
	public class CurveControlledBob
	{
		public float HorizontalBobRange;

		public float VerticalBobRange;

		public AnimationCurve Bobcurve;

		public float VerticaltoHorizontalRatio;

		[NonSerialized]
		public float m_CyclePositionX;

		[NonSerialized]
		public float m_CyclePositionY;

		public float m_BobBaseInterval;

		[NonSerialized]
		private Vector3 m_OriginalCameraPosition;

		[NonSerialized]
		public float m_Time;

		public void Setup(Camera camera, float bobBaseInterval, Vector3 camOriginalPos)
		{
		}
	}
}
