using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	[DefaultExecutionOrder(1001)]
	public class BackgroundFBHighway : BackgroundManager
	{
		private float2 BikeOffset;

		private Vector2 _initialOffset;

		private TileSprite fb_bg_hw_Back;

		private TileSprite fb_bg_hw_Front;

		private float _speedFactor;

		private float _accelerationMul;

		private float _currentAcceleration;

		private float _yMul;

		private bool isFirstUpdate;

		private bool _created;

		private List<PhaserSprite> _frontCartSprites;

		private List<PhaserSprite> _backCartSprites;

		private List<float2> _cartOffsets;

		private float _distanceTravelled;

		private int _loopLength;

		private TilingTileset _tilingTileset;

		private int _loopsDone;

		private float _nextLoopDist;

		private float _inversionMul;

		private Timer _BarrelsSpawningTimer;

		private float _playerStartX;

		public override void Create()
		{
		}

		private void SpawnBikeForCharacter(VampireSurvivors.Objects.Characters.CharacterController character, float2 offset)
		{
		}

		private void HandleDestructibleSpawning()
		{
		}

		public override void OnInitCompleted()
		{
		}

		public void SetSpeedFactor(float factor)
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

		public override void InitPickupForLoopingStage(Pickup pickup)
		{
		}

		private void MoveVehiclesAndPickups(float movement)
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateCarts()
		{
		}

		public override void Cleanup()
		{
		}

		public override void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}
	}
}
