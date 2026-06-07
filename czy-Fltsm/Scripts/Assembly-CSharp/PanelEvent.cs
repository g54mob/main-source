public class PanelEvent : GameEvent
{
	public Panel Panel { get; }

	public PanelID ID { get; } = PanelID.None;

	public PanelEvent(GameEventType eventType, Panel panel)
		: base(eventType)
	{
		Panel = panel;
		ID = panel.ID;
	}

	public static void DispatchPanelOpenedEvent(Panel panel)
	{
		new PanelEvent(GameEventType.PanelOpened, panel).Dispatch();
	}

	public static void DispatchPanelClosedEvent(Panel panel)
	{
		new PanelEvent(GameEventType.PanelClosed, panel).Dispatch();
	}
}
