using System;
using TH20.EventAwardRemixBadge;
using TH20.EventAwardStar;
using TH20.EventUnlockHospital;

namespace TH20
{
	public class MetagameMapCareerUI : MetagameMapUI, TH20.EventUnlockHospital.Interface, IGameEventCallback, TH20.EventAwardStar.Interface, TH20.EventAwardRemixBadge.Interface
	{
		private AdvisorMenu _advisorMenu;

		private MetagameButtonsMenu _metagameButtonsMenu;

		private FoundationStatusMenu _foundationStatusMenu;

		private CollaborativeSidebarMenu _collaborativeSidebarMenu;

		private bool _registerMetagameButtonEvents;

		public MetagameButtonsMenu ButtonsMenu => _metagameButtonsMenu;

		public AdvisorMenu AdvisorMenu => _advisorMenu;

		public override void Setup(App app, Metagame metagame, MetagameMap metagameMap, InputManager inputManager, HUD hud, TopDownCameraLogic cameraLogic)
		{
			base.Setup(app, metagame, metagameMap, inputManager, hud, cameraLogic);
			_foundationStatusMenu = _hud.CreateMenu<FoundationStatusMenu>();
			_foundationStatusMenu.Setup(_metagame, _hud);
			_metagameButtonsMenu = _hud.CreateMenu<MetagameButtonsMenu>();
			_metagameButtonsMenu.Setup(_app);
			_collaborativeSidebarMenu = _hud.CreateMenu<CollaborativeSidebarMenu>();
			_collaborativeSidebarMenu.Setup(_metagameMap, _metagame);
			_advisorMenu = _hud.CreateMenu<AdvisorMenu>();
			_advisorMenu.Setup(metagameMap);
			MetagameButtonsMenu metagameButtonsMenu = _metagameButtonsMenu;
			metagameButtonsMenu.OnMenuOpened = (System.Action)Delegate.Combine(metagameButtonsMenu.OnMenuOpened, new System.Action(OnSubMenuOpened));
			MetagameButtonsMenu metagameButtonsMenu2 = _metagameButtonsMenu;
			metagameButtonsMenu2.OnMenuClosed = (System.Action)Delegate.Combine(metagameButtonsMenu2.OnMenuClosed, new System.Action(OnSubMenuClosed));
			_registerMetagameButtonEvents = true;
			_metagame.OnHospitalUnlocked.Add(this);
			_metagame.OnStarAwarded.Add(this);
			_metagame.OnRemixBadgeAwarded.Add(this);
		}

		public override void RefreshMapPins()
		{
			base.RefreshMapPins();
			_mapPins = _app.MetagameMapScene.MapPins;
			_mapVisuals = _app.MetagameMapScene.MapVisuals;
			MapPin[] mapPins = _mapPins;
			foreach (MapPin mapPin in mapPins)
			{
				if (mapPin is MapPinHospital)
				{
					((MapPinHospital)mapPin).Initialise(_metagame, _metagameMap, _app.SaveSystem);
				}
				else if (mapPin is MapPinOnline)
				{
					((MapPinOnline)mapPin).Initialise(_metagameMap);
				}
				else if (mapPin is MapPinWaypoint)
				{
					((MapPinWaypoint)mapPin).Initialise(_metagame, _metagameMap, _app.SaveSystem);
				}
				else if (mapPin is MapPinUnlockMe)
				{
					((MapPinUnlockMe)mapPin).Initialise(_metagame, _metagameMap, _app.SaveSystem);
				}
			}
			MapVisualsActivation[] mapVisuals = _mapVisuals;
			for (int i = 0; i < mapVisuals.Length; i++)
			{
				mapVisuals[i].Initialise(_metagame, _metagameMap, _app.SaveSystem);
			}
			SetCameraBoundsToMapPinBounds();
		}

