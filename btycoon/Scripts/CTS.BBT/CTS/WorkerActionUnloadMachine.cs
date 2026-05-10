using System.Collections;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class WorkerActionUnloadMachine : WorkerAction
	{
		private SoftReference<MachineBase> _machine;

		private bool _shouldVictimBeControlled;

		public bool ShouldVictimLeaveAfter;

		private Customer _exitingCustomer;

		private LockToggle _crimeVisionToggle = new LockToggle();

		public WorkerActionUnloadMachine(SoftReference<MachineBase> machine, bool shouldVictimBeControlled = false)
		{
			_machine = machine;
			_shouldVictimBeControlled = shouldVictimBeControlled;
		}

		public override void OnStart()
		{
			_exitingCustomer = null;
			_crimeVisionToggle.Clear();
			_crimeVisionToggle.Lock();
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			MachineBase machineBase = _machine.Get();
			if (!machineBase)
			{
				return false;
			}
			if (!(agentRef is Worker worker))
			{
				return false;
			}
			if (!worker.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (!machineBase.HasAVictim)
			{
				return false;
			}
			if (!machineBase.CanBeUsed(agentRef) && !machineBase.CanBeUsed(machineBase.Victim))
			{
				return false;
			}
			return machineBase.UnloadCondition(agentRef);
		}

		public override IEnumerator WaitForRoutine()
		{
			MachineBase machineBase = _machine.Get();
			machineBase.UnloadPreparation();
			yield return MoveToTarget(machineBase.UnloaderPosition ? machineBase.UnloaderPosition : machineBase.LoaderPosition);
		}

		public override IEnumerator ActionRoutine()
		{
			MachineBase machineBase = _machine.Get();
			CustomerActionGetUnloaded customerUnload = new CustomerActionGetUnloaded(machineBase)
			{
				ShouldLeaveAfter = ShouldVictimLeaveAfter
			};
			Customer customer = (_exitingCustomer = (Customer)machineBase.Victim);
			_crimeVisionToggle.Add(_exitingCustomer.CrimeWitness);
			customer.ActionPlayer.PlayInstantly(customerUnload);
			if ((bool)machineBase.MachineTechTree)
			{
				machineBase.MachineTechTree.TryToGenerateResearchPoints(base.ActionAgent, base.ActionAgent.Statistics.GetStatisticValue(EAgentStatistics.Intellect));
			}
			while (customer.ActionPlayer.HasAction(customerUnload) && customerUnload.Status < EStatus.Completed)
			{
				yield return null;
				SetExitingCustomerAsControlled();
			}
			SetExitingCustomerAsControlled();
		}

		public override void OnCancel()
		{
			SetExitingCustomerAsControlled();
		}

		private void SetExitingCustomerAsControlled()
		{
			if (_shouldVictimBeControlled && !(_exitingCustomer == null))
			{
				MachineBase machineBase = _machine.Get();
				if (!(base.ActionAgent == null) && (object)machineBase.Victim != _exitingCustomer && (object)base.ActionAgent.ControlledHuman != _exitingCustomer)
				{
					base.ActionAgent.SetControlledHuman(_exitingCustomer);
					_crimeVisionToggle.Remove(_exitingCustomer.CrimeWitness);
					_exitingCustomer = null;
				}
			}
		}

		protected override void OnStopped()
		{
			_crimeVisionToggle.Clear();
		}

		public void SetMachine(MachineBase machine)
		{
			_machine = SoftReference.Create(machine);
		}
	}
}
