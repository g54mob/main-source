using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;

namespace CTS
{
	public class CustomerActionGetLoadedInMachine : CustomerAction
	{
		private SoftReference<MachineBase> _machine;

		private Tween _currentTween;

		private static readonly StringKey _satisfactionCagedLossKey = "CagedLoss";

		public CustomerActionGetLoadedInMachine(SoftReference<MachineBase> machine)
		{
			_machine = machine;
		}

		public CustomerActionGetLoadedInMachine(MachineBase machine)
			: this(SoftReference.Create(machine))
		{
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return _machine.Get() != null;
		}

		public override void OnStart()
		{
			if (base.ActionAgent.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious>())
			{
				base.ActionAgent.ContextualFSM.SetStateNormal();
				PlayActionAndResumeThis(new AgentActionGetUp());
			}
			SyncWithFurniture((MachineBase)_machine);
		}

		public override IEnumerator WaitForRoutine()
		{
			MachineBase machineBase = _machine.Get();
			base.ActionAgent.FurnitureAssignment.StartUsing(machineBase);
			yield return MoveToTarget(machineBase.LoadingPosition, (int?)(-1));
		}

		public override IEnumerator ActionRoutine()
		{
			MachineBase machine = _machine.Get();
			base.ActionAgent.Satisfaction.SetModifier(_satisfactionCagedLossKey);
			_currentTween = machine.LoadPreparation();
			yield return _currentTween.WaitForCompletion();
			_currentTween = null;
			if (machine.MovingToLoaded)
			{
				yield return MoveToTarget(machine.LoadedPosition, (int?)(-1));
			}
			_currentTween = machine.LoadVictim(base.ActionAgent);
			if (!base.ActionAgent.Tags.HasTag(EAgentTag.WentInMachine) && !(machine is ICustomerCell))
			{
				int vigilanceForEnterMachine = base.ActionAgent.VigilanceMultipliersData.GetVigilanceForEnterMachine(base.ActionAgent);
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(vigilanceForEnterMachine, base.ActionAgent, EBone.HeadTop);
			}
			yield return _currentTween.WaitForCompletion();
			_currentTween = null;
		}

		public override void OnCancel()
		{
			if (base.ActionAgent == _machine.Value.Victim)
			{
				base.ActionAgent.SetControllingVampire(null);
			}
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}
	}
}
