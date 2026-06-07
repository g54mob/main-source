namespace ModApi.GameLoop.Interfaces
{
	public interface IFlightGameLoop : IGameLoop
	{
		void Register(IGameLoopItem script);

		void Unregister(IGameLoopItem script);
	}
}
