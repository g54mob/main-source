namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostUpdate : IGameLoopItem
	{
		void FlightPostUpdate(in FlightFrameData frame);
	}
}
