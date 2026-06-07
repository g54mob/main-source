public class Drawer : DraggablePanel
{
	private DrawerBehaviour behaviour;

	protected override void Init()
	{
	}

	public override void Close(bool disableGroupEvent = false, bool immediate = false, bool overrideForceOpen = false)
	{
	}

	public override void Open(bool disableGroupEvent = false, bool immediate = false, bool overrideLock = false)
	{
	}

	public T GetDrawerBehaviour<T>() where T : DrawerBehaviour
	{
		return null;
	}
}
