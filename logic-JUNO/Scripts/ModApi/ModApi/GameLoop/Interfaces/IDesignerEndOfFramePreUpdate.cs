namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerEndOfFramePreUpdate : IGameLoopItem
	{
		void DesignerEndOfFramePreUpdate(in DesignerFrameData frame);
	}
}
