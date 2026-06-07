using System;
using System.Collections.Generic;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Strategies/Energy Pole")]
public class EnergyPolePreviewStrategy : BuildableCursorProperties, IMoveBuildablePreviewStrategy
{
	[SerializeField]
	[Tooltip("The buildable version of energy poles should not be able to be built anymore, so we want to build the decoration version instead")]
	private DecorationProperties _decorationVersionCursorProperties;

	[SerializeField]
	private float _snappingDistance = 10f;

	[SerializeField]
	private Color _selectedDecoSlotColor = Color.red;

	[Header("Rotation")]
	[SerializeField]
	private RewiredAction _rotateRewiredAction;

	[SerializeField]
	private RewiredAction _variationRewiredAction;

	[NonSerialized]
	private Dictionary<VisualPrefab, VisualPrefab> _previewPool;

	[NonSerialized]
	private VisualPrefab _polePreview;

	[NonSerialized]
	private DecorationSlots _closestDecoSlots;

	[NonSerialized]
	private Quaternion _rotation = Quaternion.identity;

	[NonSerialized]
	private DecorationProperties.Turns _turn;

	[NonSerialized]
	private List<int> _slotIndices;

	[NonSerialized]
	private List<int> _previousSlotIndicesCache;

	public override void Activate()
	{
		base.Activate();
		if (_previewPool == null)
		{
			_previewPool = new Dictionary<VisualPrefab, VisualPrefab>(8);
		}
		_visualIndex = _buildable.ReturnVisualIndex(_visualIndex);
		if (_visualIndex < 0 || _visualIndex >= _decorationVersionCursorProperties.VisualPrefabs.Length)
		{
			_visualIndex = 0;
		}
		_polePreview = ReturnPreview();
		if (!_buildable.TryGetComponent<EnergyGridPole>(out var _))
		{
			Debug.LogError("Passed a buildable to " + base.name + " that does not have a energy pole component.");
		}
	}

	public IMoveBuildablePreviewStrategy Activate(Buildable buildable, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Buildable buildableOut)
	{
		preview = IMoveBuildablePreviewStrategy.CreateConstructionVisual(buildable.Properties.Prefab, visualIndex, previewSettings, isHooked: false, createMarkerProxy: true);
		buildableOut = SetBuildable(buildable);
		ActivateInternal(visualIndex);
		return this;
	}

	public IMoveBuildablePreviewStrategy Activate(Decoration decoration, DecorationProperties decorationProperties, int visualIndex, VisualPrefabPreviewSettings previewSettings, out ConstructionPreview preview, out Decoration decorationOut)
	{
		preview = IMoveBuildablePreviewStrategy.CreateConstructionVisual(GameManager.Settings.BuildableSettings.EnergyPoleBuildableProperties.Prefab, visualIndex, previewSettings, isHooked: false, createMarkerProxy: true);
		decorationOut = SetDecoration(decoration, decorationProperties);
		ActivateInternal(visualIndex);
		return this;
	}

	private void ActivateInternal(int visualIndex)
	{
		if (_previewPool == null)
		{
			_previewPool = new Dictionary<VisualPrefab, VisualPrefab>(8);
		}
		_visualIndex = visualIndex;
		if (_visualIndex < 0 || _visualIndex >= _decorationVersionCursorProperties.VisualPrefabs.Length)
		{
			_visualIndex = 0;
		}
		_polePreview = ReturnPreview();
		UIManager.AddRewiredActionInfoToContext(this, _rotateRewiredAction, _variationRewiredAction, base.Interact, base.Cancel);
		if (_slotIndices == null)
		{
			_slotIndices = new List<int>();
		}
		else
		{
			_slotIndices.Clear();
		}
	}

	public override void DeactivateImmediately()
	{
		base.DeactivateImmediately();
		_polePreview.gameObject.SetActive(value: false);
		foreach (QuickConnecting quickConnector in QuickConnecting.QuickConnectors)
		{
			quickConnector.DisableParticle();
		}
		foreach (DecorationSlots decorationSlot in Community.PlayerCommunity.DecorationSlots)
		{
			decorationSlot.DisablePlacementMode();
		}
		UIManager.DisableRewiredActionInfoContext(this);
	}

