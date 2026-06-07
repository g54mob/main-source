using System;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Bind Pose Motor")]
	public class BindPoseMotor : BoneControllerMotor
	{
		public BindPoseMotor()
		{
		}

		public BindPoseMotor(BoneController rSkeleton)
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}
	}
}
