namespace DV.Game.Tutorial.ItemTracker
{
	public static class ItemStateUtils
	{
		public static bool IsShownInInventoryUI(this SuggestedTarget suggestedTarget)
		{
			switch (suggestedTarget)
			{
			case SuggestedTarget.Backpack:
			case SuggestedTarget.ActiveContainer:
				return true;
			case SuggestedTarget.Hotbar:
				return VRManager.IsVREnabled();
			default:
				return false;
			}
		}

		public static bool IsShownInHotbarUI(this SuggestedTarget suggestedTarget)
		{
			if (suggestedTarget == SuggestedTarget.Hotbar)
			{
				return !VRManager.IsVREnabled();
			}
			return false;
		}

		public static bool IsShownInWorld(this SuggestedTarget suggestedTarget)
		{
			if ((uint)(suggestedTarget - 4) <= 1u || (uint)(suggestedTarget - 7) <= 1u)
			{
				return true;
			}
			return false;
		}
	}
}
