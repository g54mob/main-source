namespace Brewery.Bar.Brawl.States
{
	public class BrawlCandidateState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		private float stateTime;

		private float timeout;

		private bool brawlStarted;

		public BrawlState StateType => default(BrawlState);

		public BrawlCandidateState(BrawlStateContext context)
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

		public void MarkBrawlStarted()
		{
		}

		private bool TryStartBrawl()
		{
			return false;
		}
	}
}
