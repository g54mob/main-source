namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightUpdate : IGameLoopItem
	{
		void FlightUpdate(in FlightFrameData frame);
	}
}
