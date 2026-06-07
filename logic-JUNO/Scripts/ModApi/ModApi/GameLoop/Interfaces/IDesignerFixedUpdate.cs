namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerFixedUpdate : IGameLoopItem
	{
		void DesignerFixedUpdate(in DesignerFrameData frame);
	}
}
