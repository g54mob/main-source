using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class TelegrabbableGadget : Telegrabbable
	{
		public GadgetBase gadgetBase;

		public override bool RemoteInteractionOnly => false;

		protected override void SetState(bool isBeingTelegrabbed)
		{
		}

		public override Transform GetAnchor(bool isRightHand)
		{
			return base.transform;
		}

		public override bool IsTelegrabAllowed(Vector3 targetPosition)
		{
			return gadgetBase.CanBeRemovedUsingMethod(GadgetBase.GadgetRemovalMethod.EmptyHand);
		}

		public override bool ShouldRotateToController()
		{
			return false;
		}
	}
}
