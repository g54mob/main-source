using System.Linq;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.SaveData.PersistentSOs;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils.Enums;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/DeleteTool", fileName = "DeleteTool", order = 0)]
	public class DeleteTool : SelectionFactoryTool
	{
		[Header("Delete refs")]
		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private int _deleteWarningCutoffAmount = 50;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		protected override bool CanSelectFactoryObject(FactoryObject factoryObject, bool isSingle)
		{
			if (factoryObject.CanBeDeleted)
			{
				return base.CanSelectFactoryObject(factoryObject, isSingle);
			}
			return false;
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_singleSelectCanAffectNonChangeable = true;
		}

		protected override void ImplementedSelectTool(Blueprint blueprint, bool singleObject = false)
		{
			if (singleObject)
			{
				DeleteSingleObject();
			}
			else
			{
				DeleteSelection();
			}
			SelectTool(null);
		}

		private void DeleteSingleObject()
		{
			FactoryObjectView hoveredViewOrGridView = _mouseToGridInput.GetHoveredViewOrGridView();
			if (hoveredViewOrGridView != null)
			{
				if (hoveredViewOrGridView.TryGetComponent<IDeleteToolBehaviour>(out var component))
				{
					DeleteSingleObjectInternal(component);
					return;
				}
				if (hoveredViewOrGridView.FactoryObject != null)
				{
					DeleteSingleObjectInternal(hoveredViewOrGridView.FactoryObject);
					return;
				}
			}
			DeleteSelection(deleteCranes: false);
		}

		private void DeleteSelection(bool deleteCranes = true)
		{
			if (_selection == null || _selection.Elements == null)
			{
				return;
			}
			bool flag = _selection.Elements.Count > _deleteWarningCutoffAmount;
			bool flag2 = false;
			foreach (BlueprintElement element in _selection.Elements)
			{
				if (_factoryObjectDatabase.BuildingsObjectData.BuildingDatas.Contains(element.ObjectData))
				{
					flag2 = true;
					break;
				}
			}
			if (flag || flag2)
			{
				_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.DemolishText", Sizes.M, delegate
				{
					DeleteSelectionInternal(deleteCranes);
				}, showCancelButton: true)
				{
					OverrideSuccessButtonTextKey = "ModalWarning.DemolishConfirmButton"
				}));
			}
			else
			{
				DeleteSelectionInternal(deleteCranes);
			}
		}

		private void DeleteSelectionInternal(bool deleteCranes)
		{
			_commandManager.DoCommand(new DeleteBlueprintCommand(_factoryLayer.Value, _terrainLayer, _selection, _factoryObjectsRemoveViewsEvent, _createFactoryObjectEvent, _gridLocator, deleteCranes, _cranesLibrary, _audioManagerLocator, _islandLayer, _unlockedIslandsPersistentSO));
			_selection = null;
		}

		private void DeleteSingleObjectInternal(IDeleteToolBehaviour deleteToolBehaviour)
		{
			_commandManager.DoCommand(deleteToolBehaviour.GetCommand());
		}

		private void DeleteSingleObjectInternal(FactoryObject factoryObject)
		{
			SelectFactoryObject(factoryObject);
			bool flag = false;
			foreach (BlueprintElement element in _selection.Elements)
			{
				if (_factoryObjectDatabase.BuildingsObjectData.BuildingDatas.Contains(element.ObjectData))
				{
					flag = true;
					break;
				}
			}
			DeleteBlueprintCommand deleteBpCommand = new DeleteBlueprintCommand(_factoryLayer.Value, _terrainLayer, _selection, _factoryObjectsRemoveViewsEvent, _createFactoryObjectEvent, _gridLocator, deleteCranes: false, _cranesLibrary, _audioManagerLocator, _islandLayer, _unlockedIslandsPersistentSO);
			if (flag)
			{
				_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.DemolishText", Sizes.M, delegate
				{
					_commandManager.DoCommand(deleteBpCommand);
				}, showCancelButton: true)
				{
					OverrideSuccessButtonTextKey = "ModalWarning.DemolishConfirmButton"
				}));
			}
			else
			{
				_commandManager.DoCommand(deleteBpCommand);
			}
			_selection = null;
		}

		protected override void ImplementedUpdateTool(Vector3Int position)
		{
		}

		protected override void ImplementedOnActionIntent(Vector3Int position)
		{
		}

		protected override void ImplementedDoAction(Vector3Int position)
		{
		}

		protected override void ImplementedCancelAction()
		{
		}
	}
}
