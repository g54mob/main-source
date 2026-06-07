public interface IBuildablePanelElement
{
	BuildablePanelElementId Id { get; }

	bool Activate(Buildable buildable, bool finished);

	void Deactivate();
}
