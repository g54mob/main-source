namespace ModApi.GameLoop.Interfaces
{
	public interface IUpdate : IGameLoopItem
	{
		void Update(in FrameData frame);
	}
}
