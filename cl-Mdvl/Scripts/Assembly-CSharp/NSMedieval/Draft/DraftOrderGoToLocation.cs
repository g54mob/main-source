using FoxyVoxel.Logging;
using NSEipix;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Draft
{
	public class DraftOrderGoToLocation : DraftOrder
	{
		private const float RetryForTime = 2f;

		private float startTime;

		public Vec3Int TargetGridPosition { get; private set; }

		public UnitCombatModeType Stance { get; private set; }

		public DraftOrderGoToLocation(Vector3 targetPosition, UnitCombatModeType stance = UnitCombatModeType.None)
			: base(DraftOrderType.GoToLocation, HourType.Draft)
		{
			TargetGridPosition = targetPosition.ToGridVec3Int();
			Stance = stance;
		}

		public override bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			return true;
		}

		public override void Execute(HumanoidInstance instance)
		{
			MapNode node = instance.Map.GetNode(TargetGridPosition);
			if (node == null || !node.IsWalkable)
			{
				return;
			}
			TargetGridPosition = node.Position;
			if (Stance != UnitCombatModeType.None)
			{
				instance.WorkerBehaviour.SetCombatMode(Stance);
				if (Stance == UnitCombatModeType.DraftedHoldGround)
				{
					instance.CombatAi.SetState(CombatAiState.HoldGroundGridPosition, TargetGridPosition);
				}
				else
				{
					GoToTargetPosition(instance);
				}
			}
			else
			{
				if (instance.WorkerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
				{
					instance.WorkerBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
				}
				GoToTargetPosition(instance);
			}
		}

		public override void OnDraftEnd(HumanoidInstance instance)
		{
			instance.PathDriver?.Abort();
		}

		private void GoToTargetPosition(HumanoidInstance instance)
		{
			PathfinderAgentDriver pathDriver = instance.PathDriver;
			if (pathDriver == null)
			{
				return;
			}
			P2PPath path = P2PPath.Construct(instance, TargetGridPosition);
			pathDriver.ExecutePath(new PathfinderDriverExecCfg
			{
				Path = path,
				StatusCb = delegate(bool result)
				{
					if (!result)
					{
						Log.Warning("Could not process draft-move pathfinder request.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Draft\\DraftOrderGoToLocation.cs");
					}
				}
			});
		}
	}
}
