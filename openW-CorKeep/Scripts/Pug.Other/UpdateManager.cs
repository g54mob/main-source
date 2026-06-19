using System.Collections.Generic;
using Unity.Profiling;

public class UpdateManager : ManagerBase
{
	private static readonly ProfilerMarker ManagedUpdateMarker = new ProfilerMarker("ManagedUpdate");

	private static readonly ProfilerMarker ManagedLateUpdateMarker = new ProfilerMarker("ManagedLateUpdate");

	private Dictionary<IManagedUpdate, int> updaters = new Dictionary<IManagedUpdate, int>();

	private Dictionary<IManagedLateUpdate, int> lateUpdaters = new Dictionary<IManagedLateUpdate, int>();

	private List<IManagedUpdate> updatersList = new List<IManagedUpdate>();

	private List<IManagedLateUpdate> lateUpdatersList = new List<IManagedLateUpdate>();

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("UpdateManager.Init");

	public void AddToUpdate(IManagedUpdate u)
	{
		updaters.Add(u, updatersList.Count);
		updatersList.Add(u);
	}

	public void AddToLateUpdate(IManagedLateUpdate u)
	{
		lateUpdaters.Add(u, lateUpdatersList.Count);
		lateUpdatersList.Add(u);
	}

	public void RemoveFromUpdate(IManagedUpdate u)
	{
		int num = updaters[u];
		updatersList[num] = updatersList[updatersList.Count - 1];
		updaters[updatersList[num]] = num;
		updatersList.RemoveAt(updatersList.Count - 1);
		updaters.Remove(u);
	}

	public void RemoveFromLateUpdate(IManagedLateUpdate u)
	{
		int num = lateUpdaters[u];
		lateUpdatersList[num] = lateUpdatersList[lateUpdatersList.Count - 1];
		lateUpdaters[lateUpdatersList[num]] = num;
		lateUpdatersList.RemoveAt(lateUpdatersList.Count - 1);
		lateUpdaters.Remove(u);
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			return true;
		}
	}

	public void Update()
	{
		for (int num = updatersList.Count - 1; num >= 0; num--)
		{
			if (updatersList.Count > num)
			{
				updatersList[num].ManagedUpdate();
			}
		}
	}

	public void LateUpdate()
	{
		for (int num = lateUpdatersList.Count - 1; num >= 0; num--)
		{
			if (lateUpdatersList.Count > num)
			{
				lateUpdatersList[num].ManagedLateUpdate();
			}
		}
	}
}
