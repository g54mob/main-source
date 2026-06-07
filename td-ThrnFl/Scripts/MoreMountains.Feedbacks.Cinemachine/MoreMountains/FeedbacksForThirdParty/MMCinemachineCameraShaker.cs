using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachineCameraShaker")]
	public class MMCinemachineCameraShaker : MonoBehaviour
	{
		[Header("Settings")]
		[Tooltip("the channel to receive events on")]
		public int Channel;

		[Tooltip("The default amplitude that will be applied to your shakes if you don't specify one")]
		public float DefaultShakeAmplitude = 0.5f;

		[Tooltip("The default frequency that will be applied to your shakes if you don't specify one")]
		public float DefaultShakeFrequency = 10f;

		[Tooltip("the amplitude of the camera's noise when it's idle")]
		[MMFReadOnly]
		public float IdleAmplitude;

		[Tooltip("the frequency of the camera's noise when it's idle")]
		[MMFReadOnly]
		public float IdleFrequency = 1f;

		[Tooltip("the speed at which to interpolate the shake")]
		public float LerpSpeed = 5f;

		[Header("Test")]
		[Tooltip("a duration (in seconds) to apply when testing this shake via the TestShake button")]
		public float TestDuration = 0.3f;

		[Tooltip("the amplitude to apply when testing this shake via the TestShake button")]
		public float TestAmplitude = 2f;

		[Tooltip("the frequency to apply when testing this shake via the TestShake button")]
		public float TestFrequency = 20f;

		[MMFInspectorButton("TestShake")]
		public bool TestShakeButton;
	}
}
