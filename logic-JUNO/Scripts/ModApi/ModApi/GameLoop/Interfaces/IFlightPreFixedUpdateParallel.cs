namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPreFixedUpdateParallel : IGameLoopItem
	{
		void FlightPreFixedUpdateParallel(in FlightFrameData frame);
	}
}
