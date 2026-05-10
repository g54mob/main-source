using System;
using System.Collections;
using System.Collections.Generic;
using CTS.AI;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	[Serializable]
	public abstract class AgentAction : IPerformable<Agent>
	{
		public enum EStatus
		{
			Idle = 0,
			Wait = 1,
			InProgress = 2,
			Completed = 3
		}

		private static HashSet<Type> _unauthorizedActions = new HashSet<Type>();

		private FurnitureInteractor _syncedFurniture;

		private Agent _syncedAgent;

		private Item _syncedItem;

		[field: SerializeField]
		[field: HideInInspector]
		public string Name { get; set; }

		[field: SerializeField]
		protected string DisplayName { get; set; }

		protected bool CanPlayBlockedAction { get; set; } = true;

		public bool VisibleInActionList { get; set; } = true;

		public bool Stopped { get; set; } = true;

		public EStatus Status { get; set; }

		public virtual EActionPriority Priority { get; set; }

		public AgentSyncedAction SyncedAction { get; set; }

		public List<AgentActionCancellationLink> CancellationLinks { get; } = new List<AgentActionCancellationLink>();

		public event Action<AgentAction> OnActionComplete;

		public event Action<AgentAction> OnActionCancelled;

		public event Action<AgentAction> OnActionStopped;

		public event Action ActionStarting;

		public event Action ActionStarted;

		public void SendCompleteEvent()
		{
			this.OnActionComplete?.Invoke(this);
		}

		public void SendCancelEvent()
		{
			this.OnActionCancelled?.Invoke(this);
		}

		public void SendStartingEvent()
		{
			this.ActionStarting?.Invoke();
		}

		public void SendStartedEvent()
		{
			this.ActionStarted?.Invoke();
		}

		public abstract Agent GetCurrentAgent();

		public virtual string GetDisplayName()
		{
			if (DisplayName == string.Empty)
			{
				return Name;
			}
			return DisplayName;
		}

		public virtual Type GetActionType()
		{
			return GetType();
		}

		public override string ToString()
		{
			return Name;
		}

		public abstract void SetAgent(Agent agent);

		public bool CanBePerformedBy(Agent obj)
		{
			return CanBePerformed(obj);
		}

		public abstract bool CanBePerformed(Agent agentRef);

		public abstract void OnStart();

		public abstract IEnumerator WaitForRoutine();

		public abstract IEnumerator ActionRoutine();

		protected internal virtual void OnActionGiven()
		{
		}

		internal void OnRemovedFromQueueInternal()
		{
			if (Status == EStatus.Idle)
			{
				CancelSync(forced: false);
			}
		}

		protected internal virtual void OnRemovedFromQueue()
		{
		}

		public void CancelAction(string log, bool playBlockedAction = false)
		{
			if (Status <= EStatus.Wait && (SyncedAction == null || !SyncedAction.IsAnyInProgress()))
			{
				DoCancel(log, playBlockedAction, forced: false);
			}
		}

		public void ForceCancelAction()
		{
			DoCancel("", playBlockedAction: false, forced: true);
		}

		private void DoCancel(string log, bool playBlockedAction, bool forced)
		{
			Agent currentAgent = GetCurrentAgent();
			if (!currentAgent)
			{
				return;
			}
			if (Stopped)
			{
				currentAgent.ActionPlayer.RemoveFromQueue(this);
				return;
			}
			Stopped = true;
			if (currentAgent.ActionPlayer.CurrentAction == this)
			{
				currentAgent.ActionPlayer.StopCoroutine();
			}
			currentAgent.ActionPlayer.RemoveFromQueue(this);
			CancelSync(forced);
			Status = EStatus.Idle;
			OnCancel();
			SendCancelEvent();
			OnStoppedInternal();
			if (playBlockedAction && CanPlayBlockedAction)
			{
				if (!GetCurrentAgent())
				{
					return;
				}
				if (!currentAgent.ActionPlayer.HasAnyActionOfType<AgentActionBlocked>())
				{
					currentAgent.ActionPlayer.InsertAction(new AgentActionBlocked("[" + GetType().Name + "] " + currentAgent.agentFirstName + " " + currentAgent.agentName + " blocked: " + log + "."), AgentActionPlayer.EInsertType.Silent, EActionPriority.Forced);
				}
			}
			ClearAgent();
		}

		private void CancelSync(bool forced)
		{
			if (forced)
			{
				SyncedAction?.ForceStopActions();
			}
			else
			{
				SyncedAction?.StopActions();
			}
		}

		public abstract void OnComplete();

		protected abstract void OnStopped();

		internal void OnStoppedInternal()
		{
			OnStopped();
			this.OnActionStopped?.Invoke(this);
		}

		public abstract void OnCancel();

		public abstract void ClearAgent();

		public virtual void Reset()
		{
			Status = EStatus.Idle;
		}

		public abstract Coroutine WaitForSyncedActionReady();

		public abstract Coroutine WaitForSyncedActionComplete();

		public abstract void PlayActionAndResumeThis(AgentAction action);

		public abstract void PlayActionAndResumeThis(AgentAction action, EActionPriority priority);

		public static void SyncActions(params AgentAction[] actions)
		{
			AgentSyncedAction syncedAction = new AgentSyncedAction(actions);
			for (int i = 0; i < actions.Length; i++)
			{
				actions[i].SyncedAction = syncedAction;
			}
		}

		public void ClearSyncedAction()
		{
			SyncedAction = null;
		}

		public void SyncAction(Agent agent, AgentAction action, EActionPriority priority)
		{
			if (!Stopped && SyncedAction == null)
			{
				agent.ActionPlayer.ForceAction(action, priority);
				AgentSyncedAction syncedAction = (SyncedAction = new AgentSyncedAction(this, action));
				action.SyncedAction = syncedAction;
			}
		}

		public static void LinkCancellation(AgentAction action1, AgentAction action2)
		{
			new AgentActionCancellationLink(action1, action2);
			new AgentActionCancellationLink(action2, action1);
		}

		public static AgentActionCancellationLink LinkCancellationOneSide(AgentAction parent, AgentAction target)
		{
			return new AgentActionCancellationLink(parent, target);
		}

		public static void LockAction<T>() where T : AgentAction
		{
			_unauthorizedActions.Add(typeof(T));
		}

		public static void UnlockAction<T>() where T : AgentAction
		{
			_unauthorizedActions.Remove(typeof(T));
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void Initialization()
		{
			_unauthorizedActions.Clear();
		}

		public bool IsAuthorized()
		{
			return !_unauthorizedActions.Contains(GetType());
		}

		protected CustomYieldInstruction MoveToPosition(Vector3 pos, out PathingTracker tracker, int? areaMask = null, float distancePadding = 0.5f)
		{
			tracker = SimplePathing.Start(this, pos, GetCurrentAgent().Movement.GetFilter(areaMask), distancePadding);
			return tracker;
		}

		protected PathingTracker MoveToPosition(Vector3 pos, int? areaMask = null, float distancePadding = 0.5f)
		{
			return SimplePathing.Start(this, pos, GetCurrentAgent().Movement.GetFilter(areaMask), distancePadding);
		}

		protected CustomYieldInstruction MoveToTarget(MoveTarget target, out PathingTracker tracker, int? areaMask = null)
		{
			return MoveToTarget(target, out tracker, 0.5f, areaMask);
		}

		protected CustomYieldInstruction MoveToTarget(MoveTarget target, out PathingTracker tracker, NavMeshQueryFilter? filter)
		{
			return MoveToTarget(target, out tracker, 0.5f, filter);
		}

		protected CustomYieldInstruction MoveToTarget(MoveTarget target, out PathingTracker tracker, float pathUpdate, int? areaMask = null)
		{
			tracker = MoveTargetPathing.Start(this, target, GetCurrentAgent().Movement.GetFilter(areaMask), pathUpdate);
			return tracker;
		}

		protected CustomYieldInstruction MoveToTarget(MoveTarget target, out PathingTracker tracker, float pathUpdate, NavMeshQueryFilter? filter)
		{
			tracker = MoveTargetPathing.Start(this, target, filter, pathUpdate);
			return tracker;
		}

		protected PathingTracker MoveToTarget(MoveTarget target, int? areaMask = null)
		{
			return MoveToTarget(target, 0.5f, areaMask);
		}

		protected PathingTracker MoveToTarget(MoveTarget target, float pathUpdate, int? areaMask = null)
		{
			return MoveTargetPathing.Start(this, target, GetCurrentAgent().Movement.GetFilter(areaMask), pathUpdate);
		}

		protected CustomYieldInstruction MoveToTransform(Transform target, out PathingTracker tracker, AgentPath.EDestinationType destinationType = AgentPath.EDestinationType.Simple, int? areaMask = null)
		{
			return MoveToTransform(target, out tracker, 0.5f, destinationType, areaMask);
		}

		protected CustomYieldInstruction MoveToTransform(Transform target, out PathingTracker tracker, float pathUpdate, AgentPath.EDestinationType destinationType = AgentPath.EDestinationType.Simple, int? areaMask = null)
		{
			tracker = TransformPathing.Start(this, target, destinationType, GetCurrentAgent().Movement.GetFilter(areaMask), pathUpdate);
			return tracker;
		}

		protected CustomYieldInstruction MoveToActor(IContextActor contextActor, EInteractionKey key, out PathingTracker outTracker, int? areaMask = null)
		{
			if (contextActor.ContextActorData.TryGetInteractionTarget(key, GetCurrentAgent().transform.position, out var p_target))
			{
				return MoveToTarget(p_target, out outTracker, areaMask);
			}
			CancelAction($"couldn't get {key} on {contextActor.GetType().Name}", playBlockedAction: true);
			outTracker = null;
			return null;
		}

		protected CustomYieldInstruction MoveToActor(IContextActor contextActor, EInteractionKey key, out PathingTracker outTracker, NavMeshQueryFilter? filter)
		{
			if (contextActor.ContextActorData.TryGetInteractionTarget(key, GetCurrentAgent().transform.position, out var p_target))
			{
				return MoveToTarget(p_target, out outTracker, filter);
			}
			CancelAction($"couldn't get {key} on {contextActor.GetType().Name}", playBlockedAction: true);
			outTracker = null;
			return null;
		}

		protected PathingTracker MoveToActor(IContextActor contextActor, EInteractionKey key, int? areaMask = null)
		{
			MoveToActor(contextActor, key, out var outTracker, areaMask);
			return outTracker;
		}

		protected PathingTracker MoveToActor(IContextActor contextActor, EInteractionKey key, NavMeshQueryFilter? filter)
		{
			MoveToActor(contextActor, key, out var outTracker, filter);
			return outTracker;
		}

		protected CustomYieldInstruction MoveToAgent(Agent agent, float pathUpdate, float waitDistance, out PathingTracker outTracker, AgentAction syncedAction = null, int? areaMask = null)
		{
			outTracker = AgentPathing.Start(this, agent, waitDistance, GetCurrentAgent().Movement.GetFilter(areaMask), syncedAction, pathUpdate);
			return outTracker;
		}

		protected PathingTracker MoveToAgent(Agent agent, float pathUpdate, float waitDistance, AgentAction syncedAction = null, int? areaMask = null)
		{
			MoveToAgent(agent, pathUpdate, waitDistance, out var outTracker, syncedAction, areaMask);
			return outTracker;
		}

		protected CustomYieldInstruction MoveToLookAt(Transform target, float pathUpdate, float distance, out PathingTracker outTracker, float fov = 0.5f, int? areaMask = null)
		{
			outTracker = LookAtPathing.Start(this, target, GetCurrentAgent().Movement.GetFilter(areaMask), distance, fov);
			outTracker.PathUpdate = pathUpdate;
			return outTracker;
		}

		protected PathingTracker MoveToLookAt(Transform target, float pathUpdate, float distance, float fov = 0.5f, int? areaMask = null)
		{
			MoveToLookAt(target, pathUpdate, distance, out var outTracker, fov, areaMask);
			return outTracker;
		}

		private void OnStoppedSyncing()
		{
			StopFurnitureSyncing();
			StopItemSyncing();
			StopAgentSyncing();
		}

		protected void SyncWithFurniture(FurnitureInteractor furniture)
		{
			if (!Stopped)
			{
				if ((object)_syncedFurniture != null)
				{
					StopFurnitureSyncing();
				}
				_syncedFurniture = furniture;
				_syncedFurniture.FurnitureBecameUnavailable += OnSyncedFurnitureBecameUnavailable;
			}
		}

		protected void SyncWithFurniturePlacement(FurnitureInteractor furniture)
		{
			if (!Stopped)
			{
				if ((object)_syncedFurniture != null)
				{
					StopFurnitureSyncing();
				}
				_syncedFurniture = furniture;
				_syncedFurniture.Furniture.OnFurnitureDestroyed += OnSyncedFurnitureBecameUnavailable;
				_syncedFurniture.Furniture.Controller.FurniturePlaced += OnSyncedFurniturePlaced;
			}
		}

		private void OnSyncedFurniturePlaced(bool obj)
		{
			OnSyncedFurnitureBecameUnavailable();
		}

		private void OnSyncedFurnitureBecameUnavailable()
		{
			FurnitureInteractor syncedFurniture = _syncedFurniture;
			StopFurnitureSyncing();
			Agent currentAgent = GetCurrentAgent();
			if ((bool)currentAgent)
			{
				currentAgent.Animator.SetIdleAndPlay(AgentAnim.Idle);
				if (currentAgent.FurnitureAssignment.CurrentAssignment == syncedFurniture)
				{
					currentAgent.FurnitureAssignment.StopUsing();
				}
			}
			ForceCancelAction();
		}

		protected void StopFurnitureSyncing()
		{
			if ((bool)_syncedFurniture)
			{
				_syncedFurniture.FurnitureBecameUnavailable -= OnSyncedFurnitureBecameUnavailable;
				_syncedFurniture.Furniture.OnFurnitureDestroyed -= OnSyncedFurnitureBecameUnavailable;
				_syncedFurniture.Furniture.Controller.FurniturePlaced -= OnSyncedFurniturePlaced;
				_syncedFurniture = null;
			}
		}

		protected void SyncWithItem(Item item)
		{
			if (!Stopped)
			{
				_syncedItem = item;
				_syncedItem.Destroyed -= OnSyncedItemDestroyed;
				_syncedItem.Destroyed += OnSyncedItemDestroyed;
			}
		}

		private void OnSyncedItemDestroyed()
		{
			StopItemSyncing();
			ForceCancelAction();
		}

		private void StopItemSyncing()
		{
			if ((bool)_syncedItem)
			{
				_syncedItem.Destroyed -= OnSyncedItemDestroyed;
				_syncedItem = null;
			}
		}

		protected void SyncWithAgent(Agent agent)
		{
			if (!Stopped)
			{
				StopAgentSyncing();
				_syncedAgent = agent;
				_syncedAgent.Despawned += OnSyncedAgentDespawned;
			}
		}

		private void OnSyncedAgentDespawned(Agent obj)
		{
			StopItemSyncing();
			ForceCancelAction();
		}

		protected void StopAgentSyncing()
		{
			if ((bool)_syncedAgent)
			{
				_syncedAgent.Despawned -= OnSyncedAgentDespawned;
				_syncedAgent = null;
			}
		}
	}
	[Serializable]
	public abstract class AgentAction<T> : AgentAction where T : Agent
	{
		public T ActionAgent { get; private set; }

		protected bool IsPlaying
		{
			get
			{
				if ((object)ActionAgent != null)
				{
					return ActionAgent.ActionPlayer.CurrentAction == this;
				}
				return false;
			}
		}

		public override Agent GetCurrentAgent()
		{
			return ActionAgent;
		}

		public override void SetAgent(Agent agent)
		{
			if ((bool)agent)
			{
				ActionAgent = (T)agent;
			}
		}

		public override void PlayActionAndResumeThis(AgentAction action)
		{
			action.Priority = Priority;
			ActionAgent.ActionPlayer.InsertAction(action, AgentActionPlayer.EInsertType.StopAction, action.Priority);
			AgentAction.LinkCancellationOneSide(this, action);
		}

		public override void PlayActionAndResumeThis(AgentAction action, EActionPriority priority)
		{
			action.Priority = priority;
			_ = Priority;
			ActionAgent.ActionPlayer.InsertAction(action, AgentActionPlayer.EInsertType.StopAction, action.Priority);
			AgentAction.LinkCancellationOneSide(this, action);
		}

		private bool StandUpCheck()
		{
			if ((bool)ActionAgent.FurnitureAssignment.CurrentSeat)
			{
				PlayActionAndResumeThis(new AgentActionSitUp());
				return false;
			}
			return true;
		}

		public override void ClearAgent()
		{
			ActionAgent = null;
		}

		public override void OnComplete()
		{
			if (!base.Stopped)
			{
				base.Stopped = true;
				if ((bool)ActionAgent)
				{
					ActionAgent.ActionPlayer.RemoveFromQueue(this);
				}
			}
		}

		public override Coroutine WaitForSyncedActionReady()
		{
			return base.SyncedAction.SetReadyAndWait(ActionAgent, this);
		}

		public override Coroutine WaitForSyncedActionComplete()
		{
			return base.SyncedAction.WaitForCompletion(ActionAgent);
		}

		protected bool SeatCheck()
		{
			if (!ActionAgent.FurnitureAssignment.CurrentSeat)
			{
				return false;
			}
			PlayActionAndResumeThis(new AgentActionSitUp());
			return true;
		}

		protected void DrinkInHandCheck()
		{
			if ((bool)ActionAgent && ActionAgent.ObjectHolding.IsHolding<Drink>())
			{
				ActionAgent.ObjectHolding.GetHeldObject<Drink>().Clear();
			}
		}
	}
}
