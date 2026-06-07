namespace Brewery.Bar.Brawl.States
{
	public class BrawlCombatState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		private readonly bool isAggressor;

		private float stateTime;

		private float lastCombatActivityTime;

		private const float InactivityTimeout = 30f;

		public BrawlState StateType => default(BrawlState);

		public BrawlCombatState(BrawlStateContext context, bool isAggressor)
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

		private bool IsTargetInvalid()
		{
			return false;
		}

		private bool TryFindNewTarget()
		{
			return false;
		}

		public void OnCombatActivity()
		{
		}
	}
}
