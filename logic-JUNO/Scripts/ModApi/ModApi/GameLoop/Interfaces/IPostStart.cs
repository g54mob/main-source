namespace ModApi.GameLoop.Interfaces
{
	public interface IPostStart : IGameLoopItem
	{
		void PostStart(in FrameData frame);
	}
}
