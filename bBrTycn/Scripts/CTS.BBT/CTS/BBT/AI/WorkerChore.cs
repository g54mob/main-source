using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[Serializable]
	public abstract class WorkerChore : WorkerAction
	{
		private GameTime _nextAvailabilityTime;

		private const float Cooldown = 5f;

		public bool AssignationBypassPowers { get; set; }

		public RoomObject ChoreTarget { get; }

		public ChoreCategory Category { get; }

		public GameTime CreationTime { get; }

		public int ChorePriority { get; set; }

		public bool VisibleInContextualMenu { get; set; } = true;

		public virtual bool DisableIfImpossible { get; } = true;

		private List<IContextActor> ContextActors { get; } = new List<IContextActor>();

		public bool Destroyed { get; private set; }

		public WorkerChore(ChoreCategory category, RoomObject target = null)
		{
			Category = category;
			CreationTime = GameTime.Now;
			base.Name = GetType().Name.Remove(0, 11);
			ChoreTarget = target;
		}

		public virtual RoomObject GetChoreTarget()
		{
			return ChoreTarget;
		}

		public bool ShouldBypassAssignation(Worker worker)
		{
			if (AssignationBypassPowers && worker.AssignationBypassPowers)
			{
				return true;
			}
			return false;
		}

		public virtual bool IsAvailableInRoomAssignation(Worker worker)
		{
			if (ShouldBypassAssignation(worker))
			{
				return true;
			}
			RoomObject choreTarget = GetChoreTarget();
			if ((object)choreTarget == null)
			{
				return true;
			}
			if ((object)choreTarget.CurrentRoom == null)
			{
				return true;
			}
			return worker.RoomAssignations.CanUseRoom(choreTarget.CurrentRoom);
		}

		public virtual bool CanBePerformedWithoutSelectedWorker()
		{
			return true;
		}

		public void AddContext(IContextActor p_contextActor)
		{
			RemoveContext(p_contextActor);
			ContextActors.Add(p_contextActor);
			p_contextActor.ContextActorData.AddChore(this);
		}

		public void RemoveContext(IContextActor p_contextActor)
		{
			ContextActors.Remove(p_contextActor);
			p_contextActor.ContextActorData.Remove(this);
		}

		public bool IsOnCooldown()
		{
			return Time.time < _nextAvailabilityTime;
		}

		public void SetCooldownFromNow(float duration)
		{
			_nextAvailabilityTime = Time.time + duration;
		}

		public override void OnCancel()
		{
			if (!Destroyed && base.Status < EStatus.Completed)
			{
				ReinsertToChoreList();
			}
		}

		public override void OnComplete()
		{
			base.OnComplete();
			CleanContext();
		}

		public void ReinsertToChoreList()
		{
			if (!Destroyed)
			{
				_nextAvailabilityTime = Time.time + 5f;
				if (MonoSingleton<ChoreList>.InstanceExists())
				{
					MonoSingleton<ChoreList>.Instance.ReinsertChore(this);
				}
			}
		}

		public void DestroyChore()
		{
			_ = base.Status;
			_ = 1;
			if (!Destroyed)
			{
				Destroyed = true;
				OnDestroy();
				CancelAction("chore destroyed");
				CleanContext();
				if (MonoSingleton<ChoreList>.InstanceExists())
				{
					MonoSingleton<ChoreList>.Instance.RemoveChore(this);
				}
			}
		}

		protected abstract void OnDestroy();

		private void CleanContext()
		{
			while (ContextActors.Count > 0)
			{
				RemoveContext(ContextActors[0]);
			}
		}
	}
}
