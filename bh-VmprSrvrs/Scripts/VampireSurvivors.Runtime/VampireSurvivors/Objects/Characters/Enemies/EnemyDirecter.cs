using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDirecter : EnemyController
	{
		private MultiTargetTween _onEnterTween;

		private bool _isInvul;

		public float _Radius1;

		public float _Radius2;

		public float _Radius3;

		public float _Radius4;

		public float _Radius5;

		public float _Radius6;

		public float _Radius7;

		private float _myAngle1;

		private float _myAngle2;

		private float _myAngle3;

		private float _myAngle4;

		private float _myAngle5;

		private float _myAngle6;

		private float _myAngle7;

		private EnemyDMask _eye1;

		private EnemyDMask _eye2;

		private EnemyDMask _eye3;

		private EnemyDMask _eye4;

		private EnemyDMask _eye5;

		private EnemyDMask _eye6;

		private EnemyDMask _eye7;

		private bool _spawnedMasks;

		private TileSprite _stars1;

		private TileSprite _stars2;

		private PhaserSprite _LeftHand;

		private PhaserSprite _RightHand;

		public float _scale1;

		public float _scale2;

		public float _scale3;

		public float _scale4;

		public float _scale5;

		public float _scale6;

		public float _scale7;

		private int _currentPhase;

		public float _xOffset;

		private MultiTargetTween _moveTween0;

		public float _yOffset;

		private float _breakTimer;

		private float _breakDelay;

		private MultiTargetTween _moveTween3;

		private MultiTargetTween _moveTween4;

		private ShootingEyesManager _shootingEyesManager;

		private float _attacksDurationMultiplier;

		private float _attackDelay;

		private float _attackTimer;

		private int _attack1Index;

		private int _attack2Index;

		private int _attack3Index;

		private int _attack4Index;

		private float _angleUnit;

		private ObjectPool _explosionPool;

		private SpriteMask _spriteMask;

		private List<MultiTargetTween> _allTweens;

		private float _movement0StartingOffset;

		private float _movement0TargetOffset;

		private float _movement3StartingOffset;

		private float _movement3TargetOffset;

		private float _movement4StartingOffset;

		private float _movement4TargetOffset;

		[Sync]
		public CoherenceSync Eye1
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync Eye2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync Eye3
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync Eye4
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync Eye5
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync Eye6
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync Eye7
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int StageIndex { get; set; }

		public int BrokenMasks { get; set; }

		public bool BreakEnabled { get; set; }

		private float TotalDamage { get; set; }

		private int DirectHits { get; set; }

		private bool HasHands { get; set; }

		private PhaserSprite WhiteHand { get; set; }

		private void MakeHandAnimations()
		{
		}

		protected override void Awake()
		{
		}

		private void MakeMasks()
		{
		}

		private void MakeSkulls()
		{
		}

		private void DisappearEyes()
		{
		}

		private void MakeTreasures()
		{
		}

		private void Shrink()
		{
		}

		private void SetupMovementTargetOffsetValues()
		{
		}

		private void Movement_Behaviour0(float deltaTime)
		{
		}

		private void Movement_Behaviour3(float deltaTime)
		{
		}

		private void Movement_Behaviour4(float deltaTime)
		{
		}

		private void CheckAttack()
		{
		}

		private void TriggerAttackBehaviour(Action singlePlayerTrigger, Action<long> onlineTrigger)
		{
		}

		private void Attack_Behaviour0()
		{
		}

		private void Attack_Behaviour1()
		{
		}

		[Command]
		public void OnlineAttackBehaviour1(long startingSimFrame)
		{
		}

		private void PerformAttackBehaviour1()
		{
		}

		private void Attack_Behaviour2()
		{
		}

		[Command]
		public void OnlineAttackBehaviour2(long startingSimFrame)
		{
		}

		private void PerformAttackBehaviour2()
		{
		}

		private void Attack_Behaviour3()
		{
		}

		[Command]
		public void OnlineAttackBehaviour3(long startingSimFrame, int rnd)
		{
		}

		private void PerformAttackBehaviour3(int rnd)
		{
		}

		private void DamagingZone_Explosions(float yOffset = 0f, bool follow = false, float duration = 10000f)
		{
		}

		private void Attack_Behaviour4()
		{
		}

		[Command]
		public void OnlineAttackBehaviour4(long startingSimFrame)
		{
		}

		private void PerformAttackBehaviour4()
		{
		}

		public void TriggerPhase1()
		{
		}

		[Command]
		public void OnlineTriggerPhase1(long startingSimFrame)
		{
		}

		private void TriggerPhase1OnClient()
		{
		}

		public void TriggerPhase2()
		{
		}

		[Command]
		public void OnlineTriggerPhase2(long startingSimFrame)
		{
		}

		private void TriggerPhase2OnClient()
		{
		}

		private void TriggerPhase(Action singlePlayerTrigger, Action<long> onlineTrigger)
		{
		}

		private void AutoPositionHands()
		{
		}

		public void MakeMasksBreakable()
		{
		}

		public void OnMaskBroken(EnemyDMask mask)
		{
		}

		[Command]
		public void OnMaskBrokenOnline(long startingSimFrame, CoherenceSync mask)
		{
		}

		private void PerformMaskBroken(EnemyDMask mask)
		{
		}

		private void OnFreezeFinished()
		{
		}

		public void TriggerPhase3()
		{
		}

		[Command]
		public void OnlineTriggerPhase3(long startingSimFrame)
		{
		}

		private void TriggerPhase3OnClient()
		{
		}

		public void TriggerPhase4()
		{
		}

		[Command]
		public void OnlineTriggerPhase4(long startingSimFrame)
		{
		}

		private void TriggerPhase4OnClient()
		{
		}

		public void TriggerPhase5()
		{
		}

		[Command]
		public void OnlineTriggerPhase5(long startingSimFrame)
		{
		}

		private void TriggerPhase5OnClient()
		{
		}

		private void ThrowEggR(float x, float y)
		{
		}

		private void ThrowEggL(float x, float y)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void UpdateEye(EnemyDMask eye, float2 playerPos, float scale, float angle1, float angle2, float radius)
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void MakeStars()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		private void ShootEyes(int times, float delay, float radiusMul = 1f)
		{
		}

		private void MakeWhiteHand()
		{
		}

		private void DragInWhiteHand()
		{
		}
	}
}
