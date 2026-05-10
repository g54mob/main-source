using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class ActionHubKillSafely : AgentHubAction
	{
		private PooledRef<Customer> _targetRef;

		private AgentActionSuckBlood _suckBloodAction;

		private WorkerActionHypnotize _hypnotizeAction;

		private AgentActionMove _moveAction;

		private bool _foundMoveTarget;

		private NamedLayerMask _doorLayerMask = new NamedLayerMask("Door");

		public Customer Target
		{
			get
			{
				if (!_targetRef.TryGetValue(out var outValue))
				{
					return null;
				}
				return outValue;
			}
			set
			{
				_hypnotizeAction.Human = value;
				_suckBloodAction.Human = value;
				_targetRef = new PooledRef<Customer>(value);
			}
		}

		public ActionHubKillSafely()
		{
			_suckBloodAction = new AgentActionSuckBlood(null);
			_hypnotizeAction = new WorkerActionHypnotize(null);
			_moveAction = new AgentActionMove(Vector3.zero, playBlockedAction: true);
			AddScoredAction(_suckBloodAction, CalculateKillScore);
			AddScoredAction(_hypnotizeAction, CalculateHypnotizeScore);
			AddScoredAction(_moveAction, CalculateMoveScore);
			AddScoredAction(new AgentActionWait(), CalculateWaitScore);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			if ((object)Target == null)
			{
				return true;
			}
			return Target.IsDead;
		}

		protected override bool CanAnyActionBePerformed(Agent agent)
		{
			if (NavMeshRebuilder.IsRebuilding)
			{
				return false;
			}
			if (!(agent is Worker worker))
			{
				return false;
			}
			if (!worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis))
			{
				return false;
			}
			if (agent.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			Customer target = Target;
			if ((object)target == null)
			{
				return false;
			}
			if (target.IsDead)
			{
				return false;
			}
			BuildingRoomsContainerManager instance = MonoSingleton<BuildingRoomsContainerManager>.Instance;
			if (!instance.HasAWorkerRoom() && !instance.HasAVampireRoom())
			{
				return false;
			}
			return base.CanAnyActionBePerformed(agent);
		}

		protected override void PreCheck(Agent agent)
		{
			base.PreCheck(agent);
			RoomBuilding roomBuilding = Target.RoomObject.CurrentRoom;
			if (Target.ControllingVampire == agent && agent.RoomObject.CurrentRoom.IsWorkerRoom())
			{
				roomBuilding = agent.RoomObject.CurrentRoom;
			}
			else if (roomBuilding.IsCustomerRoom())
			{
				Func<RoomBuilding, bool> filter = (RoomBuilding room) => !room.IsCustomerRoom() && !room.IsExterior();
				Func<RoomBuilding, int> scoreChange = (RoomBuilding room) => room.IsVampireRoom() ? 1 : 0;
				roomBuilding = roomBuilding.GetNearestRoom(filter, scoreChange);
			}
			_moveAction.Position = roomBuilding.GetInteractionPoint();
			_foundMoveTarget = !_moveAction.Position.Equals(Vector3.zero);
		}

		private int CalculateKillScore(Agent agent)
		{
			Customer target = Target;
			if ((object)target == null)
			{
				return -1;
			}
			if (target.RoomObject.CurrentRoom.IsCustomerRoom() || target.RoomObject.CurrentRoom.IsExterior())
			{
				return -1;
			}
			return 100;
		}

		private int CalculateHypnotizeScore(Agent agent)
		{
			Customer target = Target;
			if ((object)target == null)
			{
				return -1;
			}
			if ((object)target.ControllingVampire != null)
			{
				return -1;
			}
			return 50;
		}

		private int CalculateMoveScore(Agent agent)
		{
			if (!_foundMoveTarget)
			{
				return -1;
			}
			return 30;
		}

		private int CalculateWaitScore(Agent agent)
		{
			Customer target = Target;
			if ((object)target == null)
			{
				return -1;
			}
			if ((object)agent != target.ControllingVampire)
			{
				return -1;
			}
			if (target.Movement.Velocity.sqrMagnitude < 0.0001f)
			{
				return -1;
			}
			if (agent.RoomObject.CurrentRoom.IsCustomerRoom() || agent.RoomObject.CurrentRoom.IsExterior())
			{
				return -1;
			}
			if (target.RoomObject.CurrentRoom.IsCustomerRoom() || target.RoomObject.CurrentRoom.IsExterior())
			{
				return 40;
			}
			return -1;
		}
	}
}
