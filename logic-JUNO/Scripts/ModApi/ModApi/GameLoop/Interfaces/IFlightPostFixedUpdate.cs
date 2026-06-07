namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostFixedUpdate : IGameLoopItem
	{
		void FlightPostFixedUpdate(in FlightFrameData frame);
	}
}
