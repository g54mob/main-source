namespace Assets.Scripts.Input.Events
{
	public interface IInputEvent
	{
		float DragDistanceSinceBegin { get; }

		InputButton InputButton { get; }

		InputState InputState { get; }
	}
}
