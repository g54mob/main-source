public class ModulesDrawersGroup : DraggablePanelGroup
{
	public WorkbenchObject workbenchObject;

	private bool forceHide;

	public bool isAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void SetForceHide(bool forceHide)
	{
	}

	public override void OnPanelOpen(DraggablePanel drawer)
	{
	}

	public override void OnPanelClose(DraggablePanel drawer)
	{
	}
}
