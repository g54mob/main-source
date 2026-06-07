using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor;
using Data.FactoryFloor.Tools;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.FactoryFloor.Tools;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory.Blueprint;
using Logic.FactoryTools;
using Presentation.FactoryFloor.Toolbar;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Utils.Enums;

namespace Presentation.FactoryFloor
{
	public class ToolSystem : MonoBehaviour
	{
		[SerializeField]
		private OpenOperatorTool _openOperatorTool;

		[SerializeField]
		private PlacementTool _placementTool;

		[SerializeField]
		private DeleteTool _deleteTool;

		[SerializeField]
		private MoveTool _moveTool;

		[SerializeField]
		private DuplicateTool _duplicateTool;

		[SerializeField]
		private PlaceConveyorsTool _placeConveyorsTool;

		[SerializeField]
		private PlaceTunnelTool _placeTunnelTool;

		[SerializeField]
		private PlaceSkylineTool _placeSkylineTool;

		[SerializeField]
		private PlaceCraneFromBuildingTool _placeCraneFromBuildingTool;

		[SerializeField]
		private CleanConveyorsTool _cleanConveyorsTool;

		[SerializeField]
		private PlaceAreaTool _placeAreaTool;

		[SerializeField]
		private SaveNewBlueprintTool _saveAsBlueprintTool;

		[SerializeField]
		private SelectFactoryObjectTool _selectFactoryObjectTool;

		[SerializeField]
		private UnlockIslandTool _unlockIslandTool;

		[SerializeField]
		private PreviewSystem _previewSystem;

		[SerializeField]
		private SerializedDictionary<FactoryObjectData, FactoryTool> _pickingDataToTool;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private BoolEvent _buildModeEvent;

		[SerializeField]
		private GameplayTooltipEventSO _gameplayTooltipEvent;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		protected LockedFactoryObjectsPersistentSO _lockedFactoryObjects;

		[Space]
		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private InputActionReference _startAction;

		[SerializeField]
		private InputActionReference _endAction;

		[SerializeField]
		private InputActionReference _rotateAction;

		[SerializeField]
		private InputActionReference _mirrorAction;

		[SerializeField]
		private InputActionReference _cancelAction;

		[SerializeField]
		private InputActionReference _escapeAction;

		[SerializeField]
		private InputActionReference _swapGameMode;

		[SerializeField]
		private InputActionReference _operatorPickingAction;

		[SerializeField]
		private InputActionReference pointerPositionInputAction;

		[Space]
		[SerializeField]
		private BaseEvent _selectToolButtonPressedEvent;

		[SerializeField]
		private BaseEvent _moveToolButtonPressedEvent;

		[SerializeField]
		private BaseEvent _duplicateToolButtonPressedEvent;

		[SerializeField]
		private BaseEvent _deleteToolButtonPressedEvent;

		[SerializeField]
		private BaseEvent _placeConveyorToolEvent;

		[SerializeField]
		private BaseEvent _placeTunnelsToolEvent;

		[SerializeField]
		private BaseEvent _placeSkylinesToolEvent;

		[SerializeField]
		private BaseEvent _placeCraneFromBuildingToolEvent;

		[SerializeField]
		private BaseEvent _cleanConveyorsToolEvent;

		[SerializeField]
		private IntEvent _placementToolButtonPressedEvent;

		[SerializeField]
		private BlueprintDtoEvent _placeBlueprintToolEvent;

		[SerializeField]
		private IntEvent _placeAreaToolEvent;

		[SerializeField]
		private BaseEvent _selectNewBlueprintToolEvent;

		[SerializeField]
		private SelectFactoryObjectToolEvent _selectFactoryObjectToolEvent;

		[SerializeField]
		private SelectToolEvent _selectToolEvent;

		[SerializeField]
		private IntEvent _placeBuildingButtonPressedEvent;

		[SerializeField]
		private BaseEvent _actionCanceledEvent;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[Space]
		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		private ToolColorLibrary _toolColorLibrary;

		[Space]
		[SerializeField]
		private double _maxButtonHoldDuration = 0.175;

		[SerializeField]
		private float _maxMousePointerDistance = 0.5f;

		[Space]
		[SerializeField]
		private GoBackSourceSO _toolSystemToolDoIntentGoBackSource;

