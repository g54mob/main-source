using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("DoorComponentInstance", "")]
	public class DoorComponentInstance : BaseComponentInstance, ILockable, IDoorOrGate
	{
		private const float DrawbridgeStartingDamagePercent = 0.1f;

		[NonSerialized]
		private readonly DoorComponentBlueprint blueprint;

		[SerializeField]
		private DoorOrder doorOrder;

		[SerializeField]
		private LockState lockState;

		[SerializeField]
		private GateDirection gateDirection;

		[NonSerialized]
		private Vec3Int usePosition = Vec3Int.zero;

		[NonSerialized]
		private float damagePercent;

		private readonly float repairPercentageThreshold = 80f;

		private readonly float forceOpenPercentageThreshold = 20f;

		public bool HasOrders => doorOrder != DoorOrder.None;

		public List<LockStateData> LockStates => Blueprint.LockStates;

		public LockState LockState => lockState;

		public DoorOrder DoorOrder => doorOrder;

		public Vec3Int UsePosition => usePosition;

		public bool HasUsePosition => usePosition != Vec3Int.zero;

		public DoorComponentBlueprint Blueprint => blueprint;

		public GateDirection GateDirection => gateDirection;

		public float DamagePercent => damagePercent;

		public event Action DoorLockStatusChangedEvent;

		public event Action AbortPortcullisOpeningEvent;

		public event Action AbortDrawbridgeClosingEvent;

		public event Action AbortGateOpeningEvent;

		public event Action AbortGateClosingEvent;

		public event Action<float> StartOpeningAnimationEvent;

		public event Action<float> StartClosingAnimationEvent;

		public event Action ChangeGateDirectionEvent;

		public event Action DrawbridgeClosingCanceledEvent;

		public DoorComponentInstance(BaseBuildingInstance ownerBuilding, DoorComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			lockState = this.blueprint.DefaultLockState;
			if (ShouldLock() || ShouldUnLock() || ShouldAlwaysOpen())
			{
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
			}
			doorOrder = DoorOrder.None;
			base.OwnerBuilding.FactionChangedEvent += OnFactionChanged;
			damagePercent = GetDefaultDamagePercent();
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			if (doorOrder != DoorOrder.None)
			{
				base.Map.DoorComponentManager.HasDoorsWithOrder.Add(this);
			}
		}

		public void SetDamagePercent(float damagePercent)
		{
			this.damagePercent = damagePercent;
		}

		public Vec3Int GetUsePosition(IPathfindingAgent agent)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return base.GridDataPosition;
			}
			if (blueprint.DoorType == DoorType.Portcullis)
			{
				return usePosition;
			}
			if (blueprint.DoorType == DoorType.Regular)
			{
				return GetGridPosition();
			}
			Vec3Int a = agent.GetGridPosition();
			Vec3Int result = Vec3Int.zero;
			float num = float.MaxValue;
			MapNode node = agent.GetNode();
			foreach (Vec3Int reachablePosition in base.OwnerBuilding.ReachablePositions)
			{
				Vec3Int b = reachablePosition;
				MapNode node2 = base.Map.GetNode(b);
				float num2 = Vec3Int.Distance(in a, in b);
				if (node2 != null && node != null && node2.Area != node.Area)
				{
					num2 *= 2f;
				}
				if (num2 < num && PathfinderUtil.IsPathPossible(agent, a, b))
				{
					num = num2;
					result = b;
				}
			}
			if (result.Equals(Vec3Int.zero))
			{
				return base.GridDataPosition;
			}
			return result;
		}

		public LockStateData GetLockStateData(LockState lockState)
		{
			foreach (LockStateData lockState2 in Blueprint.LockStates)
			{
				if (lockState2.LockState == lockState)
				{
					return lockState2;
				}
			}
			return null;
		}

		public LockStateData GetLockStateDataForInfo()
		{
			foreach (LockStateData lockState in Blueprint.LockStates)
			{
				if (lockState.LockState == this.lockState)
				{
					return lockState;
				}
			}
			return null;
		}

		public LockState GetLockStateForOrder()
		{
			return doorOrder switch
			{
				DoorOrder.Lock => LockState.Locked, 
				DoorOrder.Unlock => LockState.Unlocked, 
				DoorOrder.Open => LockState.AlwaysOpen, 
				_ => LockState.Undefined, 
			};
		}

		public void InvertGateDirection()
		{
			gateDirection = ((gateDirection == GateDirection.Default) ? GateDirection.Inverted : GateDirection.Default);
			this.ChangeGateDirectionEvent?.Invoke();
		}

		public void SetDefaultGateDirection()
		{
			gateDirection = GateDirection.Default;
			this.ChangeGateDirectionEvent?.Invoke();
		}

		public void SetUsePosition(Vec3Int usePosition)
		{
			this.usePosition = usePosition;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldChangeLockState()
		{
			if (lockState == LockState.ForcedOpen)
			{
				return false;
			}
			if (!ShouldLock() && !ShouldAlwaysOpen())
			{
				return ShouldUnLock();
			}
			return true;
		}

		public void StartOpeningAnimation(float animationSpeedMultiplier)
		{
			this.StartOpeningAnimationEvent?.Invoke(animationSpeedMultiplier);
		}

		public void StartClosingAnimation(float animationSpeedMultiplier)
		{
			this.StartClosingAnimationEvent?.Invoke(animationSpeedMultiplier);
		}

		public void AbortPortcullisOpening()
		{
			this.AbortPortcullisOpeningEvent?.Invoke();
		}

		public void AbortDrawbridgeClosing()
		{
			this.AbortDrawbridgeClosingEvent?.Invoke();
			damagePercent = GetDefaultDamagePercent();
		}

		public void AbortGateOpening()
		{
			this.AbortGateOpeningEvent?.Invoke();
		}

		public void AbortGateClosing()
		{
			this.AbortGateClosingEvent?.Invoke();
		}

		public void Lock(bool afterLoading = false)
		{
			if (afterLoading || lockState != LockState.Locked)
			{
				doorOrder = DoorOrder.None;
				lockState = LockState.Locked;
				base.Map.DoorComponentManager.HasDoorsWithOrder.Remove(this);
				base.OwnerBuilding.OverrideLockState(lockState);
				base.OwnerBuilding.LoadDefaultThermalModel();
				base.OwnerBuilding.LoadDefaultPathfindingPenalty();
				base.OwnerBuilding.LoadDefaultWalkSpeedMultiplier();
				base.OwnerBuilding.LoadDefaultCombatCover();
				this.DoorLockStatusChangedEvent?.Invoke();
				ForceRefreshNodes();
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
				MonoSingleton<ConstructionController>.Instance.DoorLockStateChanged(base.OwnerBuilding);
				MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
				PathfinderUtil.ClearIsPathPossibleCache();
				MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
			}
		}

		public void Unlock(bool afterLoading = false)
		{
			if ((afterLoading || lockState != LockState.Unlocked) && base.OwnerBuilding != null && !base.OwnerBuilding.HasDisposed)
			{
				doorOrder = DoorOrder.None;
				lockState = LockState.Unlocked;
				base.Map.DoorComponentManager.HasDoorsWithOrder.Remove(this);
				base.OwnerBuilding.OverrideLockState(lockState);
				base.OwnerBuilding.LoadDefaultThermalModel();
				base.OwnerBuilding.LoadDefaultPathfindingPenalty();
				base.OwnerBuilding.LoadDefaultWalkSpeedMultiplier();
				base.OwnerBuilding.LoadDefaultCombatCover();
				this.DoorLockStatusChangedEvent?.Invoke();
				ForceRefreshNodes();
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
				MonoSingleton<ConstructionController>.Instance.DoorLockStateChanged(base.OwnerBuilding);
				MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
				PathfinderUtil.ClearIsPathPossibleCache();
				MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
			}
		}

		public void SetAlwaysOpen(bool afterLoading = false)
		{
			if (afterLoading || lockState != LockState.AlwaysOpen)
			{
				doorOrder = DoorOrder.None;
				lockState = LockState.AlwaysOpen;
				base.Map.DoorComponentManager.HasDoorsWithOrder.Remove(this);
				base.OwnerBuilding.OverrideLockState(lockState);
				base.OwnerBuilding.OverrideThermalModel(Blueprint.ThermalModel);
				base.OwnerBuilding.OverridePathfindingPenalty(blueprint.PathfindingPenaltyAlwaysOpen);
				base.OwnerBuilding.OverrideWalkSpeedMultiplier(blueprint.WalkSpeedMultiplierAlwaysOpen);
				base.OwnerBuilding.OverrideCombatCover(blueprint.CoverOpen);
				this.DoorLockStatusChangedEvent?.Invoke();
				ForceRefreshNodes();
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
				MonoSingleton<ConstructionController>.Instance.DoorLockStateChanged(base.OwnerBuilding);
				MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
				PathfinderUtil.ClearIsPathPossibleCache();
				MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
			}
		}

		public void DrawbridgeClosingCanceled()
		{
			doorOrder = DoorOrder.None;
			lockState = LockState.AlwaysOpen;
			base.Map.DoorComponentManager.HasDoorsWithOrder.Remove(this);
			base.OwnerBuilding.OverrideLockState(lockState);
			base.OwnerBuilding.OverrideThermalModel(Blueprint.ThermalModel);
			base.OwnerBuilding.OverridePathfindingPenalty(blueprint.PathfindingPenaltyAlwaysOpen);
			base.OwnerBuilding.OverrideWalkSpeedMultiplier(blueprint.WalkSpeedMultiplierAlwaysOpen);
			base.OwnerBuilding.OverrideCombatCover(blueprint.CoverOpen);
			this.DrawbridgeClosingCanceledEvent?.Invoke();
			ForceRefreshNodes();
			MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
			MonoSingleton<ConstructionController>.Instance.DoorLockStateChanged(base.OwnerBuilding);
			MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
			PathfinderUtil.ClearIsPathPossibleCache();
			MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
		}

		private void ForceRefreshNodes()
		{
			if (base.Positions.Count == 1)
			{
				GetNode()?.ForceRefreshWithNeighbours();
				return;
			}
			foreach (Vec3Int position in base.Positions)
			{
				base.Map?.GetNode(position)?.ForceRefreshWithNeighbours();
			}
		}

		private float GetDefaultDamagePercent()
		{
			if (blueprint.DoorType != DoorType.Drawbridge)
			{
				return 1f;
			}
			return 0.1f;
		}

		private void OnFactionChanged(FactionOwnership faction)
		{
			ForceRefreshNodes();
		}

		public void SetDoorOrder(DoorOrder doorOrder)
		{
			if (lockState != LockState.ForcedOpen && this.doorOrder != doorOrder)
			{
				this.doorOrder = doorOrder;
				base.Map.DoorComponentManager.HasDoorsWithOrder.Add(this);
				if (ShouldLock() || ShouldUnLock() || ShouldAlwaysOpen())
				{
					MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldLock()
		{
			if (doorOrder == DoorOrder.Lock)
			{
				return lockState != LockState.Locked;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldUnLock()
		{
			if (doorOrder == DoorOrder.Unlock)
			{
				return lockState != LockState.Unlocked;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldAlwaysOpen()
		{
			if (doorOrder == DoorOrder.Open)
			{
				return lockState != LockState.AlwaysOpen;
			}
			return false;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				this.DoorLockStatusChangedEvent = null;
				this.AbortPortcullisOpeningEvent = null;
				this.AbortDrawbridgeClosingEvent = null;
				this.AbortGateOpeningEvent = null;
				this.AbortGateClosingEvent = null;
				this.StartOpeningAnimationEvent = null;
				this.StartClosingAnimationEvent = null;
				this.ChangeGateDirectionEvent = null;
				this.DrawbridgeClosingCanceledEvent = null;
				base.Map.DoorComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public void SetupLocks()
		{
			switch (lockState)
			{
			case LockState.Locked:
				Lock(afterLoading: true);
				return;
			case LockState.Unlocked:
				Unlock(afterLoading: true);
				return;
			case LockState.AlwaysOpen:
				SetAlwaysOpen(afterLoading: true);
				return;
			case LockState.ForcedOpen:
				SetForcedOpen(afterLoading: true);
				return;
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Doors\\DoorComponentInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Missing lock state for door building at grid position ");
				messageBuilder.AppendFormatted(base.GridPosition);
			}
			Log.Warning(messageBuilder);
		}

		public float GetMaxClampedDamage(float incomingDamage)
		{
			if (lockState == LockState.ForcedOpen)
			{
				return incomingDamage;
			}
			StatInstance statInstance = base.OwnerBuilding?.Stats?.GetStat(StatType.Health);
			if (statInstance == null)
			{
				return incomingDamage;
			}
			float current = statInstance.Current;
			float num = statInstance.Max / 100f * forceOpenPercentageThreshold;
			if (current - incomingDamage <= 0f)
			{
				return current - num;
			}
			return incomingDamage;
		}

		protected override void OnHealthUpdated(StatInstance healthStat)
		{
			if (healthStat.Current <= healthStat.Max / 100f * forceOpenPercentageThreshold)
			{
				SetForcedOpen();
			}
		}

		protected override void OnBuildingRepairingTick(StatInstance healthStat)
		{
			if (healthStat.Current >= healthStat.Max / 100f * repairPercentageThreshold)
			{
				if (blueprint.DoorType == DoorType.Regular)
				{
					Unlock();
				}
				else
				{
					Lock();
				}
			}
		}

		private void SetForcedOpen(bool afterLoading = false)
		{
			if (afterLoading || lockState != LockState.ForcedOpen)
			{
				doorOrder = DoorOrder.None;
				lockState = LockState.ForcedOpen;
				base.Map.DoorComponentManager.HasDoorsWithOrder.Remove(this);
				base.OwnerBuilding.OverrideLockState(lockState);
				base.OwnerBuilding.OverrideThermalModel(Blueprint.ThermalModel);
				base.OwnerBuilding.OverridePathfindingPenalty(blueprint.PathfindingPenaltyAlwaysOpen);
				base.OwnerBuilding.OverrideWalkSpeedMultiplier(blueprint.WalkSpeedMultiplierAlwaysOpen);
				base.OwnerBuilding.OverrideCombatCover(blueprint.CoverOpen);
				this.DoorLockStatusChangedEvent?.Invoke();
				base.Map.DoorComponentManager.DoorForcedOpen(this);
				ForceRefreshNodes();
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChanged(this);
				MonoSingleton<ConstructionController>.Instance.DoorLockStateChanged(base.OwnerBuilding);
				MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
				PathfinderUtil.ClearIsPathPossibleCache();
				MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.WriteEnum("lockState", lockState);
			serializer.WriteEnum("doorOrder", doorOrder);
			serializer.WriteEnum("gateDirection", gateDirection);
		}

		public DoorComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<DoorComponentRepository, DoorComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Doors\\DoorComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in DoorComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				lockState = (LockState)deserializer.ReadInt("lockState", (int)blueprint.DefaultLockState);
				doorOrder = (DoorOrder)deserializer.ReadInt("doorOrder");
				gateDirection = (GateDirection)deserializer.ReadInt("gateDirection");
				damagePercent = GetDefaultDamagePercent();
			}
		}
	}
}
