using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

namespace DV.CabControls.VRTK
{
	[DisallowMultipleComponent]
	public class CarryTwoHandedItemAfterTeleportVRTK : CarryItemAfterTeleportVRTK
	{
		private VRTK_TwoHandedPoleGrab twoHandedGrab;

		protected override void Initialize()
		{
			twoHandedGrab = GetComponent<VRTK_TwoHandedPoleGrab>();
			base.Initialize();
		}

		protected override void OnUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			if (!interactable.IsGrabbed())
			{
				base.OnUngrabbed(sender, e);
			}
		}

		protected override bool Before()
		{
			if (!base.Before())
			{
				return false;
			}
			return true;
		}

		protected override bool After()
		{
			if (base.After())
			{
				twoHandedGrab.ReactToForceMove(start: false);
				return true;
			}
			return false;
		}
	}
}
