using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;

namespace CTS
{
	public class AgentActionGetDeleted : AgentAction<Agent>
	{
		private int _vigilanceToAdd;

		private static Addressable<PrestigeUIStatsSO> _corpsDisposalStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/CorpsDisposal.asset");

		private Addressable<PrestigeUIStatsSO> _humanCustomerDiedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HumansKilled.asset");

		private Addressable<PrestigeUIStatsSO> _investigatorDiedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/InvestigatorsKilled.asset");

		private Addressable<PrestigeUIStatsSO> _hunterCustomerDiedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HunterKilled.asset");

		public static event Action<Agent> AgentDeleted;

		public AgentActionGetDeleted(int vigilanceAdded = 0)
		{
			_vigilanceToAdd = vigilanceAdded;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			if (base.ActionAgent is Customer customer)
			{
				customer.ClearLivingState();
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			base.ActionAgent.Animator.PlayPunctual(AgentAnim.ScaredJumpStart);
			yield return Coroutines.WaitForSeconds(0.5f);
			if (base.ActionAgent is Customer { IsVampire: false } customer)
			{
				int vigilanceForAbyssalDeath = customer.VigilanceMultipliersData.GetVigilanceForAbyssalDeath(customer);
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(vigilanceForAbyssalDeath, customer, EBone.HeadTop);
				_corpsDisposalStat.Value.AddToCurrentValue(vigilanceForAbyssalDeath);
			}
			else if (base.ActionAgent is Worker worker)
			{
				worker.Dismiss();
			}
			if (base.ActionAgent.AgentVisualControler.CharacterData.SubSpecies == ESubSpecies.Investigateur)
			{
				_investigatorDiedStat.Value?.AddToCurrentValue(1);
			}
			else if (base.ActionAgent.AgentVisualControler.CharacterData.SubSpecies == ESubSpecies.Hunter)
			{
				_hunterCustomerDiedStat?.Value.AddToCurrentValue(1);
			}
			else if (base.ActionAgent.IsHuman)
			{
				_humanCustomerDiedStat.Value?.AddToCurrentValue(1);
			}
			AgentActionGetDeleted.AgentDeleted?.Invoke(base.ActionAgent);
			base.ActionAgent.ClearObject();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
