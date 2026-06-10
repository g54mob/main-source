using System.Collections.Generic;
using NSEipix;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Issue move order on target position or unit")]
	public class MoveBTAction : UnitsBTActionBase
	{
		public enum MoveMode
		{
			Position = 0,
			Unit = 1
		}

		public MoveMode moveMode;

		[ShowIf("moveMode", 1)]
		public BBParameter<CommanderAIUnit> targetUnit;

		[ShowIf("moveMode", 1)]
		public bool followUnit;

		[ShowIf("moveMode", 0)]
		public BBParameter<Vec3Int> targetPosition;

		[MinValue(0f)]
		public float desiredSpacing;

		protected override string info
		{
			get
			{
				if (moveMode == MoveMode.Position)
				{
					return $"{base.info}: Move to {targetPosition}";
				}
				if (followUnit)
				{
					return $"{base.info}: Follow {targetUnit}";
				}
				return $"{base.info}: Stand behind {targetUnit}";
			}
		}

		protected override void OnStart()
		{
			if (base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
			}
		}

		private void ExecuteMoveToUnit()
		{
			HumanoidInstance humanoidInstance = targetUnit?.value?.Humanoid;
			if (CombatUtils.IsNullOrDisposed(humanoidInstance))
			{
				EndAction(success: false);
				return;
			}
			if (followUnit)
			{
				foreach (CommanderAIUnit unit in base.Units)
				{
					unit.CurrentOrder = new MoveOrder(humanoidInstance);
				}
				return;
			}
			MapNode targetHumanoidNode = humanoidInstance.GetNode();
			Transform transform = humanoidInstance.GetTransform();
			if ((object)transform == null)
			{
				EndAction(success: false);
				return;
			}
			Vector2 targetHumanoidLookAt = transform.forward.ToVector2XZ();
			int maxNodes = base.UnitCount + (int)(desiredSpacing * desiredSpacing);
			using PooledList<MapNode> pooledList = FloodFillUtil.ScoreWalkable(humanoidInstance, targetHumanoidNode, 100f, maxNodes, delegate(MapNode node)
			{
				Vector2 vector = targetHumanoidNode.WorldPosition.ToVector2XZ() - node.WorldPosition.ToVector2XZ();
				float magnitude = vector.magnitude;
				float num = Vector2.Dot(targetHumanoidLookAt, vector.normalized) * 10f;
				return magnitude + 1000f * ((magnitude <= desiredSpacing) ? 1f : 0f) + num;
			}, debugDraw: false, !targetHumanoidNode.IsWater, null, null, (MapNode node) => !node.HasFirePresence());
			using IEnumerator<MapNode> enumerator2 = (object)pooledList.GetEnumerator();
			foreach (CommanderAIUnit unit2 in base.Units)
			{
				if (!enumerator2.MoveNext())
				{
					break;
				}
				unit2.CurrentOrder = new MoveOrder(enumerator2.Current);
			}
		}

		private void ExecuteMoveToPosition()
		{
			using IEnumerator<MapNode> enumerator = FloodFillUtil.IterateFloodFillConnections(base.agent.Agent.Map.GetNode(targetPosition.value), 100f).GetEnumerator();
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (!enumerator.MoveNext())
				{
					unit.CurrentOrder = MoveOrder.Stop(unit);
				}
				else if (enumerator.Current.IsWalkable)
				{
					unit.CurrentOrder = new MoveOrder(enumerator.Current);
				}
			}
		}

		protected override void OnTick()
		{
			if (base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			switch (moveMode)
			{
			case MoveMode.Position:
				ExecuteMoveToPosition();
				break;
			case MoveMode.Unit:
				ExecuteMoveToUnit();
				break;
			}
			if (base.Units.AnyNonAlloc((CommanderAIUnit unit) => unit.Humanoid.HasDiedOrFainted))
			{
				EndAction(success: false);
				return;
			}
			if (moveMode == MoveMode.Unit && followUnit)
			{
				HumanoidInstance humanoidInstance = targetUnit?.value?.Humanoid;
				if (humanoidInstance != null && humanoidInstance.HasDiedOrFainted)
				{
					EndAction(success: false);
				}
				return;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (unit.GetOrder<MoveOrder>().Destination.ToGridVec3Int() != unit.Humanoid.GetGridPosition())
				{
					return;
				}
			}
			EndAction(success: true);
		}

		protected override void OnStop(bool interrupted)
		{
			base.OnStop(interrupted);
			if (interrupted)
			{
				return;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				unit.CurrentOrder = MoveOrder.Stop(unit);
			}
		}
	}
}
