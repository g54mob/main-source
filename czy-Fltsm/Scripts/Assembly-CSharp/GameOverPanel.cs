public class GameOverPanel : Panel
{
	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			GameManager.UIManager.PauseGame();
			return true;
		}
		return false;
	}
}
