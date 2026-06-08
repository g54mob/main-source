using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(PostResolveSatisfactionsGroup), OrderFirst = true)]
	public class DetectFlawlessTimingAchievement : PostResolveSatisfactionSystem
	{
		private bool HasPerformedFlawlessTimingAchievement;

		protected override void OnUpdate()
		{
			HasPerformedFlawlessTimingAchievement = false;
			base.OnUpdate();
			if (HasPerformedFlawlessTimingAchievement)
			{
				GetOrCreate<CFlawlessTimingEvent>();
			}
		}

		private void Check(Entity group)
		{
			Require<CPatience>(group, out CPatience comp);
			Require<CCustomerSettings>(group, out CCustomerSettings comp2);
			if (comp2.RemainingSeconds(comp) < 1f)
			{
				HasPerformedFlawlessTimingAchievement = true;
			}
		}

		protected override void HandleSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref COrderAcceptance details)
		{
			Check(details.Group);
		}

		protected override void HandlePartialSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref CPartialOrderAcceptance details)
		{
			Check(details.Group);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
