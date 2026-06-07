using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UMA.Dynamics.Examples
{
	public class UMAShooter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPlayHit_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UMAShooter _003C_003E4__this;

			public AudioClip clip;

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
			public _003CPlayHit_003Ed__14(int _003C_003E1__state)
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
		private sealed class _003CTimedRagdoll_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RaycastHit hit;

			private UMAPhysicsAvatar _003Cplayer_003E5__2;

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
			public _003CTimedRagdoll_003Ed__15(int _003C_003E1__state)
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

		private float impactEndTime;

		private int hits;

		private Rigidbody impactTarget;

		private Vector3 impact;

		public Camera currentCamera;

		public LayerMask layers;

		public AudioClip Bang;

		public float announcerDelay;

		public AudioClip KillingSpree;

		public AudioClip HeadShot;

		public AudioClip HadToHurt;

		public GameObject Blood;

		private void Update()
		{
		}

		private RaycastHit AnnounceHit(RaycastHit hit)
		{
			return default(RaycastHit);
		}

		[IteratorStateMachine(typeof(_003CPlayHit_003Ed__14))]
		private IEnumerator PlayHit(AudioClip clip)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTimedRagdoll_003Ed__15))]
		private IEnumerator TimedRagdoll(RaycastHit hit)
		{
			return null;
		}
	}
}
