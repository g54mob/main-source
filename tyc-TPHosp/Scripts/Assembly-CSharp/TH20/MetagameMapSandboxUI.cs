using UnityEngine;

namespace TH20
{
	public class MetagameMapSandboxUI : MetagameMapUI
	{
		[SerializeField]
		private GameObject _mapPinPrefab;

		private MetagameSandboxButtons _metagameSandboxButtons;

		public override void Setup(App app, Metagame metagame, MetagameMap metagameMap, InputManager inputManager, HUD hud, TopDownCameraLogic cameraLogic)
		{
			base.Setup(app, metagame, metagameMap, inputManager, hud, cameraLogic);
			_metagameSandboxButtons = _hud.CreateMenu<MetagameSandboxButtons>();
			_metagameSandboxButtons.Setup(_app);
			MapPin[] mapPins = _app.MetagameMapScene.MapPins;
			if (mapPins != null)
			{
				MapPin[] array = mapPins;
				for (int i = 0; i < array.Length; i++)
				{
					GameObjectUtils.SetActive(array[i].gameObject, isActive: false);
				}
			}
			MapVisualsActivation[] mapVisuals = _app.MetagameMapScene.MapVisuals;
			if (mapVisuals != null)
			{
				MapVisualsActivation[] array2 = mapVisuals;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].SetLevelPlayable(levelPlayable: true);
				}
			}
			SetPinsEnabled(enablePins: true);
		}

		public override void RefreshMapPins()
		{
			base.RefreshMapPins();
			DestroyMapPins();
		}

		private MapPinSandbox CreateNewPin(SandboxSettings settings, int index)
		{
			MapPinSandbox component = Object.Instantiate(_mapPinPrefab).GetComponent<MapPinSandbox>();
			component.Initialise(settings, _app.SandboxSaveManager, _metagameMap);
			_mapPins[index] = component;
			return component;
		}

		public override void Uninitialise()
		{
			base.Uninitialise();
			DestroyMapPins();
		}

		private void DestroyMapPins()
		{
			if (_mapPins != null)
			{
				MapPin[] mapPins = _mapPins;
				foreach (MapPin obj in mapPins)
				{
					obj.PrepareForDestroy();
					Object.Destroy(obj.gameObject);
				}
				_mapPins = null;
			}
		}

		protected override void Update()
		{
			base.Update();
			if (_hud != null && !_hud.IsFullscreenMenuOpen() && _hud.FindMenu<OptionsMenu>(includeInactive: false) != null && !_inputManager.IsMouseOverGui && _inputManager.GetMouseDown(MouseButton.Left) && _metagameSandboxButtons != null)
			{
				_metagameSandboxButtons.OnOptionsPressed();
			}
		}

		protected override void ShowUI(bool show)
		{
			base.ShowUI(show);
			if (show)
			{
				_metagameSandboxButtons.gameObject.SetActive(value: true);
				_metagameSandboxButtons.OpenMenu();
				SandboxMenu sandboxMenu = _hud.CreateMenu<SandboxMenu>(recycle: true);
				sandboxMenu.Setup(everConnectedToPrime: _app.UserProfile?.PrimeGamingRefreshToken != null && !_app.UserProfile.PrimeGamingRefreshToken.IsNullOrEmpty(), config: _app.SandboxSettingsConfig, metagameMap: _app.MetagameMap, saveManager: _app.SandboxSaveManager);
				sandboxMenu.OpenMenu();
			}
			else
			{
				_metagameSandboxButtons.CloseMenu();
			}
		}

		public override void ForceHide()
		{
			base.ForceHide();
			_metagameSandboxButtons.gameObject.SetActive(value: false);
		}

		public override void AddNewSandboxPin(SandboxSettings settings)
		{
			if (_mapPins != null)
			{
				MapPin[] mapPins = _mapPins;
				_mapPins = new MapPin[mapPins.Length + 1];
				mapPins.CopyTo(_mapPins, 1);
			}
			else
			{
				_mapPins = new MapPin[1];
			}
			MapPinSandbox mapPinSandbox = CreateNewPin(settings, 0);
			SetCameraBoundsToMapPinBounds();
			_cameraLogic.TrackObject(mapPinSandbox.transform);
		}

		protected override void SetCameraFocalPointToCurrentLevel()
		{
			MapPin mapPin = null;
			if (_mapPins != null && _mapPins.Length != 0)
			{
				SandboxSettings currentSettings = SandboxSaveManager.CurrentSettings;
				if (currentSettings != null)
				{
					MapPin[] mapPins = _mapPins;
					for (int i = 0; i < mapPins.Length; i++)
					{
						MapPinSandbox mapPinSandbox = mapPins[i] as MapPinSandbox;
						if (mapPinSandbox != null && mapPinSandbox.Settings == currentSettings)
						{
							mapPin = mapPinSandbox;
							break;
						}
					}
				}
				else
				{
					mapPin = _mapPins.RandomItem();
				}
			}
			if (mapPin != null)
			{
				_cameraLogic.TrackObject(mapPin.transform);
			}
		}
	}
}
