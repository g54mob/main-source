using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class VehicleVFX : MonoBehaviour
	{
		[Serializable]
		public struct CollissionParticles
		{
			public ParticleSystem Particles;

			public LayerMask CollisionLayer;

			public float MinMagnitudeCollision;

			public float MaxMagnitudeCollision;
		}

		[CompilerGenerated]
		private sealed class _003CWaitVisibleTrail_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TrailRenderer trail;

			public VehicleVFX _003C_003E4__this;

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
			public _003CWaitVisibleTrail_003Ed__20(int _003C_003E1__state)
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

		[Header("VehicleVFX")]
		[SerializeField]
		private float MinTimeBetweenCollisions;

		[SerializeField]
		private ParticleSystem DefaultCollisionParticles;

		[SerializeField]
		private List<CollissionParticles> CollisionParticlesList;

		[SerializeField]
		private TrailRenderer TrailRef;

		protected VehicleController Vehicle;

		private Queue<TrailRenderer> FreeTrails;

		private const float OffsetHitHeightForTrail = 0.05f;

		private Transform ParentForEffects;

		private static Transform EffectsHolder;

		private float LastCollisionTime;

		public Dictionary<Wheel, TrailRenderer> ActiveTrails { get; private set; }

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		public void UpdateTrail(Wheel wheel, bool hasSlip)
		{
		}

		private void ResetAllTrails()
		{
		}

		public TrailRenderer GetTrail(Vector3 startPos)
		{
			return null;
		}

		public void SetTrailAsFree(TrailRenderer trail)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitVisibleTrail_003Ed__20))]
		private IEnumerator WaitVisibleTrail(TrailRenderer trail)
		{
			return null;
		}

		private void CollisionStay(VehicleController vehicle, Collision collision)
		{
		}

		public void PlayCollisionParticles(VehicleController vehicle, Collision collision)
		{
		}

		public ParticleSystem GetParticlesForCollision(int layer, float collisionMagnitude)
		{
			return null;
		}
	}
}
