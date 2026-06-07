using System;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public abstract class PathingTracker : CustomYieldInstruction, IUpdatable
	{
		public enum EStatus
		{
			InProgress = 0,
			Interrupted = 1,
			Failed = 2,
			Completed = 3
		}

		private float _pathUpdateTime;

		private bool _canTeleport;

		private EStatus _status;

		public override bool keepWaiting => !IsCompleted;

		public bool IsCompleted => _status != EStatus.InProgress;

		public float PathUpdate { get; set; } = 0.5f;

		protected AgentPath CurrentPath { get; set; }

		protected NavMeshQueryFilter? filter { get; set; }

		public EStatus Status
		{
			get
			{
				return _status;
			}
			set
			{
				if (_status == EStatus.InProgress && value != EStatus.InProgress)
				{
					_status = value;
					if (_status == EStatus.Failed)
					{
						Action.CancelAction("Pathing failed", playBlockedAction: true);
					}
					else if (_status == EStatus.Completed)
					{
						OnCompleted();
					}
					Stop();
				}
			}
		}

		protected AgentAction Action { get; private set; }

		protected Agent ActionAgent
		{
			get
			{
				if (!Action.GetCurrentAgent())
				{
					return null;
				}
				return Action.GetCurrentAgent();
			}
		}

		private void OnActionStopped(AgentAction action)
		{
			Stop();
		}

		protected void Start(AgentAction action)
		{
			AgentAction.EStatus status = action.Status;
			if (status < AgentAction.EStatus.Wait || status > AgentAction.EStatus.InProgress)
			{
				throw new Exception("Action isn't in progress");
			}
			Action = action;
			_status = EStatus.InProgress;
			OnStart();
			if (Status == EStatus.InProgress)
			{
				_canTeleport = ActionAgent is Worker worker && worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Blinker);
				if (IsAtDestination(ActionAgent.transform))
				{
					Status = EStatus.Completed;
					return;
				}
				if ((bool)ActionAgent.FurnitureAssignment.CurrentSeat)
				{
					Action.PlayActionAndResumeThis(new AgentActionSitUp());
					Status = EStatus.Interrupted;
					return;
				}
				_pathUpdateTime = 0f;
				Action.OnActionStopped += OnActionStopped;
				UpdateSpreader.AddUpdate(this);
				SpreadUpdate();
			}
		}

		protected void Stop()
		{
			if (Action != null)
			{
				Action.OnActionStopped -= OnActionStopped;
				UpdateSpreader.RemoveUpdate(this);
				if ((bool)ActionAgent)
				{
					ActionAgent.ResetPath();
				}
				Action = null;
				OnStopped();
			}
		}

		protected abstract void OnStart();

		void IUpdatable.OnUpdate()
		{
			if (IsCompleted || Action == null || (object)ActionAgent == null)
			{
				return;
			}
			CheckCurrentPath();
			if (IsCompleted)
			{
				return;
			}
			_pathUpdateTime += Time.deltaTime;
			if (_pathUpdateTime < PathUpdate)
			{
				return;
			}
			if (IsAtDestination(ActionAgent.transform))
			{
				Status = EStatus.Completed;
				return;
			}
			if (_canTeleport)
			{
				TryTeleport();
				if (Status == EStatus.Interrupted)
				{
					return;
				}
			}
			SpreadUpdate();
			_pathUpdateTime = 0f;
		}

		private void TryTeleport()
		{
			if (CurrentPath?.Corners == null || !ActionAgent.Statistics.TryGetStatisticValue(EAgentStatistics.TeleportMinDistance, out var statisticValue) || ActionAgent.Cooldowns.IsOnCooldown(BBTAgentTags.CD_Teleport) || ActionAgent.ObjectHolding.IsCurrentlyHolding)
			{
				return;
			}
			float num = 0f;
			Vector3 position = ActionAgent.transform.position;
			foreach (PathCorner remainingCorner in CurrentPath.RemainingCorners)
			{
				num += Vector3.Distance(position, remainingCorner.Position);
			}
			if (num < statisticValue)
			{
				return;
			}
			float teleportDistance = GetTeleportDistance();
			float num2 = 0f;
			Vector3 vector = Vector3.zero;
			Quaternion value = Quaternion.identity;
			for (int num3 = CurrentPath.Corners.Length - 1; num3 >= 1; num3--)
			{
				Vector3 position2 = CurrentPath.Corners[num3].Position;
				Vector3 vector2 = CurrentPath.Corners[num3 - 1].Position - position2;
				float num4 = Vector3.Magnitude(vector2);
				if (num2 + num4 >= teleportDistance)
				{
					vector = position2 + vector2.normalized * (teleportDistance - num2);
					value = Quaternion.LookRotation((position2 - vector).normalized, Vector3.up);
					break;
				}
				num2 += num4;
			}
			if (vector == Vector3.zero)
			{
				Debug.LogException(new Exception("Teleport couldn't find a spot"));
				return;
			}
			Action.PlayActionAndResumeThis(new AgentActionTeleport(vector, value));
			if (Status == EStatus.InProgress)
			{
				Status = EStatus.Interrupted;
			}
		}

		protected abstract float GetTeleportDistance();

		private void CheckCurrentPath()
		{
			if (Action.Stopped)
			{
				Status = EStatus.Failed;
			}
			else if (CurrentPath != null)
			{
				if (CurrentPath.PathingStatus == AgentPath.EPathingStatus.Blocked)
				{
					Status = EStatus.Failed;
				}
				else if (CurrentPath.CalculationStatus == AgentPath.ECalculationStatus.Failed)
				{
					Status = EStatus.Failed;
				}
			}
		}

		protected bool ShouldAvoidRetargeting(Vector3 agentPos)
		{
			if (CurrentPath == null)
			{
				return false;
			}
			if (CurrentPath.IsFirstCorner)
			{
				return true;
			}
			bool flag = Mathf.Approximately(ActionAgent.Movement.Velocity.sqrMagnitude, float.Epsilon);
			if (CurrentPath.PreviousCorner.IsOffLinkEntry)
			{
				return !flag;
			}
			if (CurrentPath.CurrentCorner.IsOffLinkEntry)
			{
				if (flag)
				{
					return false;
				}
				float num = Math.Max(0.2f, 0.75f * Time.timeScale);
				if (Vector3.Distance(agentPos, CurrentPath.CurrentCorner.Position) < num)
				{
					return true;
				}
			}
			NavMeshHit hit;
			return !NavMesh.SamplePosition(agentPos, out hit, 0.1f, AgentsMover.AllAreas);
		}

		public abstract bool IsAtDestination(Transform actionPlayerTransform);

		protected abstract void SpreadUpdate();

		protected abstract void OnStopped();

		protected abstract void OnCompleted();
	}
}
