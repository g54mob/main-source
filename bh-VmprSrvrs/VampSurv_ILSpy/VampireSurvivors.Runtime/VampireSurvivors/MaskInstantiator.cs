using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors;

public class MaskInstantiator : INetworkObjectInstantiator
{
	public static Action<EnemyController> OnRemoteEnemySpawned;

	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		int bindingValue = ((SpawnInfo*)spawnInfo)->GetBindingValue<int>("SyncedEnemyType");
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = core._stage.SpawnEnemy((EnemyType)bindingValue, spawnPos, asRemote: true, forceSpawn);
			Action<EnemyController> onRemoteEnemySpawned = OnRemoteEnemySpawned;
			if ((object)gameObject != null)
			{
				if (OnRemoteEnemySpawned != null)
				{
					EnemyController component = gameObject.GetComponent<EnemyController>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rbx_v3 (System.Action`1<VampireSurvivors.Objects.Characters.EnemyController>)+18] (should have been resolved before IL gen)");
				}
				return gameObject.GetComponent<CoherenceSync>();
			}
		}
		return (ICoherenceSync)new NullReferenceException();
	}

	public void Destroy(ICoherenceSync obj)
	{
		if ((object)obj.GetType() == typeof(CoherenceSync))
		{
		}
		bool flag = (object)obj.GetType() != typeof(CoherenceSync);
		Component component = null;
		if (!flag)
		{
			component = (Component)obj;
		}
		EnemyController component2 = component.GetComponent<EnemyController>();
		component2._003CKilledByAuthority_003Ek__BackingField = true;
		EnemyDMask component3 = component2.GetComponent<EnemyDMask>();
		((EnemyController)component3).Disappear();
	}

	public void OnApplicationQuit()
	{
	}

	public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
	{
	}

	public void OnUniqueObjectReplaced(ICoherenceSync instance)
	{
	}
}
