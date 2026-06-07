namespace ModApi.GameLoop.Interfaces
{
	public interface IGameLoopRegistrar
	{
		void Register(IGameLoopItem script);

		void Unregister(IGameLoopItem script);
	}
}
