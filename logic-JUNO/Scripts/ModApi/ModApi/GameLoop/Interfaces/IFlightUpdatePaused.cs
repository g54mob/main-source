namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightUpdatePaused : IGameLoopItem
	{
		void FlightUpdatePaused(in FlightFrameData frame);
	}
}
