using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Vent2Projectile : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CAnimateKillCounter_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vent2Projectile _003C_003E4__this;

			public int objectsSucked;

			private float _003CanimateT_003E5__2;

			private string _003CfullString_003E5__3;

			private int _003CfullStringLength_003E5__4;

			private int _003CcurrentStringLength_003E5__5;

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
			public _003CAnimateKillCounter_003Ed__41(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnParticles_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vent2Projectile _003C_003E4__this;

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
			public _003CSpawnParticles_003Ed__37(int _003C_003E1__state)
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

		private Vent2Weapon _trueWeapon;

		private bool _hasInitialisedGraphics;

		private TileSprite _stars;

		private float _starsWidthPixels;

		private float _doorThickness;

		private float _extendingTime;

		private float _openingTime;

		private float _closingTime;

		private float _retractingTime;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		private MultiTargetTween _tween5;

		private MultiTargetTween _tween6;

		private MultiTargetTween _tween7;

		private MultiTargetTween _tween8;

		private PhaserSprite _topDoor;

		private PhaserSprite _topDoorCap;

		private PhaserSprite _bottomDoor;

		private PhaserSprite _bottomDoorCap;

		private ParticleEmitterManager _suckParticleManager;

		private ParticleSystem _suckParticles;

		private GravityWell _suckParticleWell;

		public float _currentSuckLevel;

		private bool _xFlip;

		private bool _shouldStopASAP;

		private Timer _hitboxDelayTimer;

		private Timer _mainSuckingTimer;

		private bool _firstFiring;

		private HashSet<IDamageable> _objectsSucked;

		private float ExtraneousAnimationTimeMultiplier()
		{
			return 0f;
		}

		private float BaseDoorHeight()
		{
			return 0f;
		}

		private float CapHeight()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnParticles_003Ed__37))]
		private IEnumerator SpawnParticles()
		{
			return null;
		}

		private void StartSucking()
		{
		}

		private void ReturnToNormal()
		{
		}

		private void DisplayKillCount()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateKillCounter_003Ed__41))]
		private IEnumerator AnimateKillCounter(int objectsSucked)
		{
			return null;
		}

		private void InitialiseGraphics()
		{
		}

		public override void Despawn()
		{
		}

		private void CleanupTweens()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Cleanup()
		{
		}

		private void UpdateParticleSuck()
		{
		}

		private void LateUpdate()
		{
		}

		public void TryStoppingEarly()
		{
		}
	}
}
