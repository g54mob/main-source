namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPreLateUpdateParallel : IGameLoopItem
	{
		void FlightPreLateUpdateParallel(in FlightFrameData frame);
	}
}
