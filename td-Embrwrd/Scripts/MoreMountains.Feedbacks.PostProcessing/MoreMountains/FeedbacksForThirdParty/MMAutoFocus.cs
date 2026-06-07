using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMAutoFocus")]
	public class MMAutoFocus : MonoBehaviour
	{
		[Header("Bindings")]
		[Tooltip("the position of the camera")]
		public Transform CameraTransform;

		[Tooltip("a list of all possible targets")]
		public Transform[] FocusTargets;

		[Tooltip("an offset to apply to the focus target")]
		public Vector3 Offset;

		[Tooltip("the current target of this auto focus")]
		[Header("Setup")]
		public float FocusTargetID;

		[Header("Desired Aperture")]
		[Tooltip("the aperture to work with")]
		[Range(0.1f, 20f)]
		public float Aperture;
	}
}
