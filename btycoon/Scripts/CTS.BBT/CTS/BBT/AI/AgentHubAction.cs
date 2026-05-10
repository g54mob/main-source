using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.BBT.AI
{
	public abstract class AgentHubAction : AgentAction<Agent>
	{
		private readonly Dictionary<AgentAction, Func<Agent, int>> _actions = new Dictionary<AgentAction, Func<Agent, int>>();

		private Agent _currentAgent;

		public AgentAction CurrentAction { get; private set; }

		public bool Completed { get; private set; }

		public sealed override bool CanBePerformed(Agent agentRef)
		{
			EStatus? eStatus = CurrentAction?.Status;
			if (eStatus.HasValue && eStatus == EStatus.InProgress)
			{
				return false;
			}
			if (Completed)
			{
				return true;
			}
			return CanAnyActionBePerformed(agentRef);
		}

		public override void OnStart()
		{
			if (!Completed && ShouldBeConsideredCompleted(base.ActionAgent))
			{
				Completed = true;
			}
			if (Completed)
			{
				return;
			}
			if (TryFindBestAction(base.ActionAgent, out var outAction))
			{
				outAction.Status = EStatus.Idle;
				PlayFoundAction(outAction, base.ActionAgent);
				if (CurrentAction == null)
				{
					CancelAction("couldn't start found action " + outAction.GetType().Name);
				}
				else
				{
					AgentAction.LinkCancellation(this, CurrentAction);
				}
			}
			else
			{
				CancelAction("couldn't find an action", playBlockedAction: true);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!Completed)
			{
				CancelAction("hub Action shouldn't be in wait for routine while not completed");
			}
			yield break;
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

		protected AgentAction AddScoredAction(AgentAction action, Func<Agent, int> calculateScoreFunc)
		{
			if (!_actions.TryAdd(action, calculateScoreFunc))
			{
				return null;
			}
			return action;
		}

		protected void RemoveAction(AgentAction action)
		{
			if (action != null)
			{
				_actions.Remove(action);
			}
		}

		protected abstract bool ShouldBeConsideredCompleted(Agent agent);

		protected virtual void PreCheck(Agent agent)
		{
		}

		protected virtual void PostCheck(Agent agent)
		{
		}

		protected virtual bool CanAnyActionBePerformed(Agent agent)
		{
			if (CurrentAction != null)
			{
				return CurrentAction.CanBePerformed(agent);
			}
			if (TryFindBestAction(agent, out var _))
			{
				return true;
			}
			return false;
		}

		protected virtual bool TryFindBestAction(Agent agent, out AgentAction outAction)
		{
			int num = -1;
			AgentAction agentAction = null;
			PreCheck(agent);
			foreach (KeyValuePair<AgentAction, Func<Agent, int>> action in _actions)
			{
				int num2 = action.Value(agent);
				if (num2 > num)
				{
					num = num2;
					agentAction = action.Key;
				}
			}
			PostCheck(agent);
			if (agentAction == null || !agentAction.CanBePerformed(agent))
			{
				outAction = null;
				return false;
			}
			outAction = agentAction;
			return true;
		}

		protected virtual void PlayFoundAction(AgentAction action, Agent agent)
		{
			CurrentAction = action;
			CurrentAction.OnActionStopped += OnCurrentActionStopped;
			_currentAgent = agent;
			_currentAgent.ActionPlayer.PlayInstantly(action, AgentActionPlayer.EInsertType.StopAction, Priority);
		}

		private void OnCurrentActionStopped(AgentAction action)
		{
			if (!Completed && ShouldBeConsideredCompleted(_currentAgent))
			{
				Completed = true;
			}
			CurrentAction.OnActionStopped -= OnCurrentActionStopped;
			CurrentAction.Reset();
			_currentAgent = null;
			CurrentAction = null;
		}
	}
}
