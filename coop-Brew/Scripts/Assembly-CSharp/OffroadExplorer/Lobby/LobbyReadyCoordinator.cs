using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class LobbyReadyCoordinator : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyReadyCoordinator _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private bool _003CprofileReady_003E5__3;

			private bool _003CavatarReady_003E5__4;

			private bool _003CuiReady_003E5__5;

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
			public _003CStart_003Ed__11(int _003C_003E1__state)
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

		[Header("Configuration")]
		[Tooltip("Maximum time to wait for all systems before declaring ready anyway")]
		[SerializeField]
		private float maxWaitTime;

		[Tooltip("How often to check if systems are ready")]
		[SerializeField]
		private float checkInterval;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static bool IsReady { get; private set; }

		public static event Action OnLobbyReady
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__11))]
		private IEnumerator Start()
		{
			return null;
		}

		private void RefreshUIAvatar()
		{
		}

		public static void Reset()
		{
		}
	}
}
