using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public abstract class ConstructionCursorProperties : BuildableCursorProperties
{
	[Header("Construction")]
	[SerializeField]
	[Range(0f, 5f)]
	protected float _hookSnapDistance = 2.5f;

	protected float _hookDistance;

	public override void Initialize(Buildable buildable, int visualIndex = -1)
	{
		base.Initialize(buildable, visualIndex);
		Vector3 b = (buildable.Properties.Outline[0].Vector3TopDown() + buildable.Properties.Outline[buildable.Properties.Outline.Length - 1].Vector3TopDown()) * 0.5f;
		_hookDistance = Vector3.Distance(buildable.transform.position, b);
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < buildable.Properties.Outline.Length; i++)
		{
			int num3 = (i + 1) % buildable.Properties.Outline.Length;
			num = Vector2.Distance(buildable.Properties.Outline[i], buildable.Properties.Outline[num3]);
			if (num > num2)
			{
				num2 = num;
			}
		}
	}

	public override void DeactivateImmediately()
	{
		base.DeactivateImmediately();
		BuildingGrid.Disable();
	}

	public override void UpdateCursor(CursorManager cursor)
	{
	}

	protected ConstructionPreview CreateConstructionVisual(Buildable buildable, int visualIndex, bool isHooked = false, bool createMarkerProxy = false)
	{
		return new ConstructionPreview(buildable, _previewSettings, visualIndex, createMarkerProxy, isHooked);
	}

	public void RemoveConstructionPreview(ref ConstructionPreview preview)
	{
		if (preview != null)
		{
			preview.Destroy();
			preview = null;
		}
	}

	protected void UpdateTransform(ConstructionPreview preview, Vector3 inputPosition, out Vector2 hookedPosition, bool gridSnapping = false, Hookable illegalHook = null)
	{
		Transform transform = preview.Transform.transform;
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		bool isHooked = preview.IsHooked;
		Hookable.Hook hook = preview.Hook;
		Vector3 vector = inputPosition;
		Quaternion rotation2 = Quaternion.identity;
		Vector3 position2 = WorldManager.WaterAdjustedPosition(inputPosition);
		preview.IsHooked = Hookable.TryHook(out var closestHook, out preview.Hookable, _hookSnapDistance, inputPosition, illegalHook);
		preview.Hook = closestHook;
		if (preview.IsHooked)
		{
			rotation2 = Math3d.FlattenQuaternion(Quaternion.LookRotation(preview.Hook.Edge.InwardNormal));
			vector = preview.Hook.ReturnPosition(inputPosition, gridSnapping, out var _);
			position2 = WorldManager.WaterAdjustedPosition(preview.Hook.ReturnHookedPosition(vector, _hookDistance));
		}
		transform.rotation = rotation2;
		transform.position = position2;
		if (preview.IsHooked && TrySnapNeighbour(preview, gridSnapping, illegalHook, out var position3, out var rotation3, out var hookable, out closestHook, out var hookPosition) && preview.Hook.HasMatchingEdge(closestHook))
		{
			preview.Hookable = hookable;
			preview.Hook = closestHook;
			transform.rotation = rotation3;
			transform.position = position3;
			vector = hookPosition;
			preview.Polygon.FastUpdate();
			if (preview.IsOverlapping(Buildable.BlockingPolygons))
			{
				transform.rotation = rotation2;
				transform.position = position2;
				preview.Polygon.FastUpdate();
				if (preview.IsOverlapping(Buildable.BlockingPolygons))
				{
					transform.position = WorldManager.WaterAdjustedPosition(position);
					transform.rotation = rotation;
					preview.IsHooked = isHooked;
					preview.Hook = hook;
				}
			}
			else
			{
				preview.IsHooked = true;
			}
		}
		hookedPosition = vector.Vector2TopDown();
	}

	protected Buildable InstantiateAndInitializeBuildable(Buildable prefab, Vector3 position, Quaternion rotation, int visualIndex)
	{
		Buildable buildable = Object.Instantiate(prefab, position.Leveled(), rotation);
		buildable.Initialize(Community.PlayerCommunity, visualIndex);
		return buildable;
	}

	private bool TrySnapNeighbour(ConstructionPreview preview, bool snap, Hookable illegalHook, out Vector3 position, out Quaternion rotation, out Hookable hookable, out Hookable.Hook hook, out Vector3 hookPosition)
	{
		position = preview.Transform.transform.position;
		rotation = preview.Transform.transform.rotation;
		hookable = null;
		hook = null;
		hookPosition = Vector3.zero;
		if (TryReturnNeighbourSnappedPosition(preview, out var neighbourSnappedPosition) && Hookable.TryHook(out var closestHook, out var closestHookable, _hookSnapDistance, neighbourSnappedPosition, illegalHook))
		{
			hookable = closestHookable;
			hook = closestHook;
			rotation = Math3d.FlattenQuaternion(Quaternion.LookRotation(preview.Hook.Edge.InwardNormal));
			hookPosition = closestHook.ReturnPosition(neighbourSnappedPosition, snap, out var _);
			position = WorldManager.WaterAdjustedPosition(closestHook.ReturnHookedPosition(hookPosition, _hookDistance));
			return true;
		}
		return false;
	}

	private bool TryReturnNeighbourSnappedPosition(ConstructionPreview preview, out Vector3 neighbourSnappedPosition)
	{
		neighbourSnappedPosition = preview.Transform.transform.position;
		if (TryReturnSidesnappingOverlappingConstruction(preview, out var closestOverlappingConstruction))
		{
			Transform transform = closestOverlappingConstruction.transform;
			Vector3 rhs = transform.position - preview.Transform.transform.position;
			float num = Vector3.Dot(preview.Hook.Right, rhs);
			float a = Vector3.Dot(transform.forward, preview.Hook.Forward);
			bool flag;
			int num3;
			int num2;
			if (MathExtensions.Approximately(a, 1f))
			{
				flag = num <= 0f;
				num2 = closestOverlappingConstruction.Buildable.Properties.Width;
				num3 = closestOverlappingConstruction.Buildable.Properties.Depth;
			}
			else if (MathExtensions.Approximately(a, 0f))
			{
				flag = num < 0f;
				num2 = closestOverlappingConstruction.Buildable.Properties.Depth;
				num3 = closestOverlappingConstruction.Buildable.Properties.Width;
			}
			else
			{
				if (!MathExtensions.Approximately(a, -1f))
				{
					return false;
				}
				flag = num < 0f;
				num2 = closestOverlappingConstruction.Buildable.Properties.Width;
				num3 = closestOverlappingConstruction.Buildable.Properties.Depth;
			}
			int gridSize = GameSettings.Instance.BuildableSettings.GridSize;
			num3 *= gridSize;
			num2 *= gridSize;
			Vector3 vector = transform.position + preview.Hook.Forward * ((float)num3 - 0.01f);
			int num4 = num2 + preview.Properties.Width;
			if (flag)
			{
				neighbourSnappedPosition = vector + preview.Hook.Right * num4;
			}
			else
			{
				neighbourSnappedPosition = vector - preview.Hook.Right * num4;
			}
			return true;
		}
		return false;
	}

	private bool TryReturnSidesnappingOverlappingConstruction(ConstructionPreview preview, out Construction closestOverlappingConstruction)
	{
		preview.Polygon.FastUpdate();
		List<Construction> constructions = Community.PlayerCommunity.Constructions;
		float num = float.MaxValue;
		closestOverlappingConstruction = null;
		foreach (Construction item in constructions)
		{
			if (!item.AllowSideSnapping)
			{
				continue;
			}
			item.Buildable.OutlinePolygon.FastUpdate();
			if (item.Buildable.OutlinePolygon.ReturnArePolygonsOverlapping(preview.Polygon, includeTolerance: true))
			{
				float num2 = item.Buildable.OutlinePolygon.ReturnClosestDistance(preview.Hook.Projection);
				if (num2 < num)
				{
					num = num2;
					closestOverlappingConstruction = item;
				}
			}
		}
		return closestOverlappingConstruction != null;
	}

	protected void UpdatePreviewPlacingConstruction(ConstructionPreview constructionPreview, out Vector2 hookedPosition, out bool canBePlaced)
	{
		UpdatePreviewPlacingConstruction(constructionPreview, out hookedPosition, out canBePlaced, _buildable.Properties.Width, _buildable.Properties.Depth, _buildable.Properties.RequiredResources);
	}

	protected void UpdatePreviewPlacingConstruction(ConstructionPreview constructionPreview, out Vector2 hookedPosition, out bool canBePlaced, int gridWidth, int gridHeight, CountedItemProperty[] requiredResources)
	{
		bool snapBuilding = Settings.Instance.GameplayPlayerData.SnapBuilding;
		bool isHooked = constructionPreview.IsHooked;
		UpdateTransform(constructionPreview, CursorManager.BuildingPosition, out hookedPosition, snapBuilding);
		constructionPreview.UpdateCanBePlaced(needsHook: true, !snapBuilding);
		if (isHooked != constructionPreview.IsHooked)
		{
			if (constructionPreview.IsHooked)
			{
				BuildingGrid.Enable(gridWidth, gridHeight);
			}
			else
			{
				BuildingGrid.Disable();
			}
		}
		if (constructionPreview.IsHooked)
		{
			BuildingGrid.SetPlacement(hookedPosition.Vector3TopDown(), constructionPreview.Hook);
		}
		canBePlaced = constructionPreview.CanPlace && ResourceManager.AreCommunityResourcesAvailable(requiredResources);
		constructionPreview.SetValid(canBePlaced);
	}

	protected void TryPlacingConstruction(CursorManager cursorManager, ConstructionPreview constructionPreview)
	{
		if (GetInteract() && BuildingDevTools.TryAutoSpawnResources(_buildable.Properties.RequiredResources))
		{
			Vector3 position = constructionPreview.Transform.transform.position;
			Quaternion rotation = constructionPreview.Transform.transform.rotation;
			Buildable buildable = Object.Instantiate(_buildable, position.Leveled(), rotation);
			Hookable hookable = constructionPreview.Hookable;
			buildable.Initialize(Community.PlayerCommunity, _visualIndex);
			if (buildable.TryGetComponent<Construction>(out var component) && hookable.TryGetComponent<Construction>(out var component2) && component.AddNeighbourConstruction(component2))
			{
				component2.AddNeighbourConstruction(component);
			}
			buildable.StartBuilding();
			if (!RewiredActions.IsContinuousBuilding())
			{
				cursorManager.Deactivate();
			}
		}
	}
}
