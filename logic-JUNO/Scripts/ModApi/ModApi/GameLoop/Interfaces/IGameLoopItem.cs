namespace ModApi.GameLoop.Interfaces
{
	public interface IGameLoopItem
	{
		bool StartMethodCalled { get; set; }

		int GetInstanceID();
	}
}
