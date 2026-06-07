using UnityEngine;

namespace Cinemachine
{
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineImpulseFixedSignals.html")]
	public class CinemachineFixedSignal : SignalSourceAsset
	{
		[Tooltip("The raw signal shape along the X axis")]
		public AnimationCurve m_XCurve;

		[Tooltip("The raw signal shape along the Y axis")]
		public AnimationCurve m_YCurve;

		[Tooltip("The raw signal shape along the Z axis")]
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
