namespace Brewery.Bar.Brawl.States
{
	public class BrawlIdleState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		public BrawlState StateType => default(BrawlState);

		public BrawlIdleState(BrawlStateContext context)
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

		private bool CheckForNearbyBrawl()
		{
			return false;
		}
	}
}
