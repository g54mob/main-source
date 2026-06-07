public class BuildablePanelToggledEvent : GameEvent
{
	public Scr_UIConstructionMenu Menu;

	public BuildablePanelToggledEvent(Scr_UIConstructionMenu menu)
		: base(GameEventType.BuildableMenuToggled)
	{
		Menu = menu;
	}
}
