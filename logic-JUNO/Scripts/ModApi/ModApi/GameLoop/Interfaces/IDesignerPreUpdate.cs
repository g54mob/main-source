namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPreUpdate : IGameLoopItem
	{
		void DesignerPreUpdate(in DesignerFrameData frame);
	}
}
