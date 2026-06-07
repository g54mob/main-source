namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerLateUpdate : IGameLoopItem
	{
		void DesignerLateUpdate(in DesignerFrameData frame);
	}
}
