namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightFixedUpdateWarp : IGameLoopItem
	{
		void FlightFixedUpdateWarp(in FlightFrameData frame);
	}
}
