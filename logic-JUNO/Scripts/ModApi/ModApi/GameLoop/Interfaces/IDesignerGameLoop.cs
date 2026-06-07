namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerGameLoop : IGameLoop
	{
		void Register(IGameLoopItem script);

		void Unregister(IGameLoopItem script);
	}
}
