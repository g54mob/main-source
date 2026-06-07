using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.Feel
{
	public class BounceFeedbacks : MonoBehaviour
	{
		public MMFeedbacks ChargeFeedbacks;

		public MMFeedbacks JumpFeedbacks;

		public MMFeedbacks LandingFeedbacks;

		public virtual void PlayCharge()
		{
		}

		public virtual void PlayJump()
		{
		}

		public virtual void PlayLanding()
		{
		}
	}
}
