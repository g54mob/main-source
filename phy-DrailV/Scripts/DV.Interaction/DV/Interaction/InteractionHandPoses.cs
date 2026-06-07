using System;

namespace DV.Interaction
{
	[Serializable]
	public class InteractionHandPoses
	{
		public HandPose nearTouchPose;

		public HandPose touchPose;

		public HandPose grabPose;

		private bool wasForceGrabbed;

		public HandPose GrabPose
		{
			get
			{
				if (!wasForceGrabbed)
				{
					return HandPose.Grab;
				}
				return grabPose;
			}
		}

		public InteractionHandPoses(HandPose nearTouchPose, HandPose touchPose, HandPose grabPose)
		{
			this.nearTouchPose = nearTouchPose;
			this.touchPose = touchPose;
			this.grabPose = grabPose;
		}

		public InteractionHandPoses()
		{
			nearTouchPose = HandPose.Generic;
			touchPose = HandPose.Generic;
			grabPose = HandPose.Generic;
		}

		public void SetForceGrabbed(bool force)
		{
			wasForceGrabbed = force;
		}
	}
}
