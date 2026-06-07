using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	[DefaultExecutionOrder(1002)]
	public class BackgroundFoscariRun : BackgroundManager
	{
		protected float2 CartOffset;

		private Vector2 _initialOffset;

		private TileSprite fb_bg_hw_Back;

		private TileSprite fb_bg_hw_Front;

		private TileSprite rainbowRoad;

		private float _speedFactor;

		private float _accelerationMul;

		private bool isFirstUpdate;

		private bool _hasAlteredPrismaticMissile;

		private List<PhaserSprite> _frontCartSprites;

		private List<PhaserSprite> _backCartSprites;

		private List<float2> _cartOffsets;

		private float _distanceTravelled;

		private int _loopLength;

		private int _loopsDone;

		private float _nextLoopDist;

		private TilingTileset _tilingTileset;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _glitchEmitter;

		private ParticleSystem _glitchEmitter2;

		private bool _wasPaused;

		private float _inversionMul;

		private MapToken _mapToken;

		private float _playerStartX;

		private float _waterOffset;

		private TileSprite _water;

		private SpriteRenderer _waterFG;

		private VampireSurvivors.Objects.Characters.CharacterController _Luminaire;

		private Timer _pickupsLoopTimer;

		private float _itemLoopTimer;

		private float _itemLoopDelay;

		public void MakeWaterFallBackground()
		{
		}

		public override void Create()
		{
		}

		private void SpawnCartForCharacter(VampireSurvivors.Objects.Characters.CharacterController character, float2 offset)
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected override void OnUpdate()
		{
		}

		public float GetDistanceTravelled()
		{
			return 0f;
		}

		private void CheckDistanceTravelled()
		{
		}

		private void OnLoopDone()
		{
		}

		public override void LoopPickupPositions()
		{
		}

		private void LateUpdate()
		{
		}

		private void MoveVehiclesAndPickups(float movement)
		{
		}

		private void MoveCarts()
		{
		}

		public override void Cleanup()
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
