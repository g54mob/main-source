using System.Collections.Generic;
using System.Globalization;
using AssembleSystem;
using AssembleSystem.FSM.Parts;
using Loxodon.Framework.ViewModels;
using Player;
using Player.FSM;
using Player.Stats;
using Services.Enemy;
using Services.Save;
using StarterAssets;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Vehicles.Plane;
using WorldEnvironment.Islands;
using Zenject;

namespace Cheats
{
	public class CheatPanelViewModel : ViewModelBase
	{
		[Inject]
		private ISaveService _saveService;

		[Inject]
		private IPlayerStatsService _statsService;

		[Inject]
		private DiContainer _container;

		[Inject]
		private CheatSettings _settings;

		[Inject]
		private WorldGridManager _worldGridManager;

		[Inject]
		private IAirRaidService _airRaidService;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerFSM;

		private FirstPersonController _fpc;

		private PlayerStatsDrain _statsDrain;

		private string _posX = "0";

		private string _posY = "0";

		private string _posZ = "0";

		private string _planePosX = "0";

		private string _planePosY = "0";

		private string _planePosZ = "0";

		private float _drainMultiplier;

		private string _drainDisplay = "0.00";

		private string _alcoholDisplay = "Alcohol: -";

		private string _nicotineDisplay = "Nicotine: -";

		private int _lastAlcoholTenth = int.MinValue;

		private int _lastNicotineTenth = int.MinValue;

		private bool _flyModeEnabled;

		private bool _noclipEnabled;

		private float _flySpeed = 15f;

		private string _flySpeedDisplay = "15.0";

		private float _timeScale = 1f;

		private string _timeScaleDisplay = "1.00";

		private string _playerInfoDisplay = "";

		private int _selectedSpawnIndex;

		public string PositionX
		{
			get
			{
				return _posX;
			}
			set
			{
				Set(ref _posX, value, "PositionX");
			}
		}

		public string PositionY
		{
			get
			{
				return _posY;
			}
			set
			{
				Set(ref _posY, value, "PositionY");
			}
		}

		public string PositionZ
		{
			get
			{
				return _posZ;
			}
			set
			{
				Set(ref _posZ, value, "PositionZ");
			}
		}

		public string PlanePositionX
		{
			get
			{
				return _planePosX;
			}
			set
			{
				Set(ref _planePosX, value, "PlanePositionX");
			}
		}

		public string PlanePositionY
		{
			get
			{
				return _planePosY;
			}
			set
			{
				Set(ref _planePosY, value, "PlanePositionY");
			}
		}

		public string PlanePositionZ
		{
			get
			{
				return _planePosZ;
			}
			set
			{
				Set(ref _planePosZ, value, "PlanePositionZ");
			}
		}

		public float DrainMultiplier
		{
			get
			{
				return _drainMultiplier;
			}
			set
			{
				if (Set(ref _drainMultiplier, value, "DrainMultiplier"))
				{
					DrainDisplay = value.ToString("F2");
					if (_statsDrain != null)
					{
						_statsDrain.StatsDrainage = value;
					}
				}
			}
		}

		public string DrainDisplay
		{
			get
			{
				return _drainDisplay;
			}
			private set
			{
				Set(ref _drainDisplay, value, "DrainDisplay");
			}
		}

		public string AlcoholDisplay
		{
			get
			{
				return _alcoholDisplay;
			}
			private set
			{
				Set(ref _alcoholDisplay, value, "AlcoholDisplay");
			}
		}

		public string NicotineDisplay
		{
			get
			{
				return _nicotineDisplay;
			}
			private set
			{
				Set(ref _nicotineDisplay, value, "NicotineDisplay");
			}
		}

		public bool FlyModeEnabled
		{
			get
			{
				return _flyModeEnabled;
			}
			set
			{
				if (Set(ref _flyModeEnabled, value, "FlyModeEnabled"))
				{
					if (_fpc != null)
					{
						_fpc.FlyModeEnabled = value;
					}
					if (!value)
					{
						NoclipEnabled = false;
					}
				}
			}
		}

		public bool NoclipEnabled
		{
			get
			{
				return _noclipEnabled;
			}
			set
			{
				if (Set(ref _noclipEnabled, value, "NoclipEnabled") && _fpc != null)
				{
					_fpc.NoclipEnabled = value && _flyModeEnabled;
				}
			}
		}

		public float FlySpeed
		{
			get
			{
				return _flySpeed;
			}
			set
			{
				if (Set(ref _flySpeed, value, "FlySpeed"))
				{
					FlySpeedDisplay = value.ToString("F1");
					if (_fpc != null)
					{
						_fpc.FlySpeed = value;
					}
				}
			}
		}

		public string FlySpeedDisplay
		{
			get
			{
				return _flySpeedDisplay;
			}
			private set
			{
				Set(ref _flySpeedDisplay, value, "FlySpeedDisplay");
			}
		}

