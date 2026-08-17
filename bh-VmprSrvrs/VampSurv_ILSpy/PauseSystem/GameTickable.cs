using Zenject;

public class GameTickable : ITickable
{
	public void Tick()
	{
		if (!PauseSystem._paused)
		{
			OnTick();
		}
	}

	protected virtual void OnTick()
	{
	}
}
