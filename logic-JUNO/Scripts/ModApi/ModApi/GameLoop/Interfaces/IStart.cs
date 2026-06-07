namespace ModApi.GameLoop.Interfaces
{
	public interface IStart : IGameLoopItem
	{
		void Start(in FrameData frame);
	}
}
