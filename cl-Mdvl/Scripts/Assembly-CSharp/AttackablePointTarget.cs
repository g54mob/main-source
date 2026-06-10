using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval_Pooling;
using UnityEngine;

public class AttackablePointTarget : MonoBehaviour, IDamageTakingAgent, IDamageCommonAgent, IGoapTargetable, IGameDisposable, IDisposable, IStatsOwner, IPoolableMonoBehaviour
{
	[NonSerialized]
	private MapNode mapNode;

	private Timer disposeCheckTimer;

	[field: NonSerialized]
	public VillageMap Map { get; private set; }

	public bool HasDisposed { get; private set; }

	[field: NonSerialized]
	public StatsInstance Stats { get; private set; }

	public bool HasActivePath => false;

	public DamageTakingAgentType DamageAgentType => DamageTakingAgentType.Point;

	public bool IsOnFire => Map.FireSimLogic.GetFireData(mapNode.Index) > 0f;

	public bool HasDied => HasDisposed;

	public event Action<IGameDisposable> OnDisposedEvent;

	public static AttackablePointTarget GetNewPooled()
	{
		return MonoBehaviourPool<AttackablePointTarget>.Get("AttackablePointTarget");
	}

	public void Init(VillageMap map, Vector3 worldSpacePosition)
	{
		HasDisposed = false;
		Map = map;
		mapNode = map.GetNodeByWorldPos(worldSpacePosition);
		if (mapNode == null)
		{
			throw new ArgumentException($"Tried to attack point target '{worldSpacePosition}', but MapNode at that point is null!");
		}
		base.transform.position = worldSpacePosition;
		StatInstance item = new StatInstance(new Stat(StatType.Health, 0f, 1000000f, 0f, 1000000f), Stats);
		CustomStatsInstance customStatsInstance = new CustomStatsInstance(this);
		customStatsInstance.SetCustomAttributes(new List<AttributeInstance>());
		customStatsInstance.SetCustomStats(new List<StatInstance> { item });
		Stats = customStatsInstance;
		if (disposeCheckTimer == null)
		{
			disposeCheckTimer = new Timer(3f, restartOnEnd: true);
			disposeCheckTimer.AddCallback(DisposeIfUnused);
		}
		disposeCheckTimer.Resume();
		MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
	}

	private void OnMainSceneLeaving()
	{
		Dispose();
		Stats?.Dispose();
		Stats = null;
	}

	private void DisposeIfUnused()
	{
		if (!MonoSingleton<CombatTargetManager>.IsInstantiated() || !MonoSingleton<CombatTargetManager>.Instance.HasAttackers(this))
		{
			Dispose();
		}
	}

	public void Dispose()
	{
		if (HasDisposed)
		{
			return;
		}
		HasDisposed = true;
		if (!LoadingController.IsLeavingMainScene)
		{
			this.OnDisposedEvent?.Invoke(this);
			if (MonoSingleton<CombatTargetManager>.IsInstantiated())
			{
				MonoSingleton<CombatTargetManager>.Instance.ClearAttackers(this);
			}
		}
		if (MonoSingleton<LoadingController>.IsInstantiated())
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
		}
		mapNode = null;
		Map = null;
		this.OnDisposedEvent = null;
		disposeCheckTimer.Dispose();
		disposeCheckTimer = null;
		Stats = null;
		MonoBehaviourPool<AttackablePointTarget>.Return(this);
	}

	public Vector3 GetPosition()
	{
		return mapNode.WorldPosition;
	}

	public Vec3Int GetGridPosition()
	{
		return mapNode.Position;
	}

	public List<EquipmentInstance> GetEquipment()
	{
		return null;
	}

	public Transform GetTransform()
	{
		return base.transform;
	}

	public MapNode GetNode()
	{
		return mapNode;
	}

	public NSMedieval.StatsSystem.Attribute GetAttributeOverride(AttributeType type)
	{
		return null;
	}

	public string GetDebugName()
	{
		return $"AttackablePointTarget at {base.transform.position}, gridPos '{mapNode?.Position}'";
	}
}
