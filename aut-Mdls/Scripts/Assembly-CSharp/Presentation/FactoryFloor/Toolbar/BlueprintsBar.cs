#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.IO;
using Data;
using Data.Operator;
using Data.Variables;
using Events;
using Events.UI;
using Logic.Factory.Blueprint;
using Presentation.UI.Menus;
using Presentation.UI.Menus.GamecontrolMenus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BlueprintsBar : AbstractOperatorBar
	{
		[SerializeField]
		private GameObject _blueprintInfo;

		[SerializeField]
		private BlueprintButton _blueprintButtonPrefab;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BaseEvent _hideBarInfoEvent;

		[SerializeField]
		private IntVariableSO _blueprintMaxAmount;

		[SerializeField]
		private StringVariableSO _currentFactoryBlueprintWorkingPath;

		[SerializeField]
		private BaseEvent _newBlueprintWasAddedEvent;

		[SerializeField]
		private IntVariableSO _lastSelectedBlueprintSlot;

		[SerializeField]
		private DeleteBlueprintEvent _deleteBlueprintEvent;

		[SerializeField]
		private EditBlueprintEvent _editBlueprintEvent;

		[SerializeField]
		private UIMenuLocator _editNameAndColorMenuUILocator;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private EditNameAndColorUIData _editNameAndColorUIData;

		private List<BlueprintButton> _blueprintButtons = new List<BlueprintButton>();

		private BlueprintButton _currentSelection;

		private const string _alphabetLocaKey = "BlueprintsBar.BlueprintDesignation";

		private string _alphabetString;

		private void Awake()
		{
			_newBlueprintWasAddedEvent.Register(RefreshBlueprints);
			_deleteBlueprintEvent.Register(DeleteBlueprint);
			_editBlueprintEvent.Register(EditBlueprint);
			LocalizationUtility.OnLanguageUpdate += SetTexts;
		}

		protected override void InitalizeInternal()
		{
			SetTexts();
			if (string.IsNullOrEmpty(_currentFactoryBlueprintWorkingPath.Value))
			{
				_currentFactoryBlueprintWorkingPath.SetValue(Path.Combine(SaveSystem.GameSavePath, "FactoryBlueprints"));
			}
			for (int i = 0; i < _blueprintMaxAmount.Value; i++)
			{
				BlueprintButton blueprintButton = UnityEngine.Object.Instantiate(_blueprintButtonPrefab, base.transform);
				blueprintButton.Setup(i, _alphabetString[i % _alphabetString.Length].ToString());
				blueprintButton.OnSelected = (Action<BlueprintButton>)Delegate.Combine(blueprintButton.OnSelected, new Action<BlueprintButton>(OnButtonSelected));
				_blueprintButtons.Add(blueprintButton);
			}
			RefreshBlueprints();
		}

		private void SetTexts()
		{
			_alphabetString = LocalizationUtility.GetLocalizedText("BlueprintsBar.BlueprintDesignation");
		}

		private void OnDestroy()
		{
			_newBlueprintWasAddedEvent.UnRegister(RefreshBlueprints);
			_deleteBlueprintEvent.UnRegister(DeleteBlueprint);
			_editBlueprintEvent.UnRegister(EditBlueprint);
			for (int i = 0; i < _blueprintButtons.Count; i++)
			{
				BlueprintButton blueprintButton = _blueprintButtons[i];
				blueprintButton.OnSelected = (Action<BlueprintButton>)Delegate.Remove(blueprintButton.OnSelected, new Action<BlueprintButton>(OnButtonSelected));
			}
			LocalizationUtility.OnLanguageUpdate -= SetTexts;
		}

		private void OnButtonSelected(BlueprintButton button)
		{
			if (_currentSelection != null && _currentSelection != button)
			{
				_currentSelection.SetSelected(value: false);
			}
			_currentSelection = button;
		}

		public override void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public override void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		private void RefreshBlueprints()
		{
			DirectoryInfo info = (Directory.Exists(_currentFactoryBlueprintWorkingPath.Value) ? new DirectoryInfo(_currentFactoryBlueprintWorkingPath.Value) : Directory.CreateDirectory(_currentFactoryBlueprintWorkingPath.Value));
			List<(BlueprintDto, string)> blueprints = RetrieveBlueprintsFromPath(info);
			FillBlueprintUIButtons(blueprints);
		}

		private void FillBlueprintUIButtons(List<(BlueprintDto, string)> blueprints)
		{
			for (int i = 0; i < _blueprintButtons.Count; i++)
			{
				_blueprintButtons[i].SetUsedState(isUsed: false);
			}
			for (int j = 0; j < blueprints.Count; j++)
			{
				if (blueprints[j].Item1.Index < 0)
				{
					int num = FindFirstUnused();
					blueprints[j].Item1.Index = num;
					if (num < 0)
					{
						break;
					}
					_blueprintButtons[num].UseForBlueprint(blueprints[j]);
				}
				else
				{
					_blueprintButtons[blueprints[j].Item1.Index].UseForBlueprint(blueprints[j]);
				}
			}
		}

		private int FindFirstUnused()
		{
			for (int i = 0; i < _blueprintButtons.Count; i++)
			{
				if (!_blueprintButtons[i].IsUsed)
				{
					return i;
				}
			}
			return -1;
		}

		private List<(BlueprintDto, string)> RetrieveBlueprintsFromPath(DirectoryInfo info)
		{
			List<(BlueprintDto, string)> list = new List<(BlueprintDto, string)>();
			FileInfo[] files = info.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				if (fileInfo.Extension.Equals(".json") && SaveSystem.TryLoadData<BlueprintDto>(fileInfo.FullName, out var data))
				{
					list.Add((data, fileInfo.FullName));
				}
			}
			return list;
		}

		public void HideInfoBar()
		{
			_hideBarInfoEvent.Fire();
			if (_currentSelection != null)
			{
				_currentSelection.SetSelected(value: false);
			}
		}

		private void DeleteBlueprint(BlueprintUIData blueprintUIData)
		{
			if (SaveSystem.DoesFileExist(blueprintUIData.FileName + ".meta"))
			{
				SaveSystem.DeleteFile(blueprintUIData.FileName + ".meta");
			}
			SaveSystem.DeleteFile(blueprintUIData.FileName);
			_blueprintButtons[blueprintUIData.Index].SetUsedState(isUsed: false);
		}

		private void EditBlueprint(BlueprintUIData blueprintUIData)
		{
			_lastSelectedBlueprintSlot.SetValue(blueprintUIData.Index);
			_showUIMenuEvent.Fire(new EditNameAndColorUIMenuData(_editNameAndColorMenuUILocator.UIMenu, _editNameAndColorUIData));
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).UseEditMode(blueprintUIData);
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues += HandleBlueprintSaveNameInput;
		}

		private void HandleBlueprintSaveNameInput(bool success, string blueprintName, Color blueprintUIColor)
		{
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues -= HandleBlueprintSaveNameInput;
			if (success)
			{
				string fullSavePath = _currentFactoryBlueprintWorkingPath.Value + "/Blueprint" + _lastSelectedBlueprintSlot.Value + ".json";
				if (SaveSystem.TrySaveData(new BlueprintDto(_blueprintButtons[_lastSelectedBlueprintSlot.Value].Blueprint.CopyToBlueprint(_factoryObjectDatabase), blueprintName, blueprintUIColor, _lastSelectedBlueprintSlot.Value), fullSavePath))
				{
					RefreshBlueprints();
				}
				else
				{
					this.LogError("Saving blueprint wasn't successful!", "HandleBlueprintSaveNameInput", 231);
				}
			}
		}
	}
}
