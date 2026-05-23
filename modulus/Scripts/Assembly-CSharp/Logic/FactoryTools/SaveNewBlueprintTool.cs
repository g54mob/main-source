#define ENABLE_DEBUG_ERRORS
using Data;
using Data.FactoryFloor.Tools;
using Data.Variables;
using Events;
using Events.Generic;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.GamecontrolMenus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/SaveNewBlueprintTool", fileName = "SaveNewBlueprintTool", order = 0)]
	public class SaveNewBlueprintTool : SelectionFactoryTool
	{
		[Header("Blueprint refs")]
		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private StringVariableSO _currentFactoryBlueprintWorkingPath;

		[SerializeField]
		private BaseEvent _newBlueprintWasAddedEvent;

		[SerializeField]
		private IntVariableSO _blueprintMaxSize;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		[LocaKey]
		private string _blueprintToolargeLocaKey;

		[SerializeField]
		private UIMenuLocator _editNameAndColorMenuUILocator;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private IntVariableSO _lastSelectedBlueprintSlot;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[SerializeField]
		private ToolColorLibrary _toolColorLibrary;

		[SerializeField]
		private EditNameAndColorUIData _editNameAndColorUIData;

		private bool _isBlueprintTooLarge;

		private string _blueprintTooLargeLocaKeyWithParams;

		public override bool CanAutoSwapAwayFrom => true;

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_isBlueprintTooLarge = false;
			_blueprintTooLargeLocaKeyWithParams = LocalizationUtility.GetLocalizedText(_blueprintToolargeLocaKey).Replace("{0}", _blueprintMaxSize.Value.ToString());
		}

		protected override void ImplementedSelectTool(Blueprint blueprint, bool singleObject = false)
		{
			_selection = blueprint;
			RemoveNonBlueprintableElementsFromSelection();
			if (_isBlueprintTooLarge || _selection == null || _selection.Elements.Count == 0)
			{
				CancelAction();
				return;
			}
			TryToCreateBlueprint();
			_toolSystemLocator.ToolSystem.SelectDefaultTool();
		}

		private void TryToCreateBlueprint()
		{
			_showUIMenuEvent.Fire(new EditNameAndColorUIMenuData(_editNameAndColorMenuUILocator.UIMenu, _editNameAndColorUIData));
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues += HandleBlueprintSaveNameInput;
		}

		private void HandleBlueprintSaveNameInput(bool success, string blueprintName, Color blueprintUIColor)
		{
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues -= HandleBlueprintSaveNameInput;
			if (success)
			{
				string fullSavePath = _currentFactoryBlueprintWorkingPath.Value + "/Blueprint" + _lastSelectedBlueprintSlot.Value + ".json";
				if (SaveSystem.TrySaveData(new BlueprintDto(_selection, blueprintName, blueprintUIColor, _lastSelectedBlueprintSlot.Value), fullSavePath))
				{
					OnBlueprintCreatedSuccessfully();
				}
				else
				{
					this.LogError("Saving blueprint wasn't successful!", "HandleBlueprintSaveNameInput", 84);
				}
			}
		}

		private void OnBlueprintCreatedSuccessfully()
		{
			_newBlueprintWasAddedEvent.Fire();
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			base.UpdateTool(gridPos, mousePos);
			if (!_isSelecting)
			{
				_updateSelectionBoxColor.Fire(_toolColorLibrary.CreateBlueprintToolColor);
				_isBlueprintTooLarge = false;
			}
			else if (_actionStarted)
			{
				bool flag = IsBluePrintTooLarge(gridPos);
				if (flag && !_isBlueprintTooLarge)
				{
					_setCursorTextEvent.Fire(_blueprintTooLargeLocaKeyWithParams);
				}
				_isBlueprintTooLarge = flag;
				_updateSelectionBoxColor.Fire(_isBlueprintTooLarge ? _toolColorLibrary.InvalidPlacementColor : _toolColorLibrary.CreateBlueprintToolColor);
			}
		}

		private bool IsBluePrintTooLarge(Vector3Int gridPos)
		{
			int num = Mathf.Abs(_initialGridPosition.x - gridPos.x);
			int num2 = Mathf.Abs(_initialGridPosition.z - gridPos.z);
			return num * num2 > _blueprintMaxSize.Value;
		}

		private void RemoveNonBlueprintableElementsFromSelection()
		{
			for (int num = _selection.Elements.Count - 1; num >= 0; num--)
			{
				BlueprintElement blueprintElement = _selection.Elements[num];
				if (!blueprintElement.ObjectData.CanBeBluePrinted)
				{
					_selection.Elements.Remove(blueprintElement);
				}
			}
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
