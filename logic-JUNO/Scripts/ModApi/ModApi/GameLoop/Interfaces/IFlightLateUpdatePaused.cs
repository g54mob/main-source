namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightLateUpdatePaused : IGameLoopItem
	{
		void FlightLateUpdatePaused(in FlightFrameData frame);
	}
}
