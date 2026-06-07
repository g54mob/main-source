using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CouplerCoupledCondition : AQuickTutorialCondition
	{
		private readonly Coupler coupler;

		private ChainCouplerInteraction interaction;

		private readonly bool mustBeTight;

		public CouplerCoupledCondition(Coupler coupler, bool mustBeTight)
		{
			this.coupler = coupler;
			this.mustBeTight = mustBeTight;
		}

		public override void Start()
		{
			Transform chain = coupler.visualCoupler.chain;
			if (chain != null)
			{
				interaction = chain.GetComponentInChildren<ChainCouplerInteraction>();
			}
			else
			{
				interaction = null;
			}
		}

		private bool IsChainAttached(ChainCouplerInteraction.State state)
		{
			if (state != ChainCouplerInteraction.State.Attached && (mustBeTight || state != ChainCouplerInteraction.State.Attached_Loose))
			{
				return state == ChainCouplerInteraction.State.Attached_Tight;
			}
			return true;
		}

		public override string Check()
		{
			if (interaction != null)
			{
				if (coupler.coupledTo != null || IsChainAttached(interaction.CurrentState))
				{
					return string.Empty;
				}
				return "nope";
			}
			return "nope";
		}
	}
}
