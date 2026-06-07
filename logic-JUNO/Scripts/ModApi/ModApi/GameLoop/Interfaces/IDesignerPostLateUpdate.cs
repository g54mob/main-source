namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPostLateUpdate : IGameLoopItem
	{
		void DesignerPostLateUpdate(in DesignerFrameData frame);
	}
}
