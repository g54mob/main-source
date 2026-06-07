namespace ModApi.GameLoop.Interfaces
{
	public interface IGenericGameLoop : IGameLoop
	{
		void Register(IGameLoopItem script);

		void Unregister(IGameLoopItem script);
	}
}
