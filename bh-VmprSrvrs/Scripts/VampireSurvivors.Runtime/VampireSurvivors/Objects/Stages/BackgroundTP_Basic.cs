using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Stages
{
	[DefaultExecutionOrder(1003)]
	public class BackgroundTP_Basic : BackgroundManager
	{
		private TilingTileset _tilingTileset;

		private PlatformZoneMovement _platformMovement;

		private DopplegangerGate _dopplegangerGate;

		private TileSprite _AqueductBG;

		private TileSprite _AqueductWater;

		private List<TileSprite> _AqueductWaters;

		private List<PizzaCircle> BossPizzas;

		private Timer checkBossPizzasTimer;

		private List<PickupTeleporter> cycleGates;

		private PolygonGroupComponent[] _polygonGroups;

		private PolygonGroupComponent _currentPlatformingArea;

		private List<Rectangle> _platformingZones;

		private bool _created;

		private List<TPSoftBound> _softBounds;

		private List<TPSoftBound> _awakeSoftBounds;

		private List<TPBiomeType> _unlockedBiomes;

		private List<TPBiomeType> _accessibleBiomes;

		private TileSprite _deathFightBG;

		private TileSprite _deathFightTile;

		private PhaserSprite _deathFightTileTop;

		private float2? _deathFightStartCameraPos;

		private bool hasWater;

		private TPBiomeType? _currentBiome;

		public TPBiomeType? CurrentBiome => null;

		private void DifficultyModifier()
		{
		}

		private void SnapEggs()
		{
		}

		public override string GetDetailedMap(StageData stageData)
		{
			return null;
		}

		public override void Create()
		{
		}

		private TP_BossArena TryAddingBossArena(GameObject prefab, string enemyName, EnemyType enemyType)
		{
			return null;
		}

		private void CreateAqueductWater()
		{
		}

		private void CreateBossPizzas()
		{
		}

		private void CheckBossPizzas()
		{
		}

		public void CreateCycleGatesDelayed()
		{
		}

		private void CreateCycleGates()
		{
		}

		public Rect GetRectFromSuperObject(float xMin, float yMin, float xMax, float yMax, bool skipInverseCalculation = false)
		{
			return default(Rect);
		}

		private void LinkDoorsToBiomes()
		{
		}

		private void CreateSoftBounds()
		{
		}

		private void GreenlightBiomes()
		{
		}

		private void TryGreenlight(List<ItemType> collected, ItemType item, TPBiomeType biome)
		{
		}

		private void TryGreenlight(List<ItemType> collected, ItemType item)
		{
		}

		public bool AwakeBoundsContainingPlayers()
		{
			return false;
		}

		public float2 RestrictInsideAwakeBounds(float2 pos)
		{
			return default(float2);
		}

		public void ContainPlayersWithinSoftBounds()
		{
		}

		private void UpdateAwakeBounds()
		{
		}

		public void CreateTestDopplegangerGate()
		{
		}

		private void CreateDopplegangerGate(float2 position)
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected override void OnUpdate()
		{
		}

		private bool IsAnyPlayerInAPlatformingZone()
		{
			return false;
		}

		public void DeactivatePlatformingAltogether()
		{
		}

		public void DisableAllSoftBounds()
		{
		}

		private void ExitPlatformingZone()
		{
		}

		private void UpdateCurrentPlatformingArea()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		public override bool HasCustomMadGrooveRestriction()
		{
			return false;
		}

		public override bool IsPositionPulledByMadGroove(float2 position)
		{
			return false;
		}

		public override bool ShouldShowCursor(float2 position)
		{
			return false;
		}

		private bool IsWithinAccessibleBounds(float2 position)
		{
			return false;
		}

		private bool IsWithinUnlockedBounds(float2 position)
		{
			return false;
		}

		public override bool HasExtraSafeXYLogic()
		{
			return false;
		}

		public override float2 ExtraSafeXY(float2 position, float2 playerPosition)
		{
			return default(float2);
		}

		public void TestSpawnDeathFightBackground()
		{
		}

		public void TestRemoveDeathFightBackground()
		{
		}

		public void SpawnDeathFightBackground()
		{
		}

		public void SpawnDeathFightTile()
		{
		}

		public void RemoveDeathFightBackground()
		{
		}

		private void UpdateBackground()
		{
		}
	}
}
