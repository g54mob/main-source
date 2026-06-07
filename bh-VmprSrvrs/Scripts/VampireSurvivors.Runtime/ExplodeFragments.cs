using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ExplodeFragments : MonoBehaviour
{
	private struct OriginalTransformData
	{
		public Vector3 scale;

		public Vector3 position;

		public Quaternion rotation;
	}

	[CompilerGenerated]
	private sealed class _003CExplodeCoroutine_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ExplodeFragments _003C_003E4__this;

		private Vector3 _003CeffectiveGravity_003E5__2;

		private float _003Celapsed_003E5__3;

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
		public _003CExplodeCoroutine_003Ed__28(int _003C_003E1__state)
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

	[Header("Explosion Settings")]
	[SerializeField]
	private float lifetime;

	[SerializeField]
	private AnimationCurve scaleOverLifetime;

	[SerializeField]
	private float radialSpeed;

	[SerializeField]
	private float radialSpeedJitter;

	[SerializeField]
	private float directionJitterDegrees;

	[SerializeField]
	private Vector2 spinSpeedRangeDeg;

	[SerializeField]
	private Vector3 gravity;

	[SerializeField]
	private int seed;

	[SerializeField]
	private Vector3 extraVelocityJitter;

	[Header("FXs")]
	[SerializeField]
	private ParticleSystem explodeParticles;

	[Header("Rigidbody Settings")]
	[SerializeField]
	private float mass;

	[SerializeField]
	private float drag;

	[SerializeField]
	private float angularDrag;

	[SerializeField]
	private bool useGravity;

	[Header("Fragment Settings")]
	[SerializeField]
	private Transform fragmentRoot;

	[SerializeField]
	private Transform explosionTransform;

	[SerializeField]
	private bool enableRootOnExplode;

	[SerializeField]
	private bool disableRootOnStop;

	private Dictionary<Transform, OriginalTransformData> originalTransforms;

	private Dictionary<Transform, FakeRigidBodyMover> fragmentMovers;

	private List<Transform> fragments;

	private bool isExploding;

	private void Awake()
	{
	}

	private void CollectFragments()
	{
	}

	private void SetupFragments()
	{
	}

	public void Explode()
	{
	}

	public void ResetFragments()
	{
	}

	[IteratorStateMachine(typeof(_003CExplodeCoroutine_003Ed__28))]
	private IEnumerator ExplodeCoroutine()
	{
		return null;
	}

	private static Vector3 RandomOnUnitSphere(System.Random rng)
	{
		return default(Vector3);
	}
}
