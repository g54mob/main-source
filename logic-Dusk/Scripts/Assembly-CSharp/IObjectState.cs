public interface IObjectState : IDiscoverable
{
	bool isPowered { get; }

	bool isExplored { get; }

	bool isScanned { get; }

	bool onSchematic { get; }
}
