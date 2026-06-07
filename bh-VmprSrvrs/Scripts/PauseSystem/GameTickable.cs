using Zenject;

public class GameTickable : ITickable
{
	public void Tick()
	{
	}

	protected virtual void OnTick()
	{
	}
}
