public interface IPanel
{
	PanelID ID { get; }

	bool Open(PanelID id, IPanelContext context = null);

	void Close();
}
