namespace TH20
{
	public class CollaborativeAsyncOperationGatherData : CollaborativeAsyncOperation
	{
		public override bool UploadOnceFinished => false;

		public override bool ForceOperationToFront => true;

		public CollaborativeAsyncOperationGatherData(CollaborativePortfolio portfolio)
			: base(portfolio)
		{
		}

		public override void Enter()
		{
			Portfolio.GatherLatestData();
		}

		public override void Update()
		{
			if (!Portfolio.IsGatheringLatestData)
			{
				Portfolio.RequestUpdateInviteData();
				Handler.EndOperation(this);
			}
		}
	}
}
