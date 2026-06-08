using KitchenData;

namespace Kitchen
{
	public class AddDirtItems : PostResolveSatisfactionSystem
	{
		protected override void HandleSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref COrderAcceptance details)
		{
			base.Data.TryGet<Item>(details.DeliveredItem, out var output);
			if (output != null && output.DirtiesTo != null)
			{
				GetBuffer<CDirtItem>(details.TableSet).Add(new CDirtItem
				{
					ID = output.DirtiesTo.ID
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
