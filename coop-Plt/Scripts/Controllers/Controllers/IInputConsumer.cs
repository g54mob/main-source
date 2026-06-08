namespace Controllers
{
	public interface IInputConsumer
	{
		InputConsumerState TakeInput(int player_id, InputState state);
	}
}
