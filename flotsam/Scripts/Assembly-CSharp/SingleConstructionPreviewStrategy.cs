using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Strategies/Single Construction")]
public class SingleConstructionPreviewStrategy : ConstructionCursorProperties, IMoveBuildablePreviewStrategy
{
	private BuildableProperties _properties;

	private Vector3 _storedPosition;

	public IMoveBuildablePreviewStrategy Activate(Buildable buildable, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Buildable buildableOut)
	{
		BuildableProperties properties = buildable.Properties;
		Vector3 b = (properties.Outline[0].Vector3TopDown() + properties.Outline[properties.Outline.Length - 1].Vector3TopDown()) * 0.5f;
		float hookDistance = Vector3.Distance(properties.Prefab.transform.position, b);
		preview = IMoveBuildablePreviewStrategy.CreateConstructionVisual(properties.Prefab, visualIndex, previewSettings, isHooked: false, createMarkerProxy: true);
		_properties = properties;
		_hookDistance = hookDistance;
		_storedPosition = Vector3.back * (GameManager.Settings.GameplaySettings.DestructionRadius - 50);
		buildableOut = SetBuildable(buildable);
		return this;
	}

	public void UpdateConstructionPreview(ref ConstructionPreview preview)
	{
		bool snapBuilding = Settings.Instance.GameplayPlayerData.SnapBuilding;
		bool isHooked = preview.IsHooked;
		UpdateTransform(preview, CursorManager.BuildingPosition, out var _, snapBuilding);
		Shader.SetGlobalVector("_GLOBAL_GRIDCURSOR_Amplitude", preview.Transform.transform.position);
		preview.UpdateCanBePlaced(needsHook: true, !snapBuilding);
		preview.SetValid(preview.CanPlace);
		if (isHooked != preview.IsHooked)
		{
			if (preview.IsHooked)
			{
				BuildingGrid.Enable(_properties);
			}
			else
			{
				BuildingGrid.Disable();
			}
		}
		if (preview.IsHooked)
		{
			BuildingGrid.SetPlacement(preview.Transform.transform.position, preview.Hook);
		}
	}

	public bool MoveBuildable(ref Buildable buildable, ConstructionPreview preview)
	{
		buildable.gameObject.SetActive(value: true);
		buildable.transform.SetPositionAndRotation(preview.Transform.transform.position, preview.Transform.transform.rotation);
		if (buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable))
		{
			buildableExtendable.Initialize(buildable);
		}
		if (buildable.TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable2))
		{
			buildableExtendable2.RefreshDecorationGraphNodes();
		}
		buildable.Activate();
		Hookable hookable = preview.Hookable;
		if (buildable.TryGetComponent<Construction>(out var component) && hookable.TryGetComponent<Construction>(out var component2) && component.AddNeighbourConstruction(component2))
		{
			component2.AddNeighbourConstruction(component);
		}
		buildable.GetComponentInChildren<Buoyancy>().ForceWaterLevel(buildable.transform.position.y);
		return true;
	}

	public Buildable SetBuildable(Buildable buildable)
	{
		IMoveBuildablePreviewStrategy.DisconnectEnergyConnections(buildable);
		buildable.Deactivate();
		if (buildable.TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable))
		{
			buildableExtendable.DisconnectEnergyPoles();
		}
		if (buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable2) && Community.PlayerCommunity.Constructions.Contains(buildableExtendable2))
		{
			buildableExtendable2.Remove();
		}
		buildable.gameObject.SetActive(value: false);
		buildable.transform.position = _storedPosition;
		return buildable;
	}

	public void StoreBuildable(Buildable buildable, bool toggleCategory)
	{
		Community.PlayerCommunity.AddStoredBuildable(buildable.Properties, buildable, toggleCategory);
	}

	public void ContinuousBuilding()
	{
	}
}
