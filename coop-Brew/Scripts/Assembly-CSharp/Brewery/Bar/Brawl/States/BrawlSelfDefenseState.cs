namespace Brewery.Bar.Brawl.States
{
	public class BrawlSelfDefenseState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		private float stateTime;

		private float lastDamageTime;

		private float timeout;

		public BrawlState StateType => default(BrawlState);

		public BrawlSelfDefenseState(BrawlStateContext context)
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

		public void OnDamageTaken()
		{
		}

		private bool IsTargetGone()
		{
			return false;
		}

		private void DetachFromBarSystems()
		{
		}
	}
}
