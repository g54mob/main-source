using System;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class BipedIKSolvers
	{
		public IKSolverLimb leftFoot;

		public IKSolverLimb rightFoot;

		public IKSolverLimb leftHand;

		public IKSolverLimb rightHand;

		public IKSolverFABRIK spine;

		public IKSolverLookAt lookAt;

		public IKSolverAim aim;

		public Constraints pelvis;

		private IKSolverLimb[] tkq;

		private IKSolver[] tkr;

		public IKSolverLimb[] xpl => null;

		public IKSolver[] xpm => null;

		public void jso(BipedReferences a)
		{
		}
	}
}
