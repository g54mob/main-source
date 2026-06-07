using System;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyMazerellaDancer : EnemyController
	{
		public enum DancerSide
		{
			Left = 0,
			Right = 1
		}

		private enum DancerState
		{
			Uninitialized = 0,
			MovingToRelic = 1,
			MovingToPath = 2,
			MovingAlongPath = 3,
			MovingToDanceFloor = 4,
			DancingOnDanceFloor = 5,
			SpawningPickupsOnDeath = 6,
			Dead = 7
		}

		[SerializeField]
		private MazerellaDancerMagnet _magnet;

		[SerializeField]
		private float _maxMovementSpeed;

		[SerializeField]
		private float _movementSmoothing;

		[Space]
		[SerializeField]
		private float _distanceFromPlayer;

		[SerializeField]
		private float _regularLerpAmount;

		[Space]
		[SerializeField]
		private float _moveToRelicDuration;

		[SerializeField]
		private AnimationCurve _moveToRelicCurve;

		[Space]
		[SerializeField]
		private float _moveToScreenEdgeDuration;

		[SerializeField]
		private AnimationCurve _moveToScreenEdgeCurve;

		[Space]
		[SerializeField]
		private float _moveToDanceFloorDuration;

		[SerializeField]
		private AnimationCurve _moveToDanceFloorCurve;

		[SerializeField]
		private Vector3 _danceFloorTargetPositionOffset;

		private CoherenceSync _sync;

		private readonly MazerellaDancerAnimation _mazerellaDancerAnimation;

		private MazerellaDancerMazeNavigation _mazeNavigation;

		private DancerState _currentState;

		private DancerSide _dancerSide;

		private Vector3 _movementStartPosition;

		private Vector3 _movementTargetPosition;

		private float _movementTimer;

		private Bounds _danceFloorBounds;

		private float _mazePathPosition;

		private CharacterController _targetPlayer;

		private float MaxMoveSpeed => 0f;

		public void SetMovementTargetPosition(Vector3 targetPosition)
		{
		}

		public void SetDanceFloorBounds(Bounds bounds)
		{
		}

		[Command]
		public void InitAnimsCommand(bool isLeft)
		{
		}

		public void InitDancer(DancerSide dancerSide, MazerellaDancerMazeNavigation mazeNavigation, MazerellaDancerMazeNavigation.NavigationNode playerStartNavigationNode)
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		private void SetCurrentState(DancerState newState)
		{
		}

		protected override void OnUpdate()
		{
		}

		public void InitMagnet()
		{
		}

		public void InitMazePathPosition(float mazePathPosition)
		{
		}

		private Vector3 TargetPositionOnPathOffsetFromPlayer()
		{
			return default(Vector3);
		}

		private void LerpToPosition(Vector3 startPosition, Vector3 targetPosition, float duration, AnimationCurve movementCurve, Action onMovementComplete = null)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void GetDamagedSpecial(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true, Vector3? damagePosition = null)
		{
		}

		protected override void Die()
		{
		}
	}
}
