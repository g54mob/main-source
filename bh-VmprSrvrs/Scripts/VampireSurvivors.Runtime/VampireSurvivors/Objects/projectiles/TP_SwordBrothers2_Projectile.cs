using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SwordBrothers2_Projectile : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CDespawnInAFrame_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TP_SwordBrothers2_Projectile _003C_003E4__this;

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
			public _003CDespawnInAFrame_003Ed__26(int _003C_003E1__state)
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

		[SerializeField]
		private SpriteScroller _SpriteScroller;

		[SerializeField]
		private SpriteRenderer _LightningSprite;

		[SerializeField]
		private SpriteRenderer _Graphics;

		[SerializeField]
		private SpriteRenderer _Graphics2;

		private const float BaseRadius = 16f;

		private const int MiniSwordAmount = 32;

		private TP_SwordBrothers2_Weapon _trueWeapon;

		private ParticleEmitterManager _PfxEmitterManager;

		private Tween _moveTween;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _hitGroundTween;

		private MultiTargetTween _chargeTween;

		private MultiTargetTween _secondMoveTween;

		private MultiTargetTween _finalScaleGroundTween;

		private bool _isGrounded;

		private ParticleSystem _PfxEmitter1;

		private Circle _explosionCircle;

		private Transform _target;

		private PhaserSprite _swordSprite;

		private List<PhaserSprite> _miniSwordSprites;

		private List<Timer> _miniSwordTimers;

		private bool _propelMiniSwords;

		private float _miniSwordRendYOffset;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void DoLightningTween()
		{
		}

		[IteratorStateMachine(typeof(_003CDespawnInAFrame_003Ed__26))]
		private IEnumerator DespawnInAFrame()
		{
			return null;
		}

		public override void Despawn()
		{
		}

		protected virtual void Strike(Transform target)
		{
		}

		private void DoSwordCircle()
		{
		}

		private void CancelMiniSwordTimers()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
