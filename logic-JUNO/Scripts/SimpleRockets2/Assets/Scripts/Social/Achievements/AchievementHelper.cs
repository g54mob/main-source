using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Scenes.Events;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Social.Achievements
{
	public static class AchievementHelper
	{
		private struct CacheLandOnPlanetData
		{
			public bool CheckComplete { get; set; }

			public int CraftNodeId { get; set; }

			public string PlanetName { get; set; }

			public void Clear()
			{
				CheckComplete = false;
				CraftNodeId = -1;
				PlanetName = null;
			}
		}

		private static bool _achievementUnlockedFirstAtmosphereExit;

		private static bool _achievementUnlockedFirstOrbit;

		private static bool _achievementUnlockedSystemEscapeTrajectory;

		private static CacheLandOnPlanetData _cacheLandOnPlanet;

		private static bool? _inFlightSceneDefaultSystem;

		private static bool? _inLevel;

		public static bool InFlightSceneDefaultSystem
		{
			get
			{
				bool valueOrDefault = _inFlightSceneDefaultSystem == true;
				if (!_inFlightSceneDefaultSystem.HasValue)
				{
					valueOrDefault = Game.InFlightScene && (Game.Instance.FlightScene.FlightState?.SolarSystemData.IsDefaultSystem ?? false);
					_inFlightSceneDefaultSystem = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		public static bool InLevel
		{
			get
			{
				bool valueOrDefault = _inLevel == true;
				if (!_inLevel.HasValue)
				{
					valueOrDefault = Game.Instance.LevelManager.CurrentLevel != null;
					_inLevel = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		public static void EnterSoi(IPlanetData planet)
		{
			if (!InFlightSceneDefaultSystem || InLevel)
			{
				return;
			}
			ICraftNode craftNode = Game.Instance.FlightScene.CraftNode;
			if (craftNode != null && IsFromAnotherPlanet(craftNode, planet.Name))
			{
				AchievementKey? discoverPlanetKey = GetDiscoverPlanetKey(planet.Name);
				if (discoverPlanetKey.HasValue)
				{
					Game.Instance.AchievementManager.UnlockAchievement(discoverPlanetKey.Value);
				}
			}
		}

		public static void InContactWithPlanetOrWater(CraftNode craftNode)
		{
			if (!InFlightSceneDefaultSystem || InLevel)
			{
				return;
			}
			string name = craftNode.Parent.Name;
			int nodeId = craftNode.NodeId;
			if (name != _cacheLandOnPlanet.PlanetName || nodeId != _cacheLandOnPlanet.CraftNodeId)
			{
				_cacheLandOnPlanet.PlanetName = name;
				_cacheLandOnPlanet.CraftNodeId = nodeId;
				_cacheLandOnPlanet.CheckComplete = false;
			}
			else if (_cacheLandOnPlanet.CheckComplete)
			{
				return;
			}
			if (craftNode.FrameVelocity.magnitude > 5f)
			{
				return;
			}
			_cacheLandOnPlanet.CheckComplete = true;
			if (!craftNode.IsDestroyed && IsFromAnotherPlanet(craftNode, name))
			{
				AchievementKey? landOnPlanetKey = GetLandOnPlanetKey(name);
				if (landOnPlanetKey.HasValue)
				{
					Game.Instance.AchievementManager.UnlockAchievement(landOnPlanetKey.Value);
				}
			}
		}

		public static void InHighAltitudeOrSpace(CraftNode craftNode)
		{
			if (!InFlightSceneDefaultSystem || InLevel)
			{
				return;
			}
			if (!_achievementUnlockedFirstAtmosphereExit)
			{
				IPlanetData planetData = craftNode.Parent?.PlanetData;
				if (planetData.Name == "Droo" && craftNode.Altitude >= (planetData.AtmosphereData?.Height ?? 0.0))
				{
					_achievementUnlockedFirstAtmosphereExit = true;
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.FirstAtmosphereExit);
				}
			}
			if (!_achievementUnlockedFirstOrbit)
			{
				IOrbit orbit = craftNode.Orbit;
				IPlanetData planetData2 = craftNode.Parent.PlanetData;
				double num = orbit.PeriapsisDistance - planetData2.Radius;
				double apoapsisDistance = orbit.ApoapsisDistance;
				if (num > Mathd.Max(planetData2.AtmosphereData.Height, planetData2.MaxEstimatedTerrainElevation) && orbit.Eccentricity < 1.0 && apoapsisDistance < craftNode.Parent.SphereOfInfluence)
				{
					_achievementUnlockedFirstOrbit = true;
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.FirstOrbit);
				}
			}
			if (!_achievementUnlockedSystemEscapeTrajectory && craftNode.Parent.PlanetData.Name == "Juno")
			{
				IOrbit orbit2 = craftNode.Orbit;
				if (orbit2.Eccentricity > 1.0 || orbit2.ApoapsisDistance > craftNode.Parent.SphereOfInfluence)
				{
					_achievementUnlockedSystemEscapeTrajectory = true;
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.SystemEscapeTrajectory);
				}
			}
		}

		public static void Initialize()
		{
			Game.Instance.SceneManager.SceneLoading += OnSceneLoading;
		}

		public static bool IsInSpace(ICraftScript craftScript)
		{
			double num = craftScript.CraftNode.Parent.PlanetData.AtmosphereData?.Height ?? 0.0;
			if (num <= 0.0)
			{
				num = 20000.0;
			}
			return craftScript.CraftNode.Altitude >= num;
		}

		private static AchievementKey? GetDiscoverPlanetKey(string planetName)
		{
			return planetName switch
			{
				"Brigo" => AchievementKey.DiscoverBrigo, 
				"Boreas" => AchievementKey.DiscoverBoreas, 
				"Cylero" => AchievementKey.DiscoverCylero, 
				"Handrew's Comet" => AchievementKey.DiscoverHandrewsComet, 
				"Herma" => AchievementKey.DiscoverHerma, 
				"Hypatchion" => AchievementKey.DiscoverHypatchion, 
				"Jastrus" => AchievementKey.DiscoverJastrus, 
				"Juno" => AchievementKey.DiscoverJuno, 
				"Luna" => AchievementKey.DiscoverLuna, 
				"Miros" => AchievementKey.DiscoverMiros, 
				"Nebra" => AchievementKey.DiscoverNebra, 
				"Niobe" => AchievementKey.DiscoverNiobe, 
				"Orcus" => AchievementKey.DiscoverOrcus, 
				"Sergeaa" => AchievementKey.DiscoverSergeaa, 
				"Taurus" => AchievementKey.DiscoverTaurus, 
				"T.T." => AchievementKey.DiscoverTT, 
				"Tydos" => AchievementKey.DiscoverTydos, 
				"Urados" => AchievementKey.DiscoverUrados, 
				"Vulco" => AchievementKey.DiscoverVulco, 
				"Oord" => AchievementKey.DiscoverOord, 
				"Cladh" => AchievementKey.DiscoverCladh, 
				_ => null, 
			};
		}

		private static AchievementKey? GetLandOnPlanetKey(string planetName)
		{
			return planetName switch
			{
				"Brigo" => AchievementKey.LandOnBrigo, 
				"Boreas" => AchievementKey.LandOnBoreas, 
				"Cylero" => AchievementKey.LandOnCylero, 
				"Handrew's Comet" => AchievementKey.LandOnHandrewsComet, 
				"Herma" => AchievementKey.LandOnHerma, 
				"Hypatchion" => AchievementKey.LandOnHypatchion, 
				"Jastrus" => AchievementKey.LandOnJastrus, 
				"Luna" => AchievementKey.LandOnLuna, 
				"Miros" => AchievementKey.LandOnMiros, 
				"Nebra" => AchievementKey.LandOnNebra, 
				"Niobe" => AchievementKey.LandOnNiobe, 
				"Orcus" => AchievementKey.LandOnOrcus, 
				"Sergeaa" => AchievementKey.LandOnSergeaa, 
				"Taurus" => AchievementKey.LandOnTaurus, 
				"T.T." => AchievementKey.LandOnTT, 
				"Vulco" => AchievementKey.LandOnVulco, 
				"Oord" => AchievementKey.LandOnOord, 
				"Cladh" => AchievementKey.LandOnCladh, 
				_ => null, 
			};
		}

		private static bool IsFromAnotherPlanet(ICraftNode craftNode, string planetName)
		{
			if (craftNode.InitialCraftNodeData.Count > 0)
			{
				foreach (InitialCraftNodeData initialCraftNodeDatum in craftNode.InitialCraftNodeData)
				{
					if (initialCraftNodeDatum.LaunchPlanetName != planetName)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		private static void OnSceneLoading(object sender, SceneEventArgs e)
		{
			_inFlightSceneDefaultSystem = null;
			_inLevel = null;
			_cacheLandOnPlanet.Clear();
		}
	}
}
