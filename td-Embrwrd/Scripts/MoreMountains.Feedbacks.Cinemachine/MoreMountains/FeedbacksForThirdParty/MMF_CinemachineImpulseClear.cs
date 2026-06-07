using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackPath("Camera/Cinemachine Impulse Clear")]
	[FeedbackHelp("This feedback lets you trigger a Cinemachine Impulse clear, stopping instantly any impulse that may be playing.")]
	[AddComponentMenu(null)]
	public class MMF_CinemachineImpulseClear : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
