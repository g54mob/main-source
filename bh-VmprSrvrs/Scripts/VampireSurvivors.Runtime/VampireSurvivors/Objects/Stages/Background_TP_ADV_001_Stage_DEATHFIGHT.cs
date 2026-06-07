using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	[DefaultExecutionOrder(1003)]
	public class Background_TP_ADV_001_Stage_DEATHFIGHT : BackgroundManager
	{
		private TilingTileset _tilingTileset;

		private PlatformZoneMovement _platformMovement;

		private PolygonGroupComponent[] _polygonGroups;

		private PolygonGroupComponent _currentPlatformingArea;

		private List<Rectangle> _platformingZones;

		private bool _created;

		private TileSprite _deathFightBG;

		private TileSprite _deathFightTile;

		private PhaserSprite _deathFightTileTop;

		private float2? _deathFightStartCameraPos;

		private Camera _camera;

		public override void Awake()
		{
		}

		public override void Create()
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

		private void ExitPlatformingZone()
		{
		}

		private void UpdateCurrentPlatformingArea()
		{
		}

		public void DeactivatePlatformingAltogether()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Cleanup()
		{
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

		private void SpawnDeathFightBackground()
		{
		}

		public void SpawnDeathFightTile()
		{
		}

		private void RemoveDeathFightBackground()
		{
		}

		private void UpdateBackground()
		{
		}
	}
}
