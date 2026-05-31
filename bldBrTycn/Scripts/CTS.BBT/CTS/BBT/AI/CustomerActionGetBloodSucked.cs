using System;
using System.Collections;
using CTS.Core;
using CTS.Utilities;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionGetBloodSucked : CustomerAction
	{
		private readonly Agent _vampire;

		private static Addressable<PrestigeUIStatsSO> _investigatorKilledStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/InvestigatorsKilled.asset");

		private static Addressable<PrestigeUIStatsSO> _hunterKilledStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HunterKilled.asset");

		public static event Action<Customer> KilledByWorker;

		public CustomerActionGetBloodSucked(Agent p_vampire)
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
			base.ActionAgent.ClearLivingState();
			base.ActionAgent.Animator.Events.OnBitten += Kill;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.BittenDeath);
		}

		private void Kill()
		{
			base.ActionAgent.Animator.Events.OnBitten -= Kill;
			base.ActionAgent.Animator.Lock();
			if (_vampire is Worker)
			{
				int vigilanceForKilling = base.ActionAgent.VigilanceMultipliersData.GetVigilanceForKilling(base.ActionAgent);
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(vigilanceForKilling, base.ActionAgent, EBone.HeadTop);
				CustomerActionGetBloodSucked.KilledByWorker?.Invoke(base.ActionAgent);
			}
			base.ActionAgent.Health.ForceDeath();
			base.ActionAgent.Animator.Unlock();
		}

		protected override void OnStopped()
		{
			if ((bool)base.ActionAgent)
			{
				base.ActionAgent.Animator.Events.OnBitten -= Kill;
			}
		}

		public override void OnCancel()
		{
		}
	}
}