		[SerializeField]
		private GoBackSourceSO _toolSystemSelectToolGoBackSource;

		[Space]
		[SerializeField]
		private BoolVariableSO _isCursorHoveringUI;

		[SerializeField]
		private BoolVariableSO _operatorInteriorUIIsOpen;

		[Space]
		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		private FactoryTool _selectedTool;

		private bool _isPointerOverGameObject;

		private DateTime _startedCancelActionTimeStamp;

		private Vector2 _startedCancelActionMousePos;

		private Vector2 _startedPickingActionMousePos;

		private FactoryObjectView _lastHovered;

		private FactoryTool _previousFactoryTool;

		public FactoryTool SelectedTool => _selectedTool;

		public bool OpenToolSelected
		{
			get
			{
				if (!(_selectedTool == _openOperatorTool))
				{
					return _selectedTool == _unlockIslandTool;
				}
				return true;
			}
		}

		private void OnEnable()
		{
			_selectToolButtonPressedEvent.Register(SelectToolSelected);
			_moveToolButtonPressedEvent.Register(MoveToolSelected);
			_duplicateToolButtonPressedEvent.Register(DuplicateToolSelected);
			_deleteToolButtonPressedEvent.Register(DeleteToolSelected);
			_placementToolButtonPressedEvent.Register(PlacementToolSelected);
			_placeConveyorToolEvent.Register(PlaceConveyorsToolSelected);
			_placeTunnelsToolEvent.Register(PlaceTunnelsToolSelected);
			_placeSkylinesToolEvent.Register(PlaceSkylinesToolSelected);
			_placeCraneFromBuildingToolEvent.Register(PlaceCraneFromBuildingToolSelected);
			_cleanConveyorsToolEvent.Register(CleanConveyorsToolEvent);
			_placeAreaToolEvent.Register(PlaceAreaToolSelected);
			_placeBlueprintToolEvent.Register(PlaceBlueprintToolSelected);
			_selectNewBlueprintToolEvent.Register(SelectNewBlueprintToolSelected);
			_selectFactoryObjectToolEvent.Register(SelectFactoryObjectToolSelected);
			_selectToolEvent.Register(SelectTool);
			_placeBuildingButtonPressedEvent.Register(PlacementToolSelected);
			_finishedLoadingSaveEvent.Register(ResetTools);
			SelectTool(_openOperatorTool);
			_startAction.action.performed += StartActionPerformed;
			_endAction.action.performed += EndActionPerformed;
			_rotateAction.action.performed += RotateActionPerformed;
			_mirrorAction.action.performed += MirrorActionPerformed;
			_cancelAction.action.started += StartedMouseCancelAction;
			_cancelAction.action.performed += CancelMouseAction;
			_escapeAction.action.performed += CancelAction;
			_swapGameMode.action.performed += CancelMouseAction;
			_operatorPickingAction.action.performed += PickOperatorActionStarted;
			_operatorPickingAction.action.canceled += PickOperatorActionEnded;
		}

		private void OnDisable()
		{
			if (_selectedTool != null)
			{
				_selectedTool.DeSelectTool();
			}
			_selectedTool = null;
			_selectToolButtonPressedEvent.UnRegister(SelectToolSelected);
			_moveToolButtonPressedEvent.UnRegister(MoveToolSelected);
			_duplicateToolButtonPressedEvent.UnRegister(DuplicateToolSelected);
			_deleteToolButtonPressedEvent.UnRegister(DeleteToolSelected);
			_placementToolButtonPressedEvent.UnRegister(PlacementToolSelected);
			_placeAreaToolEvent.UnRegister(PlaceAreaToolSelected);
			_placeConveyorToolEvent.UnRegister(PlaceConveyorsToolSelected);
			_placeBlueprintToolEvent.UnRegister(PlaceBlueprintToolSelected);
			_selectNewBlueprintToolEvent.UnRegister(SelectNewBlueprintToolSelected);
			_placeTunnelsToolEvent.UnRegister(PlaceTunnelsToolSelected);
			_placeSkylinesToolEvent.UnRegister(PlaceSkylinesToolSelected);
			_placeCraneFromBuildingToolEvent.UnRegister(PlaceCraneFromBuildingToolSelected);
			_cleanConveyorsToolEvent.UnRegister(CleanConveyorsToolEvent);
			_placeBuildingButtonPressedEvent.UnRegister(PlacementToolSelected);
			_selectToolEvent.UnRegister(SelectTool);
			_finishedLoadingSaveEvent.UnRegister(ResetTools);
			_startAction.action.performed -= StartActionPerformed;
			_endAction.action.performed -= EndActionPerformed;
			_rotateAction.action.performed -= RotateActionPerformed;
			_mirrorAction.action.performed -= MirrorActionPerformed;
			_cancelAction.action.performed -= CancelMouseAction;
			_escapeAction.action.performed -= CancelAction;
			_swapGameMode.action.performed -= CancelMouseAction;
			_operatorPickingAction.action.performed -= PickOperatorActionStarted;
			_operatorPickingAction.action.canceled -= PickOperatorActionEnded;
		}