		public float TimeScale
		{
			get
			{
				return _timeScale;
			}
			set
			{
				if (Set(ref _timeScale, value, "TimeScale"))
				{
					TimeScaleDisplay = value.ToString("F2");
					Time.timeScale = value;
				}
			}
		}

		public string TimeScaleDisplay
		{
			get
			{
				return _timeScaleDisplay;
			}
			private set
			{
				Set(ref _timeScaleDisplay, value, "TimeScaleDisplay");
			}
		}

		public string PlayerInfoDisplay
		{
			get
			{
				return _playerInfoDisplay;
			}
			private set
			{
				Set(ref _playerInfoDisplay, value, "PlayerInfoDisplay");
			}
		}

		public int SelectedSpawnIndex
		{
			get
			{
				return _selectedSpawnIndex;
			}
			set
			{
				Set(ref _selectedSpawnIndex, value, "SelectedSpawnIndex");
			}
		}

		public void ResetTimeScaleCommand()
		{
			TimeScale = 1f;
		}

		public void Initialize()
		{
			_fpc = Object.FindFirstObjectByType<FirstPersonController>();
			_statsDrain = Object.FindFirstObjectByType<PlayerStatsDrain>();
			if (_fpc != null)
			{
				_flySpeed = _fpc.FlySpeed;
			}
			if (_statsDrain != null)
			{
				_drainMultiplier = _statsDrain.StatsDrainage;
			}
			_drainDisplay = _drainMultiplier.ToString("F2");
			_flySpeedDisplay = _flySpeed.ToString("F1");
			_statsService.AlcoholChanged += OnAlcoholChanged;
			_statsService.NicotineChanged += OnNicotineChanged;
			AlcoholDisplay = $"Alcohol: {_statsService.AlcoholStat:F1}";
			NicotineDisplay = $"Nicotine: {_statsService.NicotineStat:F1}";
		}

		private void OnAlcoholChanged(float v)
		{
			int num = Mathf.FloorToInt(v * 10f);
			if (num != _lastAlcoholTenth)
			{
				_lastAlcoholTenth = num;
				AlcoholDisplay = $"Alcohol: {v:F1}";
			}
		}

		private void OnNicotineChanged(float v)
		{
			int num = Mathf.FloorToInt(v * 10f);
			if (num != _lastNicotineTenth)
			{
				_lastNicotineTenth = num;
				NicotineDisplay = $"Nicotine: {v:F1}";
			}
		}

		public void SetPositionCommand()
		{
			if (!(_fpc == null) && float.TryParse(PositionX, NumberStyles.Float, CultureInfo.InvariantCulture, out var result) && float.TryParse(PositionY, NumberStyles.Float, CultureInfo.InvariantCulture, out var result2) && float.TryParse(PositionZ, NumberStyles.Float, CultureInfo.InvariantCulture, out var result3))
			{
				CharacterController component = _fpc.GetComponent<CharacterController>();
				component.enabled = false;
				_fpc.transform.position = new Vector3(result, result2, result3);
				component.enabled = true;
			}
		}

		public void SetPlanePositionCommand()
		{
			DriveablePlane driveablePlane = Object.FindFirstObjectByType<DriveablePlane>();
			float result;
			float result2;
			float result3;
			if (driveablePlane == null)
			{
				Debug.LogWarning("[Cheat] No DriveablePlane found in scene");
			}
			else if (float.TryParse(PlanePositionX, NumberStyles.Float, CultureInfo.InvariantCulture, out result) && float.TryParse(PlanePositionY, NumberStyles.Float, CultureInfo.InvariantCulture, out result2) && float.TryParse(PlanePositionZ, NumberStyles.Float, CultureInfo.InvariantCulture, out result3))
			{
				Vector3 position = new Vector3(result, result2, result3);
				Rigidbody componentInChildren = driveablePlane.GetComponentInChildren<Rigidbody>();
				((componentInChildren != null) ? componentInChildren.transform : driveablePlane.transform).position = position;
				if (componentInChildren != null)
				{
					componentInChildren.linearVelocity = Vector3.zero;
					componentInChildren.angularVelocity = Vector3.zero;
				}
			}
		}

		public void SaveCommand()
		{
			_saveService.SaveAll();
		}

		public async void LoadCommand()
		{
			await _saveService.LoadAllAsync();
		}

		public async void SpawnObjectCommand()
		{
			List<CheatSettings.SpawnableEntry> spawnableObjects = _settings.SpawnableObjects;
			if (spawnableObjects != null && spawnableObjects.Count != 0)
			{
				int index = Mathf.Clamp(_selectedSpawnIndex, 0, spawnableObjects.Count - 1);
				GameObject gameObject = await Addressables.LoadAssetAsync<GameObject>(spawnableObjects[index].AssetRef);
				if (!(gameObject == null))
				{
					Vector3 position = ((_fpc != null) ? (_fpc.transform.position + _fpc.transform.forward * 2f + Vector3.up) : Vector3.zero);
					_container.InstantiatePrefab(gameObject, position, Quaternion.identity, null);
					Addressables.Release(gameObject);
				}
			}
		}

