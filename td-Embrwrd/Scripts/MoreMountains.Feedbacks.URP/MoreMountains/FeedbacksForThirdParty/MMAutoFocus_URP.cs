using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMAutoFocus_URP")]
	[RequireComponent(typeof(Volume))]
	public class MMAutoFocus_URP : MonoBehaviour
	{
		[Tooltip("the position of the camera")]
		[Header("Bindings")]
		public Transform CameraTransform;

		[Tooltip("a list of all possible targets")]
		public Transform[] FocusTargets;

		[Tooltip("the current target of this auto focus")]
		[Header("Setup")]
		public float FocusTargetID;

		[Range(0.1f, 20f)]
		[Tooltip("the aperture to work with")]
		[Header("Desired Aperture")]
		public float Aperture;

		protected Volume _volume;

		protected VolumeProfile _profile;

		protected DepthOfField _depthOfField;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
