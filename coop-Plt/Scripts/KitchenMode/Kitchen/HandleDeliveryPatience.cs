using KitchenData;

namespace Kitchen
{
	public class HandleDeliveryPatience : PostResolveSatisfactionSystem
	{
		protected override void HandleSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref COrderAcceptance details)
		{
			Require<CPatience>(details.Group, out CPatience comp);
			Require<CCustomerSettings>(details.Group, out CCustomerSettings comp2);
			if (!details.IsSide && comp.Reason != PatienceReason.GetFoodDelivered && !comp2.Patience.SkipWaitPhase)
			{
				comp = comp2.NewPhase(PatienceReason.GetFoodDelivered);
			}
			else
			{
				comp2.AddPatience(ref comp, comp2.Patience.FoodDeliverBonus);
			}
			Set(details.Group, comp);
			CSoundEvent.Create(base.EntityManager, SoundEvent.ItemDelivered);
		}

		protected override void HandlePartialSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref CPartialOrderAcceptance details)
		{
			Require<CPatience>(details.Group, out CPatience comp);
			Require<CCustomerSettings>(details.Group, out CCustomerSettings comp2);
			comp2.AddPatience(ref comp, comp2.Patience.FoodDeliverBonus);
			Set(details.Group, comp);
			CSoundEvent.Create(base.EntityManager, SoundEvent.ItemDelivered);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
