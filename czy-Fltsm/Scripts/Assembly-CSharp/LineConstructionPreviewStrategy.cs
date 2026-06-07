using System;
using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Strategies/Line Construction")]
public class LineConstructionPreviewStrategy : LineConstructionCursorProperties, IMoveBuildablePreviewStrategy
{
	[NonSerialized]
	private Hookable _nextWaypoint;

	[NonSerialized]
	private BuildableProperties _pontonProperties;

	public IMoveBuildablePreviewStrategy Activate(Buildable buildable, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Buildable buildableOut)
	{
		return Activate(buildable, GetWalkwayPontonProperties(buildable), visualIndex, previewSettings, out preview, out buildableOut);
	}

	public IMoveBuildablePreviewStrategy Activate(Buildable buildable, BuildableProperties pontonProperties, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Buildable buildableOut)
	{
		_pontonProperties = pontonProperties;
		Buildable prefab = _pontonProperties.Prefab;
		Vector3 b = (_pontonProperties.Outline[0].Vector3TopDown() + _pontonProperties.Outline[_pontonProperties.Outline.Length - 1].Vector3TopDown()) * 0.5f;
		float hookDistance = Vector3.Distance(prefab.transform.position, b);
		preview = IMoveBuildablePreviewStrategy.CreateConstructionVisual(prefab, visualIndex, previewSettings, isHooked: false, createMarkerProxy: true);
		_startWaypointPreview = IMoveBuildablePreviewStrategy.CreateConstructionVisual(prefab, visualIndex, previewSettings);
		_endWaypointPreview = IMoveBuildablePreviewStrategy.CreateConstructionVisual(prefab, visualIndex, previewSettings);
		_endWaypointPreview.Disable();
		_segments = (_pontonProperties.PlacementCursorProperties as LineConstructionCursorProperties).Segments;
		_previewSettings = previewSettings;
		_hookDistance = hookDistance;
		buildableOut = GetBuildablePrefab(buildable);
		_buildable = buildableOut;
		InitializeSegments();
		return this;
	}

	public void UpdateConstructionPreview(ref ConstructionPreview preview)
	{
		bool canBePlaced = true;
		bool snapBuilding = Settings.Instance.GameplayPlayerData.SnapBuilding;
		switch (_iteration)
		{
		case Iteration.StartPreview:
			UpdatePreviewPlacingConstruction(_startWaypointPreview, out _startPosition, out canBePlaced, _maximumLength / 2, _maximumLength / 2, _requiredResources);
			break;
		case Iteration.LinePreview:
			UpdateLinePreview(snapBuilding, out canBePlaced);
			break;
		}
		preview.SetCanPlace(canBePlaced);
	}

	public bool MoveBuildable(ref Buildable buildable, ConstructionPreview preview)
	{
		return Iterate();
	}

	public Buildable GetBuildablePrefab(Buildable buildable)
	{
		BuildableProperties buildableProperties = buildable.Properties;
		WalkwayPonton buildableExtendable2;
		if (buildable.TryReturnBuildableExtendable<WalkwaySegment>(out var _) && buildableProperties is WalkwaySegmentProperties walkwaySegmentProperties)
		{
			buildable.Deactivate();
			buildable.Remove();
			buildableProperties = walkwaySegmentProperties.walkwayPontonProperties;
		}
		else if (buildable.TryReturnBuildableExtendable<WalkwayPonton>(out buildableExtendable2))
		{
			buildableExtendable2.RemoveAttachedWalkwaySegment();
		}
		return buildableProperties.Prefab;
	}

	public void StoreBuildable(Buildable buildable, bool toggleCategory)
	{
		Community.PlayerCommunity.AddStoredBuildable(_pontonProperties, buildable, toggleCategory);
		Remove();
	}

	private void Remove()
	{
		RemoveConstructionPreview(ref _startWaypointPreview);
		RemoveConstructionPreview(ref _endWaypointPreview);
		RemoveConstructionPreview(ref _segmentPreview);
		Reset();
	}

	private bool Iterate()
	{
		switch (_iteration)
		{
		case Iteration.StartPreview:
			_iteration++;
			_startWaypointPreview.Disable();
			_endWaypointPreview.Enable();
			break;
		case Iteration.LinePreview:
		{
			PlaceLine(_currentSegment, out var waypoint, hookNext: false, storedBuildable: true);
			_nextWaypoint = waypoint;
			Remove();
			return true;
		}
		}
		return false;
	}

	private BuildableProperties GetWalkwayPontonProperties(Buildable buildable)
	{
		if (buildable.Properties is WalkwaySegmentProperties walkwaySegmentProperties)
		{
			return walkwaySegmentProperties.walkwayPontonProperties;
		}
		if (buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable) && buildableExtendable.NeighbouringWalkwaySegments.Count == 1 && buildableExtendable.NeighbouringWalkwaySegments[0].Buildable.Properties is WalkwaySegmentProperties walkwaySegmentProperties2)
		{
			return walkwaySegmentProperties2.walkwayPontonProperties;
		}
		return buildable.Properties;
	}

	public void ContinuousBuilding()
	{
		_iteration = Iteration.LinePreview;
		_startWaypointPreview.IsHooked = true;
		ContinuousBuilding(_nextWaypoint, useWaypointPosition: true);
	}
}
