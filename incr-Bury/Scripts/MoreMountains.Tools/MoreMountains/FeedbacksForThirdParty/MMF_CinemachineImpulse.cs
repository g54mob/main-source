using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackPath("Camera/Cinemachine Impulse")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.Cinemachine", null)]
	[FeedbackHelp("This feedback lets you trigger a Cinemachine Impulse event. You'll need a Cinemachine Impulse Listener on your camera for this to work.")]
	public class MMF_CinemachineImpulse : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Cinemachine Impulse", true, 28, false, false)]
		[Tooltip("the impulse definition to broadcast")]
		public CinemachineImpulseDefinition m_ImpulseDefinition = new CinemachineImpulseDefinition();

		[Tooltip("the velocity to apply to the impulse shake")]
		public Vector3 Velocity;

		[Tooltip("whether or not to clear impulses (stopping camera shakes) when the Stop method is called on that feedback")]
		public bool ClearImpulseOnStop;

		[Header("Gizmos")]
		[Tooltip("whether or not to draw gizmos to showcase the various distance properties of this feedback, when applicable. Dissipation distance in blue, impact radius in yellow.")]
		public bool DrawGizmos;

		public override bool HasRandomness => true;

		public override float FeedbackDuration
		{
			get
			{
				if (m_ImpulseDefinition == null)
				{
					return 0f;
				}
				return m_ImpulseDefinition.TimeEnvelope.Duration;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				CinemachineImpulseManager.Instance.IgnoreTimeScale = !InScaledTimescaleMode;
				float num = ComputeIntensity(feedbacksIntensity, position);
				m_ImpulseDefinition.CreateEvent(position, Velocity * num);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && ClearImpulseOnStop)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				CinemachineImpulseManager.Instance.Clear();
			}
		}

		public override void OnAddFeedback()
		{
			if (m_ImpulseDefinition == null)
			{
				m_ImpulseDefinition = new CinemachineImpulseDefinition();
			}
			m_ImpulseDefinition.RawSignal = Resources.Load<NoiseSettings>("MM_6D_Shake");
			Velocity = new Vector3(5f, 5f, 5f);
		}

		public override void OnDrawGizmosSelectedHandler()
		{
			if (DrawGizmos && m_ImpulseDefinition != null)
			{
				if (m_ImpulseDefinition.ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Dissipating || m_ImpulseDefinition.ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Propagating || m_ImpulseDefinition.ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Legacy)
				{
					Gizmos.color = MMColors.Aqua;
					Gizmos.DrawWireSphere(Owner.transform.position, m_ImpulseDefinition.DissipationDistance);
				}
				if (m_ImpulseDefinition.ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Legacy)
				{
					Gizmos.color = MMColors.ReunoYellow;
					Gizmos.DrawWireSphere(Owner.transform.position, m_ImpulseDefinition.ImpactRadius);
				}
			}
		}

		public override void AutomaticShakerSetup()
		{
			MMCinemachineHelpers.AutomaticCinemachineShakersSetup(Owner, "CinemachineImpulse");
		}
	}
}
