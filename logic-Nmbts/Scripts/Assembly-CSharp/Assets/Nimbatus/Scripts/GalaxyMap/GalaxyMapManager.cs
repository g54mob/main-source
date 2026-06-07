using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions.Rewards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap
{
	public class GalaxyMapManager : SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>
	{
		[Serializable]
		public class ProgressionSetting
		{
			public int MinSteps = 1;

			public int MaxSteps = 5;

			public List<ProgressionStage> Stages;
		}

		[Serializable]
		public class ProgressionStage
		{
			public bool AllowAllSystems = true;

			[HideIf("AllowAllSystems", true)]
			public List<SolarSystemSetting> AllowedSystems = new List<SolarSystemSetting>();

			public bool AllowAllClimateZones = true;

			[HideIf("AllowAllClimateZones", true)]
			public List<EClimateZoneType> AllowedClimateZones = new List<EClimateZoneType>();

			public EMissionComplexity MissionComplexity;

			public EGalaxyComplexity GalaxyComplexity;
		}

		public WormHoleLocationSetting WormHoleEntranceLocation;

		public WormHoleLocationSetting WormHoleExitLocation;

		public PlanetLocationSetting CampaignEndLocation;

		public SolarSystemSetting StartSystem;

		public List<ProgressionSetting> GalaxyProgression;

		public Dictionary<int, TravelEventConsequence> EndOfGalaxyRewards;

		public List<RewardPool> EndOfGalaxyRewardPools;

		[NonSerialized]
		[HideInInspector]
		public List<LocationSetting> LocationSettings;

		[NonSerialized]
		[HideInInspector]
		public List<SolarSystemSetting> SolarSystemSettings;

		[NonSerialized]
		[HideInInspector]
		public List<SolarSystemSetting> SpecialSystemSettings;

		[NonSerialized]
		[HideInInspector]
		public List<Galaxy> Galaxies;

		private GalaxyMapGenerator _generator;

		private LocationData _currentLocation;

		internal override string Filename
		{
			get
			{
				return "GalaxyMap.xml";
			}
		}

		[HideInInspector]
		public bool IsLoading { get; set; }

		[HideInInspector]
		public bool FirstVisit { get; set; }

		[HideInInspector]
		public Galaxy CurrentGalaxy { get; set; }

		[HideInInspector]
		public LocationData TargetLocation { get; set; }

		[HideInInspector]
		public LocationData CurrentLocation
		{
			get
			{
				return _currentLocation;
			}
			set
			{
				_currentLocation = value;
				if (CurrentGalaxy != null && _currentLocation != null)
				{
					CurrentGalaxy.CurrentLocationId = _currentLocation.UniqueId;
				}
			}
		}

		protected override void PreLoad()
		{
			FirstVisit = false;
			LocationSettings = Resources.LoadAll<LocationSetting>("GalaxyMap").ToList();
			SolarSystemSettings = Resources.LoadAll<SolarSystemSetting>("GalaxyMap/SolarSystems").ToList();
			SpecialSystemSettings = Resources.LoadAll<SolarSystemSetting>("GalaxyMap/SpecialSystems").ToList();
			Galaxies = new List<Galaxy>();
		}

		public SolarSystemSetting GetRandomSolarSystem(System.Random randomGenerator, EGalaxyComplexity difficulty)
		{
			List<SolarSystemSetting> list = SolarSystemSettings.Where((SolarSystemSetting s) => s.IsCompatibleWithGameMode()).ToList();
			if (difficulty == EGalaxyComplexity.None)
			{
				return list.RandomItem(randomGenerator);
			}
			return list.RandomItemProbability((SolarSystemSetting s, int i) => s.ProbabilityByGalaxyComplexity.Evaluate((float)difficulty), randomGenerator);
		}

		public SolarSystemSetting GetRandomSpecialSystem(System.Random randomGenerator, EGalaxyComplexity difficulty)
		{
			List<SolarSystemSetting> list = SpecialSystemSettings.Where((SolarSystemSetting s) => s.IsCompatibleWithGameMode()).ToList();
			if (difficulty == EGalaxyComplexity.None)
			{
				return list.RandomItem(randomGenerator);
			}
			return list.RandomItemProbability((SolarSystemSetting s, int i) => s.ProbabilityByGalaxyComplexity.Evaluate((float)difficulty), randomGenerator);
		}

		public List<LocationSetting> GetShopLocations(int level = -1)
		{
			List<LocationSetting> list = new List<LocationSetting>();
			if (RuntimeGlobals.GameModeSettings.HasShops)
			{
				list.AddRange(LocationSettings.OfType<ShopLocationSetting>());
			}
			if (RuntimeGlobals.GameModeSettings.HasGarages)
			{
				list.AddRange(LocationSettings.OfType<GarageLocationSetting>());
			}
			if (RuntimeGlobals.GameModeSettings.HasWeaponCasino && level > 1)
			{
				list.AddRange(LocationSettings.OfType<ScrapyardLocationSetting>());
			}
			return list;
		}

		public LocationSetting GetRandomShopLocation(System.Random randomGenerator)
		{
			return GetShopLocations().RandomItem(randomGenerator);
		}

		protected override void PostLoad()
		{
			if (!base.HasBeenLoaded)
			{
				FirstVisit = true;
				StartCoroutine(GenerateGalaxyMap(SaveManager.LoadedSave.Settings.Seed, 1));
				return;
			}
			if (CurrentGalaxy != null)
			{
				CurrentGalaxy.PostLoad();
			}
			FirstVisit = false;
		}

		public void ReloadGalaxy(int seed, int level)
		{
			StartCoroutine(LoadGalaxy(seed, level));
		}

		public void ResetGalaxy()
		{
			StartCoroutine(LoadGalaxy(CurrentGalaxy.Seed, CurrentGalaxy.Level, true));
		}

		public void ScanGalaxy(int steps)
		{
			if (CurrentGalaxy == null)
			{
				return;
			}
			List<GalaxyMapSector> list = CurrentGalaxy.Sectors.Where((GalaxyMapSector s) => !s.Explored && s.Scanned).ToList();
			foreach (GalaxyMapSector item in list)
			{
				item.SetScanned(false);
			}
			list = CurrentGalaxy.Sectors.Where((GalaxyMapSector s) => s is SolarSystem && s.Revealed).ToList();
			foreach (GalaxyMapSector item2 in list)
			{
				item2.Revealed = false;
			}
			list = CurrentGalaxy.Sectors.Where((GalaxyMapSector s) => s.Explored && s.GetNeighbours().Any((GalaxyMapSector n) => !n.Explored)).ToList();
			List<GalaxyMapSector> list2 = new List<GalaxyMapSector>();
			for (int num = 0; num < steps; num++)
			{
				foreach (GalaxyMapSector item3 in list)
				{
					list2.AddRange(item3.ScanNeighbours(true));
				}
				list2 = list2.Distinct().ToList();
				list.Clear();
				list.AddRange(list2);
				list2.Clear();
			}
			list = ((steps != 0) ? CurrentGalaxy.Sectors.Where((GalaxyMapSector s) => !s.Explored && s.Scanned).ToList() : CurrentGalaxy.Sectors.Where((GalaxyMapSector s) => s.Explored).ToList());
			foreach (GalaxyMapSector item4 in list)
			{
				item4.RevealNeighbours(true);
			}
		}

		public EMissionComplexity GetActiveMissionComplexity()
		{
			if (CurrentLocation != null)
			{
				return CurrentLocation.MissionComplexity;
			}
			return EMissionComplexity.None;
		}

		private IEnumerator LoadGalaxy(int seed, int level, bool reset = false)
		{
			if (reset)
			{
				Galaxies.Remove(CurrentGalaxy);
				CurrentGalaxy = null;
				CurrentLocation = null;
				yield return StartCoroutine(GenerateGalaxyMap(seed, level));
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Save();
				SaveManager.StoreSaveGame(false, false);
			}
			else
			{
				Galaxy galaxy = Galaxies.FirstOrDefault((Galaxy g) => g.Level == level);
				if (galaxy != null)
				{
					CurrentGalaxy = galaxy;
					CurrentGalaxy.PostLoad();
					CurrentLocation = galaxy.GetLocationById(galaxy.CurrentLocationId);
				}
				else
				{
					yield return StartCoroutine(GenerateGalaxyMap(seed, level));
				}
			}
			NimbatusSceneManager.LoadScene("MissionControlScene");
		}

		private IEnumerator GenerateGalaxyMap(int seed, int level)
		{
			IsLoading = true;
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				if (RuntimeGlobals.GameModeSettings.ViewCampaignTutorial)
				{
					seed = SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.TutorialSeed;
					level--;
					RuntimeGlobals.GameModeSettings.ViewCampaignTutorial = false;
					RuntimeGlobals.GameModeSettings.InCampaignTutorial = true;
				}
				else if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
				{
					RuntimeGlobals.GameModeSettings.InCampaignTutorial = false;
				}
			}
			_generator = new GalaxyMapGenerator(seed);
			yield return StartCoroutine(_generator.GenerateMap(level));
			CurrentGalaxy = new Galaxy
			{
				Level = level,
				Seed = seed,
				StartLocationId = _generator.StartLocation.UniqueId,
				EndLocationId = _generator.EndLocation.UniqueId,
				CurrentLocationId = _generator.StartLocation.UniqueId,
				CurrentThreatLevel = ((level <= 1 || Galaxies == null) ? 0f : ((Galaxies.Count <= 0) ? 10f : (Galaxies[Galaxies.Count - 1].CurrentThreatLevel * 0.2f))),
				BaseThreatIncrease = ThreatHelper.CalculateBaseIncrease(_generator.StepCount, level),
				Sectors = _generator.Sectors
			};
			CurrentLocation = _generator.StartLocation;
			Galaxies.Add(CurrentGalaxy);
			CurrentGalaxy.PostLoad();
			IsLoading = false;
		}

		protected override void Reset()
		{
			Galaxies = new List<Galaxy>();
			CurrentGalaxy = null;
			CurrentLocation = null;
		}

		protected override void LoadFromFile(GalaxyMapSaveData data)
		{
			Galaxies = data.Galaxies;
			CurrentGalaxy = Galaxies.FirstOrDefault((Galaxy g) => g.Level == data.CurrentLevel);
			if (CurrentGalaxy != null)
			{
				CurrentLocation = CurrentGalaxy.GetLocationById(CurrentGalaxy.CurrentLocationId);
			}
		}

		protected override GalaxyMapSaveData SaveToFile()
		{
			CurrentGalaxy.CurrentLocationId = CurrentLocation.UniqueId;
			return new GalaxyMapSaveData
			{
				CurrentLocationId = CurrentLocation.UniqueId,
				CurrentLevel = CurrentGalaxy.Level,
				Galaxies = Galaxies.Where((Galaxy g) => g.Level >= CurrentGalaxy.Level).ToList()
			};
		}

		public bool CanVisitCurrentLocation()
		{
			if (CurrentLocation != null)
			{
				return CurrentLocation.Visitable;
			}
			return true;
		}

		public void ReachTargetLocation()
		{
			CurrentLocation = TargetLocation;
			TargetLocation = null;
		}
	}
}
