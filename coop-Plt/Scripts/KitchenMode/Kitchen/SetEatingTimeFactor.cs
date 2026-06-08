using KitchenData;

namespace Kitchen
{
	public class SetEatingTimeFactor : PostResolveSatisfactionSystem
	{
		protected override void HandleSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref COrderAcceptance details)
		{
			Require<CEatingTimeFactor>(details.Group, out CEatingTimeFactor comp);
			if (base.Data.TryGet<Item>(details.DeliveredItem, out var output) && output.EatingTime.Value > comp.Factor)
			{
				comp.Factor = output.EatingTime;
				Set(details.Group, comp);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
