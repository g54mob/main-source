using CTS.BBT;
using CTS.Core;

public class ConstructionSystemToggler : CTSBehaviour
{
	private LockToggle _timeLocker = new LockToggle();

	protected override void OnAwake()
	{
		base.OnAwake();
		_timeLocker.Add(MonoSingleton<TimeController>.Instance);
		UI_ConstructionSystem.OnOpenBuildMode += OnConstructionOpened;
		UI_ConstructionSystem.OnCloseBuildMode += OnConstructionClosed;
	}

	private void OnDestroy()
	{
		UI_ConstructionSystem.OnOpenBuildMode -= OnConstructionOpened;
		UI_ConstructionSystem.OnCloseBuildMode -= OnConstructionClosed;
	}

	private void OnConstructionOpened()
	{
		_timeLocker.Lock();
	}

	private void OnConstructionClosed()
	{
		_timeLocker.Unlock();
	}
}
