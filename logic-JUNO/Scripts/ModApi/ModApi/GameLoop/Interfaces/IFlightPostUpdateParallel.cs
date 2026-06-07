namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostUpdateParallel : IGameLoopItem
	{
		void FlightPostUpdateParallel(in FlightFrameData frame);
	}
}