		private void ResetTools()
		{
			if (_selectedTool != null)
			{
				_selectedTool.DeSelectTool();
			}
			SelectTool(_openOperatorTool);
		}

		private void CancelAction(InputAction.CallbackContext obj)
		{
			SelectTool(_openOperatorTool);
			_actionCanceledEvent.Fire();
			_updateSelectionBoxColor.Fire(_toolColorLibrary.SelectToolColor);
		}

		private void StartedMouseCancelAction(InputAction.CallbackContext obj)
		{
			_startedCancelActionTimeStamp = DateTime.Now;
			_startedCancelActionMousePos = pointerPositionInputAction.action.ReadValue<Vector2>();
		}

		private void CancelMouseAction(InputAction.CallbackContext obj)
		{
			if (!(Vector2.Distance(pointerPositionInputAction.action.ReadValue<Vector2>(), _startedCancelActionMousePos) > _maxMousePointerDistance) && !((DateTime.Now - _startedCancelActionTimeStamp).TotalSeconds > _maxButtonHoldDuration))
			{
				CancelAction(obj);
			}
		}

		private void PlaceConveyorsToolSelected()
		{
			if (_selectedTool != _placeConveyorsTool)
			{
				SelectTool(_placeConveyorsTool);
			}
			else
			{
				SelectDefaultTool();
			}
		}

		private void PlaceTunnelsToolSelected()
		{
			if (_selectedTool != _placeTunnelTool)
			{
				SelectTool(_placeTunnelTool);
			}
			else
			{
				SelectDefaultTool();
			}
		}

		private void PlaceSkylinesToolSelected()
		{
			if (_selectedTool != _placeSkylineTool)
			{
				SelectTool(_placeSkylineTool);
			}
			else
			{
				SelectDefaultTool();
			}
		}

		private void PlaceCraneFromBuildingToolSelected()
		{
			SelectTool(_placeCraneFromBuildingTool);
		}

		private void CleanConveyorsToolEvent()
		{
			SelectTool(_cleanConveyorsTool);
			_updateSelectionBoxColor.Fire(_toolColorLibrary.CleanConveyorsToolColor);
		}

		private void PlaceAreaToolSelected(int id)
		{
			FactoryObjectData objectDataWithId = _factoryObjectDatabase.GetObjectDataWithId(id);
			if (!(objectDataWithId == null))
			{
				Blueprint blueprint = new Blueprint(_gridLocator.GetCellPosition(_mouseToGridInput.GetSelectedMapPosition()), 0, new List<BlueprintElement>
				{
					new BlueprintElement(GetNewPosition(0, id), objectDataWithId, 0, mirrored: false)
				});
				SelectTool(_placeAreaTool, blueprint);
			}
		}

		private void MoveToolSelected()
		{
			SelectTool(_moveTool);
			_updateSelectionBoxColor.Fire(_toolColorLibrary.MoveToolColor);
		}

		private void DuplicateToolSelected()
		{
			SelectTool(_duplicateTool);
			_updateSelectionBoxColor.Fire(_toolColorLibrary.DuplicateToolColor);
		}

		private void DeleteToolSelected()
		{
			SelectTool(_deleteTool);
			_updateSelectionBoxColor.Fire(_toolColorLibrary.DeleteToolColor);
		}

		private void SelectToolSelected()
		{
			SelectTool(_openOperatorTool);
			_updateSelectionBoxColor.Fire(_toolColorLibrary.SelectToolColor);
		}

