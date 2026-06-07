using System;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Swing At Motor")]
	[IKDescription("This motor will adjust the forward direction and face of a character to swing and attack a target")]
	public class SwingAtMotor : LookAtMotor
	{
		public SwingAtMotor()
		{
		}

		public SwingAtMotor(BoneController rSkeleton)
		{
		}

		public override void AutoLoadBones(string rStyle)
		{
		}
	}
}