		public override void Uninitialise()
		{
			if (_hud != null)
			{
				_hud.DestroyMenu<AdvisorMenu>();
				_hud.DestroyMenu<MetagameButtonsMenu>();
				_hud.DestroyMenu<FoundationStatusMenu>();
				_hud.DestroyMenu<CollaborativeSidebarMenu>();
			}
			if (_registerMetagameButtonEvents)
			{
				MetagameButtonsMenu metagameButtonsMenu = _metagameButtonsMenu;
				metagameButtonsMenu.OnMenuOpened = (System.Action)Delegate.Remove(metagameButtonsMenu.OnMenuOpened, new System.Action(OnSubMenuOpened));
				MetagameButtonsMenu metagameButtonsMenu2 = _metagameButtonsMenu;
				metagameButtonsMenu2.OnMenuClosed = (System.Action)Delegate.Remove(metagameButtonsMenu2.OnMenuClosed, new System.Action(OnSubMenuClosed));
				_registerMetagameButtonEvents = false;
			}
			if (_metagame != null)
			{
				_metagame.OnHospitalUnlocked.Remove(this);
				_metagame.OnStarAwarded.Remove(this);
				_metagame.OnRemixBadgeAwarded.Remove(this);
			}
			base.Uninitialise();
		}

		protected override void Update()
		{
			base.Update();
			if (_hud != null && !_hud.IsFullscreenMenuOpen() && _hud.FindMenu<OptionsMenu>(includeInactive: false) != null && !_inputManager.IsMouseOverGui && _inputManager.GetMouseDown(MouseButton.Left) && _metagameButtonsMenu != null)
			{
				_metagameButtonsMenu.OnOptionsPressed();
			}
		}

		protected override void ShowUI(bool show)
		{
			base.ShowUI(show);
			if (show)
			{
				if (_foundationStatusMenu != null)
				{
					_foundationStatusMenu.gameObject.SetActive(value: true);
					_foundationStatusMenu.OpenMenu();
				}
				if (_metagameButtonsMenu != null)
				{
					_metagameButtonsMenu.gameObject.SetActive(value: true);
					_metagameButtonsMenu.OpenMenu();
				}
				if (_collaborativeSidebarMenu != null && _app.UserProfile.IsCollaborativeProjectsUnlocked && PlatformFeatureSupport.IsFeatureSupported(_collaborativeSidebarMenu.FeatureRequired))
				{
					_collaborativeSidebarMenu.gameObject.SetActive(value: true);
					_collaborativeSidebarMenu.OpenMenu();
				}
			}
			else
			{
				if (_foundationStatusMenu != null)
				{
					_foundationStatusMenu.CloseMenu();
				}
				if (_metagameButtonsMenu != null)
				{
					_metagameButtonsMenu.CloseAllMenus();
					_metagameButtonsMenu.CloseMenu();
				}
				if (_collaborativeSidebarMenu != null)
				{
					_collaborativeSidebarMenu.CloseMenu();
				}
			}
		}

		public override void Close()
		{
			base.Close();
			if (_metagameButtonsMenu != null)
			{
				_metagameButtonsMenu.CloseAllMenus();
			}
			if (_advisorMenu != null)
			{
				_advisorMenu.HideAdvisorMessage();
			}
		}

		public override void ForceHide()
		{
			base.ForceHide();
			_foundationStatusMenu.gameObject.SetActive(value: false);
			_metagameButtonsMenu.gameObject.SetActive(value: false);
			_collaborativeSidebarMenu.gameObject.SetActive(value: false);
		}

		private void OnSubMenuClosed()
		{
			SetPinsEnabled(enablePins: true);
		}

		private void OnSubMenuOpened()
		{
			SetPinsEnabled(enablePins: false);
		}

		public void OnHospitalUnlockedEvent(LevelConfig level)
		{
			MapPin[] mapPins = _mapPins;
			for (int i = 0; i < mapPins.Length; i++)
			{
				mapPins[i].Refresh();
			}
			MapVisualsActivation[] mapVisuals = _mapVisuals;
			for (int i = 0; i < mapVisuals.Length; i++)
			{
				mapVisuals[i].Refresh();
			}
			SetCameraBoundsToMapPinBounds();
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			MapPin[] mapPins = _mapPins;
			for (int i = 0; i < mapPins.Length; i++)
			{
				mapPins[i].Refresh();
			}
			MapVisualsActivation[] mapVisuals = _mapVisuals;
			for (int i = 0; i < mapVisuals.Length; i++)
			{
				mapVisuals[i].Refresh();
			}
		}

		public void OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug)
		{
			MapPin[] mapPins = _mapPins;
			for (int i = 0; i < mapPins.Length; i++)
			{
				mapPins[i].Refresh();
			}
			MapVisualsActivation[] mapVisuals = _mapVisuals;
			for (int i = 0; i < mapVisuals.Length; i++)
			{
				mapVisuals[i].Refresh();
			}
		}
	}
}
