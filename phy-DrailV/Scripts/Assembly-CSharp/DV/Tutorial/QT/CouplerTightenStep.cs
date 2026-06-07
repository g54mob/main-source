using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CouplerTightenStep : AQuickTutorialStep
	{
		private Coupler[] couplers;

		private ChainCouplerInteraction[] interactions;

		private bool tight;

		private int index;

		public CouplerTightenStep(Coupler coupler, Coupler otherCoupler, AQuickTutorialMessage message, bool tight, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, null, offset, shouldRecheck)
		{
			couplers = new Coupler[2] { coupler, otherCoupler };
			interactions = new ChainCouplerInteraction[2]
			{
				coupler.visualCoupler.chain.GetComponentInChildren<ChainCouplerInteraction>(),
				otherCoupler.visualCoupler.chain.GetComponentInChildren<ChainCouplerInteraction>()
			};
			this.tight = tight;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			if (interactions[1].CurrentState == ChainCouplerInteraction.State.Attached_Loose || interactions[1].CurrentState == ChainCouplerInteraction.State.Attached_Tight || interactions[1].CurrentState == ChainCouplerInteraction.State.Attached_Tightening_Couple)
			{
				index = 1;
			}
			else
			{
				index = 0;
			}
			AttentionPoint = couplers[index].visualCoupler.chain.GetComponent<ChainCouplerInteraction>().screwButton.transform;
			ShowVisual();
		}

		protected override bool InternalCheck()
		{
			if (interactions[index].CurrentState == ChainCouplerInteraction.State.Attached_Tightening_Couple && shownFloatie)
			{
				SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				shownFloatie = false;
			}
			if (tight)
			{
				return interactions[index].CurrentState == ChainCouplerInteraction.State.Attached_Tight;
			}
			return interactions[index].CurrentState != ChainCouplerInteraction.State.Attached_Tight;
		}

		protected override QTVerb GetVerb()
		{
			if (!tight)
			{
				return QTVerb.Loosen;
			}
			return QTVerb.Tighten;
		}
	}
}
