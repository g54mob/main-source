using System;
using System.Collections.Concurrent;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.Village.Map;
using UnityEngine;

public class RaidPointOfInterestManager : IDisposable
{
	private readonly ConcurrentDictionary<int, Vector3> regionToPointOfInterest;

	private Timer updateTimer;

	public RaidPointOfInterestManager()
	{
		regionToPointOfInterest = new ConcurrentDictionary<int, Vector3>();
		updateTimer = new Timer(5f, restartOnEnd: true);
		updateTimer.AddCallback(Update);
	}

	public bool TryGetPointOfInterest(CreatureBase creature, out Vector3 point)
	{
		Region region = creature?.GetNode()?.Region;
		if (region == null)
		{
			point = default(Vector3);
			return false;
		}
		return regionToPointOfInterest.TryGetValue(region.UniqueId, out point);
	}

	private void Update()
	{
		regionToPointOfInterest.Clear();
		foreach (EnemyBehaviour item in MonoSingleton<NPCManager>.Instance.IterateNPCs<EnemyBehaviour>())
		{
			IDamageTakingAgent damageTakingAgent = item?.Humanoid.GetTarget();
			if (!CombatUtils.IsNullOrDisposed(item?.Humanoid, damageTakingAgent) && damageTakingAgent is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.HasComponentInstance<DoorComponentInstance>())
			{
				MapNode node = item.Humanoid.GetNode();
				MapNode node2 = damageTakingAgent.GetNode();
				if (node.Region != null && node2.Region != null)
				{
					regionToPointOfInterest[node.Region.UniqueId] = node2.WorldPosition;
					regionToPointOfInterest[node2.Region.UniqueId] = node2.WorldPosition;
				}
			}
		}
	}

	public void Dispose()
	{
		regionToPointOfInterest.Clear();
		updateTimer?.Dispose();
		updateTimer = null;
	}
}
