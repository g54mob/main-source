namespace Brewery.Bar.Brawl.States
{
	public class BrawlFleeingState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		private float stateTime;

		private float timeout;

		private bool destinationSet;

		private bool waitingForRagdollRecovery;

		public BrawlState StateType => default(BrawlState);

		public BrawlFleeingState(BrawlStateContext context)
		{
		}

		public void OnEnter()
		{
		}

		public void OnExit()
		{
		}

		public IBrawlStateResult Tick(float deltaTime)
		{
			return null;
		}

		public BrawlState? TryGetNextState(IBrawlStateResult result)
		{
			return null;
		}

		private void StartFleeing()
		{
		}

		private bool SetFleeDestination()
		{
			return false;
		}

		private bool HasArrivedHome()
		{
			return false;
		}

		private bool IsStuck()
		{
			return false;
		}

		private bool TryRecalculatePath()
		{
			return false;
		}
	}
}
