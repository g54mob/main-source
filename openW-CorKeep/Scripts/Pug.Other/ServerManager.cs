using UnityEngine;

public class ServerManager : Manager
{
	protected override void AddSpecializedManagers()
	{
		_allManagers.Add(_platformManager);
		_allManagers.Add(_filesystemManager);
		_allManagers.Add(_prefsManager);
		_allManagers.Add(_saveManager);
		_allManagers.Add(_updateManager);
		_allManagers.Add(_memoryManager);
		_allManagers.Add(_physicsManager);
		_allManagers.Add(_loadManager);
		_allManagers.Add(_modManager);
		_allManagers.Add(_worldGenManager);
		_allManagers.Add(_networkingManager);
		_allManagers.Add(_ecsManager);
		_allManagers.Add(_traceManager);
	}

	protected override void Awake()
	{
		base.Awake();
		Application.targetFrameRate = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		QualitySettings.vSyncCount = 0;
	}
}
