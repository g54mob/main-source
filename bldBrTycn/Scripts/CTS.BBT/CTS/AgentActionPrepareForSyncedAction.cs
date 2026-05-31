using System;
using System.Collections;
using System.Collections.Generic;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

namespace CTS
{
	public class AgentActionPrepareForSyncedAction : AgentAction<Agent>
	{
		private struct RoomCell : IComparable<RoomCell>
		{
			public readonly ConstructionCell Cell;

			public readonly float DistanceToAgent;

			public RoomCell(ConstructionCell cell, Vector3 pos)
			{
				Cell = cell;
				DistanceToAgent = Vector3.SqrMagnitude(cell.transform.position - pos);
			}

			public int CompareTo(RoomCell other)
			{
				return DistanceToAgent.CompareTo(other.DistanceToAgent);
			}
		}

		private static readonly float _randomMoveRadius = 1f;

		private LayerMask _physicsMask = 1 << LayerMask.NameToLayer("Customer");

		private readonly Agent _otherAgent;

		private FrameCheck<Agent> CanHaveSyncedAction { get; } = new FrameCheck<Agent>(IsCorrectForInteraction);

		public AgentActionPrepareForSyncedAction(Agent otherAgent)
		{
			_otherAgent = otherAgent;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>();
		}

		public override void OnStart()
		{
			if ((bool)base.ActionAgent.FurnitureAssignment.CurrentSeat)
			{
				PlayActionAndResumeThis(new AgentActionSitUp());
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			NavMeshQueryFilter filter = new NavMeshQueryFilter
			{
				areaMask = 1 << (int)base.ActionAgent.RoomObject.CurrentRoom.NavArea,
				agentTypeID = AgentsMover.InteractionAgentID
			};
			RoomBuilding currentRoom = base.ActionAgent.RoomObject.CurrentRoom;
			NavMeshHit hit2;
			if ((bool)currentRoom)
			{
				Vector3 position = base.ActionAgent.transform.position;
				List<RoomCell> list = CollectionPool<List<RoomCell>, RoomCell>.Get();
				foreach (BuildingFloor floorTile in currentRoom.FloorTiles)
				{
					list.Add(new RoomCell(floorTile.LinkedCell, position));
				}
				list.Sort();
				for (int i = 0; i < list.Count; i += 2)
				{
					Debug.DrawRay(list[i].Cell.transform.position, Vector3.up, Color.magenta, 2f);
					if (NavMesh.SamplePosition(list[i].Cell.transform.position, out var hit, 1.5f, filter))
					{
						yield return MoveToPosition(hit.position, AgentsMover.AllAreas, 0.25f);
						break;
					}
				}
			}
			else if (NavMesh.SamplePosition(base.ActionAgent.transform.position, out hit2, 1.5f, filter))
			{
				yield return MoveToPosition(hit2.position, AgentsMover.AllAreas, 0.25f);
			}
			while (!CanHaveSyncedAction.Check(base.ActionAgent))
			{
				NavMeshHit hit3;
				while (!NavMesh.SamplePosition(base.ActionAgent.transform.position, out hit3, 0.1f, AgentsMover.AllAreas))
				{
					yield return null;
					Vector3 vector = (UnityEngine.Random.insideUnitCircle * _randomMoveRadius).ToHorizontal3D();
					if (NavMesh.SamplePosition(base.ActionAgent.transform.position + vector, out var hit4, 1f, base.ActionAgent.RandomMovementMask))
					{
						yield return MoveToPosition(hit4.position);
					}
				}
				yield return RepositionRoutine(base.ActionAgent);
			}
		}

		private IEnumerator RepositionRoutine(Agent actionPlayer)
		{
			Vector3 position = actionPlayer.transform.position;
			Transform transform = _otherAgent.transform;
			Vector3 dir = (transform.position - position).FlattenY().normalized;
			bool hitNavMesh = false;
			float rotation = 15f;
			float maxRepositionTime = Time.time + 2f;
			while (!hitNavMesh)
			{
				yield return null;
				position = actionPlayer.transform.position;
				_otherAgent.Selection.InterCollider.enabled = false;
				Vector3 vector = position + dir;
				if (!NavMesh.Raycast(position, vector, out var _, AgentsMover.AllAreas) && !Physics.CheckSphere(vector, 0.3f, _physicsMask))
				{
					_otherAgent.Selection.InterCollider.enabled = true;
					hitNavMesh = true;
				}
				else
				{
					_otherAgent.Selection.InterCollider.enabled = true;
					dir = Quaternion.Euler(0f, rotation, 0f) * dir;
					rotation = (float)(-Math.Sign(rotation)) * (Math.Abs(rotation) + 15f);
				}
				if (Time.time > maxRepositionTime)
				{
					yield break;
				}
			}
			Quaternion startRotation = actionPlayer.transform.rotation;
			Quaternion endRotation = Quaternion.LookRotation(dir);
			float angle = Quaternion.Angle(startRotation, endRotation);
			for (float time = 0f; time < 1f; time += Time.deltaTime / angle * actionPlayer.Movement.AngularSpeed)
			{
				actionPlayer.transform.rotation = Quaternion.Lerp(startRotation, endRotation, time);
				yield return null;
			}
			actionPlayer.transform.rotation = endRotation;
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}

		private static bool IsCorrectForInteraction(Agent agent)
		{
			Vector3 position = agent.transform.position;
			if (!NavMesh.SamplePosition(position, out var hit, 0.1f, AgentsMover.AllAreas))
			{
				return false;
			}
			if (!agent.ContextActorData.TryGetInteractionTarget(EInteractionKey.RegularUsage, position, out var p_target))
			{
				return false;
			}
			if (NavMesh.Raycast(position, p_target.Position, out hit, AgentsMover.AllAreas))
			{
				return false;
			}
			return true;
		}
	}
}
