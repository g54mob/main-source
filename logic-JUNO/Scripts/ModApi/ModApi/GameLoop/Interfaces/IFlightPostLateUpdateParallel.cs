namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostLateUpdateParallel : IGameLoopItem
	{
		void FlightPostLateUpdateParallel(in FlightFrameData frame);
	}
}