		public void SelectDefaultTool()
		{
			SelectTool(_openOperatorTool);
		}

		private void PlacementToolSelected(int id)
		{
			FactoryObjectData objectDataWithId = _factoryObjectDatabase.GetObjectDataWithId(id);
			if (!(objectDataWithId == null))
			{
				if (_selectedTool == _placementTool && _placementTool.IsSelectedBlueprint(objectDataWithId))
				{
					SelectDefaultTool();
					return;
				}
				_gameplayTooltipEvent.SetActiveState(isActive: true);
				Blueprint blueprint = new Blueprint(_gridLocator.GetCellPosition(_mouseToGridInput.GetSelectedMapPosition()), 0, new List<BlueprintElement>
				{
					new BlueprintElement(GetNewPosition(0, id), objectDataWithId, 0, mirrored: false)
				});
				int rotation = Mathf.RoundToInt(_cameraLocator.Camera.transform.eulerAngles.y / 90f) * 90 + 90;
				_placementTool.SetRotation(rotation);
				SelectTool(_placementTool, blueprint);
			}
		}

		private void PlaceBlueprintToolSelected(BlueprintDto blueprintDto)
		{
			if (blueprintDto != null)
			{
				Blueprint blueprint = blueprintDto.CopyToBlueprint(_factoryObjectDatabase);
				if (!BlueprintHasLockedFactoryObjects(blueprint))
				{
					StartPlacingBlueprint(blueprint);
				}
			}
		}

		private bool BlueprintHasLockedFactoryObjects(Blueprint blueprint)
		{
			foreach (BlueprintElement element in blueprint.Elements)
			{
				if (_lockedFactoryObjects.IsFactoryObjectLocked(element.ObjectData))
				{
					ModalDialogDto dto = new ModalDialogDto(new ModalDialogContent("ModalWarning.BlueprintsLocked"), Sizes.Xs, delegate
					{
						StartPlacingBlueprint(blueprint, checkForLockedElements: true);
					}, showCancelButton: true)
					{
						OverrideSuccessButtonTextKey = "ModalGeneric.ProceedButton",
						OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
					};
					_showModalDialogEvent.Fire(new UIModaldialogData(dto));
					return true;
				}
			}
			return false;
		}

		private void StartPlacingBlueprint(Blueprint blueprint, bool checkForLockedElements = false)
		{
			int rotation = Mathf.RoundToInt(_cameraLocator.Camera.transform.eulerAngles.y / 90f) * 90 + 90;
			_placementTool.SetRotation(rotation);
			if (checkForLockedElements)
			{
				Blueprint blueprintCopyWithoutLockedFactoryObjectDatas = GetBlueprintCopyWithoutLockedFactoryObjectDatas(blueprint);
				if (blueprintCopyWithoutLockedFactoryObjectDatas.Elements.Count > 0)
				{
					SelectTool(_placementTool, blueprintCopyWithoutLockedFactoryObjectDatas);
					return;
				}
				ModalDialogDto dto = new ModalDialogDto(new ModalDialogContent("ModalWarning.SelectionEmpty"), Sizes.Xs, delegate
				{
				})
				{
					OverrideSuccessButtonTextKey = "ModalGeneric.ConfirmButton"
				};
				_showModalDialogEvent.Fire(new UIModaldialogData(dto));
			}
			else
			{
				SelectTool(_placementTool, blueprint);
			}
		}

		private Blueprint GetBlueprintCopyWithoutLockedFactoryObjectDatas(Blueprint blueprint)
		{
			Blueprint copy = blueprint.GetCopy();
			for (int num = copy.Elements.Count - 1; num >= 0; num--)
			{
				BlueprintElement blueprintElement = copy.Elements[num];
				if (_lockedFactoryObjects.IsFactoryObjectLocked(blueprintElement.ObjectData))
				{
					copy.Elements.RemoveAt(num);
				}
			}
			return copy;
		}

		private void SelectNewBlueprintToolSelected()
		{
			SelectTool(_saveAsBlueprintTool);
			_updateSelectionBoxColor.Fire(_toolColorLibrary.CreateBlueprintToolColor);
		}

