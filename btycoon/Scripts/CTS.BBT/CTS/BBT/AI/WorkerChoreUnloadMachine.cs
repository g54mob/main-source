using System;
using System.Collections;

namespace CTS.BBT.AI
{
	public class WorkerChoreUnloadMachine : WorkerChore
	{
		private readonly Func<MachineBase, bool> _unloadCondition;

		private readonly MachineBase _machine;

		private readonly WorkerActionUnloadMachine _workerAction;

		public WorkerChoreUnloadMachine(ChoreCategory category, MachineBase machine, Func<MachineBase, bool> unloadCondition)
			: base(category, machine.Furniture.RoomObject)
		{
			_machine = machine;
			_unloadCondition = unloadCondition;
			_workerAction = new WorkerActionUnloadMachine(machine)
			{
				ShouldVictimLeaveAfter = true
			};
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!_unloadCondition(_machine))
			{
				return false;
			}
			return _workerAction.CanBePerformed(agentRef);
		}

		public override void OnStart()
		{
			_workerAction.Status = EStatus.Idle;
			_workerAction.SetAgent(base.ActionAgent);
			_workerAction.Stopped = false;
			_workerAction.OnStart();
		}

		public override IEnumerator WaitForRoutine()
		{
			_workerAction.Status = EStatus.Wait;
			yield return _workerAction.WaitForRoutine();
		}

		public override IEnumerator ActionRoutine()
		{
			_workerAction.Status = EStatus.InProgress;
			yield return _workerAction.ActionRoutine();
		}

		protected override void OnStopped()
		{
			_workerAction.ClearAgent();
		}

		public override void OnCancel()
		{
			if (_workerAction != null)
			{
				_workerAction.Status = EStatus.Idle;
			}
			base.OnCancel();
		}

		public override void OnComplete()
		{
			if (_workerAction != null)
			{
				_workerAction.Status = EStatus.Completed;
			}
			base.OnComplete();
		}

		protected override void OnDestroy()
		{
		}
	}
}
