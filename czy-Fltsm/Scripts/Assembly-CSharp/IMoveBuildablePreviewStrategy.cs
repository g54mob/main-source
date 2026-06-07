public interface IMoveBuildablePreviewStrategy
{
	IMoveBuildablePreviewStrategy Activate(Buildable buildable, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Buildable buildableOut);

	void UpdateConstructionPreview(ref ConstructionPreview preview);

	void StoreBuildable(Buildable buildable, bool toggleCategory);

	bool MoveBuildable(ref Buildable buildable, ConstructionPreview preview);

	void ContinuousBuilding();

	IMoveBuildablePreviewStrategy Activate(Decoration decoration, DecorationProperties decorationProperties, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Decoration decorationOut)
	{
		preview = null;
		decorationOut = null;
		return null;
	}

	void StoreDecoration(Decoration decoration, bool toggleCategory)
	{
	}

	bool MoveDecoration(Decoration decoration, ConstructionPreview preview)
	{
		return false;
	}

	static ConstructionPreview CreateConstructionVisual(Buildable buildable, int visualIndex, VisualPrefabPreviewSettings previewSettings, bool isHooked = false, bool createMarkerProxy = false)
	{
		return new ConstructionPreview(buildable, previewSettings, visualIndex, createMarkerProxy, isHooked);
	}

	static void DisconnectEnergyConnections(Buildable buildable)
	{
		if (!buildable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable) || !buildableExtendable.HasConnections())
		{
			return;
		}
		EnergyGridConnector[] connections = buildableExtendable.Connections;
		foreach (EnergyGridConnector energyGridConnector in connections)
		{
			if ((bool)energyGridConnector)
			{
				EnergyGrid.Disconnect(buildableExtendable, energyGridConnector);
			}
		}
	}
}
