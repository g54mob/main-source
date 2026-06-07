#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.Operator;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews.Arrows;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using Utils.Enums;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/PlacementTool", fileName = "PlacementTool", order = 0)]
	public class PlacementTool : FactoryTool
	{
		[Header("Placement refs")]
		[SerializeField]
		protected CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		protected FactoryLayer _terrainLayer;

		[SerializeField]
		protected GridLocator _gridLocator;

		[SerializeField]
		protected CommandManager _commandManager;

		[SerializeField]
		private BluePrintEvent _initPreviewEvent;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BluePrintEvent _updatePreviewEvent;

		[SerializeField]
		protected BaseEvent _stopPreviewEvent;

		[SerializeField]
		protected CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		protected IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private BoolVariableSO _isCursorHoveringUI;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private InputActionReference _startAction;

		[SerializeField]
		private InputActionReference _endAction;

		[SerializeField]
		private int _showArrowsDistance = 5;

		protected FactoryLayer _placedFactoryLayer;

		protected Blueprint _selectedBlueprint;

		private BlueprintViewDto _blueprintViewDto;

		private bool _allowRotating = true;

		private bool _allowMirroring = true;

		private int _rotation;

		private int _lastRotation;

		private bool _lastMirror;

		private readonly List<bool> _canPlaceElements = new List<bool>();

		private bool _isPendingDoAction;

		private Vector3Int? _lastPosition;

		private int _objectSize;

		private bool _isPreviewStarted;

		private bool _isPlacing;

		private bool _shouldDragPlace;

		private Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows> _factoryObjectsArrowsShowing = new Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows>();

		public override bool CanAutoSwapAwayFrom => false;

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_selectedBlueprint = blueprint;
			if (IsExcludedFromDemo())
			{
				return;
			}
			_isPendingDoAction = false;
			_placedFactoryLayer = _factoryLayer.Value;
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
			_shouldDragPlace = _selectedBlueprint.Elements.Count == 1 && _selectedBlueprint.Elements[0].ObjectData.DrawPlacement;
			RotateInternal(_rotation + _lastRotation - blueprint.Rotation);
			if (_lastMirror)
			{
				Mirror();
				_lastMirror = !_lastMirror;
			}
			_lastPosition = null;
			if (!_isCursorHoveringUI.Value)
			{
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
				UpdateTool(cellPosition, selectedMapPosition);
			}
			if (!_isPreviewStarted)
			{
				_initPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, _canPlaceElements));
			}
			_objectSize = 0;
			foreach (BlueprintElement element in blueprint.Elements)
			{
				_objectSize = Mathf.Max(_objectSize, element.ObjectData.ObjectSize);
			}
			_startAction.action.performed += StartActionPerformed;
			_endAction.action.performed += EndActionPerformed;
		}

		public void ReSelectTool(Blueprint blueprint)
		{
			_selectedBlueprint = blueprint;
			if (!IsExcludedFromDemo())
			{
				_isPendingDoAction = false;
				_placedFactoryLayer = _factoryLayer.Value;
				_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
				_lastPosition = null;
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
				UpdateTool(cellPosition, selectedMapPosition);
			}
		}

		private bool IsExcludedFromDemo()
		{
			foreach (BlueprintElement element in _selectedBlueprint.Elements)
			{
				if (_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(element.ObjectData))
				{
					return true;
				}
			}
			return false;
		}

		private void StartActionPerformed(InputAction.CallbackContext callbackContext)
		{
			_isPlacing = true;
		}

		private void EndActionPerformed(InputAction.CallbackContext callbackContext)
		{
			_isPlacing = false;
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (IsExcludedFromDemo())
			{
				return;
			}
			Vector3Int cellPosition = _gridLocator.GetCellPosition(mousePos + _selectedBlueprint.MiddleOffset);
			if (_isPendingDoAction && !_shouldDragPlace)
			{
				return;
			}
			if (_lastPosition.HasValue)
			{
				Vector3Int value = cellPosition;
				Vector3Int? lastPosition = _lastPosition;
				if (value == lastPosition)
				{
					return;
				}
			}
			gridPos = cellPosition;
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			BlueprintPlacementValidator.CanBePlacedPerIndex(gridPos, _selectedBlueprint, _placedFactoryLayer, _terrainLayer, _canPlaceElements);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			_blueprintViewDto.Position = _gridLocator.GetWorldPosition(gridPos);
			if (_isPreviewStarted)
			{
				_updatePreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, _canPlaceElements));
			}
			else
			{
				_isPreviewStarted = true;
				_startPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, _canPlaceElements));
			}
			if (_isPlacing && _shouldDragPlace)
			{
				DoActionBetweenPoints(_lastPosition.HasValue ? _lastPosition.Value : gridPos, gridPos);
			}
			_lastPosition = gridPos;
			UpdateArrows(gridPos);
		}

		private void DoActionBetweenPoints(Vector3Int lastGridPos, Vector3Int currGridPos)
		{
			foreach (Vector3Int item in GetPointsBetween(lastGridPos, currGridPos))
			{
				DoAction(item, item);
			}
		}

		private List<Vector3Int> GetPointsBetween(Vector3Int start, Vector3Int end)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			int x = start.x;
			int z = start.z;
			int x2 = end.x;
			int z2 = end.z;
			int num = Mathf.Abs(x2 - x);
			int num2 = Mathf.Abs(z2 - z);
			int num3 = x;
			int num4 = z;
			int num5 = 1 + num + num2;
			int num6 = ((x2 > x) ? 1 : (-1));
			int num7 = ((z2 > z) ? 1 : (-1));
			int num8 = num - num2;
			num *= 2;
			num2 *= 2;
			while (num5 > 0)
			{
				list.Add(new Vector3Int(num3, 0, num4));
				if (num8 > 0)
				{
					num3 += num6;
					num8 -= num2;
				}
				else if (num8 < 0)
				{
					num4 += num7;
					num8 += num;
				}
				else
				{
					num3 += num6;
					num4 += num7;
					num8 += num - num2;
					num5--;
				}
				num5--;
			}
			return list;
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_shouldDragPlace)
			{
				DoAction(gridPos, mousePos);
			}
		}

		public override void Rotate(int rotation)
		{
			if (!_allowRotating)
			{
				this.LogWarning("Has blocked rotating!", "Rotate", 244);
				return;
			}
			RotateInternal(rotation);
			_lastRotation += rotation;
			_audioManagerLocator.AudioManager.PlayRotateObject(_blueprintViewDto.Position, _objectSize);
		}

		private void RotateInternal(int rotation)
		{
			base.Rotate(rotation);
			_selectedBlueprint.Rotate(rotation);
			Vector3 position = _blueprintViewDto.Position;
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
			_blueprintViewDto.Position = position;
			_lastPosition = null;
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (IsExcludedFromDemo())
			{
				return;
			}
			Vector3Int position = _gridLocator.GetCellPosition(mousePos + _selectedBlueprint.MiddleOffset);
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			int num = BlueprintPlacementValidator.CanBePlacedPerIndex(position, _selectedBlueprint, _placedFactoryLayer, _terrainLayer, _canPlaceElements);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			if (num <= 0)
			{
				CancelDoPlacement(position);
			}
			else if (num < _selectedBlueprint.Elements.Count)
			{
				if (_selectedBlueprint.Elements.Count <= 1)
				{
					CancelDoPlacement(position);
				}
				else
				{
					MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.PlaceText", Sizes.M, delegate
					{
						DoPlacementInternal(position);
					}, showCancelButton: true, delegate
					{
						CancelDoPlacement(position);
					})
					{
						OverrideSuccessButtonTextKey = "ModalWarning.PlaceConfirmButton"
					};
					_isPendingDoAction = true;
					_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
				}
			}
			else
			{
				DoPlacementInternal(position);
			}
			HideAllArrows();
		}

		private void DoPlacementInternal(Vector3Int position)
		{
			Blueprint copy = _selectedBlueprint.GetCopy();
			BlueprintPlacementValidator.RemoveNonPlaceableBlueprintElements(_selectedBlueprint, _canPlaceElements);
			PlaceBlueprintCommand command = new PlaceBlueprintCommand(_placedFactoryLayer, _terrainLayer, position, _selectedBlueprint.Rotation, _selectedBlueprint, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
			_commandManager.DoCommand(command);
			if (_isPreviewStarted)
			{
				_isPreviewStarted = false;
				_stopPreviewEvent.Fire();
			}
			_rotation = copy.Rotation;
			ReSelectTool(copy);
		}

		private void CancelDoPlacement(Vector3Int position)
		{
			_audioManagerLocator.AudioManager.PlayCantPlace(position);
			_isPendingDoAction = false;
		}

		public override void CancelAction()
		{
			HideAllArrows();
		}

		public override void DeSelectTool()
		{
			base.DeSelectTool();
			_isPlacing = false;
			_isPreviewStarted = false;
			_stopPreviewEvent.Fire();
			_blueprintViewDto = null;
			_startAction.action.performed -= StartActionPerformed;
			_endAction.action.performed -= EndActionPerformed;
			HideAllArrows();
		}

		public override void Mirror()
		{
			if (!IsExcludedFromDemo())
			{
				if (!_allowMirroring)
				{
					this.Log("Has blocked mirroring!", "Mirror", 350);
					return;
				}
				_selectedBlueprint.Mirror();
				Vector3 position = _blueprintViewDto.Position;
				_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
				_blueprintViewDto.Position = position;
				_lastPosition = null;
				_audioManagerLocator.AudioManager.PlayRotateObject(position, _objectSize);
				_lastMirror = !_lastMirror;
			}
		}

		public void SetAllowRotating(bool allowRotation)
		{
			if (!allowRotation)
			{
				_rotation = 0;
			}
			_allowRotating = allowRotation;
		}

		public void SetAllowMirroring(bool allowMirroring)
		{
			_allowMirroring = allowMirroring;
		}

		public void SetRotation(int rotation, bool resetLastRotation = false)
		{
			_rotation = rotation;
			if (resetLastRotation)
			{
				_lastRotation = 0;
				_lastMirror = false;
			}
		}

		public bool IsSelectedBlueprint(FactoryObjectData factoryObjectData)
		{
			if (_selectedBlueprint.Elements.Count != 1)
			{
				return false;
			}
			return _selectedBlueprint.Elements[0].ObjectData.ID == factoryObjectData.ID;
		}

		private void UpdateArrows(Vector3Int position)
		{
			Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows> dictionary = new Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows>();
			for (int i = position.z - _showArrowsDistance; i < position.z + _showArrowsDistance; i++)
			{
				for (int j = position.x - _showArrowsDistance; j < position.x + _showArrowsDistance; j++)
				{
					Vector3Int position2 = new Vector3Int(j, 0, i);
					if (_factoryLayer.Value.TryGetObjectAt(position2, out var factoryObject) && FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view))
					{
						FactoryObjectInputOutputArrows componentInChildren = view.GetComponentInChildren<FactoryObjectInputOutputArrows>();
						if (!(componentInChildren == null))
						{
							dictionary.TryAdd(view, componentInChildren);
						}
					}
				}
			}
			foreach (KeyValuePair<FactoryObjectView, FactoryObjectInputOutputArrows> item in dictionary)
			{
				if (!_factoryObjectsArrowsShowing.ContainsKey(item.Key))
				{
					item.Value.ShowEmptyInputs();
					item.Value.ShowEmptyOutputs();
				}
				else
				{
					_factoryObjectsArrowsShowing.Remove(item.Key);
				}
			}
			foreach (KeyValuePair<FactoryObjectView, FactoryObjectInputOutputArrows> item2 in _factoryObjectsArrowsShowing)
			{
				item2.Value.HideAll();
			}
			_factoryObjectsArrowsShowing.Clear();
			_factoryObjectsArrowsShowing = dictionary;
		}

		private void HideAllArrows()
		{
			foreach (KeyValuePair<FactoryObjectView, FactoryObjectInputOutputArrows> item in _factoryObjectsArrowsShowing)
			{
				item.Value.HideAll();
			}
			_factoryObjectsArrowsShowing.Clear();
		}
	}
}
