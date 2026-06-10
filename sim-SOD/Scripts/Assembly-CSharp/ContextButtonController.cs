public class ContextButtonController : ButtonController
{
	public ContextMenuController cmc;

	public ContextMenuPanelController panelController;

	public ContextMenuController.ContextMenuButtonSetup setup;

	public void Setup(ContextMenuController newCmc, ContextMenuPanelController newPanel, ContextMenuController.ContextMenuButtonSetup newSetup)
	{
	}

	public override void UpdateButtonText()
	{
	}

	public override void OnLeftClick()
	{
	}
}
