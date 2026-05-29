using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun.Demo.SlotRacer.Utils;
using UnityEngine;

namespace Photon.Pun.Demo.SlotRacer
{
	[RequireComponent(typeof(SplineWalker))]
	public class PlayerControl : MonoBehaviourPun, IPunObservable
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerControl _003C_003E4__this;

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
			public _003CStart_003Ed__12(int _003C_003E1__state)
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

		public GameObject[] CarPrefabs;

		public float MaximumSpeed;

		public float Drag;

		private float CurrentSpeed;

		private float CurrentDistance;

		private GameObject CarInstance;

		private SplineWalker SplineWalker;

		private bool m_firstTake;

		private float m_input;

		void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}

		private void SetupCarOnTrack(int gridStartIndex)
		{
		}

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__12))]
		private IEnumerator Start()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}
	}
}
