public class RewiredGameSpeed : RewiredInteractable
{
	protected override bool IsInInteractableUIState()
	{
		if (UIManager.State == UIState.Map)
		{
			return true;
		}
		if (IsExempt() || !IsBlocked())
		{
			return base.IsInInteractableUIState();
		}
		return false;
	}

	private bool IsExempt()
	{
		return UIManager.HasFlagsSet(PanelContainerFlags.ExemptGameSpeed);
	}

	private bool IsBlocked()
	{
		if (!UIManager.HasFlagsSet(PanelContainerFlags.BlockGameSpeed))
		{
			return UIManager.HasFlagsSet(PanelContainerFlags.BlockDPadInput);
		}
		return true;
	}
}
