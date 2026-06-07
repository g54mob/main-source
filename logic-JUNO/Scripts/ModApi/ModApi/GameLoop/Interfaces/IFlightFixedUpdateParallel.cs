namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightFixedUpdateParallel : IGameLoopItem
	{
		void FlightFixedUpdateParallel(in FlightFrameData frame);
	}
}
