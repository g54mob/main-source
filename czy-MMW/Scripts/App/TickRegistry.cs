using System.Collections.Generic;

public class TickRegistry
{
	public delegate void TickDelegate(float deltaTime);

	private List<TickDelegate> _tickDelegates = new List<TickDelegate>();

	private List<TickDelegate> _currentlyTickingDelegates = new List<TickDelegate>();

	public event TickDelegate AppTicking
	{
		add
		{
			_tickDelegates.Add(value);
		}
		remove
		{
			_tickDelegates.Remove(value);
		}
	}

	public void Tick(float deltaTime)
	{
		_currentlyTickingDelegates.AddRange(_tickDelegates);
		foreach (TickDelegate currentlyTickingDelegate in _currentlyTickingDelegates)
		{
			currentlyTickingDelegate(deltaTime);
		}
		_currentlyTickingDelegates.Clear();
	}
}
