namespace ModApi.GameLoop.Interfaces
{
	public interface IDesignerPostStart : IGameLoopItem
	{
		void DesignerPostStart(in DesignerFrameData frame);
	}
}
