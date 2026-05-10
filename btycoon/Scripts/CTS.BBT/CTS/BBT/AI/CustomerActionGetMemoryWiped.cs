using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionGetMemoryWiped : CustomerAction
	{
		private readonly Agent _vampire;

		private bool _repositioned;

		public static StringKey MemoryWipedEvent { get; } = "MemoryWiped";

		public CustomerActionGetMemoryWiped(Agent p_vampire)
		{
			_vampire = p_vampire;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			SeatCheck();
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			yield return new WaitForSeconds(1f);
			base.ActionAgent.ContextualFSM.SetStateNormal();
			base.ActionAgent.MemoryWiped?.Invoke(_vampire);
			base.ActionAgent.Animator.Events.TriggerVFX(VFXList.MemoryWipe);
			base.ActionAgent.CrimeWitness.RestartObservingAfterCooldown(10f);
			base.ActionAgent.Satisfaction.RemoveModifier(ContextualStatePanicking.SatisfactionPanicKey);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Confused);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
