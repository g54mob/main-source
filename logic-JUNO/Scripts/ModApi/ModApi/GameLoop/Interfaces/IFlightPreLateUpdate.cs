namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPreLateUpdate : IGameLoopItem
	{
		void FlightPreLateUpdate(in FlightFrameData frame);
	}
}
