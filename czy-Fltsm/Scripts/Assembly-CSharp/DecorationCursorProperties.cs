using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Decoration")]
public class DecorationCursorProperties : CursorProperties
{
	[SerializeField]
	private VisualPrefabPreviewSettings _previewSettings;

	[SerializeField]
	private float _snapRange = 5f;

	[Tooltip("Layer mask used to get the building position that is under the cursor")]
	[SerializeField]
	private LayerMask _raycastMask;

	[SerializeField]
	private Color _selectedSlotColor = Color.red;

	[Header("Rotation")]
	[SerializeField]
	private RewiredAction _rotateRewiredAction;

	[SerializeField]
	private RewiredAction _variationRewiredAction;

	private DecorationProperties _decorationProperties;

	private int _visual;

	private Quaternion _rotation;

	private VisualPrefab _preview;

	private Dictionary<VisualPrefab, VisualPrefab> _previewPool;

	private DecorationProperties.Turns _turn;

	private List<int> _slotIndices;

	private DecorationSlots _decorationSlots;

	private List<int> _decorationSlotIndices;

	private Quaternion _decorationSlotsRotation = Quaternion.identity;

	public void Initialize(DecorationProperties decorationProperties)
	{
		_decorationProperties = decorationProperties;
		_visual = 0;
		_rotation = Quaternion.identity;
		_turn = DecorationProperties.Turns.Full;
		if (_previewPool == null)
		{
			_previewPool = new Dictionary<VisualPrefab, VisualPrefab>(32);
		}
		if (_slotIndices == null)
		{
			_slotIndices = new List<int>();
		}
		if (_decorationSlotIndices == null)
		{
			_decorationSlotIndices = new List<int>();
		}
	}

	public override void Activate()
	{
		_preview = ReturnPreview(_decorationProperties.VisualPrefabs[_visual]);
		UIManager.AddRewiredActionInfoToContext(this, _rotateRewiredAction, _variationRewiredAction, base.Interact, base.Cancel);
	}

	public override void DeactivateImmediately()
	{
		foreach (DecorationSlots decorationSlot in Community.PlayerCommunity.DecorationSlots)
		{
			decorationSlot.DisablePlacementMode();
		}
		_preview.gameObject.SetActive(value: false);
		UIManager.DisableRewiredActionInfoContext(this);
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		bool flag = false;
		if (_variationRewiredAction.GetButtonUp())
		{
			_visual = Math.IncrementIndexWrapped(_visual, _decorationProperties.VisualPrefabs.Length);
			if ((bool)_preview)
			{
				_preview.gameObject.SetActive(value: false);
			}
			_preview = ReturnPreview(_decorationProperties.VisualPrefabs[_visual]);
			AudioManager.PlayOneShot(_decorationProperties.FMODEventReference_Variation);
		}
		if (_rotateRewiredAction.GetButtonUp())
		{
			UpdateRotation();
		}
		RaycastHit hitInfo;
		Vector3 position = ((!Physics.Raycast(CameraController.MainCamera.ScreenPointToRay(FlotsamInputManager.MousePosition), out hitInfo, 500f, _raycastMask)) ? CursorManager.BuildingPosition : hitInfo.point);
		if ((bool)_decorationSlots)
		{
			_decorationSlots.TryEnablePlacementMode(_decorationProperties);
		}
		if ((bool)_decorationSlots)
		{
			_decorationSlots.ResetSlotsOutlineColor();
		}
		if (TryReturnClosestAvailableSlots(out _decorationSlots, _decorationSlotIndices, position, out var decorationPosition, _snapRange))
		{
			_decorationSlotsRotation = _decorationSlots.transform.rotation;
			_preview.transform.position = decorationPosition;
			_decorationSlots.SetSlotsOutlineColor(_decorationSlotIndices, _selectedSlotColor);
			flag = true;
		}
		else
		{
			_preview.transform.position = CursorManager.BuildingPosition;
		}
		_preview.transform.rotation = _decorationSlotsRotation * _rotation;
		if (flag && _decorationProperties.ReturnCanBePlaced(Community.PlayerCommunity))
		{
			_previewSettings.SetValid(_preview, isValid: true);
			if (!EventSystem.current.IsPointerOverGameObject() && GetInteract() && BuildingDevTools.TryAutoSpawnResources(_decorationProperties.RequiredResources))
			{
				_decorationSlots.AddDecoration(_decorationProperties, _turn, _visual, _decorationSlotIndices);
			}
		}
		else
		{
			_previewSettings.SetValid(_preview, isValid: false);
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
		AudioManager.PlayOneShot(_decorationProperties.FMODEventReference_Rotate);
	}

	private bool TryReturnClosestAvailableSlots(out DecorationSlots closestSlots, List<int> indices, Vector3 position, out Vector3 decorationPosition, float range)
	{
		float num = range * range;
		closestSlots = null;
		decorationPosition = default(Vector3);
		foreach (DecorationSlots decorationSlot in Community.PlayerCommunity.DecorationSlots)
		{
			if (!decorationSlot.TryEnablePlacementMode(_decorationProperties) || !decorationSlot.TryPopulateClosestSlotIndices(_slotIndices, position, out var closesetPosition, _decorationProperties, _turn))
			{
				continue;
			}
			float num2 = position.DistanceToSquared(closesetPosition);
			if (!(num2 < num))
			{
				continue;
			}
			num = num2;
			closestSlots = decorationSlot;
			decorationPosition = closesetPosition;
			indices.Clear();
			foreach (int slotIndex in _slotIndices)
			{
				indices.Add(slotIndex);
			}
		}
		return closestSlots != null;
	}

	private VisualPrefab ReturnPreview(VisualPrefab prefab)
	{
		bool flag = false;
		if (_previewPool.TryGetValue(prefab, out var value))
		{
			if ((bool)value)
			{
				value.gameObject.SetActive(value: true);
				return value;
			}
			flag = true;
		}
		value = _previewSettings.InstantiatePreview(prefab);
		value.name = "[PREVIEW] " + value.name;
		if (flag)
		{
			_previewPool[prefab] = value;
		}
		else
		{
			_previewPool.Add(prefab, value);
		}
		return value;
	}
}
