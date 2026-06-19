using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TutorialModeBuildRoom : TutorialMode
	{
		private enum States
		{
			None = 0,
			NeedToSelectRoomsMenu = 1,
			NeedToSelectRoom = 2,
			NeedToBuildRoomAndAccept = 3
		}

		private readonly TutorialBuildModeDefinition _definition;

		private HubMenu _hubMenu;

		private Pingable _roomsPingable;

		private ButtonAnimator _roomsButtonAnimator;

		private ButtonAnimator _acceptBuildButtonAnimator;

		private Pingable _roomSubMenuPingable;

		private Pingable _acceptBuildButtonPingable;

		private States State;

		public TutorialModeBuildRoom(TutorialBuildModeDefinition definition)
		{
			_definition = definition;
		}

		public override void Enter()
		{
			_hubMenu = Level.HUD.FindMenu<HubMenu>();
			_roomsButtonAnimator = TutorialUtils.GetHubRoomsButton(Level);
			RectTransform transform = (RectTransform)_roomsButtonAnimator.transform;
			Image image = _roomsButtonAnimator.Button.image;
			_roomsPingable = new Pingable(Level.TutorialManager.PingManagerProxy, transform, image);
		}

		public override void Destroy()
		{
			RibbonMenu ribbonMenu = Level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu != null)
			{
				ribbonMenu.ShowTutorialObject(show: false);
			}
			ShowCirclesAndArrowsOnRoomsButton(show: false);
			if (_roomsPingable != null)
			{
				_roomsPingable.Destroy();
				_roomsPingable = null;
			}
			if (_roomSubMenuPingable != null)
			{
				_roomSubMenuPingable.Destroy();
				_roomSubMenuPingable = null;
			}
			ResetAcceptBuildCirclesAndArrows(ribbonMenu);
			ResetAcceptBuildPingable();
			ResetVideo();
			base.Destroy();
		}

		public override void Update()
		{
			RibbonMenu ribbonMenu = Level.HUD.FindMenu<RibbonMenu>();
			RibbonRoomRow ribbonRoomRow = TutorialUtils.GetRibbonRoomRow(Level, _definition.RoomDefinition.Instance);
			bool flag = Level.BuildingLogic.CurrentState == BuildingLogic.State.NewRoom;
			Level.CursorManager.TryGetActiveMode<CursorRoomBuild>(out var activeMode);
			_acceptBuildButtonAnimator = null;
			if (TutorialUtils.GetRibbonBuildMenuSettings(Level, out var settings))
			{
				_acceptBuildButtonAnimator = settings.AcceptBuildButtonAnimator;
			}
			if (ribbonMenu == null)
			{
				State = States.NeedToSelectRoomsMenu;
			}
			else if (activeMode != null || flag)
			{
				State = States.NeedToBuildRoomAndAccept;
			}
			else if (ribbonRoomRow != null)
			{
				State = States.NeedToSelectRoom;
			}
			else
			{
				State = States.None;
			}
			switch (State)
			{
			case States.NeedToSelectRoomsMenu:
				ResetVideo();
				ResetRoomRowPingable(ribbonMenu);
				StartRoomsButtonPingable();
				ShowCirclesAndArrowsOnRoomsButton(show: true);
				ResetAcceptBuildPingable();
				ResetAcceptBuildCirclesAndArrows(ribbonMenu);
				break;
			case States.NeedToSelectRoom:
				ResetVideo();
				StartRoomRowPingable(ribbonMenu);
				ResetRoomsPingable();
				ShowCirclesAndArrowsOnRoomsButton(show: false);
				SetRoomMenuFilter(ribbonMenu);
				ResetAcceptBuildPingable();
				ResetAcceptBuildCirclesAndArrows(ribbonMenu);
				break;
			case States.NeedToBuildRoomAndAccept:
				OpenVideoMenu();
				ResetRoomRowPingable(ribbonMenu);
				ResetRoomsPingable();
				ShowCirclesAndArrowsOnRoomsButton(show: false);
				if (_acceptBuildButtonAnimator != null && _acceptBuildButtonAnimator.CurrentState == ButtonAnimator.State.Selectable)
				{
					StartAcceptBuildPingable();
					StartAcceptBuildCirclesAndArrows(ribbonMenu);
				}
				else
				{
					ResetAcceptBuildPingable();
					ResetAcceptBuildCirclesAndArrows(ribbonMenu);
				}
				break;
			default:
				ResetVideo();
				ResetRoomRowPingable(ribbonMenu);
				ResetRoomsPingable();
				ShowCirclesAndArrowsOnRoomsButton(show: false);
				ResetAcceptBuildPingable();
				ResetAcceptBuildCirclesAndArrows(ribbonMenu);
				break;
			}
		}

		private void ShowCirclesAndArrowsOnRoomsButton(bool show)
		{
			if (_hubMenu != null && _hubMenu.HubMenuButtons != null)
			{
				_hubMenu.HubMenuButtons.ShowTutorialHighlight(show, itemsCircle: false, hireCircle: false);
			}
		}

		private void StartRoomsButtonPingable()
		{
			_roomsPingable.RectTransform.SetAsLastSibling();
			_roomsPingable.Ping(_definition.RoomsPing);
		}

		private void ResetRoomsPingable()
		{
			_roomsPingable.StopPing();
		}

		private void StartRoomRowPingable(RibbonMenu ribbonMenu)
		{
			RibbonRoomRow ribbonRoomRow = ((ribbonMenu != null) ? TutorialUtils.GetRibbonRoomRow(Level, _definition.RoomDefinition.Instance) : null);
			if (!(ribbonRoomRow == null))
			{
				RectTransform rectTransform = (RectTransform)ribbonRoomRow.Button.transform;
				ribbonMenu.ShowTutorialObject(show: true, rectTransform);
				if (_roomSubMenuPingable == null)
				{
					_roomSubMenuPingable = new Pingable(Level.TutorialManager.PingManagerProxy, rectTransform, ribbonRoomRow.BackgroundImage);
				}
				_roomSubMenuPingable.Ping(_definition.RoomSubMenuPing);
			}
		}

		private void ResetRoomRowPingable(RibbonMenu ribbonMenu)
		{
			if (_roomSubMenuPingable != null)
			{
				_roomSubMenuPingable.Destroy();
				_roomSubMenuPingable = null;
			}
			if (ribbonMenu != null)
			{
				ribbonMenu.ShowTutorialObject(show: false);
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

		private void SetRoomMenuFilter(RibbonMenu ribbonMenu)
		{
			if (ribbonMenu != null)
			{
				ribbonMenu.RibbonMenuRoomsState.ShowTutorialItemOnly(_definition.RoomDefinition.Instance);
			}
		}

		private void StartAcceptBuildPingable()
		{
			if (!(_acceptBuildButtonAnimator == null))
			{
				if (_acceptBuildButtonPingable == null)
				{
					RectTransform transform = (RectTransform)_acceptBuildButtonAnimator.Button.transform;
					_acceptBuildButtonPingable = new Pingable(Level.TutorialManager.PingManagerProxy, transform, null);
				}
				_acceptBuildButtonPingable.Ping(_definition.RoomBuildAcceptPing);
			}
		}

		private void ResetAcceptBuildPingable()
		{
			if (_acceptBuildButtonPingable != null)
			{
				_acceptBuildButtonPingable.Destroy();
				_acceptBuildButtonPingable = null;
			}
		}

		private void StartAcceptBuildCirclesAndArrows(RibbonMenu ribbonMenu)
		{
			if (!(ribbonMenu == null))
			{
				ribbonMenu.RibbonMenuBuildState.ShowTutorialHighlight(show: true);
			}
		}

		private void ResetAcceptBuildCirclesAndArrows(RibbonMenu ribbonMenu)
		{
			if (!(ribbonMenu == null))
			{
				ribbonMenu.RibbonMenuBuildState.ShowTutorialHighlight(show: false);
			}
		}
	}
}
