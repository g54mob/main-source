using UnityEngine.Events;

namespace JUTPS.ItemSystem
{
	public class JUGeneralHoldableItem : HoldableItem
	{
		public bool DisableCharacterFireModeOnStopUsing;

		public UnityEvent OnUseItem;

		public UnityEvent OnStopUsingItem;

		protected bool OnUseItemEventCalled;

		protected bool OnStopUseItemEventCalled;

		public override void UseItem()
		{
			if (CanUseItem)
			{
				if (!OnUseItemEventCalled)
				{
					OnUseItem.Invoke();
					OnStopUseItemEventCalled = false;
					OnUseItemEventCalled = true;
				}
				base.UseItem();
			}
		}

		public override void StopUseItem()
		{
			base.StopUseItem();
			if (!OnStopUseItemEventCalled)
			{
				if (DisableCharacterFireModeOnStopUsing && TPSOwner != null)
				{
					TPSOwner.FiringMode = false;
				}
				OnStopUsingItem.Invoke();
				OnUseItemEventCalled = false;
				OnStopUseItemEventCalled = true;
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
