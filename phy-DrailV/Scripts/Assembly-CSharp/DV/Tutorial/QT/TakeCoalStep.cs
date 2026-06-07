using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class TakeCoalStep : AQuickTutorialStep
	{
		private ShovelNonPhysicalCoal shovel;

		public TakeCoalStep(string message, ShovelCoalPile shovelCoalPile, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, shovelCoalPile.transform, offset, shouldRecheck)
		{
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			Inventory instance = SingletonBehaviour<Inventory>.Instance;
			if ((bool)instance)
			{
				shovel = instance.GetEquippedItemAtSlot(0)?.GetComponent<ShovelNonPhysicalCoal>();
				if (shovel == null && VRManager.IsVREnabled())
				{
					shovel = instance.GetEquippedItemAtSlot(1)?.GetComponent<ShovelNonPhysicalCoal>();
				}
			}
		}

		protected override bool InternalCheck()
		{
			if (shovel == null)
			{
				return false;
			}
			return shovel.IsLoaded;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Take;
		}
	}
}
