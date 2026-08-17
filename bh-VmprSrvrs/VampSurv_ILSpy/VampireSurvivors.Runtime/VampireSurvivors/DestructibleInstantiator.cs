using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace VampireSurvivors;

public class DestructibleInstantiator : INetworkObjectInstantiator
{
	public static Action<Destructible> OnRemoteDestructibleSpawned;

	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		int bindingValue = ((SpawnInfo*)spawnInfo)->GetBindingValue<int>("PropType");
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._destructibleFactory != null)
			{
				ObjectPool pool = stage._destructibleFactory.GetPool((PropType)bindingValue);
				if ((object)pool != null)
				{
					Destructible objectComponent = pool.GetObjectComponent<Destructible>();
					if ((object)objectComponent != null)
					{
						objectComponent.Init((PropType)bindingValue);
						Action<Destructible> onRemoteDestructibleSpawned = OnRemoteDestructibleSpawned;
						if (OnRemoteDestructibleSpawned != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v173 @ rax_v8 (System.Action`1<VampireSurvivors.Objects.Destructible>)+18] (should have been resolved before IL gen)");
						}
						return objectComponent.GetComponent<CoherenceSync>();
					}
				}
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
		Destructible component2 = component.GetComponent<Destructible>();
		component2.RemoteDestroy();
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
