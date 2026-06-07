using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_Magic1Projectile : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CWaitForParticlesToFinish_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EME_Magic1Projectile _003C_003E4__this;

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
			public _003CWaitForParticlesToFinish_003Ed__22(int _003C_003E1__state)
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
		protected List<ParticleSystem> _availableSpiritRings;

		[Space]
		[SerializeField]
		private float _defaultOrbitRadius;

		[SerializeField]
		private float _maximumOrbitRadius;

		[SerializeField]
		private float _startingAngleOffset;

		[Space]
		[SerializeField]
		private float _defaultHitboxRadius;

		[SerializeField]
		private float _maximumHitboxRadius;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Vector3 _chosenSpiritRingScale;

		protected bool _activate;

		protected float _positionInCircumference;

		protected ParticleSystem _chosenSpiritRing;

		protected virtual float OrbitSpeed => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupProjectileScale()
		{
		}

		private void SetupTimers()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected Vector3 OrbitPositionAroundPlayer(ref float positionInCircumference, float orbitSpeed)
		{
			return default(Vector3);
		}

		public virtual void SetOffsetPosition(int index)
		{
		}

		public override void Despawn()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForParticlesToFinish_003Ed__22))]
		private IEnumerator WaitForParticlesToFinish()
		{
			return null;
		}
	}
}
