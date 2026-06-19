#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameMapUI : MonoBehaviour
	{
		[SerializeField]
		private float _cameraExtentsAroundPins = 100f;

		[SerializeField]
		private Camera _mapPinsCamera;

		protected App _app;

		protected Metagame _metagame;

		protected MetagameMap _metagameMap;

		protected InputManager _inputManager;

		protected HUD _hud;

		protected TopDownCameraLogic _cameraLogic;

		private CinematicBarsMenu _cinematicBarsMenu;

		protected MapVisualsActivation[] _mapVisuals;

		protected MapPin[] _mapPins;

		private MapPin _lastUpdatePin;

		private MapPin _selectedPin;

		private bool _pinsEnabled;

		protected bool _dirty;

		protected bool _showUI;

		private bool _DEBUG_hideMapPins;

		public CinematicBarsMenu CinematicBarsMenu => _cinematicBarsMenu;

		public virtual void Setup(App app, Metagame metagame, MetagameMap metagameMap, InputManager inputManager, HUD hud, TopDownCameraLogic cameraLogic)
		{
			_app = app;
			_metagame = metagame;
			_metagameMap = metagameMap;
			_inputManager = inputManager;
			_hud = hud;
			_cameraLogic = cameraLogic;
			_cinematicBarsMenu = _hud.CreateMenu<CinematicBarsMenu>();
			_mapPinsCamera.transform.SetParent(_cameraLogic.CameraComponent.transform);
			_mapPinsCamera.transform.localPosition = Vector3.zero;
			_mapPinsCamera.transform.localRotation = Quaternion.identity;
			OSManager.OnDLCRefreshed = (Action)Delegate.Combine(OSManager.OnDLCRefreshed, new Action(OnDLCRefreshed));
			RefreshMapPins();
			ConsoleCommandsDatabase.RegisterCommand("ToggleMapPins", "Toggle map pins on/off", "ToggleMapPins", Debug_ToggleMapPins);
		}

		public virtual void Uninitialise()
		{
			OSManager.OnDLCRefreshed = (Action)Delegate.Remove(OSManager.OnDLCRefreshed, new Action(OnDLCRefreshed));
			if (_mapPins != null)
			{
				MapPin[] mapPins = _mapPins;
				for (int i = 0; i < mapPins.Length; i++)
				{
					mapPins[i].PrepareForDestroy();
				}
			}
			if (_hud != null)
			{
				_hud.DestroyMenu<CinematicBarsMenu>();
				_hud.Destroy();
			}
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleMapPins");
		}

		public virtual void Open()
		{
			_cameraLogic.Reset();
			SetCameraBoundsToMapPinBounds();
			SetCameraFocalPointToCurrentLevel();
		}

		public virtual void Close()
		{
		}

		public virtual void ForceHide()
		{
		}

		protected virtual void Update()
		{
			if (_hud == null)
			{
				return;
			}
			if (_dirty)
			{
				ShowUI(_showUI);
				_dirty = false;
			}
			_hud.Update();
			if (_hud.IsFullscreenMenuOpen() || !(_hud.FindMenu<OptionsMenu>(includeInactive: false) == null) || _cameraLogic == null)
			{
				return;
			}
			_cameraLogic.Update();
			UpdatePins();
			if (_mapPinsCamera != null)
			{
				_mapPinsCamera.transparencySortMode = TransparencySortMode.CustomAxis;
				if (_cameraLogic != null && _cameraLogic.CameraComponent != null)
				{
					_mapPinsCamera.transparencySortAxis = _cameraLogic.CameraComponent.transform.forward;
				}
			}
		}

		private void OnDLCRefreshed()
		{
			if (_mapPins != null)
			{
				for (int i = 0; i < _mapPins.Length; i++)
				{
					_mapPins[i].Refresh();
				}
			}
			if (_mapVisuals != null)
			{
				for (int j = 0; j < _mapVisuals.Length; j++)
				{
					_mapVisuals[j].Refresh();
				}
			}
		}

		protected virtual void ShowUI(bool show)
		{
			ShowPins(show);
		}

		private void ShowPins(bool show, bool selectActivePin = true)
		{
			if (show)
			{
				SetPinsEnabled(enablePins: true);
				if (selectActivePin && _selectedPin != null)
				{
					_selectedPin.OnSelected();
				}
			}
			else
			{
				SetPinsEnabled(enablePins: false);
			}
		}

		public void ActivateUI()
		{
			Logging.Info(LogChannels.GUI, "ActivateUI");
			_showUI = true;
			_dirty = true;
		}

		public void DeactivateUI()
		{
			Logging.Info(LogChannels.GUI, "DeactivateUI");
			_showUI = false;
			_dirty = true;
		}

		public void ClearSelectedPin()
		{
			_selectedPin = null;
		}

		public virtual void RefreshMapPins()
		{
		}

		public void SetPinsEnabled(bool enablePins)
		{
			_pinsEnabled = enablePins;
			if (_mapPins != null)
			{
				MapPin[] mapPins = _mapPins;
				foreach (MapPin obj in mapPins)
				{
					obj.Refresh(refreshVisuals: false);
					GameObjectUtils.SetActive(obj.gameObject, _pinsEnabled);
				}
			}
		}

		private void UpdatePins()
		{
			MapPin mapPin = (_pinsEnabled ? FindClosestPin() : null);
			if (_lastUpdatePin != mapPin)
			{
				if (_lastUpdatePin != null)
				{
					_lastUpdatePin.OnCursorOver(over: false);
				}
				if (mapPin != null)
				{
					mapPin.OnCursorOver(over: true);
				}
				_lastUpdatePin = mapPin;
			}
			if (mapPin != null)
			{
				if (_inputManager.GetMouseDown(MouseButton.Left))
				{
					_selectedPin = mapPin;
					mapPin.OnCursorOver(over: false);
					_cameraLogic.TrackObject(mapPin.transform);
					mapPin.OnSelected();
				}
			}
			else if (_selectedPin != null && !_inputManager.IsMouseOverGui && (_inputManager.GetMouseDown(MouseButton.Left) || _inputManager.GetMouseDown(MouseButton.Right)))
			{
				_selectedPin.OnUnselected();
				_selectedPin = null;
			}
		}

		private MapPin FindClosestPin()
		{
			MapPin result = null;
			if (_mapPins != null && !_inputManager.IsMouseOverGui)
			{
				float num = float.MaxValue;
				Ray ray = _cameraLogic.CameraComponent.ScreenPointToRay(Input.mousePosition);
				MapPin[] mapPins = _mapPins;
				foreach (MapPin mapPin in mapPins)
				{
					if (mapPin != null && mapPin.RayCast(ray, 4000f, out var distance) && distance < num)
					{
						result = mapPin;
						num = distance;
					}
				}
			}
			return result;
		}

		public MapPinHospital GetPinForLevelUniqueId(string uniqueId)
		{
			if (_mapPins != null)
			{
				MapPin[] mapPins = _mapPins;
				for (int i = 0; i < mapPins.Length; i++)
				{
					MapPinHospital mapPinHospital = mapPins[i] as MapPinHospital;
					if (mapPinHospital != null && mapPinHospital.LevelConfig.UniqueId == uniqueId)
					{
						return mapPinHospital;
					}
				}
			}
			return null;
		}

		public MapPinHospital GetPinForLevel(LevelConfig level)
		{
			MapPin[] mapPins = _mapPins;
			for (int i = 0; i < mapPins.Length; i++)
			{
				MapPinHospital mapPinHospital = mapPins[i] as MapPinHospital;
				if (mapPinHospital != null && mapPinHospital.LevelConfig == level)
				{
					return mapPinHospital;
				}
			}
			return null;
		}

		protected void SetCameraBoundsToMapPinBounds()
		{
			if (_mapPins != null)
			{
				MapPin[] array = Array.FindAll(_mapPins, (MapPin x) => x.IsPinUnlocked());
				List<Vector2> list = new List<Vector2>();
				for (int num = 0; num < array.Length; num++)
				{
					Vector3 position = array[num].transform.position;
					list.Add(position.Xz());
				}
				_cameraLogic.SetBounds(list, _cameraExtentsAroundPins);
			}
		}

		protected virtual void SetCameraFocalPointToCurrentLevel()
		{
			string uniqueId = ((_metagame.CurrentLevel != null) ? _metagame.CurrentLevel.Config.UniqueId : ((_metagame.LastPlayedLevelID == null) ? _metagame.LevelList.Levels[0].Instance.UniqueId : _metagame.LastPlayedLevelID));
			MapPinHospital pinForLevelUniqueId = GetPinForLevelUniqueId(uniqueId);
			if (pinForLevelUniqueId != null)
			{
				_cameraLogic.SetFocalPoint(pinForLevelUniqueId.transform.position, snap: true);
				_selectedPin = pinForLevelUniqueId;
			}
		}

		private ConsoleCommandResult Debug_ToggleMapPins(string[] args)
		{
			_DEBUG_hideMapPins = !_DEBUG_hideMapPins;
			SetPinsEnabled(!_DEBUG_hideMapPins);
			return ConsoleCommandResult.Succeeded(_DEBUG_hideMapPins ? "Pins Hidden!" : "Pins Showing!");
		}

		public virtual void AddNewSandboxPin(SandboxSettings settings)
		{
		}
	}
}
