using DV.CabControls;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CoupleCouplerStep : AQuickTutorialStep
	{
		private ChainCouplerInteraction[] interactions;

		private ControlImplBase[] gizmos;

		private int index;

		public CoupleCouplerStep(Coupler coupler, Coupler otherCoupler, ControlImplBase firstGizmo, ControlImplBase otherGizmo, string message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, null, offset, shouldRecheck)
		{
			interactions = new ChainCouplerInteraction[2]
			{
				coupler.visualCoupler.chain.GetComponentInChildren<ChainCouplerInteraction>(),
				otherCoupler.visualCoupler.chain.GetComponentInChildren<ChainCouplerInteraction>()
			};
			gizmos = new ControlImplBase[2] { firstGizmo, otherGizmo };
		}

		protected override bool InternalCheck()
		{
			if (gizmos[0].IsGrabbed() || !gizmos[1].IsGrabbed())
			{
				index = 0;
			}
			else
			{
				index = 1;
			}
			if (gizmos[index].IsGrabbed() && AttentionPoint != interactions[index].ownAttachPoint.transform)
			{
				AttentionPoint = interactions[index].ownAttachPoint.transform;
				ShowVisual();
			}
			if (interactions[index].attachedTo != null && interactions[index].attachedTo != interactions[index])
			{
				return interactions[index].CurrentState >= ChainCouplerInteraction.State.Attached;
			}
			return false;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Attach;
		}
	}
}
