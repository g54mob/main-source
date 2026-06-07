namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPostFixedUpdate : IGameLoopItem
	{
		void DesignerPostFixedUpdate(in DesignerFrameData frame);
	}
}