		public void SetAddictionCommand()
		{
			if (_statsDrain != null)
			{
				_statsDrain.StatsDrainage = _drainMultiplier;
			}
		}

		public void SpawnEnemyPlaneCommand()
		{
			_airRaidService.InvokeAirRaid((_playerFSM as MonoBehaviour).transform.position);
		}

		public void AssembleEngineCommand()
		{
			ForceAssemble(_settings.EngineName);
		}

		public void AssemblePlaneCommand()
		{
			ForceAssemble(_settings.PlaneName);
		}

		public void DisassembleEngineCommand()
		{
			ForceDisassemble(_settings.EngineName);
		}

		public void DisassemblePlaneCommand()
		{
			ForceDisassemble(_settings.PlaneName);
		}

		private void ForceAssemble(string objectName)
		{
			AssembleObjectParent assembleObjectParent = FindAssembleParent(objectName);
			if (assembleObjectParent == null)
			{
				Debug.LogWarning("[Cheat] AssembleObjectParent '" + objectName + "' not found in scene");
				return;
			}
			foreach (GameObject part in assembleObjectParent.Parts)
			{
				if (!(part == null))
				{
					PartObjectStateMachine component = part.GetComponent<PartObjectStateMachine>();
					PartObject component2 = part.GetComponent<PartObject>();
					if (!(component == null) && !(component2 == null))
					{
						component.Placed = true;
						component2.SetProgress(1.5f);
					}
				}
			}
		}

		private void ForceDisassemble(string objectName)
		{
			AssembleObjectParent assembleObjectParent = FindAssembleParent(objectName);
			if (assembleObjectParent == null)
			{
				return;
			}
			foreach (GameObject part in assembleObjectParent.Parts)
			{
				if (part == null)
				{
					continue;
				}
				PartObjectStateMachine component = part.GetComponent<PartObjectStateMachine>();
				PartObject component2 = part.GetComponent<PartObject>();
				if (!(component == null) && !(component2 == null))
				{
					component.Placed = false;
					component.Tightened = false;
					component2.SetProgress(0f);
					component2.enabled = true;
					if (part.TryGetComponent<Rigidbody>(out var component3))
					{
						component3.isKinematic = false;
					}
				}
			}
		}

		private static AssembleObjectParent FindAssembleParent(string name)
		{
			AssembleObjectParent[] array = Object.FindObjectsByType<AssembleObjectParent>(FindObjectsSortMode.None);
			foreach (AssembleObjectParent assembleObjectParent in array)
			{
				if (assembleObjectParent.gameObject.name == name)
				{
					return assembleObjectParent;
				}
			}
			return null;
		}

		public void SetCameraRotation(bool enabled)
		{
			_fpc?.SetCanRotateCamera(enabled);
		}

		public void RefreshPlayerInfo()
		{
			if (!(_fpc == null) && _worldGridManager != null)
			{
				Vector3 position = _fpc.transform.position;
				Vector2Int gridIndexWithWorldPosition = _worldGridManager.GetGridIndexWithWorldPosition(position);
				WorldGridParams gridParams = _worldGridManager.GridParams;
				float num = gridParams.GridSize * gridParams.ChunkSize;
				Vector3 position2 = _worldGridManager.WorldCenter.position;
				float num2 = position.x - position2.x + num * 0.5f;
				float num3 = position.z - position2.z + num * 0.5f;
				float num4 = (num2 % num + num) % num;
				float num5 = (num3 % num + num) % num;
				int num6 = Mathf.FloorToInt(num4 / (float)gridParams.ChunkSize);
				int num7 = Mathf.FloorToInt(num5 / (float)gridParams.ChunkSize);
				PlayerInfoDisplay = $"Position:        ({position.x:F1}, {position.y:F1}, {position.z:F1})\n" + $"Chunk:           ({gridIndexWithWorldPosition.x}, {gridIndexWithWorldPosition.y})\n" + $"Cell in chunk: ({num6}, {num7})\n" + $"World chunk:  ({gridIndexWithWorldPosition.x}, {gridIndexWithWorldPosition.y})";
			}
		}

		public List<string> GetSpawnableLabels()
		{
			List<string> list = new List<string>();
			foreach (CheatSettings.SpawnableEntry spawnableObject in _settings.SpawnableObjects)
			{
				list.Add(string.IsNullOrEmpty(spawnableObject.Label) ? (spawnableObject.AssetRef?.AssetGUID ?? "?") : spawnableObject.Label);
			}
			return list;
		}
	}
}
