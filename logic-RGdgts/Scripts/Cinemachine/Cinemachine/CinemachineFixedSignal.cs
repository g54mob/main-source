using UnityEngine;

namespace Cinemachine
{
	public class CinemachineFixedSignal : SignalSourceAsset
	{
		public AnimationCurve m_XCurve;

		public AnimationCurve m_YCurve;

		public AnimationCurve m_ZCurve;

		public override float SignalDuration => 0f;

		private float AxisDuration(AnimationCurve axis)
		{
			return 0f;
		}

		public override void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
		{
			pos = default(Vector3);
			rot = default(Quaternion);
		}

		private float AxisValue(AnimationCurve axis, float time)
		{
			return 0f;
		}
	}
}
