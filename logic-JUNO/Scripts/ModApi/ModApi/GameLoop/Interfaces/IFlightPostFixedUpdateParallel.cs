namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostFixedUpdateParallel : IGameLoopItem
	{
		void FlightPostFixedUpdateParallel(in FlightFrameData frame);
	}
}
