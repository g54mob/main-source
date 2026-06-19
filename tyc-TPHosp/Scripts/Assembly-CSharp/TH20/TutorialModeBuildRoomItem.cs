using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TutorialModeBuildRoomItem : TutorialMode
	{
		private enum States
		{
			None = 0,
			NeedToSelectItemsMenu = 1,
			NeedToSelectRoomItem = 2,
			NeedToPlaceItem = 3
		}

		private States State;

		private TutorialBuildRoomItemModeDefinition _definition;

		private HubMenu _hubMenu;

		private Pingable _itemsPingable;

		private ButtonAnimator _itemsButtonAnimator;

		private Pingable _roomItemSubMenuPingable;

		public TutorialModeBuildRoomItem(TutorialBuildRoomItemModeDefinition definition)
		{
			_definition = definition;
		}

		public override void Enter()
		{
			_hubMenu = Level.HUD.FindMenu<HubMenu>();
			_itemsButtonAnimator = TutorialUtils.GetHubItemsButton(Level);
			RectTransform transform = (RectTransform)_itemsButtonAnimator.transform;
			Image image = _itemsButtonAnimator.Button.image;
			_itemsPingable = new Pingable(Level.TutorialManager.PingManagerProxy, transform, image);
		}

		public override void Destroy()
		{
			RibbonMenu ribbonMenu = Level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu != null)
			{
				ribbonMenu.ShowTutorialObject(show: false);
				ribbonMenu.CloseMenu();
			}
			ShowCirclesAndArrowsOnItemsButton(show: false);
			if (_itemsPingable != null)
			{
				_itemsPingable.Destroy();
				_itemsPingable = null;
			}
			ResetRoomItemPingable(ribbonMenu);
			ResetVideo();
			base.Destroy();
		}

		public override void Update()
		{
			RibbonMenu ribbonMenu = Level.HUD.FindMenu<RibbonMenu>();
			RibbonItemRow ribbonItemRow = ((ribbonMenu != null) ? TutorialUtils.GetRibbonItemRow(Level, _definition.RoomItemDefinition.Instance) : null);
			Level.CursorManager.TryGetActiveMode<CursorRoomItem>(out var activeMode);
			bool flag = activeMode != null && activeMode.RoomItem.Definition == _definition.RoomItemDefinition.Instance;
			if (ribbonMenu == null)
			{
				State = States.NeedToSelectItemsMenu;
			}
			else if (flag)
			{
				State = States.NeedToPlaceItem;
			}
			else if (ribbonItemRow != null)
			{
				State = States.NeedToSelectRoomItem;
			}
			else
			{
				State = States.None;
			}
			switch (State)
			{
			case States.NeedToSelectItemsMenu:
				ResetVideo();
				ResetRoomItemPingable(ribbonMenu);
				StartItemsButtonPingable();
				ClearRoomItemMenuFilter(ribbonMenu);
				ShowCirclesAndArrowsOnItemsButton(show: true);
				break;
			case States.NeedToSelectRoomItem:
				ResetItemsPingable();
				ShowCirclesAndArrowsOnItemsButton(show: false);
				ResetVideo();
				StartRoomItemPingable(ribbonMenu);
				SetRoomItemMenuFilter(ribbonMenu);
				break;
			case States.NeedToPlaceItem:
				ResetItemsPingable();
				ShowCirclesAndArrowsOnItemsButton(show: false);
				ResetRoomItemPingable(ribbonMenu);
				SetRoomItemMenuFilter(ribbonMenu);
				OpenVideoMenu();
				break;
			default:
				ResetItemsPingable();
				ShowCirclesAndArrowsOnItemsButton(show: false);
				ResetRoomItemPingable(ribbonMenu);
				ClearRoomItemMenuFilter(ribbonMenu);
				ResetVideo();
				break;
			}
		}

		private void ShowCirclesAndArrowsOnItemsButton(bool show)
		{
			if (_definition.ShowHubMenuArrow && _hubMenu != null && _hubMenu.HubMenuButtons != null)
			{
				_hubMenu.HubMenuButtons.ShowTutorialHighlight(roomCircle: false, show, hireCircle: false);
			}
		}

		private void StartItemsButtonPingable()
		{
			_itemsPingable.RectTransform.SetAsLastSibling();
			_itemsPingable.Ping(_definition.ItemsPing);
		}

		private void ResetItemsPingable()
		{
			_itemsPingable.StopPing();
		}

		private void StartRoomItemPingable(RibbonMenu ribbonMenu)
		{
			RibbonItemRow ribbonItemRow = ((ribbonMenu != null) ? TutorialUtils.GetRibbonItemRow(Level, _definition.RoomItemDefinition.Instance) : null);
			if (!(ribbonItemRow == null))
			{
				RectTransform rectTransform = (RectTransform)ribbonItemRow.Button.transform;
				ribbonMenu.ShowTutorialObject(show: true, rectTransform);
				if (_roomItemSubMenuPingable == null)
				{
					_roomItemSubMenuPingable = new Pingable(Level.TutorialManager.PingManagerProxy, rectTransform, ribbonItemRow.BackgroundImage);
				}
				_roomItemSubMenuPingable.Ping(_definition.RoomItemPing);
			}
		}

		private void ResetRoomItemPingable(RibbonMenu ribbonMenu)
		{
			if (_roomItemSubMenuPingable != null)
			{
				_roomItemSubMenuPingable.Destroy();
				_roomItemSubMenuPingable = null;
			}
			if (ribbonMenu != null)
			{
				ribbonMenu.ShowTutorialObject(show: false);
			}
		}

		private void SetRoomItemMenuFilter(RibbonMenu ribbonMenu)
		{
			if (ribbonMenu != null)
			{
				ribbonMenu.RibbonMenuItemsState.SetTutorialItem(_definition.RoomItemDefinition.Instance);
			}
		}

		private void ClearRoomItemMenuFilter(RibbonMenu ribbonMenu)
		{
			if (ribbonMenu != null)
			{
				ribbonMenu.RibbonMenuItemsState.SetTutorialItem(null);
			}
		}

		private void OpenVideoMenu()
		{
			VideoTutorialMenu videoTutorialMenu = Level.HUD.FindMenu<VideoTutorialMenu>();
			if (_definition.VideoReference != null)
			{
				if (videoTutorialMenu == null)
				{
					videoTutorialMenu = Level.HUD.CreateMenu<VideoTutorialMenu>(recycle: true);
				}
				if (videoTutorialMenu.Clip != _definition.VideoReference && !videoTutorialMenu.IsPlaying)
				{
					videoTutorialMenu.Setup(_definition.VideoReference.VideoClip, loop: true);
				}
				videoTutorialMenu.OpenMenu();
			}
		}

		private void ResetVideo()
		{
			VideoTutorialMenu videoTutorialMenu = Level.HUD.FindMenu<VideoTutorialMenu>();
			if (videoTutorialMenu != null)
			{
				videoTutorialMenu.CloseMenu();
			}
		}
	}
}
