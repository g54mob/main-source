using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer
{
	public class PingAndAvatarBroadcaster : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003CBootstrapPing_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PingAndAvatarBroadcaster _003C_003E4__this;

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
			public _003CBootstrapPing_003Ed__6(int _003C_003E1__state)
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
		private sealed class _003CPingLoop_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PingAndAvatarBroadcaster _003C_003E4__this;

			private WaitForSeconds _003Cwait_003E5__2;

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
			public _003CPingLoop_003Ed__7(int _003C_003E1__state)
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
		private float pingPublishInterval;

		private Coroutine _loop;

		private void Start()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		private void PingSetup()
		{
		}

		public override void OnLeftRoom()
		{
		}

		[IteratorStateMachine(typeof(_003CBootstrapPing_003Ed__6))]
		private IEnumerator BootstrapPing()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPingLoop_003Ed__7))]
		private IEnumerator PingLoop()
		{
			return null;
		}

		private void PushPing()
		{
		}
	}
}
