using UnityEngine.EventSystems;

public class UIItemRecievePipe : UIPipe, IPointerClickHandler, IEventSystemHandler
{
	public override bool CanHandlePipe(Pipe pipe)
	{
		return false;
	}

	public override void HandlePipe(Pipe pipe)
	{
	}
}
