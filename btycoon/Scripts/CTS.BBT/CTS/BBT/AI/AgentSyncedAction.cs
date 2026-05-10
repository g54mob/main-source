using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class AgentSyncedAction
	{
		private readonly Dictionary<AgentAction, bool> actions = new Dictionary<AgentAction, bool>();

		private bool _playing;

		private bool _stopped;

		private bool _waitForCompletion = true;

		private MonoBehaviour _syncRoutineParent;

		private Coroutine _syncByDistanceRoutine;

		public bool IsAnyInProgress()
		{
			return actions.Keys.Any((AgentAction action) => action.Status == AgentAction.EStatus.InProgress);
		}

		public AgentSyncedAction(params AgentAction[] p_actions)
		{
			foreach (AgentAction key in p_actions)
			{
				actions.Add(key, value: false);
			}
		}

		public void SetWaitForCompletion(bool value)
		{
			_waitForCompletion = value;
		}

		public Coroutine SetReadyAndWait(Agent p_agent, AgentAction p_waitingAction)
		{
			actions[p_waitingAction] = true;
			return p_agent.ActionPlayer.StartCoroutine(WaitForReadyRoutine());
		}

		public bool CanBePerformed()
		{
			foreach (AgentAction key in actions.Keys)
			{
				if (!key.CanBePerformed(key.GetCurrentAgent()))
				{
					return false;
				}
			}
			return true;
		}

		private IEnumerator WaitForReadyRoutine()
		{
			while (actions.Values.Any((bool value) => !value))
			{
				foreach (var (agentAction2, flag2) in actions)
				{
					if (flag2 && !agentAction2.CanBePerformed(agentAction2.GetCurrentAgent()))
					{
						StopActions();
						yield break;
					}
				}
				yield return null;
			}
			if (!CanBePerformed())
			{
				StopActions();
			}
		}

		public Coroutine WaitForCompletion(Agent p_agent)
		{
			if (!_playing)
			{
				_playing = true;
			}
			return p_agent.StartCoroutine(WaitForCompletionRoutine());
		}

		private IEnumerator WaitForCompletionRoutine()
		{
			if (_waitForCompletion)
			{
				while (actions.Keys.Any((AgentAction key) => key.Status != AgentAction.EStatus.Completed))
				{
					yield return null;
				}
			}
		}

		public void StopActions()
		{
			if (_stopped)
			{
				return;
			}
			_stopped = true;
			StopSyncRoutine();
			foreach (AgentAction key in actions.Keys)
			{
				key.CancelAction("Synced action stopped");
				key.ClearSyncedAction();
			}
		}

		public void ForceStopActions()
		{
			if (_stopped)
			{
				return;
			}
			_stopped = true;
			StopSyncRoutine();
			foreach (AgentAction key in actions.Keys)
			{
				key.ForceCancelAction();
				key.ClearSyncedAction();
			}
		}

		private void StopSyncRoutine()
		{
			if (_syncByDistanceRoutine != null && (bool)_syncRoutineParent)
			{
				_syncRoutineParent.StopCoroutine(_syncByDistanceRoutine);
			}
			_syncByDistanceRoutine = null;
		}
	}
}
