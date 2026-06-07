namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPreFixedUpdate : IGameLoopItem
	{
		void DesignerPreFixedUpdate(in DesignerFrameData frame);
	}
}
