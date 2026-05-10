using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun.UtilityScripts;
using UnityEngine;

namespace Photon.Pun.Demo.Cockpit
{
	public class PunCockpitEmbed : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PunCockpitEmbed _003C_003E4__this;

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
			public _003CStart_003Ed__6(int _003C_003E1__state)
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

		private string PunCockpit_scene;

		public bool EmbeddCockpit;

		public string CockpitGameTitle;

		public GameObject LoadingIndicator;

		public ConnectAndJoinRandom AutoConnect;

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__6))]
		private IEnumerator Start()
		{
			return null;
		}

		public override void OnJoinedRoom()
		{
		}
	}
}
