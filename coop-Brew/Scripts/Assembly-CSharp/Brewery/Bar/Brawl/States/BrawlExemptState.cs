namespace Brewery.Bar.Brawl.States
{
	public class BrawlExemptState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		private float stateTime;

		private float cooldownDuration;

		public BrawlState StateType => default(BrawlState);

		public BrawlExemptState(BrawlStateContext context)
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
	}
}
