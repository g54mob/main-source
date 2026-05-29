using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;

namespace CTS
{
	public class WorkerActionLoadMachine : WorkerAction
	{
		private SoftReference<Customer> _victim;

		private SoftReference<MachineBase> _machine;

		private PooledRef<Customer> _currentVictim;

		public Customer Victim
		{
			get
			{
				return _victim;
			}
			set
			{
				_victim = SoftReference.Create(value);
			}
		}

		public WorkerActionLoadMachine(SoftReference<MachineBase> machine, SoftReference<Customer> victim = default(SoftReference<Customer>))
		{
			_machine = machine;
			_victim = victim;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!(agentRef is Worker worker))
			{
				return false;
			}
			if (!worker.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			MachineBase machineBase = _machine.Get();
			if (!machineBase)
			{
				return false;
			}
			if (!machineBase.Furniture.Controller.IsPlaced)
			{
				return false;
			}
			Customer victim = Victim;
			if (!victim)
			{
				return false;
			}
			if (!machineBase.CanBeUsed(agentRef) && !machineBase.CanBeUsed(victim))
			{
				return false;
			}
			return machineBase.LoadCondition(agentRef);
		}

		public override void OnStart()
		{
			_currentVictim = new PooledRef<Customer>(Victim);
			SyncWithFurniture((MachineBase)_machine);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToTarget(_machine.Get().LoaderPosition);
			if (!_currentVictim.TryGetValue(out var outValue) || outValue.ControllingVampire != base.ActionAgent)
			{
				CancelAction("No customer", playBlockedAction: true);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			MachineBase machine = _machine.Get();
			if (!_currentVictim.TryGetValue(out var customer))
			{
				yield break;
			}
			CustomerActionGetLoadedInMachine customerLoad = new CustomerActionGetLoadedInMachine(_machine);
			customer.ActionPlayer.ForceAction(customerLoad, EActionPriority.Player);
			while (customer.ActionPlayer.HasAction(customerLoad))
			{
				yield return null;
			}
			if (customerLoad.Status == EStatus.Completed)
			{
				if ((bool)customer.ControllingVampire)
				{
					customer.ControllingVampire.SetControlledHuman(null);
				}
				if ((bool)machine.MachineTechTree)
				{
					machine.MachineTechTree.TryToGenerateResearchPoints(base.ActionAgent, base.ActionAgent.Statistics.GetStatisticValue(EAgentStatistics.Intellect));
				}
			}
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
			if (_victim.Value == _machine.Value.Victim)
			{
				base.ActionAgent.SetControlledHuman(null);
			}
		}
	}
}
