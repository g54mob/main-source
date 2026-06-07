using Assets.Nimbatus.GUI.MainScene.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Characters.Player;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World
{
	public class WorldController : SerializedMonoBehaviour
	{
		public ArrangeStartPosition PositionArranger;

		public static int Seed;

		public static int ClimateZoneSeed;

		public static NimbatusTerrainSetting TerrainSettings;

		public static bool HasExpandingPlanetCore;

		public static float PlanetCoreRadius;

		public static float PlanetCoreTemperature;

		public static PlayPlanetMusic PlanetMusic;

		public bool GenerateTerrain = true;

		[HideInInspector]
		public NimbatusTerrain ForeGroundTerrain;

		[HideInInspector]
		public NimbatusTerrain BackGroundTerrain;

		private float _lastTime;

		private Color[] _colorArray;

		public Transform TerrainParent;

		private Color _rareColor;

		private Color _commonColor;

		private bool _sensorLevelHighenough;

		protected void Awake()
		{
			RuntimeGlobals.WorldController = this;
			HasExpandingPlanetCore = false;
			PlanetCoreRadius = 0f;
			PlanetCoreTemperature = 0f;
		}

		public void Start()
		{
			Load();
			_lastTime = Time.realtimeSinceStartup;
			_colorArray = new Color[48400];
			_commonColor = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(ETerrainMaterial.CommonOre).ParticleColor;
			_rareColor = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(ETerrainMaterial.RareOre).ParticleColor;
			_sensorLevelHighenough = (SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance != null && SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.Sensors) >= 2) || !ReceivableHelper.UpgradeAllowed(EMothershipUpgradeType.Sensors);
		}

		public void Update()
		{
			if (RuntimeGlobals.IsGameOver)
			{
				Time.timeScale = 0.1f;
			}
			else if (RuntimeGlobals.IsGamePaused)
			{
				Time.timeScale = 0f;
			}
			else if (RuntimeGlobals.FreezeGame)
			{
				float maxDelta = Time.realtimeSinceStartup - _lastTime;
				_lastTime = Time.realtimeSinceStartup;
				Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0f, maxDelta);
			}
			else
			{
				Time.timeScale = RuntimeGlobals.TimeScale;
			}
			if (RuntimeGlobals.IsGamePaused)
			{
				AudioController.SetCategoryVolume("Sound", 0f);
			}
			else
			{
				AudioController.SetCategoryVolume("Sound", RuntimeGlobals.Settings.SoundEffectVolume);
			}
			if (!RuntimeGlobals.IsGameLoading)
			{
				SerializableMonobehaviour<MissionManager, MissionData>.Instance.UpdateTimer();
			}
		}

		private NimbatusTerrain CreateTerrain(bool background)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.position = Vector3.zero;
			NimbatusTerrain nimbatusTerrain = gameObject.AddComponent<NimbatusTerrain>();
			gameObject.AddComponent<TerrainTaskManager>();
			nimbatusTerrain.IsBackgroundTerrain = background;
			nimbatusTerrain.ChunksPerAxis = 55;
			gameObject.layer = base.gameObject.layer;
			nimbatusTerrain.TerrainChunkSize = 20;
			if (background)
			{
				gameObject.transform.position = new Vector3(0f, 0f, 10f);
				gameObject.name = "BackgroundTerrain";
			}
			else
			{
				gameObject.name = "ForeGroundTerrain";
			}
			return nimbatusTerrain;
		}

		public Color[] GenerateActivePlanetImage()
		{
			for (int i = 0; i < 220; i++)
			{
				for (int j = 0; j < 220; j++)
				{
					Vector2 vector = new Vector2(i * 5 - 540, j * 5 - 540);
					NimbatusTerrainData? data = ForeGroundTerrain.GetData(vector);
					if (data.HasValue && data.Value.Volume >= 0.5f)
					{
						if (_sensorLevelHighenough)
						{
							NimbatusClimateZoneLayer layer = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.GetLayer(data.Value.MaterialType, false);
							if (layer.TerrainMaterial == ETerrainMaterial.CommonOre)
							{
								_colorArray[j * 220 + i] = _commonColor;
							}
							else if (layer.TerrainMaterial == ETerrainMaterial.RareOre)
							{
								_colorArray[j * 220 + i] = _rareColor;
							}
							else
							{
								_colorArray[j * 220 + i] = new Color(1f, 0.55f, 0f);
							}
						}
						else
						{
							_colorArray[j * 220 + i] = new Color(1f, 0.55f, 0f);
						}
					}
					else
					{
						_colorArray[j * 220 + i] = new Color(0f, 0f, 0f, 0f);
					}
				}
			}
			return _colorArray;
		}

		public void Load()
		{
			if (GenerateTerrain)
			{
				ForeGroundTerrain = CreateTerrain(false);
				BackGroundTerrain = CreateTerrain(true);
				ForeGroundTerrain.Init();
				BackGroundTerrain.Init();
			}
		}

		public void OnApplicationQuit()
		{
			TerrainModificationHelper.StopThread = true;
		}
	}
}
