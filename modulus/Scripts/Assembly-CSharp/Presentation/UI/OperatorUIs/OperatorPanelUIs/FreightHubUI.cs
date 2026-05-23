using System.Collections.Generic;
using Data;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter;
using Presentation.UI.Freighters;
using Presentation.UI.Menus;
using Presentation.UI.Menus.GamecontrolMenus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class FreightHubUI : FactoryPanelUIMenu
	{
		[SerializeField]
		private FreightHubSlotWidgetSimple[] _inSlotWidgetsSimple = new FreightHubSlotWidgetSimple[4];

		[SerializeField]
		private FreightHubSlotWidgetSimple[] _outSlotWidgetsSimple = new FreightHubSlotWidgetSimple[4];

		[SerializeField]
		private FreightHubSlotWidget[] _inSlotWidgets = new FreightHubSlotWidget[4];

		[SerializeField]
		private FreightHubSlotWidget[] _outSlotWidgets = new FreightHubSlotWidget[4];

		[SerializeField]
		private Button _renameButton;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _editNameAndColorMenuUILocator;

		[SerializeField]
		private EditNameAndColorUIData _editNameAndColorUIData;

		[Space]
		[SerializeField]
		private Transform _freighterListParent;

		[SerializeField]
		private GameObject _freightersTitle;

		[SerializeField]
		private FreighterSelectItem _freighterItemZero;

		private FreightHubBehaviour _behaviour;

		private FreightHubBehaviour _renameBehaviour;

		private List<FreighterObject> _freighterObjects;

		private List<FreighterSelectItem> _freighterListItems = new List<FreighterSelectItem>();

		protected override void HandleOnAwake()
		{
			_freighterListItems.Clear();
			_freighterListItems.Add(_freighterItemZero);
			for (int i = 0; i < _inSlotWidgets.Length; i++)
			{
				_inSlotWidgetsSimple[i].Setup(i);
				_inSlotWidgets[i].Setup(i, HandleClearIn, CanInSlotPassResources, HandlePassIn);
			}
			for (int j = 0; j < _outSlotWidgets.Length; j++)
			{
				_outSlotWidgetsSimple[j].Setup(j);
				_outSlotWidgets[j].Setup(j, HandleClearOut);
			}
		}

		protected override void SetTexts()
		{
			_titleText.SetText(_behaviour.CustomName);
		}

		protected override void Initialized()
		{
			if (_behaviour != null)
			{
				Unsubscribe();
			}
			_behaviour = _factoryObjectBehaviour as FreightHubBehaviour;
			_behaviour.OnInSlotChanged.RegisterMainThread(HandleInSlotChanged);
			_behaviour.OnOutSlotChanged.RegisterMainThread(HandleOutSlotChanged);
			_behaviour.OnUnInit += HandleUnInit;
			_renameButton.onClick.AddListener(RenameButtonClicked);
			for (int i = 0; i < _inSlotWidgets.Length; i++)
			{
				HandleInSlotChanged(i, _behaviour.GetInSlot(i));
			}
			for (int j = 0; j < _outSlotWidgets.Length; j++)
			{
				HandleOutSlotChanged(j, _behaviour.GetOutSlot(j));
			}
			if (_state == AbstractUIMenuData.UIMenuState.ConfigureMode)
			{
				UpdateFreighterList();
			}
		}

		private void HandleUnInit(FactoryObjectBehaviour behaviour)
		{
			HideMenu();
		}

		private void Unsubscribe()
		{
			if (_behaviour != null)
			{
				_behaviour.OnInSlotChanged.UnRegisterMainThread(HandleInSlotChanged);
				_behaviour.OnOutSlotChanged.UnRegisterMainThread(HandleOutSlotChanged);
				_behaviour.OnUnInit -= HandleUnInit;
				_behaviour = null;
			}
			_renameButton.onClick.RemoveListener(RenameButtonClicked);
		}

		private void RenameButtonClicked()
		{
			_renameBehaviour = _behaviour;
			_showUIMenuEvent.Fire(new EditNameAndColorUIMenuData(_editNameAndColorMenuUILocator.UIMenu, _editNameAndColorUIData));
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).UseEditMode(_renameBehaviour.CustomName);
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues += HandleNewFreighterNameInput;
		}

		private void HandleNewFreighterNameInput(bool success, string name, Color color)
		{
			((CreateBlueprintMenu)_editNameAndColorMenuUILocator.UIMenu).OnChangedValues -= HandleNewFreighterNameInput;
			if (success)
			{
				_renameBehaviour.SetCustomName(name);
			}
		}

		public override void HideMenu()
		{
			Unsubscribe();
			base.HideMenu();
		}

		private void HandleInSlotChanged(int index, FreightHubBehaviour.FreightHubSlot slot)
		{
			_inSlotWidgets[index].UpdateDisplay(slot, _behaviour.MaxInStorage);
			_inSlotWidgetsSimple[index].UpdateDisplay(slot);
		}

		private void HandleOutSlotChanged(int index, FreightHubBehaviour.FreightHubSlot slot)
		{
			_outSlotWidgets[index].UpdateDisplay(slot, _behaviour.MaxOutStorage);
			_outSlotWidgetsSimple[index].UpdateDisplay(slot);
		}

		private bool CanInSlotPassResources(int slotIndex)
		{
			if (!_behaviour.GetInSlot(slotIndex).HasResource)
			{
				return false;
			}
			FreightHubBehaviour.FreightHubSlot outSlot = _behaviour.GetOutSlot(slotIndex);
			if (!outSlot.HasResource)
			{
				return true;
			}
			return _behaviour.IsSameResourceAsInSlot(outSlot.Resource, slotIndex);
		}

		private void HandleClearIn(int slotIndex)
		{
			_behaviour.ClearInSlot(slotIndex);
		}

		private void HandleClearOut(int slotIndex)
		{
			_behaviour.ClearOutSlot(slotIndex);
		}

		private void HandlePassIn(int slotIndex)
		{
			_behaviour.PassInSlot(slotIndex);
		}

		private void UpdateFreighterList()
		{
			_freighterObjects = _behaviour.GetFreightersWithFreightHub();
			_freightersTitle.SetActive(_freighterObjects.Count > 0);
			for (int i = 0; i < _freighterListItems.Count; i++)
			{
				_freighterListItems[i].gameObject.SetActive(value: false);
			}
			int count = _freighterListItems.Count;
			for (int j = 0; j < _freighterObjects.Count; j++)
			{
				if (j >= count)
				{
					FreighterSelectItem item = Object.Instantiate(_freighterItemZero, _freighterListParent);
					_freighterListItems.Add(item);
				}
				_freighterListItems[j].Initalize(_freighterObjects[j]);
				_freighterListItems[j].gameObject.SetActive(value: true);
			}
		}
	}
}