		private void SelectFactoryObjectToolSelected(List<Type> factoryObjectBehaviours)
		{
			SelectTool(_selectFactoryObjectTool);
			_selectFactoryObjectTool.SetNeededFactoryObjectBehaviours(factoryObjectBehaviours);
			_selectFactoryObjectTool.OnComplete += OnSelectFactoryObjectComplete;
			_selectFactoryObjectTool.OnDeselectTool += OnSelectFactoryObjectDeselected;
		}

		private void OnSelectFactoryObjectComplete()
		{
			_selectFactoryObjectTool.OnComplete -= OnSelectFactoryObjectComplete;
			_selectFactoryObjectTool.OnDeselectTool -= OnSelectFactoryObjectDeselected;
			SelectToolSelected();
		}

		private void OnSelectFactoryObjectDeselected()
		{
			_selectFactoryObjectTool.OnComplete -= OnSelectFactoryObjectComplete;
			_selectFactoryObjectTool.OnDeselectTool -= OnSelectFactoryObjectDeselected;
		}

		private void RotateActionPerformed(InputAction.CallbackContext obj)
		{
			_selectedTool.Rotate(90);
		}

		private void MirrorActionPerformed(InputAction.CallbackContext obj)
		{
			_selectedTool.Mirror();
		}

		private void PickOperatorActionStarted(InputAction.CallbackContext obj)
		{
			_startedPickingActionMousePos = pointerPositionInputAction.action.ReadValue<Vector2>();
		}

		private void PickOperatorActionEnded(InputAction.CallbackContext obj)
		{
			float num = Vector2.Distance(pointerPositionInputAction.action.ReadValue<Vector2>(), _startedPickingActionMousePos);
			FactoryObjectView hoveredViewOrGridView = _mouseToGridInput.GetHoveredViewOrGridView();
			if (hoveredViewOrGridView == null)
			{
				return;
			}
			FactoryObject factoryObject = hoveredViewOrGridView.FactoryObject;
			if (factoryObject != null && !(num > 10f) && !(factoryObject.FactoryLayer != _factoryLayer) && factoryObject.CanBeDuplicated && factoryObject.CanBeMoved && !_lockedFactoryObjects.IsFactoryObjectLocked(factoryObject.FactoryObjectData))
			{
				_gameplayTooltipEvent.SetActiveState(isActive: true);
				FactoryObjectData factoryObjectData = hoveredViewOrGridView.FactoryObject.FactoryObjectData;
				if (_pickingDataToTool.TryGetValue(factoryObjectData, out var value))
				{
					SelectTool(value);
					return;
				}
				Vector3Int cellPosition = _gridLocator.GetCellPosition(_mouseToGridInput.GetSelectedMapPosition());
				List<BlueprintElement> blueprintElements = GetBlueprintElements(cellPosition, new List<FactoryObject> { hoveredViewOrGridView.FactoryObject });
				Blueprint blueprint = new Blueprint(cellPosition, 0, blueprintElements, new List<Vector3Int>());
				_placementTool.SetRotation(0, resetLastRotation: true);
				SelectTool(_placementTool, blueprint);
			}
		}

		private List<BlueprintElement> GetBlueprintElements(Vector3Int parentPosition, List<FactoryObject> factoryObjects)
		{
			List<BlueprintElement> list = new List<BlueprintElement>();
			foreach (FactoryObject factoryObject in factoryObjects)
			{
				list.Add(new BlueprintElement(GetRelativePositions(parentPosition, factoryObject.OccupiedPositions), _factoryObjectDatabase.GetObjectDataWithId(factoryObject.ObjectId), factoryObject.Rotation, factoryObject.Mirrored, factoryObject.IsSoftLinked, factoryObject.IsHardLinked, new List<Vector3Int>(), new List<Vector3Int>(), new List<BehaviourConfigurationDto>(), new List<BehaviourSaveStateDto>()));
			}
			return list;
		}

		private List<Vector3Int> GetRelativePositions(Vector3Int parentPosition, List<Vector3Int> occupiedPositions)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			foreach (Vector3Int occupiedPosition in occupiedPositions)
			{
				list.Add(new Vector3Int(occupiedPosition.x - parentPosition.x, occupiedPosition.y - parentPosition.y, occupiedPosition.z - parentPosition.z));
			}
			return list;
		}

