#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews.Arrows;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils;
using Utils.Enums;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/MoveTool", fileName = "MoveTool", order = 0)]
	public class MoveTool : SelectionFactoryTool
	{
		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BluePrintEvent _updatePreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		protected LockedFactoryObjectsPersistentSO _lockedFactoryObjects;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private BoolVariableSO _isCurrentlyUsingMoveToolSO;

		[SerializeField]
		private int _showArrowsDistance = 5;

		private FactoryLayer _placedFactoryLayer;

		private Vector3Int _originalPosition;

		private int _originalRotation;

		private bool _originalMirror;

		private readonly List<bool> _canPlaceElements = new List<bool>();

		private bool _isPendingDoAction;

		private readonly List<FactoryObject> _movingObjects = new List<FactoryObject>();

		private BlueprintViewDto _blueprintViewDto;

		private Vector3Int? _lastPosition;

		private Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows> _factoryObjectsArrowsShowing = new Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows>();

		private bool _moveStarted
		{
			get
			{
				return _isCurrentlyUsingMoveToolSO.Value;
			}
			set
			{
				_isCurrentlyUsingMoveToolSO.SetValue(value);
			}
		}

		public override void Rotate(int rotation)
		{
			base.Rotate(rotation);
			if (!_isSelecting)
			{
				Vector3 position = _blueprintViewDto.Position;
				_blueprintViewDto = BlueprintViewDto.Create(_selection, _gridLocator, _selection.Position);
				_blueprintViewDto.Position = position;
				_lastPosition = null;
			}
		}

		public override void Mirror()
		{
			base.Mirror();
			if (!_isSelecting)
			{
				Vector3 position = _blueprintViewDto.Position;
				_blueprintViewDto = BlueprintViewDto.Create(_selection, _gridLocator, _selection.Position);
				_blueprintViewDto.Position = position;
				_lastPosition = null;
			}
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_moveStarted = false;
			_isPendingDoAction = false;
			_movingObjects.Clear();
		}

		protected override void ImplementedSelectTool(Blueprint blueprint, bool singleObject = false)
		{
			_selection = RemoveNonMoveableObjectsFromBlueprint(blueprint);
			if (blueprint.Elements.Count == 0)
			{
				SelectTool(null);
				return;
			}
			_moveStarted = true;
			_placedFactoryLayer = _factoryLayer.Value;
			_lastPosition = _selection.Position;
			_blueprintViewDto = BlueprintViewDto.Create(_selection, _gridLocator, _selection.Position);
			_startPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced: false));
			_originalPosition = blueprint.Position;
			_originalRotation = blueprint.Rotation;
			_originalMirror = blueprint.Elements[0].Mirrored;
			_factoryObjectsRemoveViewsEvent.Fire(blueprint.Elements.Select((BlueprintElement x) => x.CreatedId).ToList());
			int num = 0;
			foreach (BlueprintElement element in blueprint.Elements)
			{
				Vector3Int position = element.RelativePositions[0] + _originalPosition;
				FactoryObject objectAt = _placedFactoryLayer.GetObjectAt(position);
				_movingObjects.Add(objectAt);
				_placedFactoryLayer.RemoveObjectAt(position, invokeObjectsChangedEvent: false);
				num = Mathf.Max(num, objectAt.FactoryObjectData.ObjectSize);
			}
			_placedFactoryLayer.ObjectsInLayerChanged();
			_audioManagerLocator.AudioManager.PlayMoveObject(_originalPosition, num);
		}

		private Blueprint RemoveNonMoveableObjectsFromBlueprint(Blueprint blueprint)
		{
			List<BlueprintElement> elements = blueprint.Elements;
			for (int num = elements.Count - 1; num >= 0; num--)
			{
				BlueprintElement blueprintElement = elements[num];
				if (_lockedFactoryObjects.IsFactoryObjectLocked(blueprintElement.ObjectData))
				{
					this.Log($"Remove locked {blueprintElement} from selection!", "RemoveNonMoveableObjectsFromBlueprint", 133);
					elements.RemoveAt(num);
				}
			}
			blueprint.SetElements(elements);
			return blueprint;
		}

		protected override bool CanSelectFactoryObject(FactoryObject factoryObject, bool isSingle)
		{
			Vector3Int position = factoryObject.Position;
			if (_islandLayer.TryGetIslandAtWorldPosition(position, out var islandObject) && !_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject))
			{
				Vector3Int vector3Int = position;
				this.LogError("Can't duplicate object from locked island: " + vector3Int.ToString() + " island: " + islandObject.IslandConfig.IslandData.Name, "CanSelectFactoryObject", 148);
				return false;
			}
			if (factoryObject.CanBeMoved)
			{
				return base.CanSelectFactoryObject(factoryObject, isSingle);
			}
			return false;
		}

		protected override void ImplementedUpdateTool(Vector3Int position)
		{
			if (_isPendingDoAction)
			{
				return;
			}
			if (_lastPosition.HasValue)
			{
				Vector3Int? lastPosition = _lastPosition;
				if (position == lastPosition)
				{
					return;
				}
			}
			_lastPosition = position;
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			BlueprintPlacementValidator.CanBePlacedPerIndex(position, _selection, _placedFactoryLayer, _terrainLayer, _canPlaceElements, isBeingMoved: true);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			_blueprintViewDto.Position = _gridLocator.GetWorldPosition(position);
			_updatePreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, _canPlaceElements));
			UpdateArrows(position);
		}

		protected override void ImplementedDoAction(Vector3Int position)
		{
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			int num = BlueprintPlacementValidator.CanBePlacedPerIndex(position, _selection, _placedFactoryLayer, _terrainLayer, _canPlaceElements, isBeingMoved: true);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			if (num <= 0)
			{
				CancelAction();
			}
			else if (num < _selection.Elements.Count)
			{
				if (_selection.Elements.Count <= 1)
				{
					CancelAction();
				}
				else
				{
					MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.MoveText", Sizes.M, delegate
					{
						DoMoveInternal(position);
					}, showCancelButton: true, CancelAction)
					{
						OverrideSuccessButtonTextKey = "ModalWarning.MoveConfirmButton"
					};
					_isPendingDoAction = true;
					_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
				}
			}
			else
			{
				DoMoveInternal(position);
			}
			HideAllArrows();
		}

		private void DoMoveInternal(Vector3Int position)
		{
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			BlueprintPlacementValidator.CanBePlacedPerIndex(position, _selection, _placedFactoryLayer, _terrainLayer, _canPlaceElements, isBeingMoved: true);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			RemoveNonPlaceableBlueprintElements(_selection, _movingObjects, _canPlaceElements);
			MoveBlueprintCommand command = new MoveBlueprintCommand(_placedFactoryLayer, _terrainLayer, position, _selection.Rotation, _movingObjects, _selection, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
			_commandManager.DoCommand(command);
			_stopPreviewEvent.Fire();
			SelectTool(null);
		}

		protected override void ImplementedCancelAction()
		{
			if (_moveStarted)
			{
				_selection.Rotate(_originalRotation - _selection.Rotation);
				if (_originalMirror != _selection.Elements[0].Mirrored)
				{
					_selection.Mirror();
				}
				new MoveBlueprintCommand(_placedFactoryLayer, _terrainLayer, _originalPosition, _originalRotation, _movingObjects, _selection, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator).TryDo();
				_stopPreviewEvent.Fire();
			}
			_moveStarted = false;
			_isPendingDoAction = false;
			_selection = null;
			_movingObjects.Clear();
			HideAllArrows();
		}

		public override void DeSelectTool()
		{
			base.DeSelectTool();
			ImplementedCancelAction();
		}

		protected override void ImplementedOnActionIntent(Vector3Int position)
		{
		}

		public void RemoveNonPlaceableBlueprintElements(Blueprint blueprint, List<FactoryObject> factoryObjects, List<bool> canBePlaced)
		{
			for (int num = canBePlaced.Count - 1; num >= 0; num--)
			{
				if (!canBePlaced[num])
				{
					if (blueprint.Elements[num].IsHardLinked)
					{
						List<Vector3Int> hardLinkedToRelativePositions = blueprint.Elements[num].HardLinkedToRelativePositions;
						for (int i = 0; i < blueprint.Elements.Count; i++)
						{
							Vector3Int item = blueprint.Elements[i].RelativePositions[0];
							if (hardLinkedToRelativePositions.Contains(item))
							{
								hardLinkedToRelativePositions.Remove(item);
								if (i > num)
								{
									RemoveObjectFromBlueprint(blueprint, factoryObjects, i);
								}
								else
								{
									canBePlaced[i] = false;
								}
							}
						}
					}
					RemoveObjectFromBlueprint(blueprint, factoryObjects, num);
				}
			}
			_placedFactoryLayer.ObjectsInLayerChanged();
			void RemoveObjectFromBlueprint(Blueprint blueprint2, List<FactoryObject> list, int elementIndex)
			{
				FactoryObject factoryObject = list[elementIndex];
				blueprint2.Elements.RemoveAt(elementIndex);
				list.RemoveAt(elementIndex);
				_placedFactoryLayer.TryAddFactoryObject(factoryObject, invokeObjectsChangedEvent: false);
				CreateFactoryObjectDto data = new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(factoryObject.Position), factoryObject.Rotation, factoryObject.Mirrored, factoryObject, elementIndex, isGameLoading: true);
				_createFactoryObjectEvent.Fire(data);
			}
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
