using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundFBGaluga_Basic : BackgroundManager
	{
		private TilingTileset _tilingTileset;

		private float _mapHeight;

		private bool _hasSpawnedBigFuzz;

		private EnemyBigFuzz _bigFuzz;

		private Color _dayColor;

		private Color _nightColor;

		private Light2D _globalLight;

		private List<Vector2> _exploCarLocations;

		private List<Vector2> _exploBarrelLocations;

		private Timer _destructibleTimer;

		private float DestructibleFrequency;

		[NonSerialized]
		public PhaserSprite _leftDoor;

		[NonSerialized]
		public PhaserSprite _rightDoor;

		[NonSerialized]
		public PhaserSprite _doorFrame;

		[NonSerialized]
		public PhaserSprite _doorSpace;

		[NonSerialized]
		public PhaserSprite _doorMask;

		private PhaserSprite _waterAnim;

		private TileSprite _water;

		private Timer _simondoTimer;

		private const float DayCycleDuration = 1800f;

		public override void Awake()
		{
		}

		public override void Create()
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected void SpawnSimondo()
		{
		}

		protected void SpawnBigFuzzBattleLocation()
		{
		}

		protected void HandleDestructibleSpawning()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void UpdateDayNight()
		{
		}

		public void SetBigFuzzObject(EnemyBigFuzz bigFuzz)
		{
		}

		private void LateUpdate()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
