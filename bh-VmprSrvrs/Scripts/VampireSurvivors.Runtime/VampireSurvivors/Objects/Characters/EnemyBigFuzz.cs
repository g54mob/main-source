using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors.Objects.Characters
{
	[DefaultExecutionOrder(1003)]
	public class EnemyBigFuzz : EnemyController
	{
		private enum FightPhase
		{
			AnimatingIn = 0,
			ClawingIn = 1,
			OpeningDoors = 2,
			ShakingHeadPreLasers = 3,
			GunnaFireLaser = 4,
			DidFireLaser = 5,
			ShakingHeadPreFire = 6,
			FireBreathCharging = 7,
			FireBreathRotation = 8,
			ShakesSheadPostFire = 9,
			ClosingDoors = 10,
			Exploding = 11,
			ChoppingHead = 12,
			HeadFalling = 13,
			Finished = 14
		}

		[CompilerGenerated]
		private sealed class _003CWaitForStartCameraTransition_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnemyBigFuzz _003C_003E4__this;

			public float2 mainPosition;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForStartCameraTransition_003Ed__44(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private PhaserSprite _body;

		private PhaserSprite _leftHand;

		private PhaserSprite _rightHand;

		private PhaserSprite _leftEye;

		private PhaserSprite _rightEye;

		private PhaserSprite _leftDoor;

		private PhaserSprite _rightDoor;

		private PhaserSprite _doorFrame;

		private PhaserSprite _doorSpace;

		private PhaserSprite _doorMask;

		private PhaserSprite _laserChargingLeft;

		private PhaserSprite _laserChargingRight;

		private FightPhase _phase;

		private float _doorOpenAmount;

		private float _firebreathRotationDegrees;

		private float _firebreathProjectileCooldown;

		private List<Sprite> _explosionFrames;

		private List<PhaserSprite> _explosionSprites;

		private List<PhaserSprite> _readyExplosionSprites;

		private float _explosionTimer;

		private Timer _laserHeadShakeTimer;

		private Timer _laserChargeTimer;

		private Timer _laserFireTimer;

		private Timer _fireHeadShakeTimer;

		private Timer _fireChargeTimer;

		private Timer _fireRotationTimer;

		private Timer _postFireHeadShakeTimer;

		private Timer _blinkTimer;

		private float2 _battleCenter;

		private float _scale;

		private List<StageEdge> _stageEdges;

		private List<float> _characterFallingTimers;

		private bool _usePolygonEdges;

		private float _shieldedDamage;

		private int _cycleCount;

		private List<EquipmentInfo> _removedEquipment;

		private float _relativeScale => 0f;

		[Sync]
		public Vector2 BattleCenter
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		private void CancelTimers()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForStartCameraTransition_003Ed__44))]
		private IEnumerator WaitForStartCameraTransition(float2 mainPosition)
		{
			return null;
		}

		private void DoStartCameraTransition(float2 mainPosition)
		{
		}

		private void CreateStageEdges(float newScale)
		{
		}

		private Polygon CreatePhaserSpacePolygon(List<float2> points, float localScale)
		{
			return null;
		}

		private void AddExplosionEffect(float2 position)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void InitFireball(EnemyFBBulletFireball fireball, Vector2 velocity)
		{
		}

		private void SetDoorOpenAmount(float amount01)
		{
		}

		private void StartSequence()
		{
		}

		private void StartClawingIn()
		{
		}

		private void OpenDoors(bool firstTime)
		{
		}

		private float2 GetEyePos(bool left)
		{
			return default(float2);
		}

		private float2 GetMouthPos()
		{
			return default(float2);
		}

		private void FireLasers()
		{
		}

		private void StartPreFireShaking()
		{
		}

		private void CloseDoors()
		{
		}

		private void SpawnMines()
		{
		}

		[Command]
		public void SpawnMinesOnline(Vector2 target, float startAngleOffset)
		{
		}

		private void SpawnMinesAtTarget(Vector2 toTarget, float startAngleOffset)
		{
		}

		private void SpawnMineToLocation(float2 location, int countdownTimer)
		{
		}

		public void ScreenShake(int repeats = 6)
		{
		}

		private void LateUpdate()
		{
		}

		private void RunEdgeLogic()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Despawn()
		{
		}

		private void Clearup()
		{
		}

		private void DestroyComponentGO(Component sprite)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void RestoreBodyTint()
		{
		}

		protected override void Die()
		{
		}

		[Command]
		public void StartExplodingOnline()
		{
		}

		private void StartExploding()
		{
		}

		private void ChopHead()
		{
		}

		private void HeadFallenOff()
		{
		}

		private void ScheduleHighBrowGag()
		{
		}

		public void CleanupFromStage()
		{
		}
	}
}
