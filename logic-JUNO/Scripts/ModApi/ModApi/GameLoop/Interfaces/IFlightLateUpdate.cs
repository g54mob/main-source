namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightLateUpdate : IGameLoopItem
	{
		void FlightLateUpdate(in FlightFrameData frame);
	}
}
