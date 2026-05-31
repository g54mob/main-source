using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Photon.Pun.Demo.Asteroids
{
	public class Spaceship : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitForRespawn_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Spaceship _003C_003E4__this;

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
			public _003CWaitForRespawn_003Ed__18(int _003C_003E1__state)
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

		public float RotationSpeed;

		public float MovementSpeed;

		public float MaxSpeed;

		public ParticleSystem Destruction;

		public GameObject EngineTrail;

		public GameObject BulletPrefab;

		private PhotonView photonView;

		private Rigidbody rigidbody;

		private Collider collider;

		private Renderer renderer;

		private float rotation;

		private float acceleration;

		private float shootingTimer;

		private bool controllable;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void FixedUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForRespawn_003Ed__18))]
		private IEnumerator WaitForRespawn()
		{
			return null;
		}

		private void CheckExitScreen()
		{
		}
	}
}
