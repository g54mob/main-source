namespace ModApi.GameLoop.Interfaces
{
	public interface ILateUpdate : IGameLoopItem
	{
		void LateUpdate(in FrameData frame);
	}
}
