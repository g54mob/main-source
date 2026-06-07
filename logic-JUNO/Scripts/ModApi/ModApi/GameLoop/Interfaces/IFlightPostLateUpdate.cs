namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightPostLateUpdate : IGameLoopItem
	{
		void FlightPostLateUpdate(in FlightFrameData frame);
	}
}
