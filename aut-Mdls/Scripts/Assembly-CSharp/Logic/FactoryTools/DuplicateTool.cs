#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.SaveData.PersistentSOs;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory.Blueprint;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils;
using Utils.Enums;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/DuplicateTool", fileName = "DuplicateTool", order = 0)]
	public class DuplicateTool : SelectionFactoryTool
	{
		[Header("Placement refs")]
		[SerializeField]
		protected FactoryLayer _terrainLayer;

		[SerializeField]
		protected CommandManager _commandManager;

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
		protected LockedFactoryObjectsPersistentSO _lockedFactoryObjects;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		private FactoryLayer _placedFactoryLayer;

		private BlueprintViewDto _blueprintViewDto;

		private readonly List<bool> _canPlaceElements = new List<bool>();

		private bool _isPendingDoAction;

		private Vector3Int? _lastPosition;

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

		public override void DeSelectTool()
		{
			base.DeSelectTool();
			_stopPreviewEvent.Fire();
			_blueprintViewDto = null;
		}

		protected override void ImplementedSelectTool(Blueprint blueprint, bool singleObject = false)
		{
			_isPendingDoAction = false;
			_selection = RemoveNonDuplicableObjectsFromBlueprint(blueprint).GetCopy();
			if (blueprint.Elements.Count == 0)
			{
				SelectTool(null);
				return;
			}
			_placedFactoryLayer = _factoryLayer.Value;
			_lastPosition = _selection.Position;
			_blueprintViewDto = BlueprintViewDto.Create(_selection, _gridLocator, _selection.Position);
			_startPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced: false));
			_audioManagerLocator.AudioManager.PlayDuplicateObject(_selection.Position);
		}

		private Blueprint RemoveNonDuplicableObjectsFromBlueprint(Blueprint blueprint)
		{
			if (blueprint == null || blueprint.Elements == null)
			{
				return blueprint;
			}
			List<BlueprintElement> elements = blueprint.Elements;
			for (int num = elements.Count - 1; num >= 0; num--)
			{
				BlueprintElement blueprintElement = elements[num];
				if (_lockedFactoryObjects.IsFactoryObjectLocked(blueprintElement.ObjectData))
				{
					this.Log($"Remove locked {blueprintElement} from selection!", "RemoveNonDuplicableObjectsFromBlueprint", 99);
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
				this.LogError("Can't duplicate object from locked island: " + vector3Int.ToString() + " island: " + islandObject.IslandConfig.IslandData.Name, "CanSelectFactoryObject", 114);
				return false;
			}
			if (factoryObject.CanBeDuplicated)
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
			BlueprintPlacementValidator.CanBePlacedPerIndex(position, _selection, _placedFactoryLayer, _terrainLayer, _canPlaceElements);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			_blueprintViewDto.Position = _gridLocator.GetWorldPosition(position);
			_updatePreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, _canPlaceElements));
		}

		protected override void ImplementedDoAction(Vector3Int position)
		{
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			int num = BlueprintPlacementValidator.CanBePlacedPerIndex(position, _selection, _placedFactoryLayer, _terrainLayer, _canPlaceElements);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			if (num <= 0)
			{
				CancelDoPlacement(position);
			}
			else if (num < _selection.Elements.Count)
			{
				if (_selection.Elements.Count <= 1)
				{
					CancelDoPlacement(position);
					return;
				}
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
			else
			{
				DoPlacementInternal(position);
			}
		}

		private void DoPlacementInternal(Vector3Int position)
		{
			Blueprint copy = _selection.GetCopy();
			BlueprintPlacementValidator.RemoveNonPlaceableBlueprintElements(_selection, _canPlaceElements);
			PlaceBlueprintCommand command = new PlaceBlueprintCommand(_placedFactoryLayer, _terrainLayer, position, _selection.Rotation, _selection, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
			_commandManager.DoCommand(command);
			_stopPreviewEvent.Fire();
			ImplementedSelectTool(copy);
		}

		private void CancelDoPlacement(Vector3Int position)
		{
			_audioManagerLocator.AudioManager.PlayCantPlace(position);
			_isPendingDoAction = false;
		}

		protected override void ImplementedOnActionIntent(Vector3Int position)
		{
		}

		protected override void ImplementedCancelAction()
		{
		}
	}
}