	public override void UpdateCursor(CursorManager cursor)
	{
	}

	public void UpdateConstructionPreview(ref ConstructionPreview preview)
	{
		if (_variationRewiredAction.GetButtonUp())
		{
			_visualIndex = PajamaLlama.Math.Math.IncrementIndexWrapped(_visualIndex, _decorationVersionCursorProperties.VisualPrefabs.Length);
			if (_polePreview != null)
			{
				_polePreview.gameObject.SetActive(value: false);
			}
			_polePreview = ReturnPreview();
		}
		if (_rotateRewiredAction.GetButtonUp())
		{
			UpdateRotation();
		}
		UpdateTransform();
		ShowVisualizersInRange();
		bool flag = _closestDecoSlots != null;
		preview.SetCanPlace(flag);
		preview.SetValid(flag);
	}

	public bool MoveBuildable(ref Buildable buildable, ConstructionPreview preview)
	{
		Decoration decoration = _closestDecoSlots.AddDecoration(_decorationVersionCursorProperties, _turn, _visualIndex, _slotIndices, instantFreeBuild: true);
		if (!buildable.CustomName.IsNullOrEmpty())
		{
			decoration.Name = buildable.CustomName;
		}
		buildable.Remove();
		DeactivateImmediately();
		return true;
	}

	public bool MoveDecoration(Decoration decoration, ConstructionPreview preview)
	{
		Decoration decoration2 = _closestDecoSlots.AddDecoration(decoration.Properties, _turn, _visualIndex, _slotIndices, instantFreeBuild: true);
		if (!decoration.CustomName.IsNullOrEmpty())
		{
			decoration2.Name = decoration.CustomName;
		}
		decoration.Remove(immediately: true);
		DeactivateImmediately();
		return true;
	}

