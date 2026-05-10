using System;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	internal sealed class WorkerIdleState : WorkerState
	{
		private float _nextIdleMove;

		private const float IdleRadius = 5f;

		private static readonly Vector2 IdleRange = new Vector2(3f, 5f);

		private static readonly NamedLayerMask MoveTargetMask = new NamedLayerMask("Furniture", "InterractionZone", "AgentInterCollision");

		public override void OnStateEnter()
		{
			ResetRandomMoveCooldown();
		}

		public override void OnStateExit()
		{
		}

		public override void Update()
		{
			if (base.parent.ActionPlayer.CurrentAction == null && base.parent.ActionPlayer.TryGetNextAction<AgentAction>(out var outAction))
			{
				PlayAction(outAction);
			}
		}

		public override void SpreadUpdate()
		{
			bool flag = base.parent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
			if (flag && base.parent.AutonomousActions.TryGetAutonomousAction(out var outAction) && base.parent.ActionPlayer.TryForceAction(outAction, outAction.Priority))
			{
				PlayAction(outAction);
			}
			else if (flag && base.parent.ActionPlayer.ActionQueue.Count <= 1 && (base.parent.ActionPlayer.ActionQueue.Count != 1 || base.parent.ActionPlayer.CurrentAction is AgentActionMove))
			{
				if (base.parent.ChoreAssigner.TryGetChore(out var p_outChore))
				{
					p_outChore.Priority = EActionPriority.WorkerAutonomous;
					base.parent.ActionPlayer.AddAction(p_outChore);
					PlayAction(p_outChore);
				}
				else
				{
					TryRandomMove();
				}
			}
		}

		private void PlayAction(AgentAction action)
		{
			if (!(action is WorkerAction p_action))
			{
				if (action is AgentAction<Agent> p_action2)
				{
					base.fsm.SetState(new WorkerActionState<Agent>(p_action2));
				}
			}
			else
			{
				base.fsm.SetState(new WorkerActionState<Worker>(p_action));
			}
		}

		private void TryRandomMove()
		{
			if (base.parent.AutonomousActions.Paused || !Worker.CVarAutonomyEnabled.GetCurrentValue() || base.parent.ActionPlayer.CurrentAction is AgentActionMove)
			{
				return;
			}
			base.parent.Selection.InterCollider.enabled = false;
			if (Physics.CheckSphere(base.parent.transform.position, 0.2f, MoveTargetMask, QueryTriggerInteraction.Ignore))
			{
				base.parent.Selection.InterCollider.enabled = true;
				TryMove(5);
				return;
			}
			base.parent.Selection.InterCollider.enabled = true;
			if (!base.parent.ChoreAssigner.ObjectLock.IsLocked() && !base.parent.ObjectHolding.IsCurrentlyHolding && !(Time.time < _nextIdleMove))
			{
				if (base.parent.RoomObject.CurrentRoom.IsExterior() && EntranceResolver.EntranceExists(base.parent.RandomMovementMask))
				{
					base.parent.ActionPlayer.Play(new AgentActionEnterBar(forceEnter: true));
				}
				else
				{
					TryMove(1);
				}
			}
			void TryMove(int iterations)
			{
				for (int i = 0; i < iterations; i++)
				{
					if (base.parent.RoomAssignations.AssignedRooms.Count > 0)
					{
						if (!base.parent.IsInRoomAssignation(base.parent.RoomAssignations))
						{
							Func<RoomBuilding, bool> filter = (RoomBuilding room) => base.parent.RoomAssignations.HasRoom(room);
							Vector3 interactionPoint = base.parent.RoomObject.CurrentRoom.GetNearestRoom(filter, null).GetInteractionPoint();
							base.parent.ActionPlayer.Play(new AgentActionMove(interactionPoint));
							ResetRandomMoveCooldown();
							break;
						}
						if (DoRandomMoveInAssignation())
						{
							break;
						}
					}
					else if (DoRandomMove())
					{
						break;
					}
				}
			}
		}

		private bool DoRandomMove()
		{
			Vector3 vector = (UnityEngine.Random.insideUnitCircle * 5f).ToHorizontal3D();
			if (NavMesh.SamplePosition(base.parent.transform.position + vector, out var hit, 1f, base.parent.RandomMovementAreaMask))
			{
				ResetRandomMoveCooldown();
				base.parent.ActionPlayer.Play(new AgentActionMove(hit.position));
				return true;
			}
			return false;
		}

		private bool DoRandomMoveInAssignation()
		{
			Vector3 vector = (UnityEngine.Random.insideUnitCircle * 5f).ToHorizontal3D();
			if (!NavMesh.SamplePosition(base.parent.transform.position + vector, out var hit, 1f, base.parent.RandomMovementAreaMask))
			{
				return false;
			}
			if (!Physics.Raycast(hit.position + Vector3.up, Vector3.down, out var hitInfo, 1.5f, 1 << LayerMask.NameToLayer("Floor")))
			{
				return false;
			}
			BuildingFloor componentInParent = hitInfo.collider.GetComponentInParent<BuildingFloor>();
			if ((object)componentInParent == null)
			{
				return false;
			}
			if (!base.parent.RoomAssignations.HasRoom(componentInParent.LinkedRoom))
			{
				return false;
			}
			ResetRandomMoveCooldown();
			base.parent.ActionPlayer.Play(new AgentActionMove(hit.position));
			return true;
		}

		private void ResetRandomMoveCooldown()
		{
			_nextIdleMove = Time.time + UnityEngine.Random.Range(IdleRange.x, IdleRange.y) + 2f;
		}
	}
}
