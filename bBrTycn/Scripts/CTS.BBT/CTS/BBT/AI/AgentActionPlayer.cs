using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public abstract class AgentActionPlayer : CTSBehaviour
	{
		public enum EInsertType
		{
			Silent = 0,
			StopAction = 1,
			CancelAction = 2,
			SoftCancel = 3
		}

		[SerializeField]
		private bool _debug;

		private AgentAction _currentAction;

		[Inject(false)]
		protected Agent agent;

		public AgentAction CurrentAction
		{
			get
			{
				return _currentAction;
			}
			private set
			{
				_ = ActionQueue.Count;
				_ = 0;
				_currentAction = value;
				this.OnActionChanged?.Invoke(_currentAction);
			}
		}

		public List<AgentAction> ActionQueue { get; } = new List<AgentAction>();

		public static event Action<Agent, Type> OnActionAdded;

		public static event Action<Agent, Type> OnActionCompleted;

		public static event Action<Agent, AgentAction> OnCompleted;

		public event Action<AgentAction> OnActionChanged;

		public event Action ActionQueueChanged;

		protected override void OnDisabled()
		{
			base.OnDisabled();
			ClearActionQueue();
			CurrentAction = null;
		}

		public void Play(AgentAction p_action)
		{
			PlayAction(p_action);
		}

		private void PlayAction(AgentAction action, AgentAction.EStatus status = AgentAction.EStatus.Idle)
		{
			StopAllCoroutines();
			if (!ActionQueue.Contains(action))
			{
				ActionQueue.Insert(0, action);
				this.ActionQueueChanged?.Invoke();
			}
			CurrentAction = action;
			CurrentAction.SetAgent(agent);
			CurrentAction.Stopped = false;
			_ = base.isActiveAndEnabled;
			switch (status)
			{
			case AgentAction.EStatus.Idle:
				RoutineStart();
				break;
			case AgentAction.EStatus.Wait:
				StartCoroutine(RoutineWait(CurrentAction));
				break;
			case AgentAction.EStatus.InProgress:
				StartCoroutine(RoutineInProgress(CurrentAction));
				break;
			}
		}

		private void RoutineStart()
		{
			AgentAction currentAction = CurrentAction;
			currentAction.Status = AgentAction.EStatus.Idle;
			currentAction.OnStart();
			if (CurrentAction == currentAction)
			{
				StartCoroutine(RoutineWait(currentAction));
			}
		}

		private IEnumerator RoutineWait(AgentAction playingAction)
		{
			playingAction.Status = AgentAction.EStatus.Wait;
			playingAction.SendStartingEvent();
			yield return WaitForRoutine();
			if (playingAction.SyncedAction != null)
			{
				yield return playingAction.WaitForSyncedActionReady();
				if (playingAction.Stopped)
				{
					yield break;
				}
			}
			else
			{
				if (!playingAction.CanBePerformed(agent))
				{
					playingAction.CancelAction("Action can't be performed");
					yield break;
				}
				if (playingAction.Stopped)
				{
					yield break;
				}
			}
			StartCoroutine(RoutineInProgress(playingAction));
		}

		private IEnumerator RoutineInProgress(AgentAction playingAction)
		{
			playingAction.Status = AgentAction.EStatus.InProgress;
			playingAction.SendStartedEvent();
			yield return ActionRoutine();
			playingAction.Status = AgentAction.EStatus.Completed;
			if (playingAction.SyncedAction != null)
			{
				yield return playingAction.WaitForSyncedActionComplete();
			}
			playingAction.OnComplete();
			playingAction.SendCompleteEvent();
			AgentActionPlayer.OnActionCompleted?.Invoke(agent, playingAction.GetType());
			AgentActionPlayer.OnCompleted?.Invoke(agent, playingAction);
			playingAction.OnStoppedInternal();
			playingAction.ClearAgent();
			StopCoroutine();
		}

		protected abstract IEnumerator WaitForRoutine();

		protected abstract IEnumerator ActionRoutine();

		public abstract void PlayInstantly(AgentAction action, EInsertType insertType = EInsertType.CancelAction, EActionPriority priority = EActionPriority.Forced);

		public void CompleteAction()
		{
		}

		public void StopCoroutine()
		{
			agent.ResetPath();
			StopAllCoroutines();
			CurrentAction = null;
		}

		public void AddAction<T>(T p_action) where T : AgentAction
		{
			if (ValidateNewAction(p_action))
			{
				ActionQueue.Add(p_action);
				this.ActionQueueChanged?.Invoke();
				SetupAction(p_action);
			}
		}

		public void InsertAction(AgentAction action, EInsertType stopCurrentAction, EActionPriority priority)
		{
			if (!ValidateNewAction(action))
			{
				return;
			}
			action.Priority = priority;
			ActionQueue.Insert(0, action);
			this.ActionQueueChanged?.Invoke();
			SetupAction(action);
			if (CurrentAction == null || CurrentAction.Status > AgentAction.EStatus.Wait)
			{
				return;
			}
			switch (stopCurrentAction)
			{
			case EInsertType.StopAction:
				CurrentAction.Status = AgentAction.EStatus.Idle;
				CurrentAction.OnStoppedInternal();
				StopCoroutine();
				break;
			case EInsertType.CancelAction:
				CurrentAction.CancelAction("Cancelled from another inserted action");
				break;
			case EInsertType.SoftCancel:
			{
				AgentAction currentAction = CurrentAction;
				currentAction.Status = AgentAction.EStatus.Idle;
				currentAction.OnCancel();
				if (CurrentAction == currentAction)
				{
					CurrentAction.OnStoppedInternal();
				}
				StopCoroutine();
				break;
			}
			}
		}

		public bool TryForceAction(AgentAction newAction, EActionPriority priority = EActionPriority.Default)
		{
			if (!ValidateNewAction(newAction))
			{
				Debug.Log($"{newAction} not validated.");
				return false;
			}
			newAction.Priority = priority;
			List<AgentAction> list = new List<AgentAction>();
			for (int num = ActionQueue.Count - 1; num >= 0; num--)
			{
				while (num >= ActionQueue.Count)
				{
					num--;
				}
				if (num < 0)
				{
					break;
				}
				if (!CanActionInterruptOther(newAction, ActionQueue[num]))
				{
					return false;
				}
				list.Add(ActionQueue[num]);
			}
			if (CurrentAction != null)
			{
				if (!CanActionInterruptOther(newAction, CurrentAction))
				{
					return false;
				}
				CurrentAction.CancelAction("Cancelled from TryForceAction");
			}
			foreach (AgentAction item in list)
			{
				item.CancelAction("Cancelled from TryForceAction");
			}
			SetupAction(newAction);
			ActionQueue.Add(newAction);
			this.ActionQueueChanged?.Invoke();
			return true;
		}

		public virtual void ForceAction(AgentAction newAction, EActionPriority priority)
		{
			if (!ValidateNewAction(newAction))
			{
				Debug.Log($"{newAction} not validated.");
				return;
			}
			newAction.Priority = priority;
			for (int num = ActionQueue.Count - 1; num >= 0; num--)
			{
				while (num >= ActionQueue.Count)
				{
					num--;
				}
				if (num < 0)
				{
					break;
				}
				if (CanActionInterruptOther(newAction, ActionQueue[num]))
				{
					ActionQueue[num].CancelAction("Cancelled from ForceAction");
				}
			}
			SetupAction(newAction);
			if (CurrentAction != null && CanActionInterruptOther(newAction, CurrentAction))
			{
				CurrentAction.CancelAction("Cancelled from ForceAction");
				CurrentAction = null;
				ActionQueue.Insert(0, newAction);
				this.ActionQueueChanged?.Invoke();
			}
			else
			{
				ActionQueue.Add(newAction);
				this.ActionQueueChanged?.Invoke();
			}
		}

		private bool CanActionInterruptOther(AgentAction newAction, AgentAction testAction)
		{
			if (testAction.SyncedAction != null && testAction.SyncedAction.IsAnyInProgress())
			{
				return false;
			}
			if (testAction.Status > AgentAction.EStatus.Wait)
			{
				return false;
			}
			if (newAction.Priority == EActionPriority.Player && testAction.Priority == EActionPriority.Player)
			{
				return true;
			}
			return newAction.Priority > testAction.Priority;
		}

		private bool ValidateNewAction(AgentAction action)
		{
			if (ActionQueue.Contains(action))
			{
				Debug.Log("Queue already contains action.");
				return false;
			}
			AgentAction.EStatus status = action.Status;
			if (status <= AgentAction.EStatus.InProgress)
			{
				if (status > AgentAction.EStatus.Idle)
				{
					action.CancelAction("Cancelled from validate");
				}
				return true;
			}
			Debug.Log("Action already in progress.");
			return false;
		}

		public void ClearActionQueue()
		{
			while (ActionQueue.Count > 0)
			{
				AgentAction agentAction = ActionQueue[0];
				agentAction.CancelAction("Cancelled from ClearActionQueue");
				RemoveFromQueue(agentAction);
			}
		}

		public void ForceStopAll()
		{
			while (ActionQueue.Count > 0)
			{
				AgentAction agentAction = ActionQueue[0];
				agentAction.ForceCancelAction();
				RemoveFromQueue(agentAction);
			}
		}

		public int ActionsOfTypeCount(Type type)
		{
			int num = 0;
			foreach (AgentAction item in ActionQueue)
			{
				if (item.GetActionType() == type)
				{
					num++;
				}
			}
			return num;
		}

		public int ActionsOfTypeCount<TAction>() where TAction : AgentAction
		{
			return ActionsOfTypeCount(typeof(TAction));
		}

		public bool HasAction(AgentAction p_action)
		{
			return ActionQueue.Contains(p_action);
		}

		public bool HasAnyActionOfType(Type type)
		{
			foreach (AgentAction item in ActionQueue)
			{
				Type actionType = item.GetActionType();
				if (actionType == type || actionType.IsSubclassOf(type))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAnyActionOfType<T>() where T : AgentAction
		{
			return HasAnyActionOfType(typeof(T));
		}

		public bool HasAnyActionOfType(Type type, Func<AgentAction, bool> filter)
		{
			foreach (AgentAction item in ActionQueue)
			{
				Type actionType = item.GetActionType();
				if ((actionType == type || actionType.IsSubclassOf(type)) && filter(item))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetActionOfType<TAction>(out TAction outAction) where TAction : AgentAction
		{
			AgentAction outAction2;
			bool flag = TryGetActionOfType(typeof(TAction), out outAction2);
			outAction = (flag ? outAction2.Cast<TAction>() : null);
			return flag;
		}

		public bool TryGetActionOfType(Type type, out AgentAction outAction)
		{
			foreach (AgentAction item in ActionQueue)
			{
				Type actionType = item.GetActionType();
				if (!(actionType != type) || actionType.IsSubclassOf(type))
				{
					outAction = item;
					return true;
				}
			}
			outAction = null;
			return false;
		}

		public void RemoveFromQueue(AgentAction action)
		{
			if (ActionQueue.Contains(action))
			{
				action.Priority = EActionPriority.Default;
				action.OnRemovedFromQueueInternal();
				action.OnRemovedFromQueue();
				ActionQueue.Remove(action);
				this.ActionQueueChanged?.Invoke();
			}
		}

		public bool TryGetNextAction<T>(out T outAction) where T : AgentAction
		{
			outAction = null;
			while (outAction == null && ActionQueue.Count > 0)
			{
				AgentAction agentAction = ActionQueue[0];
				if (agentAction.CanBePerformed(agent))
				{
					outAction = (T)agentAction;
					return true;
				}
				agentAction.CancelAction("Cancelled from TryGetNextAction");
				if (ActionQueue.Contains(agentAction))
				{
					RemoveFromQueue(agentAction);
				}
			}
			outAction = null;
			return false;
		}

		private void SetupAction(AgentAction action)
		{
			action.Stopped = true;
			action.SetAgent(agent);
			action.OnActionGiven();
			AgentActionPlayer.OnActionAdded?.Invoke(agent, action.GetType());
		}
	}
}
