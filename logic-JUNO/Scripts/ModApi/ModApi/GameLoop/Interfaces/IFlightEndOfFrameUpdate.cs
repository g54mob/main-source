namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightEndOfFrameUpdate : IGameLoopItem
	{
		void FlightEndOfFrameUpdate(in FlightFrameData frame);
	}
}
