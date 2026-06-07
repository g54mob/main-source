using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PunchProjectile_Guayim : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CWaitForParticlesToFinish_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EME_PunchProjectile_Guayim _003C_003E4__this;

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
			public _003CWaitForParticlesToFinish_003Ed__21(int _003C_003E1__state)
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
		private ParticleSystem guayimPunchingVFX;

		[SerializeField]
		private ParticleSystem guayimDustVFX;

		[SerializeField]
		private float radius;

		private const float GUAYIM_DURATION = 5000f;

		private SpriteRenderer _guayimPlayerSpriteRenderer;

		private Vector3 _guayimPunchingScale;

		private Vector3 _guayimDustScale;

		private Vector3 _guayimPunchingPosition;

		private Vector3 _guayimDustPosition;

		private EnemyController _strongestEnemy;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVFX()
		{
		}

		private void SetupTimers()
		{
		}

		private EnemyController GetStrongestTarget()
		{
			return null;
		}

		private static List<EnemyController> GetAllEnemiesInRectBounds(Rectangle _rect)
		{
			return null;
		}

		public override void Despawn()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForParticlesToFinish_003Ed__21))]
		private IEnumerator WaitForParticlesToFinish()
		{
			return null;
		}
	}
}
