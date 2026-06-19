public class RadicalPauseMenuOption_Continue : RadicalPauseMenuOption
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.PopAllMenus();
	}

	public override void OnCleanupAndReset()
	{
		base.OnCleanupAndReset();
		Manager.ui.DeselectAnySelectedUIElement();
	}
}
