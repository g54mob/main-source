namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightLateUpdateParallel : IGameLoopItem
	{
		void FlightLateUpdateParallel(in FlightFrameData frame);
	}
}
