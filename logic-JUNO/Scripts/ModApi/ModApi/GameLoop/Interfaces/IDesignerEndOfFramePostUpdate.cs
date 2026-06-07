namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerEndOfFramePostUpdate : IGameLoopItem
	{
		void DesignerEndOfFramePostUpdate(in DesignerFrameData frame);
	}
}
