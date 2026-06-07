using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class ConstructionPreview : BuildablePreview
{
	public bool IsHooked;

	public Hookable Hookable;

	public Hookable.Hook Hook;

	public VisualBoundary Boundary;

	public Polygon BlockingPolygon;

	public BuildableProperties Properties;

	private MarkerProxy _primaryMarker;

	public bool CanPlace { get; private set; }

	public ConstructionPreview(Buildable buildable, VisualPrefabPreviewSettings previewSettings, int visualIndex, bool createMarkerProxy, bool isHooked = false)
		: base(buildable, previewSettings, visualIndex)
	{
		IsHooked = isHooked;
		Hookable = null;
		Hook = null;
		CanPlace = false;
		Properties = buildable.Properties;
		BlockingPolygon = Buildable.CreateBlockingPolygon(buildable.Properties, GameSettings.Instance.BuildableSettings.GridSize, base.Transform.transform, base.Transform.transform);
		Enable();
		Boundary = InstantiateVisualBoundart(buildable.Properties);
		VisualBoundary.Display(Boundary != null);
		if (createMarkerProxy && buildable.TryGetComponent<Target>(out var component))
		{
			_primaryMarker = ((component.PrimaryMarker == null) ? null : new MarkerProxy(component.PrimaryMarker, this, base.Transform.transform));
		}
	}

	public void Enable()
	{
		base.Transform.gameObject.SetActive(value: true);
	}

	public void Disable()
	{
		base.Transform.gameObject.SetActive(value: false);
	}

	public void SetCanPlace(bool canPlace)
	{
		CanPlace = canPlace;
		SetValid(canPlace);
	}

	public bool ConnectsToNavMesh()
	{
		if (_primaryMarker == null)
		{
			return true;
		}
		if (IsHooked && Hookable.TryReturnWalkwaySegment(out var walkwaySegment))
		{
			return _primaryMarker.ReturnConnectsToNavMesh(walkwaySegment);
		}
		return _primaryMarker.ReturnConnectsToNavMesh();
	}

	private VisualBoundary InstantiateVisualBoundart(BuildableProperties buildableProperties)
	{
		VisualBoundary visualBoundary = buildableProperties.ReturnBoundary();
		if (visualBoundary == null)
		{
			throw new NotImplementedException();
		}
		VisualBoundary visualBoundary2 = UnityEngine.Object.Instantiate(visualBoundary, base.Transform.transform);
		if (!buildableProperties.UseCustomSize)
		{
			visualBoundary2.SetSize(buildableProperties.Width, buildableProperties.Depth);
		}
		return visualBoundary2;
	}

	public void UpdateCanBePlaced(bool needsHook = true, bool checkFreeformBlockers = false)
	{
		bool flag = base.Transform.transform.position.IsInRange(Construction.TownheartPosition, GameSettings.Instance.GameplaySettings.ConstructionRadius);
		bool flag2 = !needsHook || IsHooked;
		bool flag3 = IsOverlapping(Buildable.BlockingPolygons);
		if (!flag3 && checkFreeformBlockers && IsOverlapping(Buildable.FreeformBlockerPolygons))
		{
			flag3 = true;
		}
		SetCanPlace(flag && flag2 && !flag3 && ConnectsToNavMesh());
	}

	public bool IsOverlapping(IEnumerable<Polygon> blockingPolygons)
	{
		base.Polygon.FastUpdate();
		foreach (Polygon blockingPolygon in blockingPolygons)
		{
			blockingPolygon.FastUpdate();
			if (base.Polygon.ReturnArePolygonsOverlapping(blockingPolygon, includeTolerance: true))
			{
				return true;
			}
		}
		return false;
	}
}
