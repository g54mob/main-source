using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone
{
	public class NimbatusClimateZoneManager : SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>
	{
		public Material EmissiveMaterial;

		public Material DiffuseMaterial;

		public TextAsset PlanetNames;

		public Gradient SpaceSkyGradient;

		public EClimateZoneType TestDriveClimateZone;

		internal List<NimbatusTerrainClimateZone> ClimateZones;

		private NimbatusTerrainClimateZone _activeClimateZone;

		private NimbatusTerrainClimateZone _testDriveZone;

		private readonly NimbatusTerrainData[] _dataCache = new NimbatusTerrainData[1212202];

		private readonly NimbatusTerrainData[] _backgroundDataCache = new NimbatusTerrainData[1212201];

		private NimbatusTerrainData[] _dataCacheTestflight;

		private NimbatusTerrainData[] _backgroundDataCacheTestflight;

		private static bool _cancelCaching;

		private static bool _needsCacheRefresh;

		private static bool _isRebuildingCache;

		private static bool _hasCacheBuilt;

		private int _currentCacheSeed;

		private BackgroundWorker _cacheThread;

		private List<string> _planetNames;

		private bool _stopThread;

		internal NimbatusTerrainClimateZone ActiveClimateZone
		{
			get
			{
				if (RuntimeGlobals.RunningMode == ERunningMode.TestFlightPlanet)
				{
					return _testDriveZone;
				}
				return _activeClimateZone;
			}
			set
			{
				_activeClimateZone = value;
			}
		}

		internal override string Filename
		{
			get
			{
				return "ClimateZones.xml";
			}
		}

		public string GetPlanetNameFromFile(System.Random rnd)
		{
			return _planetNames.RandomItem(rnd);
		}

		protected override void Awake()
		{
			_stopThread = false;
			_cacheThread = new BackgroundWorker();
			_cacheThread.DoWork += FillupCache;
			_cacheThread.RunWorkerAsync();
			_isRebuildingCache = false;
			_needsCacheRefresh = false;
			_cancelCaching = false;
			_planetNames = PlanetNames.text.Split("\n"[0]).ToList();
			for (int i = 0; i < _planetNames.Count; i++)
			{
				_planetNames[i] = _planetNames[i].Replace("\n", "").Replace("\r", "");
			}
			base.Awake();
		}

		public IEnumerator WaitForCacheBuilt()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.TestFlightPlanet)
			{
				yield break;
			}
			while (!_hasCacheBuilt || _isRebuildingCache || _needsCacheRefresh)
			{
				if (!_isRebuildingCache && !_hasCacheBuilt)
				{
					_needsCacheRefresh = true;
				}
				yield return true;
			}
			yield return true;
		}

		public bool GetDataFromCache(Vector2 worldPosition, bool background, out NimbatusTerrainData data)
		{
			int num = (int)worldPosition.x + 540;
			int num2 = (int)worldPosition.y + 540;
			if (RuntimeGlobals.RunningMode == ERunningMode.TestFlightPlanet)
			{
				if (background)
				{
					data = _backgroundDataCacheTestflight[num * 1100 + num2];
					return true;
				}
				data = _dataCacheTestflight[num * 1100 + num2];
				return true;
			}
			if (_hasCacheBuilt && !_isRebuildingCache && !_needsCacheRefresh)
			{
				if (background)
				{
					data = _backgroundDataCache[num * 1100 + num2];
					return true;
				}
				data = _dataCache[num * 1100 + num2];
				return true;
			}
			data = default(NimbatusTerrainData);
			return false;
		}

		public List<EClimateZoneType> GetAllClimateZones()
		{
			return (from c in ClimateZones
				where c.IsUsedForRandomPlanets
				select c.ZoneType).ToList();
		}

		public EClimateZoneType GetRandomClimateZone(System.Random rnd)
		{
			return ClimateZones.Where((NimbatusTerrainClimateZone c) => c.IsUsedForRandomPlanets).ToList().RandomItem(rnd)
				.ZoneType;
		}

		public NimbatusTerrainClimateZone GetClimateZone(EClimateZoneType climateZoneType, int seed)
		{
			System.Random random = new System.Random(seed);
			return ClimateZones.Where((NimbatusTerrainClimateZone c) => c.ZoneType == climateZoneType).ToList().RandomItem<NimbatusTerrainClimateZone, NimbatusTerrainClimateZone>(random);
		}

		public void BuildTerrainCache(PlanetLocationData planet)
		{
			if (planet.ClimateZoneSeed != _currentCacheSeed)
			{
				_cancelCaching = true;
				_currentCacheSeed = planet.ClimateZoneSeed;
				ActiveClimateZone = planet.ClimateZone;
				System.Random rnd = new System.Random(_currentCacheSeed);
				ActiveClimateZone.SelectedSettings = planet.PlanetSettings;
				ActiveClimateZone.InitLayers(rnd);
				_cancelCaching = false;
				_needsCacheRefresh = true;
			}
		}

		public void ResetActiveClimateZone()
		{
			ActiveClimateZone = null;
			_cancelCaching = true;
		}

		private void FillupCache(object sender, DoWorkEventArgs doWorkEventArgs)
		{
			while (!_stopThread)
			{
				try
				{
					if (_needsCacheRefresh && !_isRebuildingCache)
					{
						_isRebuildingCache = true;
						_needsCacheRefresh = false;
						for (int i = 0; i < 1100; i++)
						{
							if (_needsCacheRefresh)
							{
								break;
							}
							for (int j = 0; j < 1100; j++)
							{
								if (_needsCacheRefresh)
								{
									break;
								}
								if (_cancelCaching)
								{
									break;
								}
								if (_activeClimateZone != null)
								{
									_dataCache[i * 1100 + j] = _activeClimateZone.GenerateData(new Vector2(i - 540, j - 540), false);
									_backgroundDataCache[i * 1100 + j] = _activeClimateZone.GenerateData(new Vector2(i - 540, j - 540), true);
								}
							}
							if (_cancelCaching || _needsCacheRefresh)
							{
								break;
							}
						}
						_isRebuildingCache = false;
						_hasCacheBuilt = true;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					_needsCacheRefresh = true;
					_isRebuildingCache = false;
					_hasCacheBuilt = false;
				}
				_cancelCaching = false;
				Thread.Sleep(1);
			}
		}

		public void OnApplicationQuit()
		{
			_stopThread = true;
		}

		protected override void PreLoad()
		{
			base.PreLoad();
			if (ClimateZones == null)
			{
				ClimateZones = (from c in Resources.LoadAll("ClimateZones", typeof(NimbatusTerrainClimateZone)).OfType<NimbatusTerrainClimateZone>()
					where c.IsUsed
					select c).ToList();
				ClimateZones.ForEach(delegate(NimbatusTerrainClimateZone c)
				{
					c.FillPixels();
				});
			}
		}

		protected override void PostLoad()
		{
			base.PostLoad();
			_testDriveZone = GetClimateZone(TestDriveClimateZone, 1);
			NimbatusTerrainSetting settings = _testDriveZone.TerrainSetting.GenerateSettings(new System.Random(1), true);
			_testDriveZone.SetSettings(settings);
			_testDriveZone.InitLayers(new System.Random(1));
			if (_dataCacheTestflight != null && _backgroundDataCacheTestflight != null)
			{
				return;
			}
			_dataCacheTestflight = new NimbatusTerrainData[1212202];
			_backgroundDataCacheTestflight = new NimbatusTerrainData[1212201];
			for (int i = 0; i < 1100; i++)
			{
				for (int j = 0; j < 1100; j++)
				{
					_dataCacheTestflight[i * 1100 + j] = _testDriveZone.GenerateData(new Vector2(i - 540, j - 540), false);
					_backgroundDataCacheTestflight[i * 1100 + j] = _testDriveZone.GenerateData(new Vector2(i - 540, j - 540), true);
				}
			}
		}

		protected override void LoadFromFile(ClimateZoneManagerSaveData data)
		{
		}

		protected override ClimateZoneManagerSaveData SaveToFile()
		{
			return new ClimateZoneManagerSaveData();
		}
	}
}
