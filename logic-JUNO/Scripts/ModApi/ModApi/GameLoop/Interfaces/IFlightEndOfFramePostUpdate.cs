namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightEndOfFramePostUpdate : IGameLoopItem
	{
		void FlightEndOfFramePostUpdate(in FlightFrameData frame);
	}
}
