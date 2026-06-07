public class MovementEventButton : EventButton
{
	protected override bool ReturnCanInteract(GameEvent gameEvent)
	{
		if (gameEvent is MapEvent mapEvent)
		{
			return mapEvent.State == MapPath.State.Ok;
		}
		return false;
	}
}