		private void EndActionPerformed(InputAction.CallbackContext obj)
		{
			if (!_isPointerOverGameObject)
			{
				_uiMenuManagerLocator.UIMenuManager.GoBack(_toolSystemToolDoIntentGoBackSource);
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
				_selectedTool.DoAction(cellPosition, selectedMapPosition);
			}
			else
			{
				_buildModeEvent.Fire(data: false);
				_selectedTool.CancelAction();
			}
		}

		public void DoSelectedToolAction(FactoryObject factoryObject)
		{
			_uiMenuManagerLocator.UIMenuManager.GoBack(_toolSystemSelectToolGoBackSource);
			_selectedTool.DoAction(factoryObject);
		}

		private void HideUIMenuIfSelectingTool()
		{
		}

		private void StartActionPerformed(InputAction.CallbackContext obj)
		{
			if (!_isPointerOverGameObject)
			{
				_uiMenuManagerLocator.UIMenuManager.GoBack(_toolSystemToolDoIntentGoBackSource);
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
				_selectedTool.OnActionIntent(cellPosition, selectedMapPosition);
			}
		}

		private void Update()
		{
			_isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
			if (_selectedTool != null)
			{
				if (_isCursorHoveringUI.Value || _operatorInteriorUIIsOpen.Value)
				{
					if (_lastHovered != null)
					{
						_lastHovered.HoverStopped();
						_lastHovered = null;
					}
					return;
				}
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
				_selectedTool.UpdateTool(cellPosition, selectedMapPosition);
			}
			UpdateHoveringFactoryObject();
			UpdateHoveringIsland();
		}

		private void UpdateHoveringFactoryObject()
		{
			if (_selectedTool != _openOperatorTool)
			{
				if (_lastHovered != null)
				{
					_lastHovered.HoverStopped();
					_lastHovered = null;
				}
				return;
			}
			FactoryObjectView hoveredViewOrGridView = _mouseToGridInput.GetHoveredViewOrGridView();
			if (!(hoveredViewOrGridView == _lastHovered))
			{
				if (_lastHovered != null)
				{
					_lastHovered.HoverStopped();
				}
				if (hoveredViewOrGridView != null && !_previewSystem.IsPreviewing(hoveredViewOrGridView))
				{
					hoveredViewOrGridView.Hover();
				}
				_lastHovered = hoveredViewOrGridView;
			}
		}

		private void UpdateHoveringIsland()
		{
			if (_mouseToGridInput.TryGetSelectedIslandObject(out var islandObject) && !_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject) && !islandObject.IslandConfig.IsGNNGateIsland)
			{
				if (!(_selectedTool is UnlockIslandTool) && _selectedTool.CanAutoSwapAwayFrom)
				{
					_previousFactoryTool = _selectedTool;
					SelectTool(_unlockIslandTool);
				}
			}
			else if (_selectedTool is UnlockIslandTool)
			{
				if (_previousFactoryTool != null)
				{
					SelectTool(_previousFactoryTool);
					_previousFactoryTool = null;
				}
				else
				{
					SelectDefaultTool();
				}
			}
		}

		private void SelectTool(FactoryTool factoryTool)
		{
			SelectTool(factoryTool, null);
		}

		public void SelectTool(FactoryTool factoryTool, Blueprint blueprint)
		{
			HideUIMenuIfSelectingTool();
			_buildModeEvent.Fire(factoryTool != null && factoryTool != _openOperatorTool && factoryTool != _unlockIslandTool);
			if (_selectedTool != null)
			{
				_selectedTool.DeSelectTool();
			}
			_selectedTool = factoryTool;
			if (blueprint != null)
			{
				_selectedTool.SelectTool(blueprint);
			}
			else
			{
				_selectedTool.SelectTool(null);
			}
		}

		private List<Vector3Int> GetNewPosition(int z, int id)
		{
			List<Vector3Int> relativePositions = _factoryObjectDatabase.GetObjectDataWithId(id).RelativePositions;
			List<Vector3Int> list = new List<Vector3Int>(relativePositions.Count);
			foreach (Vector3Int item in relativePositions)
			{
				list.Add(item + new Vector3Int(0, 0, z));
			}
			return list;
		}
	}
}
