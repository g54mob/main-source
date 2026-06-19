namespace TH20
{
	public abstract class CollaborativeAsyncOperation
	{
		protected readonly CollaborativePortfolio Portfolio;

		public CollaborativeAsyncOperationHandler Handler;

		public virtual bool UploadOnceFinished => true;

		public virtual bool ForceOperationToFront => false;

		protected CollaborativeAsyncOperation(CollaborativePortfolio portfolio)
		{
			Portfolio = portfolio;
		}

		public virtual void Enter()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void Exit()
		{
		}

		public virtual void Destroy()
		{
		}
	}
}
