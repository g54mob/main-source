namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPostUpdate : IGameLoopItem
	{
		void DesignerPostUpdate(in DesignerFrameData frame);
	}
}
