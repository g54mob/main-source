namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPreLateUpdate : IGameLoopItem
	{
		void DesignerPreLateUpdate(in DesignerFrameData frame);
	}
}
