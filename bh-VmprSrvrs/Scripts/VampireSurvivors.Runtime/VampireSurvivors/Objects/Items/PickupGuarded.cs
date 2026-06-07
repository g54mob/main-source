using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class PickupGuarded : NetworkPickup
	{
		[CompilerGenerated]
		private sealed class _003CDeferredReturnToPool_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PickupGuarded _003C_003E4__this;

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
			public _003CDeferredReturnToPool_003Ed__41(int _003C_003E1__state)
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

		protected Transform _cachedTransform;

		protected Stage _stage;

		protected Camera _camera;

		protected float _left;

		protected float _right;

		protected float _top;

		protected float _bottom;

		protected bool _hasSpawned;

		protected float _guardRadius;

		protected EnemyType _enemyType;

		protected int _spawnQuantity;

		protected bool _hasAssignedSpawnData;

		protected int _eventID;

		protected bool _vfxEnabled;

		private float _totalTime;

		private const float ParticlesInterval = 0.040000003f;

		private const float Radius = 1.4399999f;

		private readonly List<EnemyController> Guards;

		[Sync]
		public bool IsAnyGuardAlive { get; set; }

		public float SpawnAngle { get; set; }

		[Sync]
		public bool HasSpawned
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SkipOnlineGuardsCheckOnDespawn { get; set; }

		[Inject]
		private void Construct(Stage stage)
		{
		}

		protected override void Awake()
		{
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetEnemySpawnType(EnemyType enemyType, int spawnQuantity)
		{
		}

		public override void Despawn()
		{
		}

		protected void SetParticleEffectsActive(bool particleEffectsActive)
		{
		}

		[IteratorStateMachine(typeof(_003CDeferredReturnToPool_003Ed__41))]
		private IEnumerator DeferredReturnToPool()
		{
			return null;
		}

		private bool IsAnyPlayerInGuardSpawnRange()
		{
			return false;
		}

		protected virtual void OnRecycle()
		{
		}

		public void ChangeActiveRadius(float pixelRadius = 32f)
		{
		}

		protected virtual void TriggerSpawn()
		{
		}

		protected void CheckSpawnParticles()
		{
		}

		protected bool AnyGuardsAlive()
		{
			return false;
		}
	}
}
