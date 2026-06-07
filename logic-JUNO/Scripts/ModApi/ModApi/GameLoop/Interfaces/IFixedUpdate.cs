namespace ModApi.GameLoop.Interfaces
{
	public interface IFixedUpdate : IGameLoopItem
	{
		void FixedUpdate(in FrameData frame);
	}
}
