public interface IUIFlagsProvider
{
	PanelContainerFlags Flags { get; }

	bool BlockCancel { get; }

	bool BlockArchitectMode => false;
}
