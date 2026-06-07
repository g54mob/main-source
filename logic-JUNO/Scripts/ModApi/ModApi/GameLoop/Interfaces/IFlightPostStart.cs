namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostStart : IGameLoopItem
	{
		void FlightPostStart(in FlightFrameData frame);
	}
}
