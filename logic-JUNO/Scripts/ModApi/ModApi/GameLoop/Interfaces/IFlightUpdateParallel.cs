namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightUpdateParallel : IGameLoopItem
	{
		void FlightUpdateParallel(in FlightFrameData frame);
	}
}
