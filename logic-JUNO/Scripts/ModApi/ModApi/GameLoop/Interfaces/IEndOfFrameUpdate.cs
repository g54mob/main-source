namespace ModApi.GameLoop.Interfaces
{
	public interface IEndOfFrameUpdate : IGameLoopItem
	{
		void EndOfFrameUpdate(in FrameData frame);
	}
}
