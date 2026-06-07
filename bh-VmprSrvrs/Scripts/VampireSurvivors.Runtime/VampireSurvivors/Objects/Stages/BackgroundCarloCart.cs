using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	[DefaultExecutionOrder(1000)]
	public class BackgroundCarloCart : BackgroundManager
	{
		[SerializeField]
		protected float2 CartOffset;

		private Vector2 _initialOffset;

		private TileSprite fb_bg_hw_Back;

		private TileSprite fb_bg_hw_Front;

		private TileSprite rainbowRoad;

		private float _speedFactor;

		private float _accelerationMul;

		private bool isFirstUpdate;

		private List<PhaserSprite> _frontCartSprites;

		private List<PhaserSprite> _backCartSprites;

		private List<float2> _cartOffsets;

		private PickupCoffin secretCoffin;

		private bool canSpawnSecretCoffin;

		private bool _isAccelerated;

		private float _accelTime;

		private float _accelDuration;

		private float _distanceTravelled;

		private int _loopLength;

		private int _loopsDone;

		private float _nextLoopDist;

		private TilingTileset _tilingTileset;

		private List<Vector2> _accelLocations;

		private Timer _accelSpawnTimer;

		private float _accelSpawnFrequency;

		private float2 _GoalPosition;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _glitchEmitter;

		private ParticleSystem _glitchEmitter2;

		private float _savedTimeScale;

		private bool _wasPaused;

		private float _initialTimeScale;

		private float _inversionMul;

		private MapToken _mapToken;

		private float _playerStartX;

		private bool _canSpawnGoal;

		public override void Create()
		{
		}

		private void SpawnCartForCharacter(VampireSurvivors.Objects.Characters.CharacterController character, float2 offset)
		{
		}

		private void OnRemoteItemInstantiated(Pickup item)
		{
		}

		public override void OnInitCompleted()
		{
		}

		public void TryToSpawnAccel()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		public float GetDistanceTravelled()
		{
			return 0f;
		}

		private void CheckDistanceTravelled()
		{
		}

		private void OnPassGoal()
		{
		}

		private void SpawnGoal()
		{
		}

		private void LateUpdate()
		{
		}

		private void MoveEnemies()
		{
		}

		private void MoveVehiclesAndPickups(float movement)
		{
		}

		public override void InitPickupForLoopingStage(Pickup pickup)
		{
		}

		private void MoveCarts()
		{
		}

		public void Accelerate()
		{
		}

		public void StopAcceleration()
		{
		}

		public override void Cleanup()
		{
		}

		public override void OnItemTriggered(ItemType itemType, Pickup pickup, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public override void OnPlayerEnteringDifferentTilemap()
		{
		}

		private void MakeEmitters()
		{
		}

		public override void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}
	}
}
