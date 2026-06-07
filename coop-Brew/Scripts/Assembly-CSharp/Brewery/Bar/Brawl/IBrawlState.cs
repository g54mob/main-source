namespace Brewery.Bar.Brawl
{
	public interface IBrawlState
	{
		BrawlState StateType { get; }

		void OnEnter();

		void OnExit();

		IBrawlStateResult Tick(float deltaTime);

		BrawlState? TryGetNextState(IBrawlStateResult result);
	}
}
