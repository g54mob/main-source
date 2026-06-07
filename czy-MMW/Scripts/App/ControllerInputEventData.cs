using UnityEngine.EventSystems;

public class ControllerInputEventData : BaseEventData
{
	public IController instigatingController;

	public ControllerInputEventData(EventSystem eventSystem, IController onController)
		: base(eventSystem)
	{
		instigatingController = onController;
	}
}
