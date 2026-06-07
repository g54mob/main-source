namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerUpdate : IGameLoopItem
	{
		void DesignerUpdate(in DesignerFrameData frame);
	}
}
