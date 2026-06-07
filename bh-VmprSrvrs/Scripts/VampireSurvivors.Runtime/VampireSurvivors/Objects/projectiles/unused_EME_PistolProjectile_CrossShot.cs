using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class unused_EME_PistolProjectile_CrossShot : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CDespawnInAFrame_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public unused_EME_PistolProjectile_CrossShot _003C_003E4__this;

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
			public _003CDespawnInAFrame_003Ed__10(int _003C_003E1__state)
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
		private ParticleSystem crossshotVFX;

		[SerializeField]
		private ParticleEventCall crossshotParticleEventCall;

		[SerializeField]
		private float hitboxWidth;

		[SerializeField]
		private float hitboxHeight;

		[SerializeField]
		private float centralOffset;

		private EnemyController _targetEnemyController;

		private Timer _expireTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics(int index)
		{
		}

		private void SetupVisuals()
		{
		}

		[IteratorStateMachine(typeof(_003CDespawnInAFrame_003Ed__10))]
		private IEnumerator DespawnInAFrame()
		{
			return null;
		}

		public override void Despawn()
		{
		}

		private void DespawnAfterParticlesStopped()
		{
		}

		private void FinishDespawn()
		{
		}
	}
}
