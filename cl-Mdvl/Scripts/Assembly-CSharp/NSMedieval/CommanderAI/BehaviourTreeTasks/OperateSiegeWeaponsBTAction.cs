using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Construction;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Fires siege weapons by asynchronously tasking units from the given source group when possible")]
	public class OperateSiegeWeaponsBTAction : UnitsBTActionBaseThread
	{
		public BBParameter<List<IDamageTakingAgent>> artilleryTargets;

		private List<OperateSiegeWeaponInstance> instances;

		private List<Vec3Int> plannedConstructionPoints;

		private List<BaseBuildingInstance> availableSiegeWeapons;

		protected override string info => $"{sourceUnits} operate siege weapons against {artilleryTargets}";

		protected override void OnStart()
		{
			if (artilleryTargets?.value == null || artilleryTargets.value.Count == 0)
			{
				EndAction(success: false);
				return;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (CombatAiUtils.IsAgentDefeated(unit.Humanoid))
				{
					EndAction(success: false);
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(89, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Ending action because at least one of the artillery squad members is defeated (agent: '");
						messageBuilder.AppendFormatted(unit.Humanoid);
						messageBuilder.AppendLiteral("')");
					}
					Log.Debug(messageBuilder);
					return;
				}
			}
			Log.Trace("Start", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
			base.OnStart();
		}

		protected override bool OnThread()
		{
			DebugTimer.StartTimer("OperateSiegeWeapons InitThread");
			if (instances == null)
			{
				instances = new List<OperateSiegeWeaponInstance>();
			}
			instances.Clear();
			if (plannedConstructionPoints == null)
			{
				plannedConstructionPoints = new List<Vec3Int>();
			}
			plannedConstructionPoints.Clear();
			if (availableSiegeWeapons == null)
			{
				availableSiegeWeapons = new List<BaseBuildingInstance>();
			}
			availableSiegeWeapons.Clear();
			availableSiegeWeapons.AddRange(base.agent.DeployedSiegeWeapons);
			using PooledQueue<string> pooledQueue = QueuePool<string>.GetJanitor();
			foreach (var (obj, num2) in base.agent.SiegeWeaponInventory)
			{
				if (num2 > 0)
				{
					for (int i = 0; i < num2; i++)
					{
						pooledQueue.Enqueue(obj);
					}
				}
			}
			using PooledQueue<BaseBuildingInstance> pooledQueue2 = QueuePool<BaseBuildingInstance>.GetJanitor();
			foreach (BaseBuildingInstance deployedSiegeWeapon in base.agent.Agent.UnitGroup.DeployedSiegeWeapons)
			{
				if (deployedSiegeWeapon.IsUnderConstruction)
				{
					pooledQueue2.Enqueue(deployedSiegeWeapon);
				}
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ToConstruct: ");
				messageBuilder.AppendFormatted(pooledQueue.Count);
				messageBuilder.AppendLiteral(", WeaponsUnderConstruction: (");
				messageBuilder.AppendFormatted(pooledQueue2.Count);
				messageBuilder.AppendLiteral(")");
			}
			Log.Debug(messageBuilder);
			using PooledList<MapNode> pooledList = FloodFillUtil.GenerateGridSurfaceNodes(base.Map, 5);
			using PooledList<CommanderAIUnit> pooledList2 = base.Units.WherePooled((CommanderAIUnit unit) => !CombatUtils.IsNullOrDisposed(unit.Humanoid));
			FVLogTraceInterpolationHandler messageBuilder2;
			while (pooledList2.Count > 0)
			{
				OperateSiegeWeaponInstance item;
				BaseBuildingInstance building;
				if (pooledQueue.TryDequeue(out var obj2))
				{
					CommanderAIUnit commanderAIUnit = pooledList2.PopFront();
					item = new OperateSiegeWeaponInstance(availableSiegeWeapons, base.agent, artilleryTargets.value, base.Map, commanderAIUnit, plannedConstructionPoints, obj2, pooledList);
					messageBuilder2 = new FVLogTraceInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Creating 'construct new weapon' instance for ");
						messageBuilder2.AppendFormatted(commanderAIUnit.Humanoid);
					}
					Log.Trace(messageBuilder2);
				}
				else if (pooledQueue2.TryDequeue(out building))
				{
					CommanderAIUnit commanderAIUnit2 = pooledList2.PopMinItem((CommanderAIUnit unit) => unit.Humanoid.DistanceSquared(building));
					item = new OperateSiegeWeaponInstance(availableSiegeWeapons, base.agent, artilleryTargets.value, base.Map, commanderAIUnit2, plannedConstructionPoints, building);
					messageBuilder2 = new FVLogTraceInterpolationHandler(70, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Creating 'finish existing construction' instance for ");
						messageBuilder2.AppendFormatted(commanderAIUnit2.Humanoid);
						messageBuilder2.AppendLiteral(", building '");
						messageBuilder2.AppendFormatted(building.BlueprintId);
						messageBuilder2.AppendLiteral("' at ");
						messageBuilder2.AppendFormatted(building.GetGridPosition());
					}
					Log.Trace(messageBuilder2);
				}
				else
				{
					CommanderAIUnit commanderAIUnit3 = pooledList2.PopFront();
					item = new OperateSiegeWeaponInstance(availableSiegeWeapons, base.agent, artilleryTargets.value, base.Map, commanderAIUnit3, plannedConstructionPoints);
					messageBuilder2 = new FVLogTraceInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Creating 'man weapon' instance for ");
						messageBuilder2.AppendFormatted(commanderAIUnit3.Humanoid);
					}
					Log.Trace(messageBuilder2);
				}
				instances.Add(item);
			}
			foreach (OperateSiegeWeaponInstance item2 in instances.IterateInReverseDynamic())
			{
				if (!item2.InitThread())
				{
					messageBuilder2 = new FVLogTraceInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Instance failed to init, removing from list (bound to ");
						messageBuilder2.AppendFormatted(item2.Unit.Humanoid);
						messageBuilder2.AppendLiteral(")");
					}
					Log.Trace(messageBuilder2);
					instances.Remove(item2);
				}
			}
			if (instances.Count <= 0)
			{
				DebugTimer.EndTimer("OperateSiegeWeapons InitThread");
				Log.Trace("All instances FAILED init, failing action", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
				isEnabled = false;
				return isEnabled;
			}
			messageBuilder2 = new FVLogTraceInterpolationHandler(35, 1, out var isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
			if (isEnabled2)
			{
				messageBuilder2.AppendFormatted(instances.Count);
				messageBuilder2.AppendLiteral(" instances successfully initialized");
			}
			Log.Trace(messageBuilder2);
			DebugTimer.EndTimer("OperateSiegeWeapons InitThread");
			isEnabled = true;
			return isEnabled;
		}

		protected override void OnDoneCallback(bool result)
		{
			if (!result)
			{
				EndAction(success: false);
				return;
			}
			foreach (OperateSiegeWeaponInstance instance in instances)
			{
				instance.OnDoneCallback();
			}
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnBuildingFinished;
		}

		protected override void OnTick()
		{
			if (instances == null || base.IsWaitingForThreadJobDiscard || base.IsThreadJobRunning)
			{
				return;
			}
			int num = 0;
			while (num < artilleryTargets.value.Count)
			{
				if (CombatAiUtils.IsAgentDefeated(artilleryTargets.value[num]))
				{
					artilleryTargets.value.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			num = 0;
			while (num < instances.Count)
			{
				OperateSiegeWeaponInstance operateSiegeWeaponInstance = instances[num];
				if (!operateSiegeWeaponInstance.Tick())
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Instance failed tick, removing from list (bound to ");
						messageBuilder.AppendFormatted(operateSiegeWeaponInstance.Unit.Humanoid);
						messageBuilder.AppendLiteral(")");
					}
					Log.Trace(messageBuilder);
					instances.RemoveAt(num);
					if (operateSiegeWeaponInstance.ShouldEndAction)
					{
						EndAction(success: false);
						return;
					}
				}
				else
				{
					num++;
				}
			}
			if (instances.Count <= 0)
			{
				EndAction(success: false);
			}
		}

		private void OnBlueprintPlaced(BaseBuildingInstance building)
		{
			foreach (OperateSiegeWeaponInstance instance in instances)
			{
				instance.OnBlueprintPlaced(building);
			}
		}

		private void OnBuildingFinished(BaseBuildingInstance building)
		{
			foreach (OperateSiegeWeaponInstance instance in instances)
			{
				instance.OnBuildingFinished(building);
			}
		}

		protected override void OnCancelledThreadDone()
		{
			Dispose();
		}

		protected override void OnStop()
		{
			Log.Trace("Stop", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponsBTAction.cs");
			if (!base.IsWaitingForThreadJobDiscard)
			{
				Dispose();
			}
		}

		private void Dispose()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnBuildingFinished;
			}
			if (instances != null)
			{
				instances.Clear();
			}
		}
	}
}