	public Buildable SetBuildable(Buildable buildable)
	{
		if (buildable.TryReturnBuildableExtendable<EnergyGridPole>(out var buildableExtendable))
		{
			if (buildable.TryGetComponentInParent<WalkwayPonton>(out var componentInParent) && componentInParent.EnergyPole == buildableExtendable)
			{
				componentInParent.DetachEnergyPole(buildable);
				buildable.transform.SetParent(null);
			}
			if (buildable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable2))
			{
				buildableExtendable2.DisconnectAll();
			}
			buildable.gameObject.SetActive(value: false);
			return buildable;
		}
		return buildable.Properties.Prefab;
	}

	public Decoration SetDecoration(Decoration decoration, DecorationProperties decorationProperties)
	{
		if (decoration.TryGetExtendable<EnergyGridPole>(out var _))
		{
			if (decoration.TryGetExtendable<EnergyGridDecorationComponent>(out var extendable2))
			{
				extendable2.DisconnectAll();
			}
			if ((bool)decoration.Parent)
			{
				decoration.Parent.RemoveDecorationImmediate(decoration);
			}
			decoration.transform.SetParent(null);
			decoration.gameObject.SetActive(value: false);
			return decoration;
		}
		return decorationProperties.DecorationPrefab;
	}

	public void StoreBuildable(Buildable buildable, bool toggleCategory)
	{
		DeactivateImmediately();
		Community.PlayerCommunity.AddStoredBuildable(buildable.Properties, buildable, toggleCategory);
	}

	public void StoreDecoration(Decoration decoration, bool toggleCategory)
	{
		DeactivateImmediately();
		Community.PlayerCommunity.AddStoredDecoration(decoration.Properties, decoration, toggleCategory);
	}

	public void ContinuousBuilding()
	{
	}

	private void UpdateTransform()
	{
		Quaternion quaternion = Quaternion.identity;
		Vector3 buildingPosition = CursorManager.BuildingPosition;
		DecorationSlots closestDecoSlots = _closestDecoSlots;
		_slotIndices.CopyTo(ref _previousSlotIndicesCache);
		if (TryReturnClosestAvailableSlots(buildingPosition, out var decorationPosition))
		{
			quaternion = _closestDecoSlots.transform.rotation;
			buildingPosition = decorationPosition;
			_closestDecoSlots.SetSlotsOutlineColor(_slotIndices, _selectedDecoSlotColor);
		}
		else
		{
			buildingPosition = WorldManager.WaterAdjustedPosition(buildingPosition);
		}
		if (closestDecoSlots != null && (closestDecoSlots != _closestDecoSlots || (!_previousSlotIndicesCache.IsNullOrEmpty() && !_previousSlotIndicesCache.IsEqual(_slotIndices))))
		{
			closestDecoSlots.SetSlotsOutlineColor(_previousSlotIndicesCache, Color.white);
		}
		_polePreview.transform.SetPositionAndRotation(buildingPosition, quaternion * _rotation);
	}

	private bool TryReturnClosestAvailableSlots(Vector3 position, out Vector3 decorationPosition)
	{
		_closestDecoSlots = null;
		decorationPosition = Vector3.zero;
		float num = _snappingDistance * _snappingDistance;
		using ListPool<int>.List list = ListPool<int>.Get();
		foreach (DecorationSlots decorationSlot in Community.PlayerCommunity.DecorationSlots)
		{
			if (!decorationSlot.TryEnablePlacementMode(_decorationVersionCursorProperties) || !decorationSlot.TryPopulateClosestSlotIndices(list, position, out var closesetPosition, _decorationVersionCursorProperties, _turn))
			{
				continue;
			}
			float num2 = position.DistanceToSquared(closesetPosition);
			if (!(num2 < num))
			{
				continue;
			}
			num = num2;
			_closestDecoSlots = decorationSlot;
			decorationPosition = closesetPosition;
			_slotIndices.Clear();
			foreach (int item in list)
			{
				_slotIndices.Add(item);
			}
		}
		return _closestDecoSlots != null;
	}

	private void ShowVisualizersInRange()
	{
		foreach (QuickConnecting quickConnector in QuickConnecting.QuickConnectors)
		{
			if (quickConnector.Component.IsInRange(_polePreview.transform.position))
			{
				quickConnector.EnableParticle();
			}
			else
			{
				quickConnector.DisableParticle();
			}
		}
	}

	private void UpdateRotation()
	{
		switch (_turn)
		{
		case DecorationProperties.Turns.Full:
			_turn = DecorationProperties.Turns.Quarter;
			_rotation = DecorationProperties.ROTATION_QUARTER;
			break;
		case DecorationProperties.Turns.Quarter:
			_turn = DecorationProperties.Turns.Half;
			_rotation = DecorationProperties.ROTATION_HALF;
			break;
		case DecorationProperties.Turns.Half:
			_turn = DecorationProperties.Turns.ThreeQuarter;
			_rotation = DecorationProperties.ROTATION_THREE_QUARTER;
			break;
		case DecorationProperties.Turns.ThreeQuarter:
			_turn = DecorationProperties.Turns.Full;
			_rotation = DecorationProperties.ROTATION_FULL;
			break;
		}
	}

	private VisualPrefab ReturnPreview()
	{
		bool flag = false;
		VisualPrefab visualPrefab = _decorationVersionCursorProperties.VisualPrefabs[_visualIndex];
		if (_previewPool.TryGetValue(visualPrefab, out var value))
		{
			if ((bool)value)
			{
				value.gameObject.SetActive(value: true);
				return value;
			}
			flag = true;
		}
		value = _previewSettings.InstantiatePreview(visualPrefab);
		value.name = "[PREVIEW] " + value.name;
		if (flag)
		{
			_previewPool[visualPrefab] = value;
		}
		else
		{
			_previewPool.Add(visualPrefab, value);
		}
		return value;
	}
}
