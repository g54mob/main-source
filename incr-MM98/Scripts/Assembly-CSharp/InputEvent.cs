public class InputEvent
{
	public enum Key
	{
		Submit = 0,
		Cancel = 1,
		LeftClick = 2,
		RightClick = 3,
		MiddleClick = 4,
		DashboardView = 5,
		UpgradesView = 6,
		DebuggerView = 7,
		WorldView = 8,
		AuctionView = 9,
		SequelView = 10,
		ResearchView = 11,
		Pause = 12
	}

	public bool Consumed;

	public Key Input;

	public void Consume()
	{
		Consumed = true;
	}
}
