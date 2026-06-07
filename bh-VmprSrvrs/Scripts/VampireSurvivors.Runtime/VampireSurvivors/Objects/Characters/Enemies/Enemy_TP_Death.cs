using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_Death : EnemyController
	{
		[CompilerGenerated]
		private sealed class _003C_SpawnAllies_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Enemy_TP_Death _003C_003E4__this;

			private float _003CtimeBetweenSpawns_003E5__2;

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
			public _003C_SpawnAllies_003Ed__89(int _003C_003E1__state)
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

		private Transform _cameraTarget;

		private PhaserSprite _deathMask;

		private PhaserSprite _deathSpine;

		private PhaserSprite _deathCape;

		private Enemy_TP_DeathArm _leftHand;

		private Enemy_TP_DeathArm _rightHand;

		private PhaserSprite _leftCracks;

		private PhaserSprite _rightCracks;

		private MultiTargetTween _leftCracksTween;

		private MultiTargetTween _rightCracksTween;

		private MultiTargetTween _screenShakeTween;

		private MultiTargetTween _droppedRelicTween;

		private List<PhaserSprite> _leftArmSprites;

		private List<PhaserSprite> _rightArmSprites;

		private ParticleSystem _rockParticles;

		private PhaserSprite _leftEye;

		private PhaserSprite _rightEye;

		private float _crawlTimer;

		private float _scytheTimer;

		private float _bigScytheTimer;

		private float _bigScytheScreamTime;

		private float _bigScythePostScreamThrowTime;

		public Enemy_TP_DeathScytheBig _currentBigScythe;

		private DeathFightDirecter _directer;

		private bool _isDirecterDead;

		private List<ItemType> _relicsToDrop;

		private PickupRelic _droppedRelic;

		private float _relicDropTimer;

		private ParticleSystem _deathZoneParticles;

		private bool _hasSpawnedAllies;

		private bool _havingAChat;

		private bool _canDie;

		private bool _sentDeathCommand;

		private float _damageZoneTimer;

		[NonSerialized]
		public List<CharacterType> _Allies;

		[NonSerialized]
		public Dictionary<CharacterType, CharacterController> _AlliesControllers;

		public int DirecterRevivals { get; set; }

		public bool HasRemovedWeapons { get; set; }

		public bool HasSpawnedAllies => false;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		[Command]
		public void OnBigScytheSpawned(CoherenceSync enemy)
		{
		}

		private void SetupParticles()
		{
		}

		public void StartSequence()
		{
		}

		[Command]
		public void EndSequence()
		{
		}

		private void DestructionEffects()
		{
		}

		private void ActuallyRemove()
		{
		}

		private void FadeOut()
		{
		}

		private void OnItemReceived(UISignals.ReceivedNewItemSignal signal)
		{
		}

		public void RunBlackDiskCutscene()
		{
		}

		private void SwitchToCredits()
		{
		}

		private void HandleUnlocksAtStart()
		{
		}

		private void HandleUnlocksAtEnd()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		private void TriggerDeath()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void TriggerDirecterBlock()
		{
		}

		[Command]
		public void CreateDamageZone(Vector2 spawnPositionOffset)
		{
		}

		private void SetupDamageZoneVisuals(Vector3 pos, DamageZoneFlexible zone)
		{
		}

		private void UpdateEyes()
		{
		}

		private void UpdateCrawling()
		{
		}

		private void UpdateSpriteTrail()
		{
		}

		private void UpdateDeathArea()
		{
		}

		private float GetArmPhase(float timer, float period, float offset01)
		{
			return 0f;
		}

		private float FindNextJointT(float2 start, float2 end, float2 lastJointPos, float lastJointT, float desiredDistance, float iterationStep = -0.01f)
		{
			return 0f;
		}

		private void UpdateArm(float phase01, float lastPhase01, float xOffset, float yOffset, float reachDistance, Enemy_TP_DeathArm arm, PhaserSprite crackSprite, List<PhaserSprite> armSprites)
		{
		}

		private void UpdateJoints(Enemy_TP_DeathArm arm, float xOffset, List<PhaserSprite> armSprites, float extraScale)
		{
		}

		private float2 ArmSample(float2 start, float2 end, float t)
		{
			return default(float2);
		}

		private void Cleanup()
		{
		}

		public void ScreenShake(int repeats = 6)
		{
		}

		public void SummonDirecter()
		{
		}

		public bool HasDirecterBeenSummoned()
		{
			return false;
		}

		public bool IsDirecterDead()
		{
			return false;
		}

		public void DirecterStartBlocking(Transform target, EnemyController toBlock)
		{
		}

		public void DoBlockingAnimation()
		{
		}

		public void DirecterDied()
		{
		}

		private void DropNextRelic()
		{
		}

		private void DoDropAnimation(PickupRelic pickup)
		{
		}

		public void SpawnAllies()
		{
		}

		private bool DoWeHaveThisAllyAlready(CharacterType type)
		{
			return false;
		}

		public void PreSpawnAllies()
		{
		}

		[IteratorStateMachine(typeof(_003C_SpawnAllies_003Ed__89))]
		private IEnumerator _SpawnAllies()
		{
			return null;
		}

		private void SpawnAlly(CharacterType charType)
		{
		}
	}
}
