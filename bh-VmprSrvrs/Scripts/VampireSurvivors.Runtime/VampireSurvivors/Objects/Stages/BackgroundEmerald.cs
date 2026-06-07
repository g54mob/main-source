using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundEmerald : BackgroundManager
	{
		public enum EmeraldsBiomes
		{
			Biome1 = 0,
			Biome2 = 1,
			Biome3 = 2,
			Biome4 = 3,
			Biome5 = 4,
			Biome6 = 5,
			Junction = 6,
			nil = 7
		}

		private EME_BiomeBounds _biomeBounds;

		private EME_RibbonController _emeraldRibbonController;

		private EME_TeleportFader _teleportFader;

		private EME_BiomeNameUI _biomeNameUi;

		private EmeraldsBiomes _nextBossBiome;

		private readonly Dictionary<EmeraldsBiomes, PizzaCircle> _bossPizzas;

		private Timer _checkBossPizzasTimer;

		private readonly Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter> _biomeToJunctionTeleporterLookup;

		private readonly Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter> _junctionToBiomeTeleporterLookup;

		private const string DestinationNameIsDestination = "isDestination";

		private const string EmeItems = "EME_items";

		private const string PizzasPoolName = "PizzaCircles";

		private const string JunctionDestination = "biome0";

		private readonly Dictionary<EmeraldsBiomes, string> _localizedBiomeNamesLookup;

		private bool _finalBossDefeated;

		private bool _ribbonTargetBossPizzas;

		private Transform _junctionSpawnTransform;

		public EmeraldsBiomes CurrentBiome { get; private set; }

		public EME_BiomeBounds GetBiomeBounds => null;

		public bool HasLeftJunction { get; private set; }

		private bool IsStageInverted => false;

		public override bool HasCustomMapRules()
		{
			return false;
		}

		public override bool HasCustomMadGrooveRestriction()
		{
			return false;
		}

		public override bool IsPositionPulledByMadGroove(float2 position)
		{
			return false;
		}

		public override bool ShouldShowPickupIconOnMap(Vector3 worldPosition)
		{
			return false;
		}

		private bool IsWithinAccessibleBounds(float2 position)
		{
			return false;
		}

		public Bounds GetBoundsForCurrentBiome(float xPosition, float width)
		{
			return default(Bounds);
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteItemInstantiated(Pickup item)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void InitBiomeNames()
		{
		}

		private void AddBiomeNameToDictionary(EmeraldsBiomes biome, string localizationKey)
		{
		}

		private void RemoveBonusesFromEggs()
		{
		}

		public override void OnInitCompleted()
		{
		}

		public void TeleportBossKilled(EmeraldsBiomes bossBiome, string[] teleportKeys)
		{
		}

		private void IncrementNextBiome()
		{
		}

		private void ActivateTeleporters(string[] teleportKeys)
		{
		}

		private void SetBiomeDifficulty()
		{
		}

		private void SetUpTeleporters()
		{
		}

		private void SetupTeleporter(Pickup_EME_Teleporter emeTeleporter)
		{
		}

		private static void DisableTeleporter(Pickup_EME_Teleporter emeTeleporter)
		{
		}

		private void ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes targetBiome, Pickup_EME_Teleporter teleporter)
		{
		}

		private void OnTeleportStart(VampireSurvivors.Objects.Characters.CharacterController playerTeleported)
		{
		}

		private void DisablePositionLimitingOnTeleportStart()
		{
		}

		private void ActivateBiome(VampireSurvivors.Objects.Characters.CharacterController playerTeleported, EmeraldsBiomes biomeToActivate)
		{
		}

		private void SetupTeleportFader()
		{
		}

		private void SetupBiomeNameUi()
		{
		}

		private void CreateBossPizzas()
		{
		}

		private void CheckBossPizzas()
		{
		}

		public void DebugTeleportToNextBiome()
		{
		}

		public void DebugTeleportToPreviousBiome()
		{
		}

		private void DebugTeleportToBiomeEntrance()
		{
		}

		public void DebugEnableAllTwoWayTeleporters()
		{
		}

		public override void Cleanup()
		{
		}

		private void Log(string message, GameObject debugGameObject = null)
		{
		}

		public override string GetDetailedMapStaticBackgroundImage(StageData stageData)
		{
			return null;
		}

		public override string GetDetailedMap(StageData stageData)
		{
			return null;
		}

		public override float GetMap_SizeX()
		{
			return 0f;
		}

		public override float GetMap_SizeY()
		{
			return 0f;
		}

		public override int GetMap_SupportHorizontal()
		{
			return 0;
		}

		public override float2 GetMap_PlayerPos()
		{
			return default(float2);
		}

		public override bool GetMap_DrawGrid()
		{
			return false;
		}
	}
}
