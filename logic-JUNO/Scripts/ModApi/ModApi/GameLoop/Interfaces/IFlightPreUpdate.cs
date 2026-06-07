namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPreUpdate : IGameLoopItem
	{
		void FlightPreUpdate(in FlightFrameData frame);
	}
}
