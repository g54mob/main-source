public class Epocalypse
{
	private enum STATE
	{
		INACTIVE = 0,
		TRIGGERED = 1,
		ACTIVE = 2,
		OFF = 3
	}

	private STATE state;

	private const int TRIGGER_TIME = 900;

	private const int TIME_TO_ACTIVATE = 1800;

	private const int ACTIVATE_TIME = 9000;

	private int triggerCounter;

	public void Update()
	{
	}

	private void SetState(STATE state)
	{
	}

	private void PopAllEggs()
	{
	}
}
