using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class DoorComponentManager : ComponentBaseManager<DoorComponent, DoorComponentInstance>
	{
		private HashSet<DoorComponentInstance> hasDoorsWithOrder = new HashSet<DoorComponentInstance>();

		public HashSet<DoorComponentInstance> HasDoorsWithOrder => hasDoorsWithOrder;

		public event Action<DoorComponentInstance> DoorForceOpenEvent;

		public DoorComponentManager(VillageMap map)
			: base(map)
		{
			MonoSingleton<CombatController>.Instance.AgentDiedEvent += OnAgentDied;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnWorkerRemoved;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
		}

		public override void Dispose()
		{
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.AgentDiedEvent -= OnAgentDied;
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnWorkerRemoved;
			}
			base.Dispose();
		}

		public void DoorForcedOpen(DoorComponentInstance door)
		{
			this.DoorForceOpenEvent?.Invoke(door);
		}

		protected override void OnWorkerRemoved(HumanoidInstance humanoidInstance)
		{
			Vec3Int gridPosition = GridUtils.GetGridPosition(humanoidInstance.GetPosition());
			TryRefreshDoorAnim(gridPosition);
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (take.HasDisposed || take.Stats.GetStat(StatType.Health).Current <= 0f)
			{
				Vec3Int gridPosition = GridUtils.GetGridPosition(take.GetPosition());
				TryRefreshDoorAnim(gridPosition);
			}
		}

		private void OnAgentDied(IDamageCommonAgent agent)
		{
			Vec3Int gridPosition = GridUtils.GetGridPosition(agent.GetPosition());
			TryRefreshDoorAnim(gridPosition);
		}

		private void TryRefreshDoorAnim(Vec3Int gridPosition)
		{
			if (PositionInstanceDictionary.TryGetValue(gridPosition, out var value) && InstanceComponentDictionary.TryGetValue(value, out var value2))
			{
				value2.StartCoroutineRefreshDoorAnim();
			}
		}

		private void Start()
		{
			MonoSingleton<CombatController>.Instance.AgentDiedEvent += OnAgentDied;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnWorkerRemoved;
		}
	}
}
