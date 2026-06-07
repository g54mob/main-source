namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPreFixedUpdate : IGameLoopItem
	{
		void FlightPreFixedUpdate(in FlightFrameData frame);
	}
}
