namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightFixedUpdate : IGameLoopItem
	{
		void FlightFixedUpdate(in FlightFrameData frame);
	}
}
