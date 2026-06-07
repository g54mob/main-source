namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerEndOfFrameUpdate : IGameLoopItem
	{
		void DesignerEndOfFrameUpdate(in DesignerFrameData frame);
	}
}
