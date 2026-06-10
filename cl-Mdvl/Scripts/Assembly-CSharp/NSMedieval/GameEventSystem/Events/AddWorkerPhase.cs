using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Village.Map;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("AddWorkerPhase", "")]
	public class AddWorkerPhase : SingleExecutePhaseBase
	{
		private IWorkerPhaseDataHolder ExternalDataHolder => base.EventInstance as IWorkerPhaseDataHolder;

		private HumanoidInstance HumanoidToAdd => ExternalDataHolder.HumanoidToAdd;

		public AddWorkerPhase()
		{
		}

		protected override void Execute()
		{
			VerifyEventIsCompatible();
			GameEventPhaseBase.Logger.Info("Adding humanoid");
			GetNewWorkerStartPosition(HumanoidToAdd.WorkerBehaviour.HumanType.WalkableModelFriendly, out var workerStart, out var workerTarget);
			HumanoidToAdd.UpdatePosition(workerStart.WorldPosition);
			foreach (GameEvent.StatSetting stat in base.Blueprint.Stats)
			{
				HumanoidToAdd.Stats.GetStat(stat.Stat).SetCurrent(stat.Value);
			}
			if (base.Blueprint.Wounds != null)
			{
				foreach (string wound in base.Blueprint.Wounds.GetWounds())
				{
					HumanoidToAdd.Stats.StartEffector(wound);
				}
			}
			MonoSingleton<RtsCamera>.Instance.JumpTo(HumanoidToAdd.GetPosition());
			MonoSingleton<WorkerController>.Instance.CreateWorker(HumanoidToAdd);
			HumanoidToAdd.DestroyEquipment();
			foreach (string item in base.Blueprint.Equipment)
			{
				HumanPreset byID = Repository<WorkerPresetRepository, HumanPreset>.Instance.GetByID(item);
				if (!(byID == null))
				{
					NPCManager.ApplyEquipmentForWorker(HumanoidToAdd, byID);
				}
			}
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				HumanoidToAdd.GetGoapAgent()?.StartTicker();
			});
			foreach (EquipmentInstance equipment in HumanoidToAdd.Inventory.GetEquipments())
			{
				equipment.StartEquipEffects(HumanoidToAdd.Stats);
			}
			if (workerTarget != null)
			{
				WalkWorkerTo(HumanoidToAdd, workerTarget.Position);
			}
			HumanoidToAdd.WorkerBehaviour.WorkerSocial.HandleAffectionEffectorTowardOthers("AffectionWelcome");
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				worker.WorkerBehaviour.WorkerSocial.HandleAffectionEffectorToward(HumanoidToAdd, "AffectionWelcome");
			}
		}

		private void VerifyEventIsCompatible()
		{
			if (!(base.EventInstance is IWorkerPhaseDataHolder))
			{
				throw new Exception("Incompatible event type for this phase! The event instance must implement the IWorkerPhaseDataHolder interface.");
			}
		}

		private static bool GetNewWorkerStartPosition(in WalkableModel walkableModel, out MapNode workerStart, out MapNode workerTarget)
		{
			List<MapNode> outStartingNodes;
			bool startAndTarget = MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(walkableModel, out workerTarget, out outStartingNodes, 1);
			if (startAndTarget)
			{
				workerStart = outStartingNodes[0];
				return startAndTarget;
			}
			List<MapNode> nodesNearEdge = NPCStartPositionManager.GetNodesNearEdge(16, null, skipUnderwaterNodes: true);
			if (nodesNearEdge.Count == 0)
			{
				nodesNearEdge = NPCStartPositionManager.GetNodesNearEdge(16, null, skipUnderwaterNodes: false);
			}
			workerStart = nodesNearEdge.PickRandom();
			workerTarget = null;
			return startAndTarget;
		}

		private static void WalkWorkerTo(HumanoidInstance humanoid, Vec3Int targetPosition)
		{
			Agent goapAgent = humanoid.GetGoapAgent();
			WalkToPositionGoal walkToPositionGoal = new WalkToPositionGoal(goapAgent);
			walkToPositionGoal.SetPosition(targetPosition);
			goapAgent.Abort();
			goapAgent.ForceNextGoal(walkToPositionGoal);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public AddWorkerPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
