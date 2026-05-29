using System.Collections;
using CTS.Core;

namespace CTS.BBT.AI
{
	internal sealed class WorkerActionPlayer : AgentActionPlayer
	{
		private Worker _workerRef;

		protected override void OnAwake()
		{
			base.OnAwake();
			_workerRef = (Worker)agent;
		}

		protected override IEnumerator WaitForRoutine()
		{
			yield return StartCoroutine(base.CurrentAction.WaitForRoutine());
		}

		protected override IEnumerator ActionRoutine()
		{
			yield return StartCoroutine(base.CurrentAction.ActionRoutine());
		}

		public override void ForceAction(AgentAction newAction, EActionPriority priority)
		{
			base.ForceAction(newAction, priority);
			if (newAction is WorkerChore p_chore)
			{
				MonoSingleton<ChoreList>.Instance.RemoveChore(p_chore);
			}
		}

		public override void PlayInstantly(AgentAction action, EInsertType insertType = EInsertType.CancelAction, EActionPriority priority = EActionPriority.Forced)
		{
			InsertAction(action, insertType, priority);
			if (base.CurrentAction != null)
			{
				return;
			}
			if (!(action is WorkerAction p_action))
			{
				if (action is AgentAction<Agent> p_action2)
				{
					_workerRef.FSM.SetState(new WorkerActionState<Agent>(p_action2));
				}
			}
			else
			{
				_workerRef.FSM.SetState(new WorkerActionState<Worker>(p_action));
			}
		}
	}
}
