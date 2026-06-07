namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightEndOfFramePreUpdate : IGameLoopItem
	{
		void FlightEndOfFramePreUpdate(in FlightFrameData frame);
	}
}
