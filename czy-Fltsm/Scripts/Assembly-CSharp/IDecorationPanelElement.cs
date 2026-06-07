public interface IDecorationPanelElement
{
	DecorationPanelElementId Id { get; }

	void Activate(Decoration decoration);

	void Deactivate();
}
