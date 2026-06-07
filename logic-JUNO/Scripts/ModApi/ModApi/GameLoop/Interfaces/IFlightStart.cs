namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightStart : IGameLoopItem
	{
		void FlightStart(in FlightFrameData frame);
	}
}
