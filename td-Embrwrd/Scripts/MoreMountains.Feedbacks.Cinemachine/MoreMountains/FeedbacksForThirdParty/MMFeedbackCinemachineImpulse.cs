using Cinemachine;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackPath("Camera/Cinemachine Impulse")]
	[FeedbackHelp("This feedback lets you trigger a Cinemachine Impulse event. You'll need a Cinemachine Impulse Listener on your camera for this to work.")]
	public class MMFeedbackCinemachineImpulse : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Cinemachine Impulse")]
		[Tooltip("the impulse definition to broadcast")]
		[CinemachineImpulseDefinitionProperty]
		public CinemachineImpulseDefinition m_ImpulseDefinition;

		[Tooltip("the velocity to apply to the impulse shake")]
		public Vector3 Velocity;

		[Tooltip("whether or not to clear impulses (stopping camera shakes) when the Stop method is called on that feedback")]
		public bool ClearImpulseOnStop;

		public override float FeedbackDuration => 0f;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
