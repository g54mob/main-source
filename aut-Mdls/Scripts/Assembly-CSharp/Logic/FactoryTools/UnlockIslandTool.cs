#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_EXCEPTIONS
using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using Utils;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/UnlockIslandTool", fileName = "UnlockIslandTool", order = 0)]
	public class UnlockIslandTool : FactoryTool
	{
		[Header("Unlock Island Tool")]
		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[Header("Cost")]
		[SerializeField]
		private CurrencyPersistentSO _currency;

		[SerializeField]
		private ResourceCost _resourceCost;

		[Header("Modal")]
		[SerializeField]
		private UIMenuLocator _unlockIslandDialogLocator;

		[SerializeField]
		private AbstractUIMenuData.ToggleTypes _toggleTypes;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		private IslandObject _lastHoveredIsland;

		private bool _isModalOpen;

		public override bool CanAutoSwapAwayFrom => true;

		public override void SelectTool(Blueprint blueprint)
		{
			_isModalOpen = false;
			_lastHoveredIsland = null;
		}

		public override void DeSelectTool()
		{
			StopHoverPreviousIsland();
			_lastHoveredIsland = null;
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (!_isModalOpen && _mouseToGridInput.TryGetSelectedIslandObject(in gridPos, out var islandObject) && _lastHoveredIsland != islandObject)
			{
				if (!_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject))
				{
					StopHoverPreviousIsland();
					StartHoverIsland(islandObject);
					SetCursor();
				}
				else
				{
					StopHoverPreviousIsland();
				}
			}
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (!_mouseToGridInput.TryGetSelectedIslandObject(in gridPos, out var islandObject))
			{
				this.DevException("Should never be on this tool unless we're hovering an island?", "DoAction", 83);
				return;
			}
			_audioManagerLocator.AudioManager.PlayIslandClick();
			_isModalOpen = true;
			UnlockIslandDialogDto data = new UnlockIslandDialogDto(_resourceCost, _unlockedIslandsPersistentSO.IsIslandAvaliable(islandObject), _unlockIslandDialogLocator.UIMenu, _toggleTypes, delegate
			{
				TryBuyIsland(islandObject);
			}, OnModalClosed);
			_showUIMenuEvent.Fire(data);
		}

		public override void CancelAction()
		{
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
		}

		private void TryBuyIsland(IslandObject islandObject)
		{
			if (_isModalOpen)
			{
				OnModalClosed();
				if (!_currency.TryBuy(_resourceCost))
				{
					this.LogWarning("Couldn't afford", "TryBuyIsland", 108);
				}
				else if (_unlockedIslandsPersistentSO.UnlockedIslandCount < UnlockedIslandsPersistentSO.MAX_DEMO_UNLOCKABLE_ISLAND_COUNT)
				{
					_cameraViewLocator.CameraView.LerpToTargetPosition(islandObject.Position, 1f, blockInput: false);
					_unlockedIslandsPersistentSO.UnlockIsland(islandObject);
				}
			}
		}

		public bool CanBuyIsland()
		{
			return _currency.HasEnoughResources(_resourceCost);
		}

		private void OnModalClosed()
		{
			_isModalOpen = false;
		}

		private void StartHoverIsland(IslandObject islandObject)
		{
			islandObject.IslandView.Hover();
			_lastHoveredIsland = islandObject;
		}

		private void StopHoverPreviousIsland()
		{
			_lastHoveredIsland?.IslandView?.HoverStopped();
			_lastHoveredIsland = null;
		}
	}
}
