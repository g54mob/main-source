namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPreUpdateParallel : IGameLoopItem
	{
		void FlightPreUpdateParallel(in FlightFrameData frame);
	}
}
