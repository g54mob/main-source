public class TutorialSpawnersManager : SpawnersManager
{
	protected override void Start()
	{
		base.Start();
		StopRoundSpawners();
		StopWaveSpawners();
		currentCycle = -1;
	}

	public void NextCycle()
	{
		OnCycleChanged(currentCycle + 1, ECycleMode.Neutral);
	}

	public void SetCycle(int cycle)
	{
		OnCycleChanged(cycle, ECycleMode.Neutral);
	}

	public void StopSpawners()
	{
		StopRoundSpawners();
		StopWaveSpawners();
	}
}
